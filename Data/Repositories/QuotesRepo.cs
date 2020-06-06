using Data.Models;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Bson;
using System;

namespace Data.Repositories
{
    public class QuotesRepo : IQuotesRepo
    {
        private readonly IMongoCollection<Quote> _quotes;
        public QuotesRepo(IQuotesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _quotes = database.GetCollection<Quote>(settings.QuotesCollection);

        }

        public async Task<List<Quote>> GetAllQuotes()
        {
            var quotes = await _quotes.Find(i => true).ToListAsync();
            return quotes;
        }
        public async Task<Quote> GetQuoteById(ObjectId Id)
        {
            return await _quotes.Find(i => i.Id == Id).FirstOrDefaultAsync();
            
        }
        public async Task<Quote> CreateQuote(Quote quote)
        {
            await _quotes.InsertOneAsync(quote);
            return quote;
        }

        public async Task<List<Quote>> GetQuotesByCatagory(string catagory)
        {
            var quotes = await _quotes.Find<Quote>(i => i.Catagory.Name.ToUpper() == catagory.ToUpper()).ToListAsync();
            return quotes;
        }

        public async Task DeleteQuoteById(ObjectId Id)
        {
           await _quotes.DeleteOneAsync(i => i.Id == Id);

        }

        public async Task UpdateQuote(ObjectId Id, Quote quoteIn)
        {
            quoteIn.Id = Id;
            await _quotes.ReplaceOneAsync(i => i.Id == Id, quoteIn);

        }
    }
}