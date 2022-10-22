using LogsAPI.Entities;
using LogsAPI.Interfeces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LogsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogController : Controller
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpGet]
        public ActionResult<List<Log>> Get() => _logService.Get();

        [HttpGet("{id:length(24)}", Name = "GetLog")]
        public ActionResult<Log> Get(string id)
        {
            var log = _logService.GetById(id);

            if (log == null)
            {
                return NotFound();
            }

            return log;
        }

        [HttpPost]
        public ActionResult<Log> Create(Log log)
        {
            var _log = _logService.Create(log);
            return CreatedAtRoute("GetLog", new { id = _log.Id.ToString() }, _log);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Log bookIn)
        {
            var log = _logService.GetById(id);

            if (log == null)
            {
                return NotFound();
            }

            _logService.Update(id, bookIn);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var log = _logService.GetById(id);

            if (log == null)
            {
                return NotFound();
            }

            _logService.Remove(id);

            return Ok();
        }
    }
}
