using BlogApp.Data;
using BlogApp.Models;
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

        public PostViewModel Get(long Id)
        {
            var post = _dbContext.Posts.Include(p => p.User).Include(p => p.Comments).First(p => p.PostId == Id);
            return new PostViewModel()
            {
                PostId = post.PostId,
                PostTitle = post.PostTitle,
                PostBody = post.PostBody,
                PostDate = post.PostDate,
                UserName = post.User.UserName,
                Comments = post.Comments.Where(c => c.IsDeleted == false).Select(c => new CommentViewModel()
                {
                    CommentDate = c.CommentDate,
                    CommentId = c.CommentId,
                    CommentText = c.CommentText,
                    UserName = c.User.UserName,
                }).ToArray()
            };
        }

        public IEnumerable<PostListViewModel> GetAll()
        {
            return _dbContext.Posts.Where(p => p.IsDeleted == false)
                .Include(p => p.User)
                .ToArray()
                .Select(p => new PostListViewModel()
            {
                PostId = p.PostId,
                PostTitle = p.PostTitle,
                PostBody = p.PostBody,
                PostDate = p.PostDate,
                UserName = p.User.UserName,
            });
        }

        public long Create(PostCreateViewModel model)
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

        public void Update(PostUpdateViewModel model)
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
