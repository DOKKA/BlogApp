using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class Post
    {
        public Post()
        {

        }
        public Post(string title, string body, ApplicationUser user)
        {
            PostTitle = title;
            PostBody = body;
            PostDate = DateTime.Now;
            User = user;
        }

        [Key]
        public long PostId { get; set; }

        public string PostTitle { get; set; }
        public string PostBody { get; set; }
        public DateTime PostDate { get; set; }
        public bool IsDeleted { get; set; }

        public ApplicationUser User { get; set; }
    }
}
