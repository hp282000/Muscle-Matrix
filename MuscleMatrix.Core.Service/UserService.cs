

using AutoMapper;
using Microsoft.Extensions.Configuration;
using MuscleMatrix.Core.Builder;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;
using MuscleMatrix.Infrastructure.Contract;
using MuscleMatrix.Infrastructure.Domain.Entities;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Security.Cryptography;
using System.Text;

namespace MuscleMatrix.Core.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordChangeRepository _passwordChangeRepository;
        private readonly IConfiguration _config;

        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordChangeRepository passwordChangeRepository,IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordChangeRepository = passwordChangeRepository;
            _config= configuration;
        }

        public async Task<string> UserLoginAsync(UserLogin userLogin)
        {
            var checkUser = await _userRepository.UserLogin(userLogin);

            var hsa = new HMACSHA256(checkUser.PasswordSalt);

            var userPassword = Encoding.ASCII.GetBytes(userLogin.Password);

            var computeuserPassword = hsa.ComputeHash(userPassword);

            if (checkUser.Password.SequenceEqual(computeuserPassword))
            {
                return "User Found";
            }
            return "User Not Found";

        }

        public async Task<int> AddUserAsync(UserRequestModel userRequestModel)
        {
           // var userpassword = new User();

            var hsa = new HMACSHA256();
            var computePassword = hsa.ComputeHash(Encoding.ASCII.GetBytes(userRequestModel.Password));
            var passwordSalt = hsa.Key;
            
            //var computepassword = hsa.ComputeHash(password);

            //userpassword.Password = computepassword;
            //userpassword.Password = password;    
            //userpassword.PasswordSalt = hsa.Key;

            var addUser = UserBuilder.Build(userRequestModel, computePassword, passwordSalt);
       
               var user = await _userRepository.AddUser(addUser);

            if(user == 0)
            {
                throw   new ArgumentNullException("User is not created Successfully Make sure that your repository works properly");
            }
                return user;
        }

        public async Task<List<UserResponseModel>> GetUserAsync()
        {
 
            var getUsers = await _userRepository.GetAllUsers();

            var mapping = _mapper.Map<List<UserResponseModel>>(getUsers);

            return mapping;
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            var deleteUser = await _userRepository.DeleteUser(id);

            if(deleteUser == null)
            {
                throw new ArgumentNullException("No Record Found");
            }
            return id;
        }

        public async Task<UserResponseModel> UpdateUserAsync(UserRequestModel userRequestModel, int id)
        {
            var getUser = await _userRepository.GetUserById(id);
            
            getUser.UpdateData(userRequestModel.Name, userRequestModel.Email, userRequestModel.ContactNo, userRequestModel.Gender, userRequestModel.DateOfBirth);
            
            var updateUser = await _userRepository.UpdateUser(getUser);
            var mapping = _mapper.Map<UserResponseModel>(updateUser);

            return mapping;
        }

        public async Task<(string mail, string otp)> SendEmailAsync(string email)
        {
            var user = await _passwordChangeRepository.GetEmail(email);

            if(user == null)
            {
                throw new ArgumentNullException("Please Enter Register Email");
            }
            else
            {
                string fromEmail = _config.GetSection("SendGridEmailSettings")["FromEmail"];
                string fromName = _config.GetSection("SendGridEmailSettings")["FromName"];
                Random rnd = new Random();
                var randomNumber = rnd.Next(100000, 999999).ToString();
                string message = randomNumber;
                var apiKey = _config.GetSection("SendGridEmailSettings")["APIKey"];
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(fromEmail,fromName);
                var subject = "Hello P-360 Member";
                var to = new EmailAddress(email);
                var plainTextContent = message;
                var htmlContent = "<strong> Hey Your Otp is </strong>  <br><h1>\" " + message +  " \"</h1><br>OTP is valid for 5 minitues only!!";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                string mailResponse = response.IsSuccessStatusCode ? "Otp Sent Success" : "Email Send Failed";

                   
            return (mail : mailResponse , otp: message);



            }
        }
    }
}