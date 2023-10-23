using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Calina_Oprea_Lab2.Models;

namespace Calina_Oprea_Lab2.Data
{
    public class Calina_Oprea_Lab2Context : DbContext
    {
        public Calina_Oprea_Lab2Context (DbContextOptions<Calina_Oprea_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Calina_Oprea_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Calina_Oprea_Lab2.Models.Publisher>? Publisher { get; set; }
    }
}
