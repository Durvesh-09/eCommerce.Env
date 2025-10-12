using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContract;
using eCommerce.Core.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Services
{
    internal class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersService(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

            if (user == null)
            {
                return null;
            }

            
            //return new AuthenticationResponse(user.UserId, user.Email, user.PersonName, user.Gender, "TOKEN", Success: true);
            return _mapper.Map<AuthenticationResponse>(user) with 
              { Success =true , Token= "token" };
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            // Create a new Application object from RegisterRequest 
            //ApplicationUser user = new ApplicationUser()
            //{
            //    PersonName = registerRequest.PersonName,
            //    Email = registerRequest.Email,
            //    Password = registerRequest.Password,
            //    Gender = registerRequest.Gender.ToString(),
            //};

            var user =_mapper.Map<ApplicationUser>(registerRequest);

            ApplicationUser? registerdUser = await _userRepository.AddUser(user);
            
            if (registerdUser == null)
            {
                return null;
            }

            //return new AuthenticationResponse(registerdUser.UserId,
            //    registerdUser.Email,
            //    registerdUser.PersonName,
            //    registerdUser.Gender,
            //    "TOKEN",
            //    Success: true);

            return _mapper.Map<AuthenticationResponse>(registerdUser) with
            { Success =true , Token = "token"};
        }
    }
}
