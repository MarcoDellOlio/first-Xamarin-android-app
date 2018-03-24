
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

namespace BlueFetchFeed
{
    [Activity(Label = "Profile")]
    public class Profile : Activity
    {
        private User user;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Profile);


            TextView title = FindViewById<TextView>(Resource.Id.profiletitle);
            ImageView imageView = FindViewById<ImageView>(Resource.Id.profilepicture);


            user = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("User"));

            title.Text = $"{user.username} profile page";
            String url ="https://bfsharingapp.bluefletch.com"+user.imageUrl;
            var imageBitmap = GetImageBitmapFromUrl(url);
            imageView.SetImageBitmap(imageBitmap);

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
    }
}
