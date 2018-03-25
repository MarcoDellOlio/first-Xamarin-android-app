
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
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Profile);


            TextView title = FindViewById<TextView>(Resource.Id.profiletitle);
            ImageView imageView = FindViewById<ImageView>(Resource.Id.profilepicture);


            user = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("User"));

            title.Text = $"{user.username} profile page";
            String url = "https://bfsharingapp.bluefletch.com" + user.imageUrl;
            var imageBitmap = GetImageBitmapFromUrl(url);
            imageView.SetImageBitmap(imageBitmap);
                
            var feed = await GetFeed();
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

        protected async Task<Feed> GetFeed()
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
                    Console.WriteLine(responseBody);
                    Feed feed = new Feed();
                    return feed;
                }
            }
        }
    }
}