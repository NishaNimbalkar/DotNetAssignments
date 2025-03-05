using System.Runtime.Serialization;

namespace Menu_Driven_Application_Hackthon.Repository
{
    [Serializable]
    internal class PolicyNotFoundException : System.Exception
    {
        public PolicyNotFoundException()
        {
        }

        public PolicyNotFoundException(string? message) : base(message)
        {
        }

        public PolicyNotFoundException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }

        protected PolicyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}