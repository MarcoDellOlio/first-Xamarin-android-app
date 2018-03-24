using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BlueFetchFeed
{
    public class User
    {
        public string _id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string imageUrl { get; set; }
        public string lastActiondate { get; set; }
        public string createdDate { get; set; }
    }
}
