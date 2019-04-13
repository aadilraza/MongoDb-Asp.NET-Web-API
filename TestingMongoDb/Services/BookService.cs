using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using TestingMongoDb.Models;

namespace TestingMongoDb.Services
{
    public class BookService
    {
        private MongoClient MongoClient;
        private readonly IMongoCollection<Books> booksCollection;

        public BookService()
        {
            MongoClient = new MongoClient(ConfigurationManager.AppSettings["MongoDbHost"]);
            var Db = MongoClient.GetDatabase(ConfigurationManager.AppSettings["MongoDbName"]);
            booksCollection = Db.GetCollection<Books>("Books");
        }


        public List<Books> FindAll()
        {
            return booksCollection.AsQueryable<Books>().ToList();
        }

        public Books FindByBookName(string Name)
        {
            var Found = booksCollection.Find<Books>(book => book.BookName == Name).FirstOrDefault();
            return Found;
        }

        public bool Create(Books book)
        {
            try
            {
                booksCollection.InsertOne(book);
                return true;
            }
            catch(Exception ex)
            {
                var Error = ex.ToString();
                return false;
            }
        }

        //public void Update(string id, Book bookIn)
        //{
        //    _books.ReplaceOne(book => book.Id == id, bookIn);
        //}

        public bool RemoveByAuthorName(string AuthorName)
        {
            try
            {
                booksCollection.DeleteOne(x => x.Author == AuthorName);
                return true;
            }
            catch (Exception ex)
            {
                var Error = ex.ToString();
                return false;
            }
           
        }

    }
}