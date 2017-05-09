using Proiect_2.Elements;

namespace Proiect_2.Syntax
{
    public class From : BaseLogic
    {
        public Agent Agent { get; set; }
        public BaseLogic Formula { get; set; }

        public override string ToString()
        {
            return $"{Formula} from {Agent}";
        }
    }
}