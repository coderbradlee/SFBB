using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFBB.Model;

namespace SFBB.Interfaces
{
    public interface ISfbbUnitOfWork
    {
        void Commit();

        //Repositories
        IRepository<User> Users { get; }
    }
}
