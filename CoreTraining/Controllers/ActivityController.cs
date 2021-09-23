using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CoreTraining.ViewModels;

namespace CoreTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly HubContext _context;

        public ActivityController(
            IMapper mapper,
            HubContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        [HttpGet]
        public IEnumerable<ActivityViewModel> Get()
        {
            var activities = _context.Activity.ToList();
            return _mapper.Map<List<ActivityViewModel>>(activities);
        }
    }
}
