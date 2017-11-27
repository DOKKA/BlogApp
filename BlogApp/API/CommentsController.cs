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
    public class CommentsController : Controller
    {
        private readonly UserManager<ApplicationUser> _manager;
        private readonly CommentService _commentService;

        public CommentsController(UserManager<ApplicationUser> manager, CommentService commentService)
        {
            _manager = manager;
            _commentService = commentService;
        }

        // POST api/comments
        [HttpPost]
        public async void Post([FromBody]CommentCreateViewModel model)
        {
            model.User =  await _manager.GetUserAsync(User);
            //model.User = await _manager.FindByEmailAsync("scuffmark@gmail.com");
            _commentService.Create(model);
        }

        // DELETE api/comments/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _commentService.Delete(id);
        }

    }
}
