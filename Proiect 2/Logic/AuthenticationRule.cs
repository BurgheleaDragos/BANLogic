using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public class AuthenticationRule
    {
        public BaseLogic Formula { get; set; }

        public bool Result => GetResult();
        public AuthenticationRule()
        {
        }
        public AuthenticationRule(BaseLogic formula)
        {
            Formula = formula;
        }
        private bool GetResult()
        {
            try
            {
                Believe formula = Formula as Believe;

                if (formula != null && //First formula must be of type Believe
                    formula.Formula.GetType() == typeof(SharedKey)
                ) //The second parameter must be an encrypted value with key K
                {
                    var encryptedFormula = formula.Formula as SharedSecret;
                    if (Equals(formula.Agent1, encryptedFormula.Agent1) ||
                         Equals(formula.Agent1, encryptedFormula.Agent1)) //The  Agents are the same 
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return false;
        }
    }
}

