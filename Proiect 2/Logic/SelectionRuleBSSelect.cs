using System;
using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public class SelectionRuleBSSelect
    {
        public BaseLogic Formula1 { get; set; }

        public SelectionRuleBSSelect()
        {
        }

        public SelectionRuleBSSelect(BaseLogic formula1)
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
                Believe formula1 = Formula1 as Believe;

                if (formula1 != null && //First formula must be of type Receives
                    formula1.Formula.GetType() == typeof(Said))//The second parameter must be an encrypted value with key K
                {
                    var believeFormula = formula1.Formula as Said;

                    if (believeFormula.Message.Equals("X1...Xi...Xn")) //The encrypted message key and the shared key between Agent1 and Agent2 are identical

                    {
                        return new Believe()
                        {
                            Agent1 = formula1.Agent1,
                            Formula = new Said()
                            {
                                Agent1 = believeFormula.Agent1,
                                Message = "Xi"
                            }
                        };
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