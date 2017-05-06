using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public class ReceivePublicRule
    {
        public BaseLogic Formula1 { get; set; }
        public BaseLogic Formula2 { get; set; }

        public BaseLogic Result
        {
            get { return this.GetResult(); }
        }

        public ReceivePublicRule()
        {
        }

        public ReceivePublicRule(BaseLogic formula1, BaseLogic formula2)
        {
            Formula1 = formula1;
            Formula2 = formula2;
        }

        private BaseLogic GetResult()
        {
            try
            {
                Sees formula1 = Formula1 as Sees;
                Believe formula2 = Formula2 as Believe;


                if (formula1 != null && //First formula must be of type Sees
                    formula1.Formula.GetType() == typeof(EncryptedSecret))//The second parameter must be an encrypted secret
                {
                    var encryptedSecret = formula1.Formula as EncryptedSecret;

                    if (formula2 != null && //Second formula must be of type Believes
                        formula2.Formula.GetType() == typeof(PublicEncryption))//The second parameter must be an encrypted secret
                    {
                        var encryptedFormula = formula2.Formula as PublicEncryption;
                        if (encryptedFormula.Key.Equals(encryptedFormula.Key, StringComparison.InvariantCultureIgnoreCase) &&//The encrypted message key and the shared key between Agent1 and Agent2 are identical
                            Equals(formula1.Agent1, formula2.Agent1) &&//The first Agents are the same
                            encryptedFormula.Agent1.Equals(formula1.Agent1))// the shared key agent is the same with the agent from the first formula.
                        {
                            return new Believe
                            {
                                Agent1 = formula1.Agent1,
                                Formula = new Said
                                {
                                    Agent1 = encryptedFormula.Agent1,
                                    Message = encryptedFormula.Key
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

