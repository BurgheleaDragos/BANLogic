using System.Collections.Generic;
using System.Text;

namespace Proiect_2.Syntax
{
    public class Concatenate : BaseLogic
    {
        public List<BaseLogic> Formulas { get; set; }

        public Concatenate()
        {
            Formulas = new List<BaseLogic>();
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            for (var index = 0; index < Formulas.Count - 1; index++)
            {
                var formula = Formulas[index];
                str.Append($"{formula}, ");
            }
            str.Append($"{Formulas[Formulas.Count - 1]}");
            return str.ToString();
        }
    }
}