using System;
using System.Linq;
using AutoMapper;
using CoreTraining.Models;
using CoreTraining.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly HubContext _context;

        public PropertyController(
            IMapper mapper,
            HubContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        [HttpGet]
        public PropertyViewModel Get(Guid id)
        {
            var property = _context.Properties
                .Include(x => x.Address)
                .SingleOrDefault(x => x.Id == id);
            return property != null ? _mapper.Map<PropertyViewModel>(property) : null;
        }
    }
}
