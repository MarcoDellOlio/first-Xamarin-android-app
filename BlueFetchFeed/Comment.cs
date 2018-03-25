using System;
namespace BlueFetchFeed
{
    public class Comment
    {
        public string id { get; set; }                
        public string commentText { get; set; } 
        public User commentUser { get; set; } 
        public string originalCommentText { get; set; } 
        public int numCommentUpdate { get; set; } 
        public string createdDate { get; set; }
    }
}
