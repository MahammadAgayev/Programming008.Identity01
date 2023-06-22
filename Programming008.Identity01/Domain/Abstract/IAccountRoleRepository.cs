using Programming008.Identity01.Domain.Entities;

namespace Programming008.Identity01.Domain.Abstract
{
    public interface IAccountRoleRepository
    {
        void Add(AccountRole accountRole);
        List<AccountRole> GetByRoleAccountId(int accountId);
    }
}
