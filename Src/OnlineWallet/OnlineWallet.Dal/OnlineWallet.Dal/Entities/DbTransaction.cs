using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineWallet.Dal.Entities
{
    [Table("Transaction")]
    public class DbTransaction : IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int Sum { get; set; }

        public bool AddMoney { get; set; }

        public Guid WalletId { get; set; }

        public DbWallet Wallet { get; set; }

        public DateTime Date { get; set; }
    }
}
