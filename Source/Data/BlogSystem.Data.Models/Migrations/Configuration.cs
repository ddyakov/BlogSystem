namespace BlogSystem.Data.Models.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using Models;
    using System;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //SeedUsers(context);
            //SeedComments(context);
            //SeedPosts(context);
            //SeedCategories(context);
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    UserName = "dimitar.dyakov98@gmail.com",
                    FirstName = "Dimitar",
                    LastName = "Dyakov"
                },
                new ApplicationUser
                {
                    UserName = "gosho.goshov@gmail.com",
                    FirstName = "Gosho",
                    LastName = "Goshov"
                },
                new ApplicationUser
                {
                    UserName = "ivan.ivanov@gmail.com",
                    FirstName = "Ivan",
                    LastName = "Ivanov"
                }
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }

        private void SeedComments(ApplicationDbContext context)
        {
            var comments = new List<Comment>();

            for (int i = 0; i < 10; i++)
            {
                comments.Add(new Comment
                {                    
                    Content = "Content" + i,
                    CreatedOn = DateTime.Today
                });
            }

            foreach (var comment in comments)
            {
                context.Comments.Add(comment);
            }

            context.SaveChanges();
        }

        private void SeedPosts(ApplicationDbContext context)
        {
            var posts = new List<Post>();

            for (int i = 0; i < 10; i++)
            {
                posts.Add(new Post
                {
                    Header = "Header" + i,
                    Content = "Content" + i,
                    CreatedOn = DateTime.Today
                });
            }

            foreach (var post in posts)
            {
                context.Posts.Add(post);
            }

            context.SaveChanges();
        }

        private void SeedCategories(ApplicationDbContext context)
        {
            var categories = new List<Category>();

            for (int i = 0; i < 10; i++)
            {
                categories.Add(new Category
                {
                    Name = "Category" + i
                });
            }

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }

            context.SaveChanges();
        }
    }
}

