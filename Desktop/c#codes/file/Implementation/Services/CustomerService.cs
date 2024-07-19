using file.Entities;
using file.Interfaces.Repositoritories;
using file.Interfaces.Services;
using file.RequestModel;
using file.ResponseModel;
namespace file.Implementation.Services
{
    public class CustomerService :ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;

        public CustomerService(ICustomerRepository customerRepository,IUserRepository userRepository)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
        }


        public BaseResponse Register(CustomerRequestModel customerRequestModel)
        {
            //var customer = _customerRepository.GetAllCustomers().SingleOrDefault(x => x.Email == customerRequestModel.Email);
            if (_customerRepository.GetAllCustomers().SingleOrDefault(x => x.Email == customerRequestModel.Email) != null)
            {
                return new BaseResponse
                {
                    Message = "Email already exist",
                    Status = false
                };             
            }
            Customer customer = new Customer
            {
                Name = customerRequestModel.Name,
                Address = customerRequestModel.Address,
                Email = customerRequestModel.Email,
            };
            User user = new User
            {
                UserName = customer.Name,
                UserRole = User.Role.Customer,
                PasswordHash = PasswordUtil.HashPassword(customerRequestModel.Password)
            };
            customer.UserId = user.Id;
            _customerRepository.Add(customer);
            _userRepository.Add(user);
            return new BaseResponse
            {
                Message = "Sucessfully registered",
                Status = true
            };
            
        }
        public BaseResponse CraeteAdmin()
        {
            Admin admin = new Admin
            {
                Name = "Mahmudah Adeyemi",
                Email = "mahmudah@gmail.com",
                Address = "Sapon"
            };
            User user = new User
            {
                UserName = admin.Name,
                UserRole = User.Role.Admin,
                PasswordHash = PasswordUtil.HashPassword("mahmudah2009")
            };
            admin.UserId= user.Id;
            return new BaseResponse
            {
                Message = "Sucessfully created",
                Status = true
            };
            
        }
        public BaseResponse ChangeAddress(int id,string address)
        {
            var customer = _customerRepository.GetCustomer(id);
            if (customer == null)
            {
                return new BaseResponse
                {
                    Message = "Customer not found",
                    Status = false
                };
            }
            var customer1 = new Customer
            {
                Email = customer.Email,
                Name = customer.Name,
                Address = address
            };
            _customerRepository.Delete(customer.Id);
            _customerRepository.Add(customer1);
            return new BaseResponse
            {
                Message = "Sucessfully changed",
                Status = false
            };

        }
        public BaseResponse ChangePassword(ChangePasswordRequest changePasswordRequest)
        {
            if ( AuthenticatedUser.UserName == null)
            {
                return new BaseResponse
                {
                    Message = "You need to login",
                    Status = false
                };
            }
            var user = _userRepository.GetAllUsers().Single(x => x.UserName == AuthenticatedUser.UserName);
            if(user.PasswordHash != PasswordUtil.HashPassword(changePasswordRequest.OldPassword))
            {
                return new BaseResponse
                {
                    Message = "Incorrect old Password",
                    Status = false
                };
            }
            _userRepository.Delete(user.Id);
            user.PasswordHash = PasswordUtil.HashPassword(changePasswordRequest.NewPassword);
            _userRepository.Add(user);
            return new BaseResponse
            {
                Message = "Sucessfully changed",
                Status = false
            };

        }
        public BaseResponse Login(LoginRequestModel loginRequestModel)
        {
            if ( AuthenticatedUser.UserName != null)
            {
                return new BaseResponse
                {
                    Message = "You are login",
                    Status = false
                };
            }
            var customer = _userRepository.GetAllUsers().FirstOrDefault(x => x.UserName == loginRequestModel.UserName);
            if (customer == null)
            {
                return new BaseResponse
                {
                    Message = "You need to register before you can login",
                    Status = false
                };
            }
            // Remenber to hash password
            if (customer.PasswordHash != PasswordUtil.HashPassword(loginRequestModel.Password))
            {
                return new BaseResponse
                {
                    Message = "Incorrect Password",
                    Status = false
                };
            }
            AuthenticatedUser.SetAuthUser(customer.UserName, customer.UserRole);
            
            return new BaseResponse
            {
                Message = "Sucessfully logged in",
                Status =true
            };


        }

    }
}