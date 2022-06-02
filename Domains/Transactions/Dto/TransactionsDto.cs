
using EggStore.Domains.Users.Dto;

namespace EggStore.Domains.Transactions.Dto
{
    public class TransactionsDto
    {
        public Guid Id { get; set; } = default;

        public UsersDto UserId { get; set; }
    }
}
