using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class QuotesDatabaseSettings : IQuotesDatabaseSettings
    {
        public string QuotesCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IQuotesDatabaseSettings
    {
        string QuotesCollection { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
