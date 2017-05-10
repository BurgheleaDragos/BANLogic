using System.Collections.Generic;
using Proiect_2.Elements;
using Proiect_2.Syntax;

namespace Proiect_2.Protocols
{
    public class NSSKProtocol : IProtocol
    {
        public List<BaseLogic> InitialAssumptions { get; set; }
        public List<BaseLogic> ProtocolSteps { get; set; }
        public List<BaseLogic> Knowledge { get; set; }
        public Dictionary<string, Agent> AgentList { get; set; }
        public NSSKProtocol()
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

            var i1 = new Believe
            {
                Agent1 = AgentList["A"],
                Formula = new SharedKey()
            };
            ((SharedKey)i1.Formula).Agent1 = AgentList["A"];
            ((SharedKey)i1.Formula).Agent2 = AgentList["S"];
            ((SharedKey)i1.Formula).Key = "Kas";
            InitialAssumptions.Add(i1);

            #endregion

            #region B bel B <Kbs>S

            var i2 = new Believe
            {
                Agent1 = AgentList["B"],
                Formula = new SharedKey()
            };
            ((SharedKey)i2.Formula).Agent1 = AgentList["B"];
            ((SharedKey)i2.Formula).Agent2 = AgentList["S"];
            ((SharedKey)i2.Formula).Key = "Kbs";
            InitialAssumptions.Add(i2);

            #endregion

            #region A bel S controls A<K>B

            var i3 = new Believe { Agent1 = AgentList["A"] };
            var i4 = new Controls { Agent1 = AgentList["S"] };
            var i5 = new SharedKey();
            i3.Formula = i4;
            i4.Formula = i5;
            i5.Agent1 = AgentList["A"];
            i5.Agent2 = AgentList["B"];
            i5.Key = "K";
            InitialAssumptions.Add(i3);

            #endregion

            #region B bel S controls A<K>B

            var i6 = new Believe { Agent1 = AgentList["B"] };
            var i7 = new Controls { Agent1 = AgentList["S"] };
            var i10 = new SharedKey();
            i6.Formula = i7;
            i7.Formula = i10;
            i10.Agent1 = AgentList["A"];
            i10.Agent2 = AgentList["B"];
            i10.Key = "K";
            InitialAssumptions.Add(i6);

            #endregion

            #region A bel fresh(Na)

            var i11 = new Believe
            {
                Agent1 = AgentList["A"],
                Formula = new Fresh()
            };
            ((Fresh)i11.Formula).Message = "Na";
            InitialAssumptions.Add(i11);

            #endregion


            #region B bel fresh(Nb)

            var i12 = new Believe
            {
                Agent1 = AgentList["B"],
                Formula = new Fresh()
            };
            ((Fresh)i12.Formula).Message = "Nb";
            InitialAssumptions.Add(i12);

            #endregion


            #region A bel S controls fresh(A,K>B)

            var i13 = new Believe { Agent1 = AgentList["A"] };
            var i14 = new Controls { Agent1 = AgentList["S"] };
            var i15 = new Fresh();
            i13.Formula = i14;
            i14.Formula = i15;
            i15.Formula = new SharedKey();
            ((SharedKey)i15.Formula).Key = "K";
            ((SharedKey)i15.Formula).Agent1 = AgentList["A"];
            ((SharedKey)i15.Formula).Agent1 = AgentList["B"];
            InitialAssumptions.Add(i13);

            #endregion
        }
        public void InitializeProtocolSteps()
        {
            #region Step 1: A receives {Na, a<Kab>B, fresh(Kab), {A<Kab>B}Kbs}Kas

            var step1Sees = new Receives
            {
                Agent1 = AgentList["A"]
            };
            var encryptionFormula = new Encryption { Key = "Kas" };
            step1Sees.Formula = encryptionFormula;
            var concatenateFormula = new Concatenate();
            encryptionFormula.Formula = concatenateFormula;
            var baseLogicFormula = new BaseLogic { Message = "Na" };
            concatenateFormula.Formulas.Add(baseLogicFormula);
            var sharedKeyFormula = new SharedKey
            {
                Key = "Kab",
                Agent1 = AgentList["A"],
                Agent2 = AgentList["B"]
            };
            concatenateFormula.Formulas.Add(sharedKeyFormula);
            var freshFormula = new Fresh { Message = "Kab" };
            concatenateFormula.Formulas.Add(freshFormula);
            var encryptionFormula2 = new Encryption
            {
                Key = "Kbs"
            };
            var sharedKeyFormula2 = new SharedKey()
            {
                Key = "Kab",
                Agent1 = AgentList["A"],
                Agent2 = AgentList["B"]
            };
            encryptionFormula2.Formula = sharedKeyFormula2;
            concatenateFormula.Formulas.Add(encryptionFormula2);
            ProtocolSteps.Add(step1Sees);

            #endregion // pas1 NSSK

            #region Step 2: B receives {A<Kab>B}Kbs

            var step2Sees = new Receives
            {
                Agent1 = AgentList["B"],
                Formula = new Encryption()
            };
            ((Encryption)step2Sees.Formula).Formula = new SharedKey();
            ((Encryption)step2Sees.Formula).Key = "Kbs";
            ((SharedKey)((Encryption)step2Sees.Formula).Formula).Agent1 = AgentList["A"];
            ((SharedKey)((Encryption)step2Sees.Formula).Formula).Agent2 = AgentList["B"];
            ((SharedKey)((Encryption)step2Sees.Formula).Formula).Key = "Kab";
            ProtocolSteps.Add(step2Sees);

            #endregion // pas2 NSSK

            #region Step 3: A receives {Nb,A<Kab>B}Kab

            var step3Sees = new Receives
            {
                Agent1 = AgentList["A"],
                Formula = new Encryption()
            };
            ((Encryption)step3Sees.Formula).Key = "Kab";
            ((Encryption)step3Sees.Formula).Formula = new Concatenate();
            var par1 = new BaseLogic { Message = "Nb" };
            ((Concatenate)((Encryption)step3Sees.Formula).Formula).Formulas.Add(par1);
            var par2 = new SharedKey
            {
                Key = "Kab",
                Agent1 = AgentList["A"],
                Agent2 = AgentList["B"]
            };
            ((Concatenate)((Encryption)step3Sees.Formula).Formula).Formulas.Add(par2);
            ProtocolSteps.Add(step3Sees); //pas3 NSSK

            #endregion

            #region Step 4: B receives {Nb,A<Kab>B}Kab

            var step4Sees = new Receives()
            {
                Agent1 = AgentList["B"],
                Formula = new Encryption()
            };
            ((Encryption)step4Sees.Formula).Key = "Kab";
            ((Encryption)step4Sees.Formula).Formula = new Concatenate();
            var param1 = new BaseLogic { Message = "Nb" };
            ((Concatenate)((Encryption)step4Sees.Formula).Formula).Formulas.Add(param1);
            var param2 = new SharedKey
            {
                Key = "KB",
                Agent1 = AgentList["A"],
                Agent2 = AgentList["B"]
            };
            ((Concatenate)((Encryption)step4Sees.Formula).Formula).Formulas.Add(param2);
            ProtocolSteps.Add(step4Sees); //pas4 NSSK

            #endregion

        }
        public void InitializeElements()
        {
            AgentList.Add("A", new Agent { Name = "A" });
            AgentList.Add("B", new Agent { Name = "B" });
            AgentList.Add("S", new Agent { Name = "S" });
        }
    }
}
