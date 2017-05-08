namespace Proiect_2.Syntax
{
    public class Encryption : BaseLogic
    {
        public BaseLogic Formula { get; set; }
        public string Value { get; set; }
        public string Key { get; set; }
        public SharedKey FormulaKey { get; set; }

        public override string ToString()
        {
            return $"{{{Formula}}} {Key}";
        }
    }
}