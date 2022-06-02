using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EggStore.Infrastucture.Shareds.DataAccess
{
    public class BaseEntity
    {
        [Column(name: "created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column(name: "updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}
