using SQLConnectionApplication.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnectionApplication
{
    public class DatabaseContext : DbContext
    {
        
        public DatabaseContext() : base("name = ConnectionString") {
            Database.SetInitializer<DatabaseContext>(new DBInitializer<DatabaseContext>());
        } 

        public virtual DbSet<Rom> Rom { get; set; }
        public virtual DbSet<Reservasjon> Reservasjoner { get; set; }
        public virtual DbSet<Kunde> Kunder { get; set; }
        public virtual DbSet<ServiceOppgave> ServiceOppgaver { get; set; }
    }
}
