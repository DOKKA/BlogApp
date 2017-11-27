using BlogApp.Data;
using BlogApp.Models;
using BlogApp.Models.PostViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Services
{
    public class PostService
    {
        private readonly ApplicationDbContext _dbContext;

        public PostService(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public ListViewModel Get(long Id)
        {
            var post = _dbContext.Posts.Include(p => p.User).First(p => p.PostId == Id);
            return new ListViewModel()
            {
                PostTitle = post.PostTitle,
                PostBody = post.PostBody,
                PostDate = post.PostDate,
                UserName = post.User.UserName,
            };
        }

        public IEnumerable<ListViewModel> GetAll()
        {
            return _dbContext.Posts.Where(p => p.IsDeleted == false)
                .Include(p => p.User)
                .ToArray()
                .Select(p => new ListViewModel()
            {
                PostTitle = p.PostTitle,
                PostBody = p.PostBody,
                PostDate = p.PostDate,
                UserName = p.User.UserName,
            });
        }

        public long Create(CreateViewModel model)
        {
            var post = _dbContext.Add(new Post()
            {
                PostTitle = model.PostTitle,
                PostBody = model.PostBody,
                User = model.User,
                PostDate = DateTime.Now
            });
            _dbContext.SaveChanges();
            return post.Entity.PostId;
        }

        public void Update(UpdateViewModel model)
        {
            var post = _dbContext.Posts.First(p => p.PostId == model.PostId);
            post.PostTitle = model.PostTitle;
            post.PostBody = model.PostBody;
            _dbContext.SaveChanges();
        }
        
        public void Delete(long id)
        {
            var post = _dbContext.Posts.First(p => p.PostId == id);
            post.IsDeleted = true;
            _dbContext.SaveChanges();
        }

    }


}
