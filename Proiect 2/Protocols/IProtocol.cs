using System.Collections.Generic;
using Proiect_2.Elements;
using Proiect_2.Syntax;

namespace Proiect_2.Protocols
{
    public interface IProtocol
    {
        List<BaseLogic> InitialAssumptions { get; set; }
        List<BaseLogic> ProtocolSteps { get; set; }
        List<BaseLogic> Knowledge { get; set; }
        Dictionary<string, Agent> AgentList { get; set; }
        void InitializeProtocol();
        void InitializeProtocolSteps();
        void InitializeAssumptions();
        void InitializeElements();
    }
}