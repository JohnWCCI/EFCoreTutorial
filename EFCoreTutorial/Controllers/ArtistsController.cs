using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreTutorial.Context;
using EFCoreTutorial.Models;
using EFCoreTutorial.Repositories.Interfaces;

namespace EFCoreTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : BaseController<Artist>
    {
      
        

        public ArtistsController(IArtistRepository repository) 
            : base(repository)
        {
           
        }

        
    }
}
