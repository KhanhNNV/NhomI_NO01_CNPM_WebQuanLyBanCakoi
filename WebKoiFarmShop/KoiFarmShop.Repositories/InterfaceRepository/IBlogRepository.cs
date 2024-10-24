﻿using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.InterfaceRepository
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlog();
        Boolean DeleteBlog(int id);
        Boolean DeleteBlog(Blog blog);
        Boolean UpdateBlog(Blog blog);
        Boolean AddBlog(Blog blog);
        Task<Blog> GetBlogById(int id);
    }
}