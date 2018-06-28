namespace TodoApi.Models
{
    public class Ticker
    {
        public TickerData Data { get; set; }
    }

    public class TickerData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}