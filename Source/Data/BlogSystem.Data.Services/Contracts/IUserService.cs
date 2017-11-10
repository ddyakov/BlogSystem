namespace BlogSystem.Data.Services.Contracts
{
    using System.Linq;
    using Models;
    using ViewModels.User;

    public interface IUserService
    {
        IQueryable<ApplicationUser> GetAllUsers();

        UserVM GetById(string id);

        UserVM GetByEmail(string email);

        UserVM Add(UserVM model);

        void Update(UserVM model);

        bool EmailExists(string email);

        bool Exists(string id);

        void Delete(UserVM model);
    }
}
