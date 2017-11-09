namespace BlogSystem.Data.Services.Implementation
{
    using System.Linq;
    using AutoMapper;
    using Common;
    using Contracts;
    using Models;
    using ViewModels.User;

    public class UserService : IUserService
    {
        private IRepository<ApplicationUser> users;

        public UserService(IRepository<ApplicationUser> users)
        {
            this.users = users;
        }

        public IQueryable<ApplicationUser> GetAllUsers()
        {
            return this.users.GetAll();
        }

        public UserVM GetById(string id)
        {
            var entity = this.users.FirstOrDefault(x => x.Id == id);
            var vm = Mapper.Map<UserVM>(entity);

            return vm;
        }

        public UserVM GetByEmail(string email)
        {
            var entity = this.users.FirstOrDefault(x => x.Email == email);
            var vm = Mapper.Map<UserVM>(entity);

            return vm;
        }

        public UserVM Add(UserVM model)
        {
            var entity = this.users.FirstOrDefault(x => x.Id == model.Id);
            this.users.Add(entity);
            var vm = Mapper.Map<UserVM>(entity);

            return vm;
        }

        public void Update(UserVM model)
        {
            var entity = this.users.FirstOrDefault(x => x.Id == model.Id);
            this.users.Update(entity);
            this.users.SaveChanges();
        }

        public bool Exists(string email)
        {
            return this.users.Any(s => s.Email == email);
        }

        public bool Exists(string id, string email)
        {
            return this.users.Any(s => s.Id != id && s.Email == email);
        }

        public void Delete(UserVM model)
        {
            var entity = this.users.FirstOrDefault(x => x.Id == model.Id);
            this.users.Delete(entity);
            this.users.SaveChanges();
        }
    }
}
