using loanAPI.Models;

namespace loanAPI.Repositories
{
    public interface IClientRepository 
    {
        Task<Client> GetClientByIdAsync(int clientId);
    }
}
