namespace DrozdHW_AQA.Interface
{
    public interface IEmailSender
    {
        void Send(string to, string text);
    }
}
