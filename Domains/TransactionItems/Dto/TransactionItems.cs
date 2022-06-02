using EggStore.Domains.Eggs.Dto;
using EggStore.Domains.Transactions.Dto;

namespace EggStore.Domains.TransactionItems.Dto
{
    public class TransactionItemsDto
    {
        public Guid Id { get; set; } = default;
        public TransactionsDto TransactionId { get; set; }
        public EggsDto EggId { get; set; }
    }
}
