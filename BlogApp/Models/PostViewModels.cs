using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models.PostViewModels
{
    public class ListViewModel
    {
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
        public DateTime PostDate { get; set; }
        public string UserName { get; set; }
    }

    public class CreateViewModel
    {
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
        public ApplicationUser User { get; set; }
    }

    public class UpdateViewModel
    {
        public long PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
    }
}
