using MySql.Data.Entity;
using SecureSystemsMediator.Models;
using System.Data.Common;
using System.Data.Entity;

namespace MediatorEE.Models
{
    public class MedStorageContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public MedStorageContext() : base("name=MedStorageContext")
        {
        }

        // Constructor to use on a DbConnection that is already opened
        public MedStorageContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {

        }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//          base.OnModelCreating(modelBuilder);
//            modelBuilder.Entity<MediatorPartKey>().MapToStoredProcedures();
//        }

        public DbSet<MediatorPartKey> MediatorPartKeys { get; set; }
    }
}