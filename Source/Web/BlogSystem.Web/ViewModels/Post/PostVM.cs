namespace BlogSystem.Web.ViewModels.Post
{
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using Category;
    using Comment;
    using Infrastructure;
    using User;

    public class PostVM : IMapFrom<Post>
    {
        public PostVM()
        {
            this.Categories = new List<CategoryVM>();
            this.Comments = new List<CommentVM>();
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public string Header { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public UserVM ApplicationUser { get; set; }

        public List<CategoryVM> Categories { get; set; }

        public List<CommentVM> Comments { get; set; }
    }
}
