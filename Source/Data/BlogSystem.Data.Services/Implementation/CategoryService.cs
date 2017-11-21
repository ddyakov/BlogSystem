namespace BlogSystem.Data.Services.Implementation
{
    using Common;
    using Models;
    using Contracts;
    using System.Linq;
    using AutoMapper;
    using BlogSystem.ViewModels.Category;

    public class CategoryService : ICategoryService
    {
        private IRepository<Category> categories;

        public CategoryService(IRepository<Category> comments)
        {
            this.categories = comments;
        }

        public CategoryVM Add(CategoryVM model)
        {
            var entity = Mapper.Map<Category>(model);
            var savedComment = this.categories.Add(entity);

            return Mapper.Map<CategoryVM>(savedComment);
        }

        public void Delete(CategoryVM model)
        {
            var entity = this.categories.FirstOrDefault(x => x.Id == model.Id);
            this.categories.DeleteAndSave(entity);
        }

        public bool Exists(int id)
        {
            return this.categories.Any(com => com.Id == id);
        }

        public IQueryable<Category> GetAllCategories()
        {
            return this.categories.GetAll();
        }

        public CategoryVM GetById(int id)
        {
            return Mapper.Map<CategoryVM>(this.categories.FirstOrDefault(com => com.Id == id));
        }

        public void Update(CategoryVM model)
        {
            var entinty = this.categories.FirstOrDefault(com => com.Id == model.Id);
            this.categories.UpdateAndSave(Mapper.Map(model, entinty));
        }
    }
}
