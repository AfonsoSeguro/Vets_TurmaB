using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinarios.Models;

namespace Veterinarios.Data
{
    public class VetsBD : DbContext{

        public  DbSet<Animais> Animais { get; set; }
        public DbSet<Consultas> Consultas { get; set; }
        public DbSet<Veter> Veterinarios { get; set; }
        public DbSet<Donos> Donos { get; set; }


        public VetsBD(DbContextOptions<VetsBD> options) : base(options){

        }

    }
}
