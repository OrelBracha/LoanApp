namespace loanAPI.Services
{
    public class DefaultInterestCalculationStrategy : IInterestCalculationStrategy
    {
        private const decimal PrimeInterest = 1.5m;

        public decimal CalculateBaseInterest(int age, decimal amount)
        {
            if (age < 20)
                return 2 + PrimeInterest;
            else if (age <= 35)
            {
                if (amount <= 5000) return 2;
                if (amount <= 30000) return 1.5m + PrimeInterest;
                return 1 + PrimeInterest;
            }
            else
            {
                if (amount <= 15000) return 1.5m + PrimeInterest;
                if (amount <= 30000) return 3 + PrimeInterest;
                return 1;
            }
        }

        public decimal CalculateExtraInterest(int periodInMonths)
        {
            if (periodInMonths <= 12) return 0;
            return (periodInMonths - 12) * 0.15m;
        }
    }
}
