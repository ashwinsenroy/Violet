using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Violet.Interfaces.RepositoryInterfaces
{
    public interface IGenericDataRepository<T>
    {
        bool Add<T>(T data);

    }
}
