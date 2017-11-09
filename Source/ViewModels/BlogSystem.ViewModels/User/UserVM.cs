namespace BlogSystem.ViewModels.User
{
    using System.Collections.Generic;
    using AutoMapper;
    using Comment;
    using Data.Models;
    using Infrastructure;
    using Post;

    public class UserVM : IMapFrom<ApplicationUser>
    {
        public UserVM(ApplicationUser user)
        {
            Mapper.Map(user, this);

            this.Posts = new List<PostVM>();
            this.Comments = new List<CommentVM>();
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<PostVM> Posts { get; set; }

        public List<CommentVM> Comments { get; set; }
    }
}
