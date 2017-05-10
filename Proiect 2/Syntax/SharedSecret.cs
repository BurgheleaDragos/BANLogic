using System;
using Proiect_2.Elements;

namespace Proiect_2.Syntax
{
    public class SharedSecret : BaseLogic
    {
        public Agent Agent1 { get; set; }
        public Agent Agent2 { get; set; }
        public string Key { get; set; }
        public override string ToString()
        {
            return $"{Agent1} and {Agent2} have shared secret {Key}";
        }

        public override bool Equals(object obj)
        {
            var sharedSecret = obj as SharedSecret;
            if (sharedSecret == null)
            {
                return false;
            }
            return sharedSecret.Agent1 != null && sharedSecret.Agent1.Equals(Agent1) &&
                    sharedSecret.Agent2 != null && sharedSecret.Agent2.Equals(Agent2) &&
                    sharedSecret.Key != null && sharedSecret.Key.Equals(Key, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}