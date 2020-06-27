using Data.Models;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Bson;
using System;
using System.Drawing;

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

        public async Task<Quote> GetRandomQuote()
        {
            Random rand = new Random();
            var count = await _quotes.Find(i => true).CountDocumentsAsync();
            var number = rand.Next(1, Convert.ToInt32(count));
            var rec = await _quotes.Find(i => true).Skip(number).FirstOrDefaultAsync();
            return rec;
        }

    }
}