namespace BlogSystem.Data.Services.Implementation
{
    using BlogSystem.Data.Services.Contracts;
    using System.Linq;
    using BlogSystem.Data.Models;
    using BlogSystem.ViewModels.Post;
    using BlogSystem.Data.Common;
    using AutoMapper;

    public class PostService : IPostService
    {
        IRepository<Post> posts;
        private object mapper;

        public PostService(IRepository<Post> posts)
        {
            this.posts = posts;
        }

        public PostVM Add(PostVM model)
        {
            var entity = Mapper.Map<Post>(model);
            var savedEntity = this.posts.Add(entity);
            return Mapper.Map<PostVM>(savedEntity);
        }

        public void Delete(PostVM model)
        {
            var entity = this.posts.FirstOrDefault(p => p.Id == model.Id);
            this.posts.DeleteAndSave(entity);
        }

        public bool Exists(int id)
        {
            return this.posts.Any(p => p.Id == id);
        }

        public IQueryable<Post> GetAllPosts()
        {
            return this.posts.GetAll();
        }

        public PostVM GetById(int id)
        {
            return Mapper.Map<PostVM>(this.posts.Get(id));
        }

        public void Update(PostVM model)
        {
            var entity = this.posts.Get(model.Id);
            this.posts.UpdateAndSave(Mapper.Map(model, entity));
        }
    }
}
