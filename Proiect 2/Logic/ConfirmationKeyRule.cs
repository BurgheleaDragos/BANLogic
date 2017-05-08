using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public class ConfirmationKeyRule
    {
        public BaseLogic Formula { get; set; }

        public bool Result => GetResult();

        public ConfirmationKeyRule()
        {
        }
        public ConfirmationKeyRule(BaseLogic formula)
        {
            Formula = formula;
        }
        private bool GetResult()
        {
            try
            {
                Believe formula = Formula as Believe;

                if (formula != null && //First formula must be of type Believe
                    formula.Formula.GetType() == typeof(Believe) && ((Believe)formula.Formula).Formula.GetType() == typeof(SharedKey) // there are two believe formulas and one SharedKey formulas 
                    )
                {
                    var encryptedFormula1 = formula.Formula as Believe;
                    var encryptedFormula2 = encryptedFormula1.Formula as SharedKey;
                    if (Equals(formula.Agent1, encryptedFormula2.Agent1) &&
                        Equals(encryptedFormula1.Agent1, encryptedFormula2.Agent2)) //The  Agents are the same 
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

