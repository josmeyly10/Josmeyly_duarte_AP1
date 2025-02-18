using josmeyly_Duarte_Ap1.Models;
using Microsoft.EntityFrameworkCore;

namespace josmeyly_Duarte_Ap1.DAL
{
   
        public class Contexto : DbContext
        {
        public Contexto(DbContextOptions<Contexto> options):base (options) { }
         
         public DbSet<Aporte> Aporte { get; set; } //tabla del aporte 
           
        }
}
