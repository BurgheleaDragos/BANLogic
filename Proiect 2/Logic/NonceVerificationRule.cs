using System;
using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public class NonceVerificationRule : IRule
    {
        public BaseLogic Formula1 { get; set; }
        public BaseLogic Formula2 { get; set; }

        public BaseLogic Result => GetResult();

        public NonceVerificationRule()
        {
        }

        public NonceVerificationRule(BaseLogic formula1, BaseLogic formula2)
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

                if (formula1 != null && //First formula must be of type Believe
                    formula1.Formula.GetType() == typeof(Fresh))//The second parameter must be an encrypted value with key K
                {
                    var freshFormula = formula1.Formula as Fresh;

                    if (formula2 != null && //Second formula must be of type Believes
                        formula2.Formula.GetType() == typeof(Said))//The second parameter must be a shared key K
                    {
                        var said = formula2.Formula as Said;
                        if (freshFormula.Message.Equals(said.Message, StringComparison.InvariantCultureIgnoreCase) &&//The encrypted message key and the shared key between Agent1 and Agent2 are identical
                            Equals(formula1.Agent1, formula2.Agent1)) //The first Agents are the same
                        {
                            return new Believe
                            {
                                Agent1 = formula1.Agent1,
                                Formula = new Believe
                                {
                                    Agent1 = said.Agent1,
                                    Message = said.Message
                                }
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