using EggStore.Domains.Eggs.Entities;
using EggStore.Domains.Transactions.Entities;
using EggStore.Infrastucture.Shareds.DataAccess;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EggStore.Domains.TransactionItems.Entities
{
    [Table("transaction_items")]
    public class TransactionItemsEntity:BaseEntity
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; } = default;

        [Column("transaction_id")]
        public Guid TransactionId { get; set; }

        [Column("egg_id")]
        public Guid EggId { get; set; }

        [ForeignKey("TransactionId")]
        public TransactionsEntity TransactionsEntity { get; set; }

        [ForeignKey("EggId")]
        public EggsEntity EggsEntity { get; set; }
    }
}
