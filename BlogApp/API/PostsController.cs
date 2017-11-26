using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Models;
using BlogApp.Data;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.API
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _manager;

        public PostsController(ApplicationDbContext dbContext, UserManager<ApplicationUser> manager)
        {
            _dbContext = dbContext;
            _manager = manager;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var user = await  _manager.GetUserAsync(User);

            _dbContext.Posts.Add(new Post("First real post", "A post body", user));
            _dbContext.SaveChanges();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
