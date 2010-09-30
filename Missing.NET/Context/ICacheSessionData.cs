namespace Missing.Context
{
    public interface ICacheSessionData
    {
        T Get<T>(string key);
        object this[string name] { get; set; }
    }
}