using Microsoft.Extensions.Logging;
using MLService.Infrastructure.Models;
using MLService.MachineLearning.DAL.Data;
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
            _log.LogInformation("Create machine");
            return new(Guid.NewGuid(), "тра-та-та");
        }

        public void StartLearn()
        {
            throw new NotImplementedException();
        }
    }
}
