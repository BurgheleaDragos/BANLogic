using System;
using Proiect_2.Elements;

namespace Proiect_2.Syntax
{
    public class Receives : BaseLogic
    {
        public Agent Agent1 { get; set; }
        public BaseLogic Formula { get; set; }

        public override string ToString()
        {
            return $"{Agent1} receives {Formula}";
        }

        public override bool Equals(object obj)
        {
            var receive = obj as Receives;
            if (receive == null)
            {
                return false;
            }
            return Agent1.Equals(receive.Agent1) &&
                (Formula != null && Formula.Equals(receive.Formula) ||
                Message != null && Message.Equals(receive.Message, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}