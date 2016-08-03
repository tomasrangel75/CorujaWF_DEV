using Library.Persistencia_DbCentral.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistencia_DbCentral
{
    public class DbCentralContext : DbContext
    {
        public DbCentralContext()
            : base("name=DbCentral")
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }


        public DbSet<Especialista> Especialistas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Avaliacao>Avaliacaos { get; set; }
        public DbSet<Questionario> Questionarios { get; set; }

    }
}
