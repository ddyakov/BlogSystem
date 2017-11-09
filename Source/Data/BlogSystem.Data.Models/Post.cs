namespace BlogSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        public Post()
        {
            this.Categories = new List<Category>();
            this.Comments = new List<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public string Header { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public List<Category> Categories { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
