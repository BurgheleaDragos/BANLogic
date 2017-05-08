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
            foreach (var formula in Formulas)
            {
                str.Append($"{formula} and");
            }
            return str.ToString();
        }
    }
}