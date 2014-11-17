namespace Axh.Wedding.Application.Config
{
    using System;
    using System.Configuration;

    using Axh.Wedding.Application.Contracts.Config;

    public class WeddingConfig : IWeddingConfig
    {
        public WeddingConfig()
        {
            this.Bride = ConfigurationManager.AppSettings["Bride"];
            this.Groom = ConfigurationManager.AppSettings["Groom"];
            this.Venue = ConfigurationManager.AppSettings["Venue"];
            this.Date = DateTime.Parse(ConfigurationManager.AppSettings["Date"]);
        }

        public string Bride { get; private set; }

        public string Groom { get; private set; }

        public string Venue { get; private set; }

        public DateTime Date { get; private set; }
        
    }
}
