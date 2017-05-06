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
            textBoxRead.Text = reader.ReadData();
            //            reader.Data = textBoxRead.Text + "_test";

            //            textBoxWrite.Text = reader.Data;
            reader.WriteData();

            NSSKAlgorithm();

            testReceiveRule();
            testFreshRule();
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
            //            BanLogic.ProtocolSteps.Add();
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
            BanLogic.ProtocolSteps.Add(f1);

            #endregion

            #region S bel A<Kas>S

            var f2 = new Believe();
            f2.Agent1 = AgentS;
            f2.Formula = new SharedKey();
            ((SharedKey)f2.Formula).Agent1 = AgentA;
            ((SharedKey)f2.Formula).Agent2 = AgentS;
            ((SharedKey)f2.Formula).Key = "Kas";
            BanLogic.ProtocolSteps.Add(f2);

            #endregion

            #region S bel A<Kab>S

            var f3 = new Believe();
            f3.Agent1 = AgentS;
            f3.Formula = new SharedKey();
            ((SharedKey)f3.Formula).Agent1 = AgentA;
            ((SharedKey)f3.Formula).Agent2 = AgentS;
            ((SharedKey)f3.Formula).Key = "Kab";
            BanLogic.ProtocolSteps.Add(f3);

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
            BanLogic.ProtocolSteps.Add(f4);

            #endregion

            #region B bel S controls A<K>B

            var f7 = new Believe();
            f7.Agent1 = AgentB;
            var f8 = new Controls();
            f8.Agent1 = AgentS;
            var f9 = new SharedKey();
            f4.Formula = f8;
            f5.Formula = f9;
            f6.Agent1 = AgentA;
            f6.Agent2 = AgentB;
            f6.Key = "K";
            BanLogic.ProtocolSteps.Add(f7);

            #endregion

            #region A bel fresh(TS)

            var f10 = new Believe();
            f10.Agent1 = AgentA;
            var f11 = new Fresh();
            f11.Message = "TS";
            f10.Formula = f11;
            BanLogic.ProtocolSteps.Add(f10);

            #endregion

            #region B bel fresh(TS)

            var f12 = new Believe();
            f12.Agent1 = AgentB;
            var f13 = new Fresh();
            f13.Message = "TS";
            f12.Formula = f13;
            BanLogic.ProtocolSteps.Add(f12);

            #endregion
            
            #region B bel fresh(TA)

            var f14 = new Believe();
            f14.Agent1 = AgentB;
            var f15 = new Fresh();
            f15.Message = "TA";
            f14.Formula = f15;
            BanLogic.ProtocolSteps.Add(f14);

            #endregion 
            
            #region A bel fresh(TA)

            var f16 = new Believe();
            f16.Agent1 = AgentA;
            var f17 = new Fresh();
            f17.Message = "TA";
            f16.Formula = f17;
            BanLogic.ProtocolSteps.Add(f16);

            #endregion

            #region B bel B <Kbs>S

            var f18 = new Believe();
            f18.Agent1 = AgentB;
            f18.Formula = new SharedKey();
            ((SharedKey)f18.Formula).Agent1 = f18.Agent1;
            ((SharedKey)f18.Formula).Agent2 = AgentS;
            ((SharedKey)f18.Formula).Key = "Kbs";
            BanLogic.ProtocolSteps.Add(f18);

            #endregion
           
            #region S bel B <Kbs>S

            var f19 = new Believe();
            f19.Agent1 = AgentS;
            f19.Formula = new SharedKey();
            ((SharedKey)f19.Formula).Agent1 = new Agent(){Name="B"};
            ((SharedKey)f19.Formula).Agent2 = AgentS;
            ((SharedKey)f19.Formula).Key = "Kbs";
            BanLogic.ProtocolSteps.Add(f19);

            #endregion

            #region A sees {Ts, A<Kab>B,{Ts,A<Kab>B}Kbs}Kas
            var f20=new Encryption();
            f20.Key = "Kas";
            f20.Formula=new Concatenate();
            var p1 = new BaseLogic();
            p1.Message = "TS";
            ((Concatenate)f20.Formula).Formulas.Add(p1);
            var p2= new SharedKey();
            p2.Agent1 = AgentA;
            p2.Agent2 = AgentB;
            p2.Key = "Kab";
           ((Concatenate)f20.Formula).Formulas.Add(p2);
            var p3= new Encryption();
            p3.Key = "Kbs";
            p3.Formula = new Concatenate();
            var par1= new BaseLogic();
            p1.Message = "TS";
            ((Concatenate)p3.Formula).Formulas.Add(par1);
            var par2 = new SharedKey();
            p2.Agent1 = AgentA;
            p2.Agent2 = AgentB;
            p2.Key = "Kab";
            ((Concatenate)p3.Formula).Formulas.Add(par2);
            ((Concatenate)f20.Formula).Formulas.Add(p3);
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

            #endregion //   pas4 (KERBEROS)
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
