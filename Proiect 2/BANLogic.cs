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
        }
        public BanLogic(List<BaseLogic> initialAssumptions)
        {
            InitialAssumptions = initialAssumptions;
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
                #region ReceiveRule
                IRule receiveRule = new ReceiveRule(protocolStep, initialAssumption);
                BaseLogic receiveRuleResult = receiveRule.Result;
                if (receiveRuleResult != null)
                {
                    InitialAssumptions.Add(receiveRuleResult);
                }
                IRule receiveRule2 = new ReceiveRule(initialAssumption, protocolStep);
                BaseLogic receiveRule2Result = receiveRule2.Result;
                if (receiveRule2Result != null)
                {
                    InitialAssumptions.Add(receiveRule2Result);
                }
                #endregion
            }

            foreach (var currentKnowledge in CurrentKnowledge)
            {
                
            }
        }


    }
}
