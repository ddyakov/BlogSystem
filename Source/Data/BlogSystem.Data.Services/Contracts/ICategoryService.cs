using BlogSystem.Data.Models;
using BlogSystem.ViewModels.Comment;
using System.Linq;

namespace BlogSystem.Data.Services.Contracts
{
    public interface ICategoryService
    {
        IQueryable<Comment> GetAllComments();

        CommentVM GetById(int id);
        
        CommentVM Add(CommentVM model);

        void Update(CommentVM model);

        bool Exists(int id);
        
        void Delete(CommentVM model);
    }
}
