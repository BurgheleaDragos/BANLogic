using System.Collections.Generic;
using System.Linq;
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
        public BanLogic()
        {
            InitialAssumptions = new List<BaseLogic>();
            ProtocolSteps = new List<BaseLogic>();
            CurrentKnowledge = new List<BaseLogic>();
        }
        public BanLogic(List<BaseLogic> initialAssumptions, List<BaseLogic> protocolSteps, List<BaseLogic> currentKnowledge)
        {
            InitialAssumptions = initialAssumptions;
            ProtocolSteps = protocolSteps;
            CurrentKnowledge = currentKnowledge;
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
                    //                    break;
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
            #region ReceiveRule
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
