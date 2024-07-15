using Microsoft.AspNetCore.Mvc;
using MyFunkoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MyApi.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialsController : ControllerBase
    {
     private readonly ILogger<MaterialsController> _logger;

     private AnaiahFunkoDatabaseContext _context;

     public MaterialsController(ILogger<MaterialsController> logger ,AnaiahFunkoDatabaseContext dbContext){
         _logger = logger;
         _context = dbContext;
     }

      [HttpGet]

         public ActionResult getMaterials(){
            return Ok(_context.Materials.ToList());
         }
 

    }
}