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
            foreach (var currentKnowledge in CurrentKnowledge)
            {
                TestRule(protocolStep, currentKnowledge);
            }
            var c = new Fresh();

        }

        private void TestRule(BaseLogic protocolStep, BaseLogic initialAssumption)
        {
            #region ReceiveRule

            //            IRule receiveRule = new ReceiveRule(protocolStep, initialAssumption);
            //            BaseLogic receiveRuleResult = receiveRule.Result;
            BaseLogic receiveRuleResult = ReceiveRule.GetResult(protocolStep, initialAssumption);
            if (receiveRuleResult != null)
            {
                CurrentKnowledge.Add(receiveRuleResult);
            }
            //            IRule receiveRule2 = new ReceiveRule(initialAssumption, protocolStep);
            //            BaseLogic receiveRule2Result = receiveRule2.Result;
            BaseLogic receiveRule2Result = ReceiveRule.GetResult(initialAssumption, protocolStep);
            if (receiveRule2Result != null)
            {
                CurrentKnowledge.Add(receiveRule2Result);
            }
            #endregion
            #region FreshRule

            #endregion

            #region ConcatenateRule
            var concatRule = ConcatenateRule.GetResult(initialAssumption);
            if (concatRule != null)
            {
                CurrentKnowledge.AddRange(concatRule);
            }
            #endregion

        }

    }
}
