using Microsoft.Extensions.Logging;
using MLService.Infrastructure.Models;
using MLService.MachineLearning.DAL.Data;
using MLService.MachineLearning.DAL.Models;
using MLService.MassTransit.MLService.Requests;

namespace MLService.MachineLearning.BAL.Services.Impl
{
    public class LearnService : ILearnService
    {
        private readonly ILogger<LearnService> _log;
        private readonly MachineLearnDbContext _context;


        public LearnService(ILogger<LearnService> log, MachineLearnDbContext context)
        {
            _log = log;
            _context = context;
        }

        public IdWithName CreateMachine(CreateMachineRequest request)
        {
            _log.LogInformation("Create machine..");
            var machine = new Machine(request.MachineName, request.MachineDescription, request.MachineType);
            _context.Add(machine);
            _context.SaveChanges();
            _log.LogInformation("Machine succsesfull created!");
            return new(machine.Id, machine.Name);
        }

        public void StartLearn()
        {
            throw new NotImplementedException();
        }
    }
}
