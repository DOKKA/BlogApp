using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class CommentViewModel
    {
        public long CommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public string UserName { get; set; }
    }

    public class CommentCreateViewModel
    {
        public long PostId { get; set; }
        public string CommentText { get; set; }
        public ApplicationUser User { get; set; }
    }
}
