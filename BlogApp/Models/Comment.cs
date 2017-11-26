using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class Comment
    {
        [Key]
        public long CommentId { get; set; }

        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public bool IsDeleted { get; set; }

        public ApplicationUser User { get; set; }
    }
}
