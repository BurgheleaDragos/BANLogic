using System;
using System.Collections.Generic;
using System.Linq;
using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public class FreshRule
    {
        public BaseLogic Formula1 { get; set; }
        public BaseLogic Formula2 { get; set; }

        public FreshRule()
        {
        }

        public FreshRule(BaseLogic formula1, BaseLogic formula2)
        {
            Formula1 = formula1;
            Formula2 = formula2;
        }

        public BaseLogic Result => GetResult();

        private BaseLogic GetResult()
        {
            try
            {
                var formula1 = Formula1 as Believe;
                var formula2 = Formula2 as Believe;

                if (formula1?.Formula != null &&
                    formula1.Formula.GetType() == typeof(Said))
                {
                    var saidFormula = formula1.Formula as Said;

                    if (saidFormula?.Formula != null &&
                        saidFormula.Formula.GetType() == typeof(Concatenate))
                    {
                        var concatenateFormula = saidFormula.Formula as Concatenate;
                        if (formula2?.Formula != null &&
                            formula2.Formula.GetType() == typeof(Fresh))
                        {
                            var freshFormula = formula2.Formula as Fresh;

                            if (concatenateFormula?.Formulas != null &&
                                freshFormula?.Message != null &&
                                concatenateFormula.Formulas.Any(s => s.Message != null &&
                                                                     s.Message.Equals(freshFormula.Message,
                                                                         StringComparison.InvariantCultureIgnoreCase))
                            )
                            {
                                var concatenateResult = new Concatenate();
                                foreach (var baseLogic in concatenateFormula.Formulas)
                                {
                                    if (baseLogic.Message != null)
                                    {
                                        concatenateResult.Formulas.Add(new Fresh()
                                        {
                                            Message = baseLogic.Message,
                                        });
                                    }
                                    else
                                    {
                                        concatenateResult.Formulas.Add(new Fresh()
                                        {
                                            Formula = baseLogic
                                        });
                                    }
                                }
                                return new Believe
                                {
                                    Agent1 = formula1.Agent1,
                                    Formula = concatenateResult
                                };
                            }
                        }
                    }
                }

                return null;
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