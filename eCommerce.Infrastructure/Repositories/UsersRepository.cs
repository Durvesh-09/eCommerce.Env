using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContract;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UsersRepository : IUserRepository
    {
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            // Generate a new guid for user 
            user.UserId = Guid.NewGuid();
            return user;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? Email, string? Password)
        {
            return new ApplicationUser()
            {
                UserId = Guid.NewGuid(),
                Email = Email,
                Password = Password,
                PersonName = "New User",
                Gender = GenderOptions.Male.ToString()
            };
        }
    }
}
