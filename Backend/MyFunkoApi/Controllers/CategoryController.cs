using Microsoft.AspNetCore.Mvc;
using MyFunkoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MyApi.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
     private readonly ILogger<CategoryController> _logger;

     private AnaiahFunkoDatabaseContext _context;

     public CategoryController(ILogger<CategoryController> logger ,AnaiahFunkoDatabaseContext dbContext){
         _logger = logger;
         _context = dbContext;
     }

      [HttpGet]

         public ActionResult getCategory(){
            return Ok(_context.Categories.ToList());
         }
 

    }
}