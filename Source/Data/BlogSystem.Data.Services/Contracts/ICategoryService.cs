namespace BlogSystem.Data.Services.Contracts
{
    using BlogSystem.Data.Models;
    using BlogSystem.ViewModels.Category;
    using BlogSystem.ViewModels.Comment;
    using System.Linq;

    public interface ICategoryService
    {
        IQueryable<Category> GetAllCcategories();

        CategoryVM GetById(int id);
        
        CategoryVM Add(CategoryVM model);

        void Update(CategoryVM model);

        bool Exists(int id);
        
        void Delete(CategoryVM model);
    }
}
