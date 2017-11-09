namespace BlogSystem.Data.Services.Implementation
{
    using System.Linq;
    using Common;
    using Models;
    using Contracts;

    public class CommentsService : ICommentsService
    {
        private IRepository<Comment> comments;

        public CommentsService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public IQueryable<Comment> GetAllComments()
        {
            return this.comments.GetAll();
        }

        public Comment Add(Comment comment)
        {
            var entity = this.comments.Get(comment.Id);

            if (entity != null)
            {
                this.comments.Add(entity);
            }

            return entity;
        }

        public Comment GetById(int id)
        {
            return this.comments.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = this.comments.Get(id);

            if (entity != null)
            {
                this.comments.Delete(entity);
            }
        }

        public void Update(Comment comment)
        {
            var entity = this.comments.Get(comment.Id);

            if (entity != null)
            {
                this.comments.Update(entity);
            }
        }

        public Comment Get(Comment comment)
        {
            return this.comments.FirstOrDefault(x => x.Id == comment.Id);
        }
    }
}
