using System;
using System.Runtime.Serialization;

namespace Altkom._20_22._11.CSharp.Module2.Models
{
    [Serializable]
    internal class ClassFullException : Exception
    {
        public string ClassName { get; }

        public ClassFullException()
        {
        }

        public ClassFullException(string message) : base(message)
        {
        }

        public ClassFullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ClassFullException(string className, string message) : this(message)
        {
            ClassName = className;
        }

        public ClassFullException(string className, string message, Exception innerException) : this(message, innerException)
        {
            ClassName = className;
        }


        protected ClassFullException(SerializationInfo info, StreamingContext context) : base(info, context)
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