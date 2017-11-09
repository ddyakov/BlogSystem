namespace BlogSystem.ViewModels.Category
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure;
    using Post;

    public class CategoryVM : IMapFrom<Category>
    {
        public CategoryVM()
        {
            this.Posts = new List<PostVM>();   
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<PostVM> Posts { get; set; }
    }
}
