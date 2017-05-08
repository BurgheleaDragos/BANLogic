using System;

namespace Proiect_2.Elements
{
    public class Key
    {
        public string Name { get; set; }
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