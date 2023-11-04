using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormApp.Persistence
{
    class ConverterXMLContext : DbContext
    {
        #region Propriétés DBSet
        public virtual DbSet<RandomObject> RandomObjects { get; set; }
        #endregion

        #region Constructeur
        public ConverterXMLContext(DbContextOptions<ConverterXMLContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            BuildClient(builder);
        }

        private void BuildClient(ModelBuilder builder)
        {
            //Table
            builder.Entity<RandomObject>();
            //Colonnes
            builder.Entity<RandomObject>()
                .Property(obj => obj.IdRandomObj)
                    .IsRequired()
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("NEWID()");
            builder.Entity<RandomObject>()
                .Property(obj => obj.Name)
                .IsRequired();
            builder.Entity<RandomObject>().Property(obj => obj.Color).IsRequired();
            builder.Entity<RandomObject>().Property(obj => obj.Size);
            builder.Entity<RandomObject>().Property(obj => obj.Description).IsRequired();
            builder.Entity<RandomObject>().Property(obj => obj.Weight).IsRequired();
            //Clé primaire 
            builder.Entity<RandomObject>()
                .HasKey(obj => obj.IdRandomObj);
        }





    }
}
