using Programming008.Identity01.Domain.Abstract;
using Programming008.Identity01.Domain.Entities;

namespace Programming008.Identity01.Domain.DataAccess
{
    public class InMemoryAccountRepository : IAccountRepository
    {
        public void Add(Account account)
        {
            account.Id = DB.AccountIdCounter++;
            DB.Accounts.Add(account);
        }

        public void Update(Account account)
        {
            Account? update = DB.Accounts.FirstOrDefault(x => x.Id == account.Id);

            if(update is null)
            {
                return;
            }

            update.Username = account.Username;
            update.PasswordHash = account.PasswordHash;
        }

        public Account? Get(string username)
        {
            return DB.Accounts.FirstOrDefault(x => x.Username.ToUpperInvariant() == username.ToUpperInvariant());
        }

        public Account? Get(int id)
        {
            return DB.Accounts.FirstOrDefault(x => x.Id == id);
        }
    }
}
