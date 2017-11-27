using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Models;
using BlogApp.Data;
using Microsoft.AspNetCore.Identity;
using BlogApp.Services;


namespace BlogApp.API
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly UserManager<ApplicationUser> _manager;
        private readonly PostService _postService;

        public PostsController(UserManager<ApplicationUser> manager, PostService postService)
        {
            _manager = manager;
            _postService = postService;
        }

        // GET api/posts
        [HttpGet]
        public  IEnumerable<PostListViewModel> Get()
        {
            return _postService.GetAll();
        }

        // GET api/posts/5
        [HttpGet("{id}")]
        public PostViewModel Get(long id)
        {
            return _postService.Get(id);
        }

        // POST api/posts
        [HttpPost]
        public async void Post([FromBody]PostCreateViewModel model)
        {
            model.User =  await _manager.GetUserAsync(User);
            //model.User = await _manager.FindByEmailAsync("scuffmark@gmail.com");
            _postService.Create(model);
        }

        // PUT api/posts/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody]PostUpdateViewModel model)
        {
            _postService.Update(model);
        }

        // DELETE api/posts/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _postService.Delete(id);
        }
    }
}
