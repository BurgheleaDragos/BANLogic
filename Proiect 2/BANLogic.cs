using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Proiect_2.Logic;
using Proiect_2.Syntax;

namespace Proiect_2
{
    public class BanLogic
    {
        public List<BaseLogic> ProtocolSteps;
        public BanLogic()
        {
            ProtocolSteps = new List<BaseLogic>();
        }
        public BanLogic(List<BaseLogic> protocolSteps)
        {
            ProtocolSteps = protocolSteps;
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
            foreach (var baseLogic in ProtocolSteps)
            {

                #region ReceiveRule
                ReceiveRule receiveRule = new ReceiveRule(protocolStep, baseLogic);
                BaseLogic receiveRuleResult = receiveRule.Result;
                if (receiveRuleResult != null)
                {
                    ProtocolSteps.Add(receiveRuleResult);
                }
                ReceiveRule receiveRule2 = new ReceiveRule(baseLogic, protocolStep);
                BaseLogic receiveRule2Result = receiveRule2.Result;
                if (receiveRule2Result != null)
                {
                    ProtocolSteps.Add(receiveRule2Result);
                }
                #endregion

            }
        }
    }
}
