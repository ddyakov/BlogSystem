namespace BlogSystem.Data.Services.Contracts
{
    using Models;
    using ViewModels.Post;
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
