using System;
using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public class SelectionRuleRSelect
    {
        public BaseLogic Formula1 { get; set; }

        public SelectionRuleRSelect()
        {
        }

        public SelectionRuleRSelect(BaseLogic formula1)
        {
            Formula1 = formula1;
        }

        public BaseLogic Result
        {
            get { return this.GetResult(); }
        }

        private BaseLogic GetResult()
        {
            try
            {
                Receives formula1 = Formula1 as Receives;

                if (formula1 != null && //First formula must be of type Receives
                    formula1.Message.Contains("Xi"))//The second parameter must be an encrypted value with key K
                {
                    //                    var saidFormula = formula1.Formula as Fresh;

                    //                    if (saidFormula.Message.Equals(freshFormula.Message, StringComparison.InvariantCultureIgnoreCase) &&//The encrypted message key and the shared key between Agent1 and Agent2 are identical
                    //                        Equals(formula1.Agent1, formula2.Agent1)) //The first Agents are the same
                    //                    {
                    return new Receives()
                    {
                        Agent1 = formula1.Agent1,
                        Message = "Xi"
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