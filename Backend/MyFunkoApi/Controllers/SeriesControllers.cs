using Microsoft.AspNetCore.Mvc;
using MyFunkoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MyApi.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class SeriesController : ControllerBase
    {
     private readonly ILogger<SeriesController> _logger;

     private AnaiahFunkoDatabaseContext _context;

     public SeriesController(ILogger<SeriesController> logger ,AnaiahFunkoDatabaseContext dbContext){
         _logger = logger;
         _context = dbContext;
     }

      [HttpGet]

         public ActionResult getMaterials(){
            return Ok(_context.Series.ToList());
         }
 

    }
}