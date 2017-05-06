using System;
using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public class SelectionRuleBBSelect : IRule
    {
        public BaseLogic Formula1 { get; set; }
        public BaseLogic Formula2 { get; set; }

        public SelectionRuleBBSelect()
        {
        }

        public SelectionRuleBBSelect(BaseLogic formula1)
        {
            Formula1 = formula1;
        }

        public BaseLogic Result => GetResult();

        private BaseLogic GetResult()
        {
            try
            {
                Believe formula1 = Formula1 as Believe;

                if (formula1 != null && //First formula must be of type Receives
                    formula1.Formula.GetType() == typeof(Believe))//The second parameter must be an encrypted value with key K
                {
                    var believeFormula = formula1.Formula as Believe;

                    if (believeFormula.Message.Equals("X1...Xi...Xn")) //The encrypted message key and the shared key between Agent1 and Agent2 are identical

                    {
                        return new Believe()
                        {
                            Agent1 = formula1.Agent1,
                            Formula = new Believe()
                            {
                                Agent1 = believeFormula.Agent1,
                                Message = "Xi"
                            }
                        };
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