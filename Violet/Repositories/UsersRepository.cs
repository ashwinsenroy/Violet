using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Violet.Interfaces.RepositoryInterfaces;
using Violet.Models;

namespace Violet.Repositories
{
    public class UsersRepository : GenericDataRepository<Users>, IUsersRepository
    {


    }
}