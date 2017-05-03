﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public class ReceiveRule
    {
        public BaseLogic Formula1 { get; set; }
        public BaseLogic Formula2 { get; set; }

        public BaseLogic Result
        {
            get { return this.GetResult(); }
        }

        public ReceiveRule()
        {
        }

        public ReceiveRule(BaseLogic formula1, BaseLogic formula2)
        {
            Formula1 = formula1;
            Formula2 = formula2;
        }

        private BaseLogic GetResult()
        {
            try
            {
                Receives formula1 = Formula1 as Receives;
                Believe formula2 = Formula2 as Believe;

                if (formula1 != null && //First formula must be of type Receives
                    formula1.Formula.GetType() == typeof(Encryption))//The second parameter must be an encrypted value with key K
                {
                    var encryptionFormula = formula1.Formula as Encryption;

                    if (formula2 != null && //Second formula must be of type Believes
                        formula2.Formula.GetType() == typeof(SharedKey))//The second parameter must be a shared key K
                    {
                        var sharedKey = formula2.Formula as SharedKey;
                        if (encryptionFormula.Key.Equals(sharedKey.Key, StringComparison.InvariantCultureIgnoreCase) &&//The encrypted message key and the shared key between Agent1 and Agent2 are identical
                            Equals(formula1.Agent1, formula2.Agent1) &&//The first Agents are the same
                            sharedKey.Agent1.Equals(formula1.Agent1))// the shared key agent is the same with the agent from the first formula.
                        {
                            return new Believe
                            {
                                Agent1 = formula1.Agent1,
                                Formula = new Said
                                {
                                    Agent1 = sharedKey.Agent2,
                                    Message = encryptionFormula.Value
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
