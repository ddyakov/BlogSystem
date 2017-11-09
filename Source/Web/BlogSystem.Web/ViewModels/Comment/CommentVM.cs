namespace BlogSystem.Web.ViewModels.Comment
{
    using System;
    using Data.Models;
    using Infrastructure;
    using Post;
    using User;

    public class CommentVM : IMapFrom<Comment>
    {
        public int Id { get; set; }
        
        public string ApplicationUserId { get; set; }

        public UserVM ApplicationUser { get; set; }

        public PostVM Post { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
