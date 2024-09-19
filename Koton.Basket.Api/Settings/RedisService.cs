using StackExchange.Redis;

namespace Koton.Basket.Api.Settings
{
    public class RedisService(string host, int port)
    {
        private readonly string _host = host;
        private readonly int _port = port;
        private ConnectionMultiplexer _connectionMultiplexer;

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        public IDatabase GetDb(int db = 1)=>_connectionMultiplexer.GetDatabase(0);
    }
}
