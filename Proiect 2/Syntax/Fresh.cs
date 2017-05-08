namespace Proiect_2.Syntax
{
    public class Fresh : BaseLogic
    {
        public BaseLogic Formula { get; set; }

        public override string ToString()
        {
            if (Formula != null)
            {
                return $"{Formula} is fresh";
            }
            else
            {
                return $"{Message} is fresh";
            }
        }
    }
}