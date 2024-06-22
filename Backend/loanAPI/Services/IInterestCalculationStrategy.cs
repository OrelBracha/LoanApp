namespace loanAPI.Services
{
    public interface IInterestCalculationStrategy
    {
        decimal CalculateBaseInterest(int age, decimal amount);
        decimal CalculateExtraInterest(int periodInMonths);
    }
}
