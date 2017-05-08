namespace Proiect_2.Syntax
{
    public class Fresh : BaseLogic
    {
        public BaseLogic Formula { get; set; }

        public override string ToString()
        {
            return Formula != null ? $"{Formula} is fresh" : $"{Message} is fresh";
        }
    }
}