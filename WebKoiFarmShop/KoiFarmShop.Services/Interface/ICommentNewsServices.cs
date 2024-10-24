using KoiFarmShop.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Interface
{
    public interface ICommentNewsServices
    {
        bool AddComment(CommentNews comment);
        Task AddCommentAsync(CommentNews comment);
        bool DelComment(int CommentId);
        Task<CommentNews> GetCommentById(int commentId);
        Task<List<CommentNews>> GetCommentsForNews(int newsId);
        Task UpdateComment(CommentNews comment);
        Task SaveChangesAsync();
    }
}
