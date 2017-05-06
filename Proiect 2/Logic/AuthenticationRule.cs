using System;
using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public class AuthenticationRule
    {
        public BaseLogic Formula { get; set; }

        public bool Result
        {
            get { return this.GetResult(); }
        }

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
                    return true;
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

