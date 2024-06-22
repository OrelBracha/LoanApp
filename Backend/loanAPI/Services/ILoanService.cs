using loanAPI.Models;

namespace loanAPI.Services
{
    public interface ILoanService
    {
        Task<LoanResponse> CalculateLoanAsync(LoanRequest request);
    }
}
