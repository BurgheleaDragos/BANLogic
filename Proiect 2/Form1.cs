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

            var d = new FreshRule(f1, f2);
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

        }


    }
}
