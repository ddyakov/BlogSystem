namespace BlogSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.Posts = new List<Post>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Post> Posts { get; set; }
    }
}
