namespace Event_Management_System.Exceptions
{
    public class EventNotFoundException:ApplicationException
    {
        public EventNotFoundException()
        {
            
        }
        public EventNotFoundException(string msg):base(msg)
        {
            
        }
    }
}
