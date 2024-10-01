using UnityEngine.Events;

namespace Application
{
    public abstract class AService
    {
        public delegate void HandleResponse(string messageID, object data);
        public delegate void HandleError(string messageID, string error);
        public abstract string MessageID();
    }
}