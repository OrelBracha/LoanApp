using loanAPI.Models;

namespace loanAPI.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly List<Client> _clients = new List<Client>
    {
        new Client { Id = 1, Age = 19 },
        new Client { Id = 2, Age = 25 },
        new Client { Id = 3, Age = 40 }
    };

        public async Task<Client> GetClientByIdAsync(int clientId)
        {
            return await Task.FromResult(_clients.FirstOrDefault(c => c.Id == clientId));
        }
    }
}
