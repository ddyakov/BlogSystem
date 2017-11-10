namespace BlogSystem.Data.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class ApplicationUser : IdentityUser
    {
        private ICollection<Post> posts;
        private ICollection<Comment> comments;

        public ApplicationUser()
        {
            this.posts = new HashSet<Post>();
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public override string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Post> Posts
        {
            get => this.posts;
            set => this.posts = value;
        }

        public virtual ICollection<Comment> Comments
        {
            get => this.comments;
            set => this.comments = value;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}
