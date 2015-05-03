using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoW.Data.Repositories;
using UoW.Model;

namespace UoW.Data.UoW
{
    public class UoWUnitOfWork : IUoWUnitOfWork, IDisposable
    {
        private UoWDbContext DbContext { get; set; }

        public UoWUnitOfWork()
        {
            CreateDbContext();                   
        }
 
        //repositories
        #region Repositries
        private IRepository<Skill> _skills;
        private IRepository<Certification> _certifications;
        private IRepoApplicant _applicants;
        private IRepository<User> _users;
        
        public IRepository<User> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new MyRepository<User>(DbContext);

                }

                return _users;
            }
        }

        //get Skills repo
        public IRepository<Skill> Skills
        {
            get 
            {
                if (_skills == null)
                {
                    _skills = new MyRepository<Skill>(DbContext);
                
                }
                return _skills;            
            }
        } 
 
        //get Certification repo
        public IRepository<Certification> Certifications
        {
            get
            {
                if (_certifications == null)
                {
                    _certifications = new MyRepository<Certification>(DbContext);
 
                }
                return _certifications; 
            }
        }
        //get aplicants repo
        public IRepoApplicant Applicants
        {
            get
            {
                if (_applicants == null)
                {
                    _applicants = new RepoApplicant(DbContext);
 
                }
 
                return _applicants; 
            }
        }
 
        #endregion
         
        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public void Commit()
        {             
            DbContext.SaveChanges();
        }
 
        protected void CreateDbContext()
        {
            DbContext = new UoWDbContext();        
 
            // Do NOT enable proxied entities, else serialization fails.
            //if false it will not get the associated certification and skills when we
           //get the applicants
            DbContext.Configuration.ProxyCreationEnabled = false;
 
            // Load navigation properties explicitly (avoid serialization trouble)
           DbContext.Configuration.LazyLoadingEnabled = false;
 
            // Because Web API will perform validation, we don't need/want EF to do so
            DbContext.Configuration.ValidateOnSaveEnabled = false;
 
            //DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.
        }        
 
        #region IDisposable
 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
 
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }
 
        #endregion     
    }
}
