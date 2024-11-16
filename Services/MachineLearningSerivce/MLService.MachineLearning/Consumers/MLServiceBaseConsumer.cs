using MassTransit;
using MLService.MachineLearning.BAL.Services;

namespace MLService.MachineLearning.Consumers
{
    public abstract class MLServiceBaseConsumer<T>(ILearnService learnService) : IConsumer<T>
        where T : class
    {
        protected readonly ILearnService LearnService = learnService;

        public abstract Task Consume(ConsumeContext<T> context);
    }
}
