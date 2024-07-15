using Microsoft.AspNetCore.Mvc;
using MyFunkoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MyApi.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class EditionsController : ControllerBase
    {
     private readonly ILogger<EditionsController> _logger;

     private AnaiahFunkoDatabaseContext _context;

     public EditionsController(ILogger<EditionsController> logger ,AnaiahFunkoDatabaseContext dbContext){
         _logger = logger;
         _context = dbContext;
     }

      [HttpGet]

         public ActionResult getEditions(){
            return Ok(_context.Editions.ToList());
         }
 

    }
}