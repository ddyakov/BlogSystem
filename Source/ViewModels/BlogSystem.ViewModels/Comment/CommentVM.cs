namespace BlogSystem.ViewModels.Comment
{
    using System;
    using Data.Models;
    using Infrastructure;

    public class CommentVM : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public int PostId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
