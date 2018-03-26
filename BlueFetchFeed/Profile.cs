
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Net;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BlueFetchFeed
{
    [Activity(Label = "Profile")]
    public class Profile : Activity
    {
        private User user;
        private ListView feedlist;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Profile);


            TextView title = FindViewById<TextView>(Resource.Id.profiletitle);
            ImageView imageView = FindViewById<ImageView>(Resource.Id.profilepicture);
            feedlist = FindViewById<ListView>(Resource.Id.feeds);
            EditText postText = FindViewById<EditText>(Resource.Id.postText);
            Button postButton = FindViewById<Button>(Resource.Id.addPost);

            user = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("User"));

            title.Text = $"{user.username} profile page";

            String url = "https://bfsharingapp.bluefletch.com" + user.imageUrl;
            var imageBitmap = GetImageBitmapFromUrl(url);
            imageView.SetImageBitmap(imageBitmap);
            updateList();


            postButton.Click += async (sender, e) =>
            {
                string newPost = postText.Text;
                string username = user.username;
                await SendPost(username, newPost);
                updateList();
            };

        }

        private async void updateList()
        {
            var allFeeds = await GetFeed();
            var userFeeds = allFeeds.Where(feed => feed.postUser.username == user.username);
            var orederedFeed = userFeeds.OrderByDescending(feed => DateTime.Parse(feed.lastUpdatedDate)).ToList();

            List<string> feedText = orederedFeed.Select(feed => feed.postText).ToList();
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, feedText);
            feedlist.Adapter = adapter;
        }


        private Bitmap GetImageBitmapFromUrl(String url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }


        protected async Task<List<Feed>> GetFeed()
        {
            var baseAddress = new System.Uri("https://bfsharingapp.bluefletch.com");
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                foreach (Cookie cookie in MainActivity.userCookies)
                {
                    cookieContainer.Add(baseAddress, cookie);
                }

                var response = await client.GetAsync("/feed");
                response.EnsureSuccessStatusCode();
                using (HttpContent data = response.Content)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    List<Feed> feeds = JsonConvert.DeserializeObject<List<Feed>>(responseBody);

                    return feeds;
                }
            }
        }

        async Task<string> SendPost(string username, string postText)
        {
            var client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var values = new Dictionary<string, string>
                {
                    { "username", username },
                    { "postText", postText }
                };
                
                var body = new FormUrlEncodedContent(values);
                    Console.WriteLine("name " + username);
                    Console.WriteLine("text " + postText); 
                var response = await client.PostAsync("https://bfsharingapp.bluefletch.com/post", body);
                response.EnsureSuccessStatusCode();
                using (HttpContent data = response.Content)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return responseBody;
                }
        }
    }
}