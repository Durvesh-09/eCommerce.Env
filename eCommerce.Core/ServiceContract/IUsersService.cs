using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContract
{
    /// <summary>
    /// Contract for user service that contains use cases for users 
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// Method to handle user login use case and returns an AuthenticationResponse
        /// object taht contains status of login
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

        /// <summary>
        /// Method to handle user registration use case and return an object of AuthenticationResponse 
        /// type that represents status of user registration
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
    }
}
