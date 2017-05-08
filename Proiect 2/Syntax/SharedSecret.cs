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
    }
}