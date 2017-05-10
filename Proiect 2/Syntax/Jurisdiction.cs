using Proiect_2.Elements;

namespace Proiect_2.Syntax
{
    public class Jurisdiction : BaseLogic
    {
        public Agent Agent1 { get; set; }
        public BaseLogic Formula { get; set; }

        public override string ToString()
        {
            return $"{Agent1} has jurisdiction over {Formula}";
        }
        public override bool Equals(object obj)
        {
            var jurisdiction = obj as Jurisdiction;
            if (jurisdiction == null) return false;
            return jurisdiction.Agent1 != null && jurisdiction.Agent1.Equals(Agent1) &&
                   (Message != null && jurisdiction.Message == Message ||
                    jurisdiction.Formula != null && jurisdiction.Formula.Equals(Formula));
        }
    }
}