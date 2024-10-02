using MLService.Infrastructure.Models;
using MLService.MassTransit.MLService.Requests;

namespace MLService.MachineLearning.BAL.Services
{
    public interface ILearnService
    {
        IdWithName CreateMachine(CreateMachineRequest request);
        void StartLearn();
    }
}
