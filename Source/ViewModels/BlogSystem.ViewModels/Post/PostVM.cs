namespace BlogSystem.ViewModels.Post
{
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using Comment;
    using Infrastructure;

    public class PostVM : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Header { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ApplicationUserId { get; set; }

        public string UserFullName { get; set; }

        public List<CommentVM> Comments { get; set; }
    }
}
