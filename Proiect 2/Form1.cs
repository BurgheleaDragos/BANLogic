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


    }
}
