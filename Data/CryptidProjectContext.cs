using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CryptidProject.Models;

namespace CryptidProject.Data
{
    public class CryptidProjectContext : DbContext
    {
        public CryptidProjectContext (DbContextOptions<CryptidProjectContext> options)
            : base(options)
        {
        }

        public DbSet<CryptidProject.Models.Cryptids> Cryptids { get; set; } = default!;
    }
}
