using EggStore.Infrastucture.Shareds.DataAccess;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EggStore.Domains.Users.Entities
{
    [Table("users")]
    public class UsersEntity : BaseEntity
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("role")]
        public string Role { get; set; }
    }
}
