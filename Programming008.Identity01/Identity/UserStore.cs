using Microsoft.AspNetCore.Identity;

using Programming008.Identity01.Domain.Abstract;
using Programming008.Identity01.Domain.Entities;

namespace Programming008.Identity01.Identity
{
    public class UserStore : IUserStore<Account>, IUserPasswordStore<Account>, IUserRoleStore<Account>, IUserPhoneNumberStore<Account>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IRoleRepository _roleRepository;

        public UserStore(IAccountRepository accountRepository, IAccountRoleRepository accountRoleRepository, IRoleRepository roleRepository)
        {
            _accountRepository = accountRepository;
            _accountRoleRepository = accountRoleRepository;
            _roleRepository = roleRepository;
        }


        public Task<IdentityResult> CreateAsync(Account user, CancellationToken cancellationToken)
        {
            _accountRepository.Add(user);

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(Account user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(Account user, CancellationToken cancellationToken)
        {
            _accountRepository.Update(user);

            return Task.FromResult(IdentityResult.Success);
        }

        public void Dispose()
        {
            //nothing to dispose
        }

        public Task<Account> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            int id = int.Parse(userId);
            Account? account = _accountRepository.Get(id);

            return Task.FromResult(account);
        }

        public Task<Account> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            Account? account = _accountRepository.Get(normalizedUserName);


            return Task.FromResult(account);
        }

        public Task<string> GetNormalizedUserNameAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username.ToUpperInvariant());
        }

        public Task<string> GetUserIdAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username?.ToString());
        }

        public Task SetNormalizedUserNameAsync(Account user, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(Account user, string userName, CancellationToken cancellationToken)
        {
            user.Username = userName;

            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(Account user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;

            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(string.IsNullOrEmpty(user.PasswordHash));
        }

        public Task AddToRoleAsync(Account user, string roleName, CancellationToken cancellationToken)
        {
            Role role = _roleRepository.GetByName(roleName);

            AccountRole accountRole = new AccountRole
            {
                Account = user,
                Role = role
            };

            _accountRoleRepository.Add(accountRole);

            return Task.CompletedTask;
        }

        public Task RemoveFromRoleAsync(Account user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(Account user, CancellationToken cancellationToken)
        {
            List<AccountRole> accountRoles = _accountRoleRepository.GetByRoleAccountId(user.Id);

            List<string> roles = accountRoles.Select(x => x.Role.RoleName).ToList();

            return Task.FromResult(roles as IList<string>);
        }

        public Task<bool> IsInRoleAsync(Account user, string roleName, CancellationToken cancellationToken)
        {
            List<AccountRole> roles = _accountRoleRepository.GetByRoleAccountId(user.Id);

            bool isInRole = roles.Any(x => x.Role.RoleName.ToUpperInvariant() == roleName.ToUpperInvariant());

            return Task.FromResult(isInRole);
        }

        public Task<IList<Account>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPhoneNumberAsync(Account user, string phoneNumber, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPhoneNumberAsync(Account user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(Account user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPhoneNumberConfirmedAsync(Account user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
