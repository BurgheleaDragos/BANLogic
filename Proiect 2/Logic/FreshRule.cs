using System;
using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public class FreshRule
    {
        public BaseLogic Formula1 { get; set; }
        public BaseLogic Formula2 { get; set; }

        public FreshRule() { }
        public FreshRule(BaseLogic formula1, BaseLogic formula2)
        {
            Formula1 = formula1;
            Formula2 = formula2;
        }

        public BaseLogic Result => GetResult();

        private BaseLogic GetResult()
        {
            try
            {
                var formula1 = Formula1 as Believe;
                var formula2 = Formula1 as Concatenate;

                if (formula1 != null &&
                    formula1.Formula.GetType() == typeof(Fresh))
                {
                    var con = new Concatenate();
                    foreach (BaseLogic formula in formula2.Formulas)
                    {
                        if (!string.Equals(formula.Message, formula1.Message,
                            StringComparison.InvariantCultureIgnoreCase))
                        {
                            con.Formulas.Add(new Fresh()
                            {
                                Formula = formula
                            });
                        }
                    }
                    return new Fresh
                    {
                        Formula = con
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return null;
        }
    }
}