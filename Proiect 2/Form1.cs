using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proiect_2.Elements;
using Proiect_2.Logic;
using Proiect_2.Syntax;

namespace Proiect_2
{
    public partial class Form1 : Form
    {
        public Reader reader;
        public BanLogic BanLogic { get; set; }
        public Form1()
        {
            InitializeComponent();
            reader = new Reader();
            BanLogic = new BanLogic();
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            //  textBoxRead.Text = reader.ReadData();
            //            reader.Data = textBoxRead.Text + "_test";

            //            textBoxWrite.Text = reader.Data;
            // reader.WriteData();

            //            NSSKAlgorithm();

            // KerberosProtocol();
            NSSKProtocol();

//            testReceiveRule();
//            testFreshRule();
        }

        private void NSSKAlgorithm()
        {
            //todo: to implement
            var step2 = new Sees();
            step2.Agent1 = new Agent
            {
                Name = "Agent_A"
            };
            //            step2.Formula = new 
            //            BanLogic.InitialAssumptions.Add();
        }

        private void testReceiveRule()
        {

            var f1 = new Receives();
            f1.Agent1 = new Agent()
            {
                Name = "Agent_A"
            };
            f1.Formula = new Encryption()
            {
                Key = "Cheia_K",
                Value = "Text criptat"
            };

            var f2 = new Believe();
            f2.Agent1 = new Agent() { Name = "Agent_A" };
            f2.Formula = new SharedKey()
            {
                Agent1 = new Agent() { Name = "Agent_A" },
                Agent2 = new Agent() { Name = "Agent_B" },
                Key = "Cheia_K"
            };

            var d = new ReceiveRule(f1, f2);
            d.Formula1 = f1;
            d.Formula2 = f2;
            var z = d.Result;
        }
        private void testFreshRule()
        {

            var f1 = new Believe();
            f1.Agent1 = new Agent()
            {
                Name = "Agent_A"
            };
            f1.Formula = new Said()
            {
                Agent1 = new Agent() { Name = "Agent_B" },
                Message = "X"
            };

            var f2 = new Believe();
            f2.Agent1 = new Agent() { Name = "Agent_A" };
            f2.Formula = new Fresh()
            {
                Message = "X"
            };

            var d = new FreshRule(f1, f1);
            var z = d.Result;
        }

