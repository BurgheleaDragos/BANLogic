using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public interface IRule
    {
        BaseLogic Formula1 { get; set; }
        BaseLogic Formula2 { get; set; }
        BaseLogic Result { get; }

    }
}