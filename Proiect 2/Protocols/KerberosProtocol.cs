using System.Collections.Generic;
using Proiect_2.Elements;
using Proiect_2.Syntax;

namespace Proiect_2.Protocols
{
    public class KerberosProtocol : IProtocol
    {
        public List<BaseLogic> InitialAssumptions { get; set; }
        public List<BaseLogic> ProtocolSteps { get; set; }
        public List<BaseLogic> Knowledge { get; set; }
        public Dictionary<string, Agent> AgentList { get; set; }
        public KerberosProtocol()
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

            #region A bel A <Kas>S

            var f1 = new Believe
            {
                Agent1 = AgentList["A"],
                Formula = new SharedKey()
            };
            ((SharedKey)f1.Formula).Agent1 = f1.Agent1;
            ((SharedKey)f1.Formula).Agent2 = AgentList["S"];
            ((SharedKey)f1.Formula).Key = "Kas";
            InitialAssumptions.Add(f1);

            #endregion

            #region S bel A<Kas>S

            var f2 = new Believe
            {
                Agent1 = AgentList["S"],
                Formula = new SharedKey()
            };
            ((SharedKey)f2.Formula).Agent1 = AgentList["A"];
            ((SharedKey)f2.Formula).Agent2 = AgentList["S"];
            ((SharedKey)f2.Formula).Key = "Kas";
            InitialAssumptions.Add(f2);

            #endregion

            #region S bel A<Kab>S

            var f3 = new Believe
            {
                Agent1 = AgentList["S"],
                Formula = new SharedKey()
            };
            ((SharedKey)f3.Formula).Agent1 = AgentList["A"];
            ((SharedKey)f3.Formula).Agent2 = AgentList["S"];
            ((SharedKey)f3.Formula).Key = "Kab";
            InitialAssumptions.Add(f3);

            #endregion

            #region A bel S controls A<K>B

            var f4 = new Believe { Agent1 = AgentList["A"] };
            var f5 = new Controls { Agent1 = AgentList["S"] };
            var f6 = new SharedKey();
            f4.Formula = f5;
            f5.Formula = f6;
            f6.Agent1 = AgentList["A"];
            f6.Agent2 = AgentList["B"];
            f6.Key = "K";
            InitialAssumptions.Add(f4);

            #endregion

            #region B bel S controls A<K>B

            var f7 = new Believe { Agent1 = AgentList["B"] };
            var f8 = new Controls { Agent1 = AgentList["S"] };
            var f9 = new SharedKey();
            f7.Formula = f8;
            f8.Formula = f9;
            f9.Agent1 = AgentList["A"];
            f9.Agent2 = AgentList["B"];
            f9.Key = "K";
            InitialAssumptions.Add(f7);

            #endregion

            #region A bel fresh(TS)

            var f10 = new Believe { Agent1 = AgentList["A"] };
            var f11 = new Fresh { Message = "TS" };
            f10.Formula = f11;
            InitialAssumptions.Add(f10);

            #endregion

            #region B bel fresh(TS)

            var f12 = new Believe { Agent1 = AgentList["B"] };
            var f13 = new Fresh { Message = "TS" };
            f12.Formula = f13;
            InitialAssumptions.Add(f12);

            #endregion

            #region B bel fresh(TA)

            var f14 = new Believe { Agent1 = AgentList["B"] };
            var f15 = new Fresh { Message = "TA" };
            f14.Formula = f15;
            InitialAssumptions.Add(f14);

            #endregion

            #region A bel fresh(TA)

            var f16 = new Believe { Agent1 = AgentList["A"] };
            var f17 = new Fresh { Message = "TA" };
            f16.Formula = f17;
            InitialAssumptions.Add(f16);

            #endregion

            #region B bel B <Kbs>S

            var f18 = new Believe
            {
                Agent1 = AgentList["B"],
                Formula = new SharedKey()
            };
            ((SharedKey)f18.Formula).Agent1 = f18.Agent1;
            ((SharedKey)f18.Formula).Agent2 = AgentList["S"];
            ((SharedKey)f18.Formula).Key = "Kbs";
            InitialAssumptions.Add(f18);

