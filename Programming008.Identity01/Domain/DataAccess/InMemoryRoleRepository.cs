using Programming008.Identity01.Domain.Abstract;
using Programming008.Identity01.Domain.Entities;

namespace Programming008.Identity01.Domain.DataAccess
{
    public class InMemoryRoleRepository : IRoleRepository
    {
        public Role? GetByName(string roleName)
        {
            return DB.Roles
                .FirstOrDefault(x => x.RoleName?.ToUpperInvariant() == roleName.ToUpperInvariant());
        }
    }
}
