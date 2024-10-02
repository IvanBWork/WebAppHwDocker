using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebAppHwDocker.RSATools
{
    public class RSAExtensions
    {
        public static RSA GetPrivateKey()
        {
            var key = File.ReadAllText(@"../WebAppHwDocker/Keys/private_key.pem");
            var rsa = RSA.Create();

            rsa.ImportFromPem(key);

            return rsa;
        }

        public static RSA GetPublicKey()
        {
            var key = File.ReadAllText(@"../WebAppHwDocker/Keys/public_key.pem");
            var rsa = RSA.Create();

            rsa.ImportFromPem(key);

            return rsa;
        }
    }
}
