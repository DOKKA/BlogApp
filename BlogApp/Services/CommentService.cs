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
    public class CommentService
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentService(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }


    }


}
