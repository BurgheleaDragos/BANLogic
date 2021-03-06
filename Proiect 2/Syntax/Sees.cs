using Proiect_2.Elements;

namespace Proiect_2.Syntax
{
    public class Sees : BaseLogic
    {
        public Agent Agent1 { get; set; }
        public BaseLogic Formula { get; set; }
        public override string ToString()
        {
            return $"{Agent1} sees {Formula}";
        }
    }
}