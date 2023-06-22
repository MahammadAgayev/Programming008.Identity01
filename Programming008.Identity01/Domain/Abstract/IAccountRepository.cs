using Microsoft.AspNetCore.SignalR;

using Programming008.Identity01.Domain.Entities;

namespace Programming008.Identity01.Domain.Abstract
{
    public interface IAccountRepository
    {
        void Add(Account account);
        void Update(Account account);

        Account? Get(string username);
        Account? Get(int id);
    }
}
