using System;
using System.Runtime.Serialization;

namespace Altkom._20_22._11.CSharp.Module2.Models
{
    [Serializable]
    internal class ClassFullException : Exception
    {
        //TODO 9.1a: Dodaj właściwość ClassName tylko do odczytu. Będzie w niej przechowywane oznaczenie klasy (grupy studentów), która wywołała wyjątek.
        public ClassFullException()
        {
        }
        
        //TODO 9.1b: Przekaż parametry konstruktorów bezpośrednio do konstruktorów klasy bazowej
        public ClassFullException(string message)
        {
        }

        public ClassFullException(string message, Exception innerException)
        {
        }

        protected ClassFullException(SerializationInfo info, StreamingContext context)
        {
        }

        //TODO 9.1c: Dodaj konstrukory przyjmujące dodatkowo oznaczenie klasy (grupy studentów)

        protected ClassFullException(SerializationInfo info, StreamingContext context)
    : base(info, context)
        {
            ClassName = info.GetString("ClassName");
        }


        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentException("info");
            }
            base.GetObjectData(info, context);
            info.AddValue("ClassName", ClassName, typeof(string));
        }
    }
}