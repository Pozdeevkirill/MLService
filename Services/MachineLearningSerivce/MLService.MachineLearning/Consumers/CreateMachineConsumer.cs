using MassTransit;
using MLService.MachineLearning.BAL.Services;
using MLService.MassTransit.MLService.Requests;

namespace MLService.MachineLearning.Consumers
{
    public class CreateMachineConsumer : MLServiceBaseConsumer<CreateMachineRequest>
    {
        public CreateMachineConsumer(ILearnService learnService) : base(learnService) { }

        public override Task Consume(ConsumeContext<CreateMachineRequest> request)
        {
            LearnService.CreateMachine(request.Message);

            return Task.CompletedTask;
        }
    }
}
