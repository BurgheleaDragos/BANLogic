using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proiect_2
{
    public class BanLogic
    {
        public string ProtocolList { get; set; }
        private List<BanLogic> _protocolSteps;
        public BanLogic()
        {
            _protocolSteps = new List<BanLogic>();
        }
        public BanLogic(string protocolList)
        {
            ProtocolList = protocolList;
            _protocolSteps = new List<BanLogic>();
            SplitProtocolSteps();
        }

        private bool SplitProtocolSteps()
        {
//            _protocolSteps = ProtocolList.Split('\n').ToList();
            return true;
        }

        private bool InterpretProtocolStep(string protocolStep)
        {
//            Regex.s
            return true;
        }
        public string IdealizingProtocol()
        {
            if (_protocolSteps.Count <= 0)
            {
                SplitProtocolSteps();
            }
            return string.Join(",",_protocolSteps);
        }
    }
}
