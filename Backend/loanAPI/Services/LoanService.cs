using loanAPI.Models;
using loanAPI.Repositories;

namespace loanAPI.Services
{
    public class LoanService : ILoanService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IInterestCalculationStrategy _interestCalculationStrategy;

        public LoanService(IClientRepository clientRepository, IInterestCalculationStrategyFactory strategyFactory)
        {
            _clientRepository = clientRepository;
            _interestCalculationStrategy = strategyFactory.GetStrategy();
        }

        public async Task<LoanResponse> CalculateLoanAsync(LoanRequest request)
        {
            var client = await _clientRepository.GetClientByIdAsync(request.ClientId);
            if (client == null) throw new ArgumentException("Invalid client ID");

            decimal baseInterest = _interestCalculationStrategy.CalculateBaseInterest(client.Age, request.Amount);
            decimal extraInterest = _interestCalculationStrategy.CalculateExtraInterest(request.PeriodInMonths);

            decimal totalInterest = baseInterest + extraInterest;
            decimal totalAmount = request.Amount + (request.Amount * totalInterest / 100);

            return new LoanResponse
            {
                TotalAmount = totalAmount,
                Interest = totalInterest
            };
        }
    }
}
