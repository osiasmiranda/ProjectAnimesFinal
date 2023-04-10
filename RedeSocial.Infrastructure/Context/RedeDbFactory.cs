using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocial.Infrastructure.Context
{
    public class RedeDbFactory : IDesignTimeDbContextFactory<RedeDbContext>
    {
        public RedeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RedeDbContext>();
            optionsBuilder.UseSqlServer("Server=MIRANDA\\SQLEXPRESS;Database=Db_projetoDeBloco;TrustServerCertificate=True;MultipleActiveResultSets=True;Trusted_Connection=True");
            return new RedeDbContext(optionsBuilder.Options);
        }

    }
}
