using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineWallet.Dal.Entities;

namespace OnlineWallet.Dal
{
    [Table("Wallet")]
    public class DbWallet : IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int Balance { get; set; }

        public Guid? CustomerId { get; set; }

        public DbCustomer Customer { get; set; }
    }
}
