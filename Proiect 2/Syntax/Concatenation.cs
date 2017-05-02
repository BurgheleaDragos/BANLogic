namespace Proiect_2.Syntax
{
    public class Concatenation : BaseLogic
    {
        public string X { get; set; }
        public string Y { get; set; }
        public string Concatenated => string.Concat(X, Y);
    }
}