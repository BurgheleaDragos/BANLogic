using System;
using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public class FreshInjectRule : IRule
    {
        public BaseLogic Formula1 { get; set; }
        public BaseLogic Formula2 { get; set; }
        public FreshInjectRule()
        {
        }

        public FreshInjectRule(BaseLogic formula1, BaseLogic formula2)
        {
            Formula1 = formula1;
            Formula2 = formula2;
        }

        public BaseLogic Result => GetResult();

        private BaseLogic GetResult()
        {
            try
            {
                Believe formula1 = Formula1 as Believe;

                if (formula1 != null && //First formula must be of type Receives
                    formula1.Formula.GetType() == typeof(Fresh))//The second parameter must be an encrypted value with key K
                {
                    //                    var saidFormula = formula1.Formula as Fresh;

                    //                    if (saidFormula.Message.Equals(freshFormula.Message, StringComparison.InvariantCultureIgnoreCase) &&//The encrypted message key and the shared key between Agent1 and Agent2 are identical
                    //                        Equals(formula1.Agent1, formula2.Agent1)) //The first Agents are the same
                    //                    {
                    return new Believe
                    {
                        Agent1 = formula1.Agent1,
                        Formula = new Fresh()
                        {
                            Formula = Formula2
                        }
                    };
                    //                    }
                }
            }
            //            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return null;
        }
    }
}