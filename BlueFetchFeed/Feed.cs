using System;
using System.Collections.Generic;

namespace BlueFetchFeed
{
    public class Feed
    {
        public string _id { get; set; }
        public string postText { get; set; }
        public User postUser { get; set; }
        public string numUpdates { get; set; }
        public List<Comment> comments { get; set; }
        public string lastUpdatedDate { get; set; }
        public string createdDate { get; set; }
    }
}
