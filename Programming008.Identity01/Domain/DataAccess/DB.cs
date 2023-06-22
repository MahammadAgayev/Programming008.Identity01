using Programming008.Identity01.Domain.Entities;

namespace Programming008.Identity01.Domain.DataAccess
{
    public static class DB
    {
        public static List<Account> Accounts = new List<Account>
        {
            new Account()
            {
                Id = 1,
                PasswordHash = "AQAAAAEAACcQAAAAEL6vmojNweAcAmIEEGKNIv9Ce9/buuH7grN43m2pATxOaw0a0DB3zwuJG/o4IwQL1A==",
                Username = "mahammad"
            }
        };
        public static int AccountIdCounter = 2;

        public static List<Role> Roles = new List<Role>
        {
            new Role { Id = 1, RoleName = "Admin"    },
            new Role { Id = 2, RoleName = "Customer" },
            new Role { Id = 3, RoleName = "Driver"   }
        };


        public static List<AccountRole> AccountRoles = new List<AccountRole>
        {
            new AccountRole
            {
                Account = Accounts[0],
                Id = 1,
                Role = Roles[0]
            }
        };

        public static int AccountRoleIdCounter = 2;
    }
}
