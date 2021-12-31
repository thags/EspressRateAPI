using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace EspressRateAPI.Models
{
    public class EspressoContext : DbContext
    {
        public EspressoContext(DbContextOptions<EspressoContext> options)
            : base(options) {}

        public DbSet<EspressoItem> EspressoItems { get; set; } = null!;

    }
}
