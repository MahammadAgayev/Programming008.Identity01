namespace Programming008.Identity01.Domain.Entities
{
    public class AccountRole
    {
        public int Id { get; set; }
        public Role? Role { get; set; }
        public Account? Account { get; set; }
    }
}
