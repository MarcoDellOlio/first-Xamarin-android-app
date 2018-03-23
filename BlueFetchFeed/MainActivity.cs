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

namespace BlueFetchFeed
{
    [Activity(Label = "Phone Word", MainLauncher = true)]
    public class MainActivity : Activity
    {
        static readonly List<string> phoneNumbers = new List<string>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            EditText username = FindViewById<EditText>(Resource.Id.email);
            EditText password = FindViewById<EditText>(Resource.Id.password);
            TextView translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneWord);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            Button translationHistoryButton = FindViewById<Button>(Resource.Id.TranslationHistoryButton);
        
            translateButton.Click += async (sender, e) =>
            {
                String json = await GetData(username.Text, password.Text);
                Console.Write(json);
            };

            translationHistoryButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(TranslationHistoryActivity));
                intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);
            };

        }



        private async Task<String> GetData(string username, string password)
        {
            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
                {
                   { "username", username },
                   { "password", password }
                };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://bfsharingapp.bluefletch.com/login", content);
            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);
            //string url = "https://bfsharingapp.bluefletch.com/login";
            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            //request.Method = "GET";
            //request.ContentType = "application/json";

            //// Send the request to the server and wait for the response:
            //WebResponse response = await request.GetResponseAsync();
           
            //        // Use this stream to build a JSON document object
            //var dataStream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(dataStream);
            //string responseFromServer = reader.ReadToEnd();
            //Console.WriteLine(responseFromServer);

            return "test";
        }
    }
}
