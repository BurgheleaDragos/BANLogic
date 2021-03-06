using System;
using System.Collections.Generic;
using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public class ConcatenateRule
    {
        public BaseLogic Formula1 { get; set; }
        public List<BaseLogic> Result => RuleLogic(Formula1);
        public ConcatenateRule() { }
        public static List<BaseLogic> GetResult(BaseLogic formula1)
        {
            return RuleLogic(formula1);
        }

        public ConcatenateRule(BaseLogic formula1)
        {
            Formula1 = formula1;
        }

        private static List<BaseLogic> RuleLogic(BaseLogic _formula1)
        {
            try
            {
                var formula1 = _formula1 as Believe;

                if (formula1 != null &&
                    formula1.Formula.GetType() == typeof(Said))
                {
                    var formula2 = formula1.Formula as Said;
                    if ((formula2?.Formula != null && 
                        formula2.Formula.GetType() == typeof(Concatenate)))
                    {
                        var concatenate = formula2.Formula as Concatenate;
                        if (concatenate == null)
                        {
                            return null;
                        }
                        var ruleLogic = new List<BaseLogic>();
                        foreach (var formula in concatenate.Formulas)
                        {
                            ruleLogic.Add(new Believe()
                            {
                                Agent1 = formula1.Agent1,
                                Formula = new Said()
                                {
                                    Agent1 = formula2.Agent1,
                                    Formula = formula
                                }
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