using System.Collections.Generic;
using Proiect_2.Elements;
using Proiect_2.Syntax;

namespace Proiect_2.Protocols
{
    public class AndrewSecureRpcProtocol : IProtocol
    {
        public List<BaseLogic> InitialAssumptions { get; set; }
        public List<BaseLogic> ProtocolSteps { get; set; }
        public List<BaseLogic> Knowledge { get; set; }
        public Dictionary<string, Agent> AgentList { get; set; }
        public AndrewSecureRpcProtocol()
        {
            InitialAssumptions = new List<BaseLogic>();
            ProtocolSteps = new List<BaseLogic>();
            Knowledge = new List<BaseLogic>();
            AgentList = new Dictionary<string, Agent>();
            InitializeProtocol();
        }

        public void InitializeProtocol()
        {
            InitializeElements();
            InitializeAssumptions();
            InitializeProtocolSteps();
        }

        public void InitializeAssumptions()
        {

            #region A bel A <Kab> B

            var f1 = new Believe
            {
                Agent1 = AgentList["A"],
                Formula = new SharedKey()
            };
            ((SharedKey)f1.Formula).Agent1 = f1.Agent1;
            ((SharedKey)f1.Formula).Agent2 = AgentList["B"];
            ((SharedKey)f1.Formula).Key = "Kab";
            InitialAssumptions.Add(f1);

            #endregion

            #region B bel A<Kab> B

            var f2 = new Believe
            {
                Agent1 = AgentList["B"],
                Formula = new SharedKey()
            };
            ((SharedKey)f2.Formula).Agent1 = AgentList["A"];
            ((SharedKey)f2.Formula).Agent2 = AgentList["B"];
            ((SharedKey)f2.Formula).Key = "Kab";
            InitialAssumptions.Add(f2);

            #endregion

            #region B bel A <Kab'> B

            var f3 = new Believe
            {
                Agent1 = AgentList["B"],
                Formula = new SharedKey()
            };
            ((SharedKey)f3.Formula).Agent1 = AgentList["A"];
            ((SharedKey)f3.Formula).Agent2 = AgentList["B"];
            ((SharedKey)f3.Formula).Key = "Kab'";
            InitialAssumptions.Add(f3);

            #endregion

            #region A bel B controls A<K>B

            var f4 = new Believe { Agent1 = AgentList["A"] };
            var f5 = new Controls { Agent1 = AgentList["B"] };
            var f6 = new SharedKey();
            f4.Formula = f5;
            f5.Formula = f6;
            f6.Agent1 = AgentList["A"];
            f6.Agent2 = AgentList["B"];
            f6.Key = "K";
            InitialAssumptions.Add(f4);

            #endregion

            #region A bel fresh(Na)

            var f10 = new Believe { Agent1 = AgentList["A"] };
            var f11 = new Fresh { Message = "Na" };
            f10.Formula = f11;
            InitialAssumptions.Add(f10);

            #endregion

            #region B bel fresh(Nb)

            var f12 = new Believe { Agent1 = AgentList["B"] };
            var f13 = new Fresh { Message = "Nb" };
            f12.Formula = f13;
            InitialAssumptions.Add(f12);

            #endregion

            #region B bel fresh(Nb')

            var f14 = new Believe { Agent1 = AgentList["B"] };
            var f15 = new Fresh { Message = "Nb'" };
            f14.Formula = f15;
            InitialAssumptions.Add(f14);

            #endregion

        }
        public void InitializeProtocolSteps()
        {
            #region Step 1: B sees {Na}Kab
            var step1EncryptionRule = new Encryption
            {
                Key = "Kab",
                Message = "Na"
            };
            var step1 = new Receives
            {
                Agent1 = AgentList["B"],
                Formula = step1EncryptionRule
            };
            ProtocolSteps.Add(step1);
            #endregion // pas2 

            #region Step 2: A sees {Na,Nb}Kab

            var step2Concatenate = new Concatenate();
            var param1 = new BaseLogic { Message = "Na" };
            var param2 = new BaseLogic { Message = "Nb" };
            step2Concatenate.Formulas.Add(param1);
            step2Concatenate.Formulas.Add(param2);

            var step2Encryption = new Encryption
            {
                Key = "Kab",
                Formula = step2Concatenate
            };
            var step2 = new Receives
            {
                Agent1 = AgentList["A"],
                Formula = step2Encryption
            };
            ProtocolSteps.Add(step2);
            #endregion //   pas3 (KERBEROS)
            
            #region Step 3: B sees {Nb} Kab
            var step3EncryptionRule = new Encryption
            {
                Key = "Kab",
                Message = "Nb"
            };
            var step3 = new Receives
            {
                Agent1 = AgentList["B"],
                Formula = step3EncryptionRule
            };
            ProtocolSteps.Add(step3);
            #endregion // pas2 
            
            #region Step 4: A sees { A<Kab'>B, Nb'}Kab

            var f22 = new Encryption
            {
                Key = "Kab",
                Formula = new Concatenate()
            };
            var step4C1 = new SharedKey
            {
                Agent1 = AgentList["A"],
                Agent2 = AgentList["B"],
                Key = "Kab'"
            };
            ((Concatenate)f22.Formula).Formulas.Add(step4C1);
            var step4C2 = new BaseLogic { Message = "Nb'" };
            ((Concatenate)f22.Formula).Formulas.Add(step4C2);
            var step4 = new Receives
            {
                Agent1 = AgentList["A"],
                Formula = f22
            };
            ProtocolSteps.Add(step4);
            #endregion //   pas4 

        }
        public void InitializeElements()
        {
            AgentList.Add("A", new Agent { Name = "A" });
            AgentList.Add("B", new Agent { Name = "B" });
        }
    }
}