            #endregion

            #region S bel B <Kbs>S

            var f19 = new Believe
            {
                Agent1 = AgentList["S"],
                Formula = new SharedKey()
            };
            ((SharedKey)f19.Formula).Agent1 = AgentList["B"];
            ((SharedKey)f19.Formula).Agent2 = AgentList["S"];
            ((SharedKey)f19.Formula).Key = "Kbs";
            InitialAssumptions.Add(f19);

            #endregion

        }
        public void InitializeProtocolSteps()
        {
            #region Step 2: A sees {Ts, A<Kab>B,{Ts,A<Kab>B}Kbs}Kas

            var step1EncryptionRule = new Encryption
            {
                Key = "Kas",
                Formula = new Concatenate()
            };
            var step1BaseLogicTs = new BaseLogic { Message = "TS" };
            ((Concatenate)step1EncryptionRule.Formula).Formulas.Add(step1BaseLogicTs);
            var step1SharedKey = new SharedKey
            {
                Agent1 = AgentList["A"],
                Agent2 = AgentList["B"],
                Key = "Kab"
            };
            ((Concatenate)step1EncryptionRule.Formula).Formulas.Add(step1SharedKey);
            var p3 = new Encryption
            {
                Key = "Kbs",
                Formula = new Concatenate()
            };
            ((Concatenate)p3.Formula).Formulas.Add(step1BaseLogicTs);
            ((Concatenate)p3.Formula).Formulas.Add(step1SharedKey);
            ((Concatenate)step1EncryptionRule.Formula).Formulas.Add(p3);
            var step1 = new Receives
            {
                Agent1 = AgentList["A"],
                Formula = step1EncryptionRule
            };
            ProtocolSteps.Add(step1);
            #endregion // pas2 (KERBEROS)

            #region Step 3: B sees {{Ts, A<Kab>B}Kbs,{Ta,A<Kab>B}Kab}}

            var f21 = new Concatenate();
            var param1 = new Encryption
            {
                Key = "Kbs",
                Formula = new Concatenate()
            };
            var m1 = new BaseLogic { Message = "TS" };
            ((Concatenate)param1.Formula).Formulas.Add(m1);
            var m2 = new SharedKey
            {
                Agent1 = AgentList["A"],
                Agent2 = AgentList["B"],
                Key = "Kab"
            };
            ((Concatenate)param1.Formula).Formulas.Add(m2);
            ((Concatenate)f21).Formulas.Add(param1);

            var param2 = new Encryption
            {
                Key = "Kab",
                Formula = new Concatenate()
            };
            var msg1 = new BaseLogic { Message = "Ta" };
            ((Concatenate)param2.Formula).Formulas.Add(msg1);
            var msg2 = new SharedKey
            {
                Agent1 = AgentList["A"],
                Agent2 = AgentList["B"],
                Key = "Kab"
            };
            ((Concatenate)param2.Formula).Formulas.Add(msg2);
            ((Concatenate)f21).Formulas.Add(param2);
            var step2 = new Receives
            {
                Agent1 = AgentList["B"],
                Formula = f21
            };
            ProtocolSteps.Add(step2);
            #endregion //   pas3 (KERBEROS)

            #region Step 4: A sees {Ta, A<Kab>B}Kab

            var f22 = new Encryption
            {
                Key = "Kab",
                Formula = new Concatenate()
            };
            var v1 = new BaseLogic { Message = "Ta" };
            ((Concatenate)f22.Formula).Formulas.Add(v1);
            var v2 = new SharedKey
            {
                Agent1 = AgentList["A"],
                Agent2 = AgentList["B"],
                Key = "Kab"
            };
            ((Concatenate)f22.Formula).Formulas.Add(v2);
            var step3 = new Receives
            {
                Agent1 = AgentList["A"],
                Formula = f22
            };
            ProtocolSteps.Add(step3);
            #endregion //   pas4 (KERBEROS)

        }
        public void InitializeElements()
        {
            AgentList.Add("A", new Agent { Name = "A" });
            AgentList.Add("B", new Agent { Name = "B" });
            AgentList.Add("S", new Agent { Name = "S" });
        }
    }
}