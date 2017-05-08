using Proiect_2.Elements;

namespace Proiect_2.Syntax
{
    public class SharedKey : BaseLogic
    {
        public Agent Agent1 { get; set; }
        public Agent Agent2 { get; set; }
        public string Key { get; set; }
        public override string ToString()
        {
            return $"{Agent1} <--{Key}--> {Agent2}";
        }
    }
}