        private void KerberosProtocol()
        {
            var AgentA = new Agent();
            AgentA.Name = "A";
            var AgentB = new Agent();
            AgentB.Name = "B";
            var AgentS = new Agent();
            AgentS.Name = "S";

            #region A bel A <Kas>S

            var f1 = new Believe();
            f1.Agent1 = AgentA;
            f1.Formula = new SharedKey();
            ((SharedKey)f1.Formula).Agent1 = f1.Agent1;
            ((SharedKey)f1.Formula).Agent2 = AgentS;
            ((SharedKey)f1.Formula).Key = "Kas";
            BanLogic.InitialAssumptions.Add(f1);

            #endregion

            #region S bel A<Kas>S

            var f2 = new Believe();
            f2.Agent1 = AgentS;
            f2.Formula = new SharedKey();
            ((SharedKey)f2.Formula).Agent1 = AgentA;
            ((SharedKey)f2.Formula).Agent2 = AgentS;
            ((SharedKey)f2.Formula).Key = "Kas";
            BanLogic.InitialAssumptions.Add(f2);

            #endregion

            #region S bel A<Kab>S

            var f3 = new Believe();
            f3.Agent1 = AgentS;
            f3.Formula = new SharedKey();
            ((SharedKey)f3.Formula).Agent1 = AgentA;
            ((SharedKey)f3.Formula).Agent2 = AgentS;
            ((SharedKey)f3.Formula).Key = "Kab";
            BanLogic.InitialAssumptions.Add(f3);

            #endregion

            #region A bel S controls A<K>B

            var f4 = new Believe();
            f4.Agent1 = AgentA;
            var f5 = new Controls();
            f5.Agent1 = AgentS;
            var f6 = new SharedKey();
            f4.Formula = f5;
            f5.Formula = f6;
            f6.Agent1 = AgentA;
            f6.Agent2 = AgentB;
            f6.Key = "K";
            BanLogic.InitialAssumptions.Add(f4);

            #endregion

            #region B bel S controls A<K>B

            var f7 = new Believe();
            f7.Agent1 = AgentB;
            var f8 = new Controls();
            f8.Agent1 = AgentS;
            var f9 = new SharedKey();
            f7.Formula = f8;
            f8.Formula = f9;
            f9.Agent1 = AgentA;
            f9.Agent2 = AgentB;
            f9.Key = "K";
            BanLogic.InitialAssumptions.Add(f7);

            #endregion

            #region A bel fresh(TS)

            var f10 = new Believe();
            f10.Agent1 = AgentA;
            var f11 = new Fresh();
            f11.Message = "TS";
            f10.Formula = f11;
            BanLogic.InitialAssumptions.Add(f10);

            #endregion

            #region B bel fresh(TS)

            var f12 = new Believe();
            f12.Agent1 = AgentB;
            var f13 = new Fresh();
            f13.Message = "TS";
            f12.Formula = f13;
            BanLogic.InitialAssumptions.Add(f12);

            #endregion

            #region B bel fresh(TA)

            var f14 = new Believe();
            f14.Agent1 = AgentB;
            var f15 = new Fresh();
            f15.Message = "TA";
            f14.Formula = f15;
            BanLogic.InitialAssumptions.Add(f14);

            #endregion

            #region A bel fresh(TA)

            var f16 = new Believe();
            f16.Agent1 = AgentA;
            var f17 = new Fresh();
            f17.Message = "TA";
            f16.Formula = f17;
            BanLogic.InitialAssumptions.Add(f16);

            #endregion

            #region B bel B <Kbs>S

            var f18 = new Believe();
            f18.Agent1 = AgentB;
            f18.Formula = new SharedKey();
            ((SharedKey)f18.Formula).Agent1 = f18.Agent1;
            ((SharedKey)f18.Formula).Agent2 = AgentS;
            ((SharedKey)f18.Formula).Key = "Kbs";
            BanLogic.InitialAssumptions.Add(f18);

            #endregion

            #region S bel B <Kbs>S

            var f19 = new Believe();
            f19.Agent1 = AgentS;
            f19.Formula = new SharedKey();
            ((SharedKey)f19.Formula).Agent1 = new Agent() { Name = "B" };
            ((SharedKey)f19.Formula).Agent2 = AgentS;
            ((SharedKey)f19.Formula).Key = "Kbs";
            BanLogic.InitialAssumptions.Add(f19);

            #endregion

            #region A sees {Ts, A<Kab>B,{Ts,A<Kab>B}Kbs}Kas

            var step1EncryptionRule = new Encryption
            {
                Key = "Kas",
                Formula = new Concatenate()
            };
            var step1BaseLogicTs = new BaseLogic { Message = "TS" };
            ((Concatenate)step1EncryptionRule.Formula).Formulas.Add(step1BaseLogicTs);
            var step1SharedKey = new SharedKey
            {
                Agent1 = AgentA,
                Agent2 = AgentB,
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
                Agent1 = AgentA,
                Formula = step1EncryptionRule
            };
            BanLogic.ProtocolSteps.Add(step1);
            #endregion // pas2 (KERBEROS)

            #region B sees {{Ts, A<Kab>B}Kbs,{Ta,A<Kab>B}Kab}}

            var f21 = new Concatenate();
            var param1 = new Encryption();
            param1.Key = "Kbs";
            param1.Formula = new Concatenate();
            var m1 = new BaseLogic();
            m1.Message = "TS";
            ((Concatenate)param1.Formula).Formulas.Add(m1);
            var m2 = new SharedKey();
            m2.Agent1 = AgentA;
            m2.Agent2 = AgentB;
            m2.Key = "Kab";
            ((Concatenate)param1.Formula).Formulas.Add(m2);
            ((Concatenate)f21).Formulas.Add(param1);

            var param2 = new Encryption();
            param2.Key = "Kab";
            param2.Formula = new Concatenate();
            var msg1 = new BaseLogic();
            msg1.Message = "Ta";
            ((Concatenate)param2.Formula).Formulas.Add(msg1);
            var msg2 = new SharedKey();
            msg2.Agent1 = AgentA;
            msg2.Agent2 = AgentB;
            msg2.Key = "Kab";
            ((Concatenate)param2.Formula).Formulas.Add(msg2);
            ((Concatenate)f21).Formulas.Add(param2);
            var step2 = new Receives();
            step2.Agent1 = AgentB;
            step2.Formula = f21;
            BanLogic.ProtocolSteps.Add(step2);
            #endregion //   pas3 (KERBEROS)

            #region A sees {Ta, A<Kab>B}Kab

            var f22 = new Encryption();
            f22.Key = "Kab";
            f22.Formula = new Concatenate();
            var v1 = new BaseLogic();
            v1.Message = "Ta";
            ((Concatenate)f22.Formula).Formulas.Add(v1);
            var v2 = new SharedKey();
            v2.Agent1 = AgentA;
            v2.Agent2 = AgentB;
            v2.Key = "Kab";
            ((Concatenate)f22.Formula).Formulas.Add(v2);
            var step3 = new Receives();
            step3.Agent1 = AgentA;
            step3.Formula = f22;
            BanLogic.ProtocolSteps.Add(step3);
            #endregion //   pas4 (KERBEROS)

            BanLogic.ProtocolStepsKnowledge();

            var readerStrBuilder = new StringBuilder();
            foreach (var initialAssumption in BanLogic.InitialAssumptions)
            {
                readerStrBuilder.AppendLine(initialAssumption.ToString());
            }
            foreach (var protocolStep in BanLogic.ProtocolSteps)
            {
                readerStrBuilder.AppendLine(protocolStep.ToString());
            }
            textBoxRead.Text = readerStrBuilder.ToString();
            var strBuilder = new StringBuilder();
            foreach (var logic in BanLogic.CurrentKnowledge)
            {
                strBuilder.AppendLine(logic.ToString());
            }
            textBoxWrite.Text = strBuilder.ToString();
        }


