using System;
using System.Collections.Generic;

namespace Proiect_2.Elements
{
    public class Agent
    {
        public string Name { get; set; }
        public List<object> Knownledge { get; set; }

        public override bool Equals(object obj)
        {
            var agent = obj as Agent;
            if (agent != null && !agent.Name.Equals(this.Name, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return Name;
        }
    }

}