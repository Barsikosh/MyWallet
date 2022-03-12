using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;

namespace OnlineWallet.Dal.Entities
{
    [Table("Customer")]
    public class DbCustomer : IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Unique]
        [Required]
        public string UserName { get; set; }

        [Required]
        public string HashPassword { get; set; }

        public bool PassAllAuthorization { get; set; }


        public DbWallet Wallet;
    }
}
