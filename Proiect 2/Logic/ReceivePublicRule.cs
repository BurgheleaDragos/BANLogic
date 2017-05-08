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

        public BaseLogic Result => GetResult();

        public ReceivePublicRule() { }

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


                if (formula1 != null &&
                    formula1.Formula.GetType() == typeof(EncryptedSecret))
                {
                    if (formula2 != null &&
                        formula2.Formula.GetType() == typeof(PublicEncryption))
                    {
                        var encryptedFormula = formula2.Formula as PublicEncryption;
                        if (encryptedFormula.Key.Equals(encryptedFormula.Key) &&
                            Equals(formula1.Agent1, formula2.Agent1) &&
                            encryptedFormula.Agent1.Equals(formula1.Agent1))
                        {
                            return new Believe
                            {
                                Agent1 = formula1.Agent1,
                                Formula = new Said
                                {
                                    Agent1 = encryptedFormula.Agent1,
                                    Formula = encryptedFormula.Key
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

