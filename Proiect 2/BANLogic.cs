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

        public void GenerateKnowledge()
        {
            foreach (var protocolStep in ProtocolSteps)
            {
                CheckKnowledge(protocolStep);
            }
        }

        private void CheckKnowledge(BaseLogic protocolStep)
        {
            foreach (var initialAssumption in InitialAssumptions)
            {
                this.TestRule(protocolStep, initialAssumption);
            }
            var localCopy = CurrentKnowledge.ToArray();
            foreach (var currentKnowledge in localCopy)
            {
                TestRule(protocolStep, currentKnowledge);
            }
            var c = new Fresh();

        }

        private void TestRule(BaseLogic protocolStep, BaseLogic initialAssumption)
        {
            #region ReceiveRule

            BaseLogic receiveRuleResult = (BaseLogic)RuleInstance<ReceiveRule>.GetResult(protocolStep, initialAssumption);
            if (receiveRuleResult != null)
            {
                CurrentKnowledge.Add(receiveRuleResult);
            }
            BaseLogic receiveRule2Result = (BaseLogic)RuleInstance<ReceiveRule>.GetResult(initialAssumption, protocolStep);
            if (receiveRule2Result != null)
            {
                CurrentKnowledge.Add(receiveRule2Result);
            }
            #endregion
            #region FreshRule

            #endregion

            #region ConcatenateRule

            var concatRule = (List<BaseLogic>)RuleInstance<ConcatenateRule>.GetResult(initialAssumption);
            if (concatRule != null)
            {
                CurrentKnowledge.AddRange(concatRule);
            }
            #endregion

        }

    }
}
