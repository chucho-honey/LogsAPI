namespace LogsAPI.Interfeces
{
    public interface IMongodbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
