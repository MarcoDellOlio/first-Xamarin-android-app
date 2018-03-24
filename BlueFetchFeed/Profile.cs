
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
            user = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("User"));
            Console.WriteLine(user.username);
        }
    }
}
