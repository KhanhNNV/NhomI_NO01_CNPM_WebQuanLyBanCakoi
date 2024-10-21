using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;

namespace KoiFarmShop.Services
{
    public class CommentBlogService : ICommentBlogService
    {
        private readonly ICommentBlogRepository _repository;

        public CommentBlogService(ICommentBlogRepository repository)
        {
            _repository = repository;
        }

        public bool AddBlog(CommentBlog commentBlog)
        {
            return _repository.AddCommentBlog(commentBlog);
        }

        public Task<List<CommentBlog>> CommentBlog()
        {
            return _repository.GetCommentBlog();
        }

        public Task<List<CommentBlog>> GetAllBlogComment()
        {
            return _repository.GetCommentBlog();
        }

        public Task<CommentBlog> GetCommentBlogByID(int ID)
        {
            return _repository.CommentBlogByID(ID);
        }

        public bool DelBlog(int ID)
        {
            return _repository.DelCommentBlog(ID);
        }

        public bool DelBlog(CommentBlog commentBlog)
        {
            return _repository.DelCommentBlog(commentBlog);
        }

        public bool UpDBlog(CommentBlog commentBlog)
        {
           
            return _repository.UpdCommentBlog(commentBlog);
        }

        public Task<IList<CommentBlogRepository>> CommentBlogs()
        {
            throw new NotImplementedException();
        }

        Task<List<CommentBlogRepository>> ICommentBlogService.GetAllBlogComment()
        {
            throw new NotImplementedException();
        }

        public bool DelBlog(CommentBlogRepository commentBlog)
        {
            throw new NotImplementedException();
        }

        public bool AddBlog(CommentBlogRepository commentBlog)
        {
            throw new NotImplementedException();
        }

        public bool UpDBlog(CommentBlogRepository commentBlog)
        {
            throw new NotImplementedException();
        }

        Task<CommentBlogRepository> ICommentBlogService.GetCommentBlogByID(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
