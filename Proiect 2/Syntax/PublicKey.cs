using System;
using Proiect_2.Elements;

namespace Proiect_2.Syntax
{
    public class PublicKey : BaseLogic
    {
        public Agent Agent1 { get; set; }
        public Agent Agent2 { get; set; }
        public string Key { get; set; }
        public override string ToString()
        {
            return $"{Agent1} has the public key {Key}";
        }
        public override bool Equals(object obj)
        {
            var publicEncryption = obj as PublicKey;
            if (publicEncryption != null && !publicEncryption.Key.Equals(this.Key, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }
            return true;
        }
    }
}