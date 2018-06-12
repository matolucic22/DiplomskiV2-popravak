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

        public DbSet<Korisnik> Korisnici { get; set; }//check naming
        public DbSet<Kviz> Kvizovi { get; set; }
        public DbSet<Ocjena> Ocjene { get; set; }//make table
        public DbSet<Predmet> Predmeti { get; set; }
        public DbSet<Ucenik> Ucenici { get; set; }
        public DbSet<PredmetKorisnik> PredmetKorisnik { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)//code first
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//Instead, the table names will be Korisnici, Kvizovi. Developers disagree about whether table names should be pluralized or not. Method prevents table name of being puralized.
        }

        public new DbSet<T> Set<T>() where T : class//Nešto kao instanca za svaku bazu koju smo kreirali
        {
            return base.Set<T>();
        }

    }
}
