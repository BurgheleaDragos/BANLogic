using System.Collections.Generic;
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
                    break;
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
                            break;
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
            #region ReceiveRule

            BaseLogic receiveRuleResult = (BaseLogic)RuleInstance<ReceiveRule>.GetResult(protocolStep, initialAssumption);
            if (receiveRuleResult != null)
            {
                CurrentKnowledge.Add(receiveRuleResult);
                return true;
            }
            BaseLogic receiveRule2Result = (BaseLogic)RuleInstance<ReceiveRule>.GetResult(initialAssumption, protocolStep);
            if (receiveRule2Result != null)
            {
                CurrentKnowledge.Add(receiveRule2Result);
                return true;
            }
            #endregion
            #region FreshRule

            BaseLogic freshRule = (BaseLogic)RuleInstance<FreshRule>.GetResult(protocolStep, initialAssumption);
            if (freshRule != null)
            {
                CurrentKnowledge.Add(freshRule);
                return true;
            }
            #endregion

            #region ConcatenateRule
            var concatRule = (List<BaseLogic>)RuleInstance<ConcatenateRule>.GetResult(protocolStep);
            if (concatRule != null)
            {
                CurrentKnowledge.AddRange(concatRule);
                return true;
            }
            #endregion

            return false;
        }

    }
}
