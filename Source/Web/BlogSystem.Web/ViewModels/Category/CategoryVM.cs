namespace BlogSystem.Web.ViewModels.Category
{
    using System.Collections.Generic;
    using Data.Models;
    using Post;
    using Infrastructure;

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
