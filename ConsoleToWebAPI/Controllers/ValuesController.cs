using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] //base url
    public class ValuesController : ControllerBase
    {
        //multiple url for same resource are possible untill they are unique
        [Route("~/api/get-all")]
        [Route("~/getall")]
        [Route("~/get-all")]
        //[Route("[controller]/[action]")] //token replacement
        public string GetAll()
        {
            return "Hello from Get All";
        }
        //[Route("api/get-all-authors")]
        //[Route("getall")] this is not possible since not unique, same url for multiple resource not possible
        //[Route("[controller]/[action]")]  //token replacement
        public string GetAllAuthors()
        {
            return "Hello from Get All Authors";
        }

        //[Route("books/{id}")]
        [Route("{id}")]
        public string GetAllById(int id)
        {
            return "Hello "+id;
        }

        [Route("{id}/author/{s}")] //for passing variable with base route
        public string GetAllAuthorsById(int id,string s)
        {
            return "Hello " +s+" "+ id;
        }

        //[Route("search")]
        public string SearchBooks(int id, string name,int price,int rating)
        {
            return "Hello from search";
        }
    }

}
