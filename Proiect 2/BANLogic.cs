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

            } while (i < 100);

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

            #region BelieveConcatenation
            BaseLogic believeConcatenationResult = (BaseLogic)RuleInstance<BelieveConcatenation>.GetResult(protocolStep, initialAssumption);
            if (believeConcatenationResult != null)
            {
                if (!CurrentKnowledge.Contains(believeConcatenationResult))
                {
                    CurrentKnowledge.Add(believeConcatenationResult);
                    added = true;
                }
            }
            BaseLogic believeConcatenation2Result = (BaseLogic)RuleInstance<BelieveConcatenation>.GetResult(initialAssumption, protocolStep);
            if (believeConcatenation2Result != null)
            {
                if (!CurrentKnowledge.Contains(believeConcatenation2Result))
                {
                    CurrentKnowledge.Add(believeConcatenation2Result);
                    added = true;
                }
            }
            #endregion

            #region BelieveDecomposition
            var believeDecompositionResult = (List<BaseLogic>)RuleInstance<BelieveDecomposition>.GetResult(protocolStep);
            if (believeDecompositionResult != null)
            {
                foreach (BaseLogic believeDecompositionLogic in believeDecompositionResult)
                {
                    if (!CurrentKnowledge.Contains(believeDecompositionLogic))
                    {
                        CurrentKnowledge.Add(believeDecompositionLogic);
                        added = true;
                    }
                }
            }
            #endregion

            #region BelieveSaidConcatenation
            var believeSaidConcatenationResult = (List<BaseLogic>)RuleInstance<BelieveSaidConcatenation>.GetResult(protocolStep, initialAssumption);
            if (believeSaidConcatenationResult != null)
            {
                foreach (BaseLogic believeSaidConcatenationLogic in believeSaidConcatenationResult)
                {
                    if (!CurrentKnowledge.Contains(believeSaidConcatenationLogic))
                    {
                        CurrentKnowledge.Add(believeSaidConcatenationLogic);
                        added = true;
                    }
                }
            }
            #endregion

            #region JurisdictionRule
            BaseLogic jurisdictionRuleResult = (BaseLogic)RuleInstance<JurisdictionRule>.GetResult(protocolStep, initialAssumption);
            if (jurisdictionRuleResult != null)
            {
                if (!CurrentKnowledge.Contains(jurisdictionRuleResult))
                {
                    CurrentKnowledge.Add(jurisdictionRuleResult);
                    added = true;
                }
            }
            BaseLogic jurisdictionRule2Result = (BaseLogic)RuleInstance<JurisdictionRule>.GetResult(initialAssumption, protocolStep);
            if (jurisdictionRule2Result != null)
            {
                if (!CurrentKnowledge.Contains(jurisdictionRule2Result))
                {
                    CurrentKnowledge.Add(jurisdictionRule2Result);
                    added = true;
                }
            }
            #endregion

            #region NonceVerificationRule
            BaseLogic nonceVerificationRuleResult = (BaseLogic)RuleInstance<NonceVerificationRule>.GetResult(protocolStep, initialAssumption);
            if (nonceVerificationRuleResult != null)
            {
                if (!CurrentKnowledge.Contains(nonceVerificationRuleResult))
                {
                    CurrentKnowledge.Add(nonceVerificationRuleResult);
                    added = true;
                }
            }
            BaseLogic nonceVerificationRule2Result = (BaseLogic)RuleInstance<NonceVerificationRule>.GetResult(initialAssumption, protocolStep);
            if (nonceVerificationRule2Result != null)
            {
                if (!CurrentKnowledge.Contains(nonceVerificationRule2Result))
                {
                    CurrentKnowledge.Add(nonceVerificationRule2Result);
                    added = true;
                }
            }
            #endregion

            #region ReceivePublicRule
            BaseLogic receivePublicRuleResult = (BaseLogic)RuleInstance<ReceivePublicRule>.GetResult(protocolStep, initialAssumption);
            if (receivePublicRuleResult != null)
            {
                if (!CurrentKnowledge.Contains(receivePublicRuleResult))
                {
                    CurrentKnowledge.Add(receivePublicRuleResult);
                    added = true;
                }
            }
            BaseLogic receivePublicRule2Result = (BaseLogic)RuleInstance<ReceivePublicRule>.GetResult(initialAssumption, protocolStep);
            if (receivePublicRule2Result != null)
            {
                if (!CurrentKnowledge.Contains(receivePublicRule2Result))
                {
                    CurrentKnowledge.Add(receivePublicRule2Result);
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

            #region ReceiveSecretRule
            BaseLogic receiveSecretRuleResult = (BaseLogic)RuleInstance<ReceiveSecretRule>.GetResult(protocolStep, initialAssumption);
            if (receiveSecretRuleResult != null)
            {
                if (!CurrentKnowledge.Contains(receiveSecretRuleResult))
                {
                    CurrentKnowledge.Add(receiveSecretRuleResult);
                    added = true;
                }
            }
            BaseLogic receiveSecretRule2Result = (BaseLogic)RuleInstance<ReceiveSecretRule>.GetResult(initialAssumption, protocolStep);
            if (receiveSecretRule2Result != null)
            {
                if (!CurrentKnowledge.Contains(receiveSecretRule2Result))
                {
                    CurrentKnowledge.Add(receiveSecretRule2Result);
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
