using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Violet.Interfaces.ManagerInterfaces;
using Violet.Interfaces.RepositoryInterfaces;
using Violet.Models;

namespace Violet.Managers
{
    public class UsersManager : IUsersManager
    {   
        public IUsersRepository objUsersRepository;
        public UsersManager(IUsersRepository usersRepository) 
        {
            objUsersRepository = usersRepository;
        }

        public void AddNewUser(Users objUser)
        {
            if(objUser != null)
            {
               objUsersRepository.Add(objUser);
            }
        }
    }
}