        private void NSSKProtocol()
        {
            var AgentA = new Agent();
            AgentA.Name = "A";
            var AgentB = new Agent();
            AgentB.Name = "B";
            var AgentS = new Agent();
            AgentS.Name = "S";


            #region A bel A <Kas>S

            var i1 = new Believe();
            i1.Agent1 = AgentA;
            i1.Formula = new SharedKey();
            ((SharedKey)i1.Formula).Agent1 = new Agent() { Name = "A" };
            ((SharedKey)i1.Formula).Agent2 = AgentS;
            ((SharedKey)i1.Formula).Key = "Kas";
            BanLogic.InitialAssumptions.Add(i1);

            #endregion

            #region B bel B <Kbs>S

            var i2 = new Believe();
            i2.Agent1 = AgentB;
            i2.Formula = new SharedKey();
            ((SharedKey)i2.Formula).Agent1 = new Agent() { Name = "B" };
            ((SharedKey)i2.Formula).Agent2 = AgentS;
            ((SharedKey)i2.Formula).Key = "Kbs";
            BanLogic.InitialAssumptions.Add(i2);

            #endregion

            #region A bel S controls A<K>B

            var i3 = new Believe();
            i3.Agent1 = AgentA;
            var i4 = new Controls();
            i4.Agent1 = AgentS;
            var i5 = new SharedKey();
            i3.Formula = i4;
            i4.Formula = i5;
            i5.Agent1 = AgentA;
            i5.Agent2 = AgentB;
            i5.Key = "K";
            BanLogic.InitialAssumptions.Add(i3);

            #endregion

            #region B bel S controls A<K>B

            var i6 = new Believe();
            i6.Agent1 = AgentB;
            var i7 = new Controls();
            i7.Agent1 = AgentS;
            var i10 = new SharedKey();
            i6.Formula = i7;
            i7.Formula = i10;
            i10.Agent1 = AgentA;
            i10.Agent2 = AgentB;
            i10.Key = "K";
            BanLogic.InitialAssumptions.Add(i6);

            #endregion

            #region A bel fresh(Na)

            var i11 = new Believe();
            i11.Agent1 = AgentA;
            i11.Formula = new Fresh();
            ((Fresh)i11.Formula).Message = "Na";
            BanLogic.InitialAssumptions.Add(i11);

            #endregion


            #region B bel fresh(Nb)

            var i12 = new Believe();
            i12.Agent1 = AgentB;
            i12.Formula = new Fresh();
            ((Fresh)i12.Formula).Message = "Nb";
            BanLogic.InitialAssumptions.Add(i12);

            #endregion


            #region A bel S controls fresh(A,K>B)

            var i13 = new Believe();
            i13.Agent1 = AgentA;
            var i14 = new Controls();
            i14.Agent1 = AgentS;
            var i15 = new Fresh();
            i13.Formula = i14;
            i14.Formula = i15;
            i15.Formula = new SharedKey();
            ((SharedKey)i15.Formula).Key = "K";
            ((SharedKey)i15.Formula).Agent1 = AgentA;
            ((SharedKey)i15.Formula).Agent1 = AgentB;
            BanLogic.InitialAssumptions.Add(i13);

            #endregion

            #region A sees{Na, a<Kab>B, fresh(Kab),{A<Kab>B}Kbs}KAs from S

            var f1 = new Sees();
            f1.Agent1 = AgentA;
            f1.Formula = new From();
            ((From)f1.Formula).Agent = AgentS;
            var f2 = new Encryption();
            ((From)f1.Formula).Formula = f2;
            f2.Formula = new Concatenate();
            var p1 = new BaseLogic();
            p1.Message = "Na";
            ((Concatenate)f2.Formula).Formulas.Add(p1);
            var p2 = new SharedKey();
            p2.Key = "Kab";
            p2.Agent1 = AgentA;
            p2.Agent2 = AgentB;
            ((Concatenate)f2.Formula).Formulas.Add(p2);
            var p3 = new Fresh { Message = "Kab" };
            ((Concatenate)f2.Formula).Formulas.Add(p3);
            var p4 = new Encryption();
            p4.Key = "Kbs";
            p4.Formula = new SharedKey();
            ((SharedKey)p4.Formula).Key = "Kab";
            ((SharedKey)p4.Formula).Agent1 = AgentA;
            ((SharedKey)p4.Formula).Agent2 = AgentB;
            ((Concatenate)f2.Formula).Formulas.Add(p4);
            BanLogic.ProtocolSteps.Add(f2);

            #endregion // pas1 NSSK

            #region B sees {A<Kab>B}Kbs from S

            var f3 = new Sees();
            f3.Agent1 = AgentB;
            f3.Formula = new From();
            ((From)f3.Formula).Formula = new Encryption();
            ((From)f3.Formula).Agent = AgentS;
            ((Encryption)((From)f3.Formula).Formula).Formula = new SharedKey();
            ((Encryption)((From)f3.Formula).Formula).Key = "Kbs";
            ((SharedKey)((Encryption)((From)f3.Formula).Formula).Formula).Agent1 = AgentA;
            ((SharedKey)((Encryption)((From)f3.Formula).Formula).Formula).Agent2 = AgentB;
            ((SharedKey)((Encryption)((From)f3.Formula).Formula).Formula).Key = "Kab";
            BanLogic.ProtocolSteps.Add(f3);

            #endregion // pas2 NSSK

            #region A sees {Nb,A<Kab>B}Kab from B

            var f4 = new Sees();
            f4.Agent1 = AgentA;
            f4.Formula = new From();
            ((From)f4.Formula).Formula = new Encryption();
            ((From)f4.Formula).Agent = AgentB;
            ((Encryption)((From)f4.Formula).Formula).Key = "Kab";
            ((Encryption)((From)f4.Formula).Formula).Formula = new Concatenate();
            var par1 = new BaseLogic();
            par1.Message = "Nb";
            ((Concatenate)((Encryption)((From)f4.Formula).Formula).Formula).Formulas.Add(par1);
            var par2 = new SharedKey();
            par2.Key = "Kbs";
            par2.Agent1 = AgentA;
            par2.Agent2 = AgentB;
            par2.Key = "Kab";
            ((Concatenate)((Encryption)((From)f4.Formula).Formula).Formula).Formulas.Add(par2);
            BanLogic.ProtocolSteps.Add(f4); //pas3 NSSK

            #endregion

            #region B sees {Nb,A<Kab>B}Kab from A

            var f5 = new Sees();
            f5.Agent1 = AgentB;
            f5.Formula = new From();
            ((From)f5.Formula).Formula = new Encryption();
            ((From)f5.Formula).Agent = AgentA;
            ((Encryption)((From)f5.Formula).Formula).Key = "Kab";
            ((Encryption)((From)f5.Formula).Formula).Formula = new Concatenate();
            var param1 = new BaseLogic();
            param1.Message = "Nb";
            ((Concatenate)((Encryption)((From)f5.Formula).Formula).Formula).Formulas.Add(param1);
            var param2 = new SharedKey();
            param2.Key = "Kbs";
            param2.Agent1 = AgentA;
            param2.Agent2 = AgentB;
            param2.Key = "Kab";
            ((Concatenate)((Encryption)((From)f5.Formula).Formula).Formula).Formulas.Add(param2);
            BanLogic.ProtocolSteps.Add(f5); //pas4 NSSK

            #endregion
            BanLogic.ProtocolStepsKnowledge();

            var readerStrBuilder = new StringBuilder();
            foreach (var initialAssumption in BanLogic.InitialAssumptions)
            {
                readerStrBuilder.AppendLine(initialAssumption.ToString());
            }
            foreach (var protocolStep in BanLogic.ProtocolSteps)
            {
                readerStrBuilder.AppendLine(protocolStep.ToString());
            }
            textBoxRead.Text = readerStrBuilder.ToString();
            var strBuilder = new StringBuilder();
            foreach (var logic in BanLogic.CurrentKnowledge)
            {
                strBuilder.AppendLine(logic.ToString());
            }
            textBoxWrite.Text = strBuilder.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
