using System.Collections.Generic;
using System.Linq;
using Proiect_2.Elements;
using Proiect_2.Logic;
using Proiect_2.Syntax;

namespace Proiect_2
{
    public class BanLogic
    {
        public List<BaseLogic> InitialAssumptions;
        public List<BaseLogic> ProtocolSteps;
        public List<BaseLogic> CurrentKnowledge;
        public Queue<BaseLogic> CurrentKnowledgeQueue;
        public bool AIsAuthenticated { get; set; }
        public bool BIsAuthenticated { get; set; }
        public bool AAuthenticationValidation { get; set; }
        public bool BAuthenticationValidation { get; set; }
        public BanLogic()
        {
            InitialAssumptions = new List<BaseLogic>();
            ProtocolSteps = new List<BaseLogic>();
            CurrentKnowledge = new List<BaseLogic>();
            AIsAuthenticated = BIsAuthenticated =
            AAuthenticationValidation = BAuthenticationValidation = false;
        }
        public BanLogic(List<BaseLogic> initialAssumptions, List<BaseLogic> protocolSteps, List<BaseLogic> currentKnowledge)
        {
            InitialAssumptions = initialAssumptions;
            ProtocolSteps = protocolSteps;
            CurrentKnowledge = currentKnowledge;
            AIsAuthenticated = BIsAuthenticated =
                AAuthenticationValidation = BAuthenticationValidation = false;
        }

        public void ProtocolStepsKnowledge()
        {
            foreach (var protocolStep in ProtocolSteps)
            {
                CurrentKnowledge.Add(protocolStep);
                CheckKnowledge(protocolStep);
            }
        }

        private void CheckKnowledge(BaseLogic protocolStep)
        {
            foreach (var initialAssumption in InitialAssumptions)
            {
                if (TestRule(protocolStep, initialAssumption))
                {
                    if (AIsAuthenticated && BIsAuthenticated && AAuthenticationValidation && BAuthenticationValidation)
                    {
                        return;
                    }
                }
            }
            int i = 1;
            do
            {
                if (CurrentKnowledge.Count > i)
                {
                    var logic = CurrentKnowledge[i];
                    foreach (var initialAssumption in InitialAssumptions)
                    {
                        if (TestRule(logic, initialAssumption))
                        {
                            if (AIsAuthenticated && BIsAuthenticated && AAuthenticationValidation && BAuthenticationValidation)
                            {
                                return;
                            }
                            //                            break;
                        }
                    }
                    i++;
                }
                else
                {
                    break;
                }

            } while (true);

        }

        private bool TestRule(BaseLogic protocolStep, BaseLogic initialAssumption)
        {
            bool added = false;
            #region ValidationRules
            AIsAuthenticated = protocolStep.GetType() == typeof(Believe) &&
                    ((Believe)protocolStep).Agent1.Equals(new Agent { Name = "A" }) &&
                    (bool)RuleInstance<AuthenticationRule>.GetResult(protocolStep);
            BIsAuthenticated = protocolStep.GetType() == typeof(Believe) &&
                    ((Believe)protocolStep).Agent1.Equals(new Agent { Name = "B" }) &&
                    (bool)RuleInstance<AuthenticationRule>.GetResult(protocolStep);
            AAuthenticationValidation = protocolStep.GetType() == typeof(Believe) &&
                    ((Believe)protocolStep).Agent1.Equals(new Agent { Name = "A" }) &&
                    (bool)RuleInstance<ConfirmationKeyRule>.GetResult(protocolStep);
            BAuthenticationValidation = protocolStep.GetType() == typeof(Believe) &&
                    ((Believe)protocolStep).Agent1.Equals(new Agent { Name = "B" }) &&
                    (bool)RuleInstance<ConfirmationKeyRule>.GetResult(protocolStep);
            if (AIsAuthenticated && BIsAuthenticated && AAuthenticationValidation && BAuthenticationValidation)
            {
                return true;
            }
            #endregion

            #region FreshRule
            BaseLogic freshRule = (BaseLogic)RuleInstance<FreshRule>.GetResult(protocolStep, initialAssumption);
            if (freshRule != null)
            {
                if (!CurrentKnowledge.Contains(freshRule))
                {
                    CurrentKnowledge.Add(freshRule);
                    added = true;
                }
            }
            #endregion
            #region ReceiveRulez
            BaseLogic receiveRuleResult = (BaseLogic)RuleInstance<ReceiveRule>.GetResult(protocolStep, initialAssumption);
            if (receiveRuleResult != null)
            {
                if (!CurrentKnowledge.Contains(receiveRuleResult))
                {
                    CurrentKnowledge.Add(receiveRuleResult);
                    added = true;
                }
            }
            BaseLogic receiveRule2Result = (BaseLogic)RuleInstance<ReceiveRule>.GetResult(initialAssumption, protocolStep);
            if (receiveRule2Result != null)
            {
                if (!CurrentKnowledge.Contains(receiveRule2Result))
                {
                    CurrentKnowledge.Add(receiveRule2Result);
                    added = true;
                }
            }
            #endregion

            #region ConcatenateRule
            var concatRules = (List<BaseLogic>)RuleInstance<ConcatenateRule>.GetResult(protocolStep);
            if (concatRules != null)
            {
                foreach (var concatRule in concatRules)
                {
                    if (!CurrentKnowledge.Contains(concatRule))
                    {
                        CurrentKnowledge.Add(concatRule);
                        added = true;
                    }
                }
            }
            #endregion

            return added;
        }

    }
}
