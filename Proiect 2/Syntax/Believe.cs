using Proiect_2.Elements;

namespace Proiect_2.Syntax
{
    public class Believe : BaseLogic
    {
        public Agent Agent1 { get; set; }
        public BaseLogic Formula { get; set; }
        public string Message { get; set; }
    }
}