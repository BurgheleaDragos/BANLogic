using Proiect_2.Syntax;

namespace Proiect_2.Logic
{
    public static class RuleInstance<T>
    {
        public static object GetResult(BaseLogic formula1, BaseLogic formula2 = null)
        {
            switch (typeof(T).Name)
            {
                case "AuthenticationRule":
                    return new AuthenticationRule(formula1).Result;
                case "BelieveConcatenation":
                    return new BelieveConcatenation(formula1, formula2).Result;
                case "BelieveDecomposition":
                    return new BelieveDecomposition(formula1).Result;
                case "BelieveSaidConcatenation":
                    return new BelieveSaidConcatenation(formula1).Result;
                case "ConcatenateRule":
                    return new ConcatenateRule(formula1).Result;
                case "ConfirmationKeyRule":
                    return new ConfirmationKeyRule(formula1).Result;
                case "FreshInjectRule":
                    return new FreshInjectRule(formula1, formula2).Result;
                case "FreshRule":
                    return new FreshRule(formula1, formula2).Result;
                case "JurisdictionRule":
                    return new JurisdictionRule(formula1, formula2).Result;
                case "NonceVerificationRule":
                    return new NonceVerificationRule(formula1, formula2).Result;
                case "ReceivePublicRule":
                    return new ReceivePublicRule(formula1, formula2).Result;
                case "ReceiveRule":
                    return new ReceiveRule(formula1, formula2).Result;
                case "ReceiveSecretRule":
                    return new ReceiveSecretRule(formula1, formula2).Result;
            }
            return null;
        }
    }
}