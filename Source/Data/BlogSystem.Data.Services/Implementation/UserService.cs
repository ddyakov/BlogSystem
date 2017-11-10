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
            var entity = Mapper.Map<ApplicationUser>(model);
            this.users.Add(entity);

            return Mapper.Map<UserVM>(entity);
        }

        public void Update(UserVM model)
        {
            var entity = this.users.FirstOrDefault(x => x.Id == model.Id);
            this.users.UpdateAndSave(Mapper.Map(model, entity));
        }

        public bool EmailExists(string email)
        {
            return this.users.Any(s => s.Email == email);
        }

        public bool Exists(string id)
        {
            return this.users.Any(s => s.Id == id);
        }

        public void Delete(UserVM model)
        {
            var entity = users.FirstOrDefault(x => x.Id == model.Id);
            this.users.DeleteAndSave(entity);
        }
    }
}
