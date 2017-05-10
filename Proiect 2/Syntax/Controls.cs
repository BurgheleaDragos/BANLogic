using System;
using Proiect_2.Elements;

namespace Proiect_2.Syntax
{
    public class Controls : BaseLogic
    {
        public Agent Agent1 { get; set; }
        public BaseLogic Formula { get; set; }

        public override string ToString()
        {
            return $"{Agent1} controls {Formula}";
        }
        public override bool Equals(object obj)
        {
            var controls = obj as Controls;
            if (controls == null) return false;
            return Agent1!=null && Agent1.Equals(controls.Agent1) &&
                (Message != null && controls.Message == Message ||
                   controls.Formula != null && controls.Formula.Equals(Formula));
        }
    }
}