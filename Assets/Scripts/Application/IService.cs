namespace Application
{
    public interface IService
    {
        public string MessageID();
        public void Init(object data);
        public void Execute();
    }
}