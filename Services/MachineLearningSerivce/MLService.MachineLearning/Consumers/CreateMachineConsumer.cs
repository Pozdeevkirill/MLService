using MassTransit;
using MLService.MachineLearning.BAL.Services;
using MLService.MassTransit.MLService.Requests;

namespace MLService.MachineLearning.Consumers
{
    public class CreateMachineConsumer : MLServiceBaseConsumer, IConsumer<CreateMachineRequest>
    {
        public CreateMachineConsumer(ILearnService learnService) : base(learnService) { }

        public Task Consume(ConsumeContext<CreateMachineRequest> request)
        {
            //LearnService.CreateMachineConsumer(request);
            var test = request.Message;

            return Task.CompletedTask;
        }
    }
}
