using System;
using System.Text;
using System.Windows.Forms;
using Proiect_2.Protocols;

namespace Proiect_2
{
    public partial class Form1 : Form
    {
        public BanLogic BanLogic { get; set; }
        public Form1()
        {
            InitializeComponent();
            BanLogic = new BanLogic();
        }

        private void KerberosProtocol()
        {
            var kerberos = new KerberosProtocol();
            BanLogic = new BanLogic(kerberos.InitialAssumptions, kerberos.ProtocolSteps, kerberos.Knowledge);
            BanLogic.ProtocolStepsKnowledge();
            WriteData();
        }


        private void NSSKProtocol()
        {
            var nssk = new NSSKProtocol();
            BanLogic = new BanLogic(nssk.InitialAssumptions, nssk.ProtocolSteps, nssk.Knowledge);

            BanLogic.ProtocolStepsKnowledge();
            WriteData();
        }
        private void AndrewSecureRpcProtocol()
        {
            var andrewSecureRpcProtocol = new AndrewSecureRpcProtocol();
            BanLogic = new BanLogic(andrewSecureRpcProtocol.InitialAssumptions, andrewSecureRpcProtocol.ProtocolSteps, andrewSecureRpcProtocol.Knowledge);

            BanLogic.ProtocolStepsKnowledge();
            WriteData();
        }

        private void WriteData()
        {
            textBoxRead.Text = "";
            textBoxWrite.Text = "";
            var readerStrBuilder = new StringBuilder();
            readerStrBuilder.AppendLine("Initial Assumptions: ");
            foreach (var initialAssumption in BanLogic.InitialAssumptions)
            {
                readerStrBuilder.AppendLine(initialAssumption.ToString());
            }
            readerStrBuilder.AppendLine("-------------------------------------------------------");
            readerStrBuilder.AppendLine();
            readerStrBuilder.AppendLine("Protocol steps: ");
            var i = 1;
            foreach (var protocolStep in BanLogic.ProtocolSteps)
            {
                readerStrBuilder.AppendLine($"Step {i}: {protocolStep}");
                i++;
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

        private void buttonKerberos_Click(object sender, EventArgs e)
        {
            KerberosProtocol();
        }

        private void buttonNSSK_Click(object sender, EventArgs e)
        {
            NSSKProtocol();
        }

        private void buttonUnsafe_Click(object sender, EventArgs e)
        {
            //we cannot reach A believes B believes A<--Kab-->B 
            //=> vulnerable to replay attack
            AndrewSecureRpcProtocol();
        }
    }
}
