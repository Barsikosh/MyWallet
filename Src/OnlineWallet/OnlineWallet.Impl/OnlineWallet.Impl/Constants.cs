using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineWallet.Impl
{
    public static class Constants
    {
        public const string UserIdHeader = "X-UserId";

        public const string Realm = "wallet-realm";

        public const string ClaimType = "DIGEST_AUTHENTICATION_NAME";
    }
}
