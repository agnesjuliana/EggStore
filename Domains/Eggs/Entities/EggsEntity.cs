using EggStore.Domains.Packages.Entities;
using EggStore.Infrastucture.Shareds.DataAccess;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EggStore.Domains.Eggs.Entities
{
    [Table("eggs")]
    public class EggsEntity : BaseEntity
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }

        [Column("package_id")]
        public Guid PackageId { get; set; }

        [Column("egg_name")]
        public string EggName { get; set; }

        [Column("stok")]
        public int Stok { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [ForeignKey("packageId")]
        public PackagesEntity PackagesEntity { get; set; }
    }
}
