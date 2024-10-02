using MassTransit;
using MLService.MassTransit.MLService.Requests;

namespace MLService.MachineLearning.Consumers
{
    public class CreateMachineConsumer : IConsumer<CreateMachineRequest>
    {
        public CreateMachineConsumer() { }

        public Task Consume(ConsumeContext<CreateMachineRequest> request)
        {
            //LearnService.CreateMachineConsumer(request);
            var test = request.Message;

            return Task.CompletedTask;
        }
    }
}
