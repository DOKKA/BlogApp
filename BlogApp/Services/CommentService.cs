using BlogApp.Data;
using BlogApp.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Services
{
    public class CommentService
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentService(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public long Create(CommentCreateViewModel model)
        {
            var comment = _dbContext.Comments.Add(new Comment()
            {
                PostId = model.PostId,
                CommentText = model.CommentText,
                CommentDate = DateTime.Now,
                User = model.User,
            });
            _dbContext.SaveChanges();
            return comment.Entity.CommentId;
        }

        public void Delete(long id)
        {
            var comment = _dbContext.Comments.First(c => c.CommentId == id);
            comment.IsDeleted = true;
            _dbContext.SaveChanges();
        }
    }




}
