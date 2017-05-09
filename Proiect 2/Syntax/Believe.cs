using Proiect_2.Elements;

namespace Proiect_2.Syntax
{
    public class Believe : BaseLogic
    {
        public Agent Agent1 { get; set; }
        public BaseLogic Formula { get; set; }

        public override string ToString()
        {
            return $"{Agent1} believes {Formula}";
        }
        public override bool Equals(object obj)
        {
            var said = obj as Believe;
            if (said == null) return false;
            return said.Agent1.Equals(Agent1) &&
                   said.Message == Message && 
                   said.Formula != null && Formula != null && said.Formula.Equals(Formula);
        }

    }
}