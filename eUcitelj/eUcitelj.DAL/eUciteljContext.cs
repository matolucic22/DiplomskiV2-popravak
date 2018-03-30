using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using eUcitelj.DAL.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace eUcitelj.DAL
{
    public class eUciteljContext : DbContext
    {
        public eUciteljContext() : base("eUciteljContext")
        {

        }

        public DbSet<Korisnik> Korisniks { get; set; }
        public DbSet<Kviz> Kvizs { get; set; }
        public DbSet<Ocjene> Ocjenes { get; set; }
        public DbSet<Predmeti> Predmetis { get; set; }
        public DbSet<Ucenici> Ucenicis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)//code first
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//Instead, the table names will be Korisniks, Kvizs. Developers disagree about whether table names should be pluralized or not. Method prevents table name of being puralized.
        }

        public new DbSet<T> Set<T>() where T : class//Nešto kao instanca za svaku bazu koju smo kreirali
        {
            return base.Set<T>();
        }

    }
}
