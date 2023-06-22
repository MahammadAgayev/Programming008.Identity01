using Programming008.Identity01.Domain.Abstract;
using Programming008.Identity01.Domain.Entities;

namespace Programming008.Identity01.Domain.DataAccess
{
    public class InMemoryAccountRoleRepository : IAccountRoleRepository
    {
        public void Add(AccountRole accountRole)
        {
            accountRole.Id = DB.AccountRoleIdCounter++;
            DB.AccountRoles.Add(accountRole);
        }

        public List<AccountRole> GetByRoleAccountId(int accountId)
        {
            return DB.AccountRoles.Where(x => x.Account.Id == accountId).ToList();
        }
    }
}
