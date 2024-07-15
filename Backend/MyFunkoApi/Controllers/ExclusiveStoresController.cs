using Microsoft.AspNetCore.Mvc;
using MyFunkoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MyApi.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class ExclusiveStoresController : ControllerBase
    {
     private readonly ILogger<ExclusiveStoresController> _logger;

     private AnaiahFunkoDatabaseContext _context;

     public ExclusiveStoresController(ILogger<ExclusiveStoresController> logger ,AnaiahFunkoDatabaseContext dbContext){
         _logger = logger;
         _context = dbContext;
     }

      [HttpGet]

         public ActionResult getMaterials(){
            return Ok(_context.ExclusiveStores.ToList());
         }
 

    }
}