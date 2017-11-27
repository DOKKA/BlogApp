using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class PostViewModel
    {
        public long PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
        public DateTime PostDate { get; set; }
        public string UserName { get; set; }
        public ICollection<CommentViewModel> Comments { get; set; }
    }

    public class PostListViewModel
    {
        public long PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
        public DateTime PostDate { get; set; }
        public string UserName { get; set; }
    }

    public class PostCreateViewModel
    {
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
        public ApplicationUser User { get; set; }
    }

    public class PostUpdateViewModel
    {
        public long PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
    }
}
