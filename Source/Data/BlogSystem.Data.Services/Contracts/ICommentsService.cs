namespace BlogSystem.Data.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface ICommentsService
    {
        IQueryable<Comment> GetAllComments();

        Comment Add(Comment comment);

        Comment GetById(int id);

        Comment Get(Comment comment);

        void Update(Comment comment);

        void Delete(int id);
    }
}
