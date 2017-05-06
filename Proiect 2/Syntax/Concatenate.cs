using System.Collections.Generic;

namespace Proiect_2.Syntax
{
    public class Concatenate : BaseLogic
    {
        public List<BaseLogic> Formulas { get; set; }

        public Concatenate()
        {
            Formulas = new List<BaseLogic>();
        }
    }
}