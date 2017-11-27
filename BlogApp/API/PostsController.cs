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
using BlogApp.Models.PostViewModels;

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

        // GET api/values
        [HttpGet]
        public  IEnumerable<ListViewModel> Get()
        {
            return _postService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ListViewModel Get(long id)
        {
            return _postService.Get(id);
        }

        // POST api/values
        [HttpPost]
        public async void Post([FromBody]CreateViewModel model)
        {
            model.User =  await _manager.GetUserAsync(User);
            _postService.Create(model);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody]UpdateViewModel model)
        {
            _postService.Update(model);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _postService.Delete(id);
        }
    }
}
