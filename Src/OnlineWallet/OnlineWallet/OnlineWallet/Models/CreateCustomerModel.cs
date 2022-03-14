
namespace OnlineWallet.Models
{
    public class CreateCustomerModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool PassAllAuthorization { get; set; }
    }
}
