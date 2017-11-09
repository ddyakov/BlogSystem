namespace BlogSystem.Data.Services.Implementation
{
    using Common;
    using Models;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BlogSystem.ViewModels.Comment;
    using AutoMapper;

    public class CategoryService : ICategoryService
    {
        private IRepository<Comment> comments;

        public CategoryService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public CommentVM Add(CommentVM model)
        {
            var entity = Mapper.Map<Comment>(model);
            var savedComment = this.comments.Add(entity);

            return Mapper.Map<CommentVM>(savedComment);
        }

        public void Delete(CommentVM model)
        {
            var entity = this.comments.FirstOrDefault(x => x.Id == model.Id);
            this.comments.Delete(entity);
            this.comments.SaveChanges();
        }

        public bool Exists(int id)
        {
            return this.comments.Any(com => com.Id == id);
        }

        public IQueryable<Comment> GetAllComments()
        {
            return this.comments.GetAll();
        }

        public CommentVM GetById(int id)
        {
            return Mapper.Map<CommentVM>(this.comments.FirstOrDefault(com => com.Id == id));
        }

        public void Update(CommentVM model)
        {
            var entinty = this.comments.FirstOrDefault(com => com.Id == model.Id);
            this.comments.Update(Mapper.Map(model, entinty));
            this.comments.SaveChanges();
        }
    }
}
