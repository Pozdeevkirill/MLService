using Microsoft.EntityFrameworkCore;
using MLService.MachineLearning.DAL.Models;

namespace MLService.MachineLearning.DAL.Data;
public class MachineLearnDbContext : DbContext
{
    public DbSet<Machine> Machines { get; set; } 
    public MachineLearnDbContext(DbContextOptions options) : base(options)
    {
    }
}
