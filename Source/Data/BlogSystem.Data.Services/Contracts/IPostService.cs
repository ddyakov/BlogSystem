namespace BlogSystem.Data.Services.Contracts
{
    using BlogSystem.Data.Models;
    using BlogSystem.ViewModels.Post;
    using System.Linq;

    public interface IPostService
    {
        IQueryable<Post> GetAllPosts();

        PostVM GetById(int id);
        
        PostVM Add(PostVM model);

        void Update(PostVM model);

        bool Exists(int id);

        void Delete(PostVM model);
    }
}
