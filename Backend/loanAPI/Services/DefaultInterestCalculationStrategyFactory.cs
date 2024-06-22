namespace loanAPI.Services
{
    public class DefaultInterestCalculationStrategyFactory : IInterestCalculationStrategyFactory
    {
        public IInterestCalculationStrategy GetStrategy()
        {
            return new DefaultInterestCalculationStrategy();
        }
    }
}
