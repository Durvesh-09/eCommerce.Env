using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContract
{
    /// <summary>
    /// Contract to be implemented by UserRepository that contains data access logic of users data store
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// method to add user to the database and returns the same 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ApplicationUser?> AddUser(ApplicationUser user);

        /// <summary>
        /// method to retrive existing user by email and password
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        Task<ApplicationUser?> GetUserByEmailAndPassword(string? Email, string? Password);
    }
}
