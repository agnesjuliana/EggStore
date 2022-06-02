using EggStore.Domains.Users.Entities;
using EggStore.Infrastucture.Shareds.DataAccess;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EggStore.Domains.Transactions.Entities
{
    [Table("transactions")]
    public class TransactionsEntity:BaseEntity
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; } = default;

        [Column("user_id")]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public UsersEntity UsersEntity { get; set; }
    }
}
