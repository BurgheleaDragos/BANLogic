using System;
using System.Collections.Generic;
using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public class BelieveConcatenation
    {
        public BaseLogic Formula1 { get; set; }
        public BaseLogic Formula2 { get; set; }
        public BaseLogic Result => RuleLogic(Formula1, Formula2);
        public BelieveConcatenation() { }
        public static BaseLogic GetResult(BaseLogic formula1, BaseLogic formula2)
        {
            return RuleLogic(formula1, formula2);
        }

        public BelieveConcatenation(BaseLogic formula1, BaseLogic formula2)
        {
            Formula1 = formula1;
            Formula2 = formula2;
        }

        private static BaseLogic RuleLogic(BaseLogic _formula1, BaseLogic _formula2)
        {
            try
            {
                var formula1 = _formula1 as Believe;
                var formula2 = _formula2 as Believe;

                if (formula1 != null &&
                    formula2 != null &&
                    formula1.Agent1.Equals(formula2.Agent1))
                {

                    var concatenate = new Concatenate();
                    concatenate.Formulas.Add(formula1.Formula);
                    concatenate.Formulas.Add(formula2.Formula);
                    var believe = new Believe
                    {
                        Agent1 = formula1.Agent1,
                        Formula = concatenate
                    };
                    return believe;

                };
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