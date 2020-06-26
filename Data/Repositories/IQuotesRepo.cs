using Data.Models;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IQuotesRepo
    {
        Task<Quote> CreateQuote(Quote quote);
        Task<List<Quote>> GetQuotesByCatagory(string catagory);
        Task<List<Quote>> GetAllQuotes();
        Task<Quote> GetQuoteById(ObjectId Id);
        Task DeleteQuoteById(ObjectId Id);
        Task UpdateQuote(ObjectId Id, Quote quoteIn);
        Task<Quote> GetRandomQuote();
    }
}