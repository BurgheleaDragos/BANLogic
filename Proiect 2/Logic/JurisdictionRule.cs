using System;
using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public class JurisdictionRule : IRule
    {
        public BaseLogic Formula1 { get; set; }
        public BaseLogic Formula2 { get; set; }

        public BaseLogic Result => GetResult();

        public JurisdictionRule()
        {
        }

        public JurisdictionRule(BaseLogic formula1, BaseLogic formula2)
        {
            Formula1 = formula1;
            Formula2 = formula2;
        }

        private BaseLogic GetResult()
        {
            try
            {
                Believe formula1 = Formula1 as Believe;
                Believe formula2 = Formula2 as Believe;

                if (formula1 != null &&
                    formula1.Formula.GetType() == typeof(Controls))
                {
                    var controlFormula = formula1.Formula as Controls;

                    if (formula2 != null &&
                        formula2.Formula.GetType() == typeof(Believe))
                    {
                        var believeFormula = formula2.Formula as Believe;
                        if (believeFormula != null && (controlFormula != null && 
                                     (formula1.Agent1.Equals(formula2.Agent1) &&
                          controlFormula.Agent1.Equals(believeFormula.Agent1) &&
                          controlFormula.Message.Equals(believeFormula.Message, StringComparison.InvariantCultureIgnoreCase))))
                        {
                            return new Believe
                            {
                                Agent1 = formula1.Agent1,
                                Message = controlFormula.Message
                            };
                        }
                    }
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