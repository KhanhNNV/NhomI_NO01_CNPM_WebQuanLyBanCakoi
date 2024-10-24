using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interface;
using KoiFarmShop.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.Services
{
    public class CommentNewsServices : ICommentNewsServices
    {
        private readonly ICommentNewsRepositories _repositories;

        public CommentNewsServices(ICommentNewsRepositories repositories)
        {
            _repositories = repositories;
        }

        public bool AddComment(CommentNews comment)
        {
            return _repositories.AddComment(comment);
        }

        public async Task AddCommentAsync(CommentNews comment)
        {
            await _repositories.AddCommentAsync(comment);
        }

        public bool DelComment(int CommentId)
        {
            return _repositories.DelComment(CommentId);
        }

        public async Task<CommentNews> GetCommentById(int commentId)
        {
            return await _repositories.GetCommentById(commentId);
        }

        public async Task<List<CommentNews>> GetCommentsForNews(int newsId)
        {
            return await _repositories.GetCommentsForNews(newsId);
        }

        public async Task UpdateComment(CommentNews comment)
        {
            _repositories.Update(comment);
            await _repositories.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _repositories.SaveChangesAsync();
        }
    }
}
