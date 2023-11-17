using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeManagement.Interfaces;

namespace RecipeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        private readonly ILoggingService _loggingService;
        private readonly IMapper _mapper;
        public LoggingController(ILoggingService loggingService, IMapper mapper)
        {
            _loggingService = loggingService;
            _mapper = mapper;
        }
    }
}
