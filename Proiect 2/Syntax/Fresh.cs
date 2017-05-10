namespace Proiect_2.Syntax
{
    public class Fresh : BaseLogic
    {
        public BaseLogic Formula { get; set; }

        public override string ToString()
        {
            return Formula != null ? $"Fresh({Formula})" : $"Fresh({Message})";
        }

        public override bool Equals(object obj)
        {
            var said = obj as Fresh;
            if (said == null) return false;
            return Message != null && said.Message == Message ||
                   (said.Formula != null && said.Formula.Equals(Formula));
        }
    }
}