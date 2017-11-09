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

        UserVM Add(UserVM entity);

        void Update(UserVM entity);

        bool Exists(string id);

        bool Exists(string id, string email);

        void Delete(UserVM entity);
    }
}
