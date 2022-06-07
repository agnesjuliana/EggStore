using EggStore.Infrastucture.Shareds.DataAccess;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EggStore.Domains.Packages.Entities
{
    [Table("packages")]
    public class PackagesEntity : BaseEntity
    {
        internal bool id;

        [Column("id")]
        [Key]
        public Guid Id { get; set; }

        [Column("package_name")]
        public string PackageName { get; set; }
    }
}
