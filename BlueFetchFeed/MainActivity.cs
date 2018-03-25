using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using System.Linq;

namespace BlueFetchFeed
{
    [Activity(Label = "Phone Word", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public static IEnumerable<Cookie> userCookies { get;  set;}

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            EditText username = FindViewById<EditText>(Resource.Id.email);
            EditText password = FindViewById<EditText>(Resource.Id.password);
            TextView translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneWord);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
        
            translateButton.Click += async (sender, e) =>
            {
                var user = await GetData(username.Text, password.Text);
                var intent = new Intent(this, typeof(Profile));
                intent.PutExtra("User", JsonConvert.SerializeObject(user));
                this.StartActivity(intent);
                this.Finish();
            };

        }



        protected async Task<User> GetData(string username, string password)
        {
           
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var values = new Dictionary<string, string>
            {
               { "username", username },
               { "password", password }
            };

            var body = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://bfsharingapp.bluefletch.com/login", body);
                response.EnsureSuccessStatusCode();
                using (HttpContent content = response.Content)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    User user = JsonConvert.DeserializeObject<User>(responseBody);
                    Uri uri = new Uri("https://bfsharingapp.bluefletch.com");
                    IEnumerable<Cookie> responseCookies = cookies.GetCookies(uri).Cast<Cookie>();
                    userCookies = responseCookies;
                    foreach (Cookie cookie in responseCookies)
                        Console.WriteLine(cookie.Name + ": " + cookie.Value);

                    Console.ReadLine();
                    return user;
                } 
            
          
        }
    }
}
