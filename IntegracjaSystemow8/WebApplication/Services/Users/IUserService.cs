using WebApplication.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Entities;

namespace WebApplication.Services.Users;

public interface IUserService
{
    AuthenticationResponse
        Authenticate(AuthenticationRequest request);
    IEnumerable<User> GetUsers();
    User GetByUsername(string username);
    User GetById(int id);
}