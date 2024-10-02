using MLService.MachineLearning.BAL.Services;

namespace MLService.MachineLearning.Consumers
{
    public abstract class MLServiceBaseConsumer(ILearnService learnService)
    {
        protected readonly ILearnService LearnService = learnService;
    }
}
