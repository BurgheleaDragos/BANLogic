namespace Proiect_2.Syntax
{
    public class BaseLogic
    {
        public string Message { get; set; }

        public override string ToString()
        {
            return Message;
        }

//        public override bool Equals(object obj)
//        {
//            var bl = obj as BaseLogic;
//            if (bl == null) return false;
//            return Message == bl.Message;
//        }
    }

}