namespace LogsAPI.Interfeces
{
    public interface IMongoDBSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
