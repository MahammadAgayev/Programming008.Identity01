using Programming008.Identity01.Domain.Entities;

namespace Programming008.Identity01.Domain.Abstract
{
    public interface IRoleRepository
    {
        Role? GetByName(string roleName);
    }
}
