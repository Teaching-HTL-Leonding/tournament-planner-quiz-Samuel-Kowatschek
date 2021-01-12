using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentPlanner.Data;

namespace TournamentPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentPlannerController : ControllerBase
    {
        private readonly TournamentPlannerDbContext context;

        public TournamentPlannerController(TournamentPlannerDbContext context)
        {
            this.context = context;
        }
    }
}
