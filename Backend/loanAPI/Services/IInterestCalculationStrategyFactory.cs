namespace loanAPI.Services
{
    public interface IInterestCalculationStrategyFactory
    {
        IInterestCalculationStrategy GetStrategy();
    }
}
