using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestingMongoDb.Models;
using MongoDB.Driver.Linq;
using TestingMongoDb.Services;
using System.Web.Http.Cors;

namespace TestingMongoDb.Controllers
{
    public class ValuesController : ApiController
    {

        private BookService _BookService = new BookService();

        [HttpGet, Route("api/AllBooks")]
        [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
        public List<Books> CustomMethod()
        {
            var List = _BookService.FindAll();
            return List;
        }


        [HttpGet, Route("api/FindByName/{Name}")]
        public void CustomMethod1(string Name)
        {
            var RequiredBook = _BookService.FindByBookName(Name);
        }

        [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
        [HttpPost, Route("api/InsertBook")]
        public void CustomMethod2([FromBody] Books book)
        {
            var IsCreated = _BookService.Create(book);
        }


        [HttpGet, Route("api/DeleteBook/{Name}")]
        public void CustomMethod3(string Name)
        {
            var IsDeleted = _BookService.RemoveByAuthorName(Name);
        }
        //[HttpGet, Route("api/CustomMethod/{price}")]
        //public string CustomMethod(double price)
        //{
        //    var names = new List<string>();
        //    //IMongoCollection<Book> _books;
        //    string ConStr = ConfigurationManager.ConnectionStrings["MongoDbConString"].ConnectionString;
        //    var client = new MongoClient(ConStr);
        //    var database = client.GetDatabase("BookstoreDb");
        //    var collection = database.GetCollection<Book>("Books");
        //    var query = from e in collection.AsQueryable<Book>()
        //                where e.Author == "Ralph Johnson"
        //                select e;
        //    string Name = null;
        //    foreach (var employee in query)
        //    {
        //        Name = employee.Author;// process employees named "John"
        //        return Name;
        //    }
        //    return "Not Executed!";
        //}

        //[HttpGet,Route("api/MyMethod/{firstItem}/{secondItem}")] 
        //public void CustomMethod2(string firstItem,string secondItem)
        //{     
        //    var names = new List<string>();
        //    IMongoCollection<Book> _books;
        //    string ConStr = ConfigurationManager.ConnectionStrings["MongoDbConString"].ConnectionString;
        //    var client = new MongoClient(ConStr);
        //    var database = client.GetDatabase("BookstoreDb");
        //    _books = database.GetCollection<Book>("Books"); 
        //}
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        //public void CustomMethod(int price)
        //{
        //    var names = new List<Info>();
        //    IMongoCollection<Info> Persons;
        //    string ConStr = ConfigurationManager.ConnectionStrings["MongoDbConString"].ConnectionString;
        //    var client = new MongoClient(ConStr);
        //    var database = client.GetDatabase("test");
        //    Persons = database.GetCollection<Info>("persons");
        //    var filter = Builders<Info>.Filter.Empty;
        //    var ass = Persons.Find(filter).ToListAsync().Result.ToArray();
        //    //foreach (Info Aperson in )
        //    //{
        //    //    names.Add(Aperson);
        //    //}

        //}


    }
}
