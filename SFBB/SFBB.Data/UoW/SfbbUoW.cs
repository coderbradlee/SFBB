using SFBB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFBB.Model;
using SFBB.Data;

namespace Sfbb.Data.UoW
{
    public class SfbbUnitOfWork : ISfbbUnitOfWork, IDisposable
    {
        private SfbbDbContext DbContext { get; set; }

        public SfbbUnitOfWork()
        {
            CreateDbContext();
        }

        //repositories
        #region Repositries
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
            DbContext = new SfbbDbContext();

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
