using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoW.Data.Repositories;
using UoW.Model;

namespace UoW.Data.UoW
{
    public interface IUoWUnitOfWork
    {
        void Commit();

        //Repositories
        IRepository<Skill> Skills { get; }
        IRepository<Certification> Certifications { get; }
        IRepoApplicant Applicants { get; }
        IRepository<User> Users { get; }
    }
}
