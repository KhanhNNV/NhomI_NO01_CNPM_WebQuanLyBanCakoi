using KoiFarmShop.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Interface
{
    public interface ICommentNewsRepositories
    {
        bool AddComment(CommentNews comment);
        Task AddCommentAsync(CommentNews comment);
        bool DelComment(int CommentId);
        Task<CommentNews> GetCommentById(int commentId);
        Task<List<CommentNews>> GetCommentsForNews(int newsId);
        void Update(CommentNews comment);
        Task SaveChangesAsync();
    }
}
