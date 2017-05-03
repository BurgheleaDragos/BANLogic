using System;
using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public class FreshInjectRule
    {
        public BaseLogic Formula1 { get; set; }
        public BaseLogic MainMessage { get; set; }
        public FreshInjectRule()
        {
        }

        public FreshInjectRule(BaseLogic formula1, BaseLogic mainMessage)
        {
            Formula1 = formula1;
            MainMessage = mainMessage;
        }

        public BaseLogic Result
        {
            get { return this.GetResult(); }
        }

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
                            Formula = MainMessage
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