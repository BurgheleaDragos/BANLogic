namespace Proiect_2.Syntax
{
    public class Fresh : BaseLogic
    {
        public BaseLogic Formula { get; set; }

        public override string ToString()
        {
            return Formula != null ? $"Fresh({Formula})" : $"Fresh({Message})";
        }
    }
}