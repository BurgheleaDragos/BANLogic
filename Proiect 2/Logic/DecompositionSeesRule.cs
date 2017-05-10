using System;
using System.Collections.Generic;
using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public class DecompositionSeesRule
    {
        public BaseLogic Formula1 { get; set; }
        public List<BaseLogic> Result => RuleLogic(Formula1);
        public DecompositionSeesRule() { }
        public static List<BaseLogic> GetResult(BaseLogic formula1)
        {
            return RuleLogic(formula1);
        }

        public DecompositionSeesRule(BaseLogic formula1)
        {
            Formula1 = formula1;
        }

        private static List<BaseLogic> RuleLogic(BaseLogic _formula1)
        {
            try
            {
                var formula1 = _formula1 as Sees;

                if (formula1 != null &&
                    formula1.Formula.GetType() == typeof(Concatenate))
                {
                    var formula2 = formula1.Formula as Concatenate;
                    if (formula2 != null &&
                        formula2.GetType() == typeof(Concatenate))
                    {

                        var ruleLogic = new List<BaseLogic>();
                        foreach (var formula in formula2.Formulas)
                        {
                            ruleLogic.Add(new Sees()
                            {
                                Agent1 = formula1.Agent1,
                                Formula = formula

                            });
                        }
                        return ruleLogic;
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