using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using SFBB.Model;

namespace SFBB.Data
{
    public partial class SfbbDbContext : IdentityDbContext<User>
    {
        public SfbbDbContext()
            : base("DefaultConnection")
        {
       
        }

        

        public static SfbbDbContext Create()
        {
            return new SfbbDbContext();
        }


    }
}
