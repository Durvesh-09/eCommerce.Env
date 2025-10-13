using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContract;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UsersRepository : IUserRepository
    {
        private readonly DapperDbContext _dbContext;

        public UsersRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            // Generate a new guid for user 
            user.UserId = Guid.NewGuid();

            // SQL Query to insert user data into the "users" table
            string query = "INSERT INTO \"Users\" (\"UserID\",\"Email\",\"PersonName\",\"Gender\",\"Password\") VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";

            int rowContAffected=await _dbContext.DbConnection.ExecuteAsync(query , user);
            if (rowContAffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? Email, string? Password)
        {

            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email and \"Password\"=@Password";

            ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query,new{Password = Password , Email =Email});
            //return new ApplicationUser()
            //{
            //    UserId = Guid.NewGuid(),
            //    Email = Email,
            //    Password = Password,
            //    PersonName = "New User",
            //    Gender = GenderOptions.Male.ToString()
            //};
            return user;
        }
    }
}
 