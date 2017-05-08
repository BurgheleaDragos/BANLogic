using System;
using Proiect_2.Elements;

namespace Proiect_2.Syntax
{
    public class PublicEncryption : BaseLogic
    {
        public Agent Agent1 { get; set; }
        public PublicKey Key { get; set; }
        public override string ToString()
        {
            return $"{Agent1} has public key {Key}";
        }

    }
}