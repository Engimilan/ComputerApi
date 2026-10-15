using computerwebshop.models;
using computerwebshop.models.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace computerwebshop.Controllers
{
    [Route("osystems")]
    [ApiController
        ]
    public class OsystemController : ControllerBase
    {
        public ComputerShopDbContext _context = new();
        [HttpPost]

        public object AddNewOsystems([FromBody] AddNewOsystem addnewosystem)
        {
            var osystem = new Osystem
            {
                Id = Guid.NewGuid(),
                Name = addnewosystem.Name,
                Version = addnewosystem.Version,
                RegisterTime = DateTime.Now,
                UpdateTime = DateTime.Now,
            };

            if (osystem != null)
            {
                _context.Osystems.Add(osystem);
                _context.SaveChanges();

                return StatusCode(201, new { message = "siker", result = addnewosystem });
            }
            return StatusCode(404, new { message = "Nem jó", result = addnewosystem });
        }

        [HttpGet]

        public object GetAll()
        {
            var result = _context.Osystems.ToList();

            if (result.Count > 0)
            {
                return StatusCode(200, new { message = "siker", result = result });
            }
            return StatusCode(400, new { message = "Nem jó", result = result });
        }

        [HttpDelete]

        public object DeleteOsystem([FromQuery]Guid id ) 
        {  
            var osystem = _context.Osystems.FirstOrDefault(o =>o.Id == id);

            if (osystem != null)
            {
                _context.Osystems.Remove(osystem);
                _context.SaveChanges();
                return StatusCode(200, new { message = "siker", result = osystem });
            }
            return StatusCode(404, new { message = "Nem jó", result = "" });

        }

        [HttpPut]

        public object UpdateOsystem([FromQuery,]Guid id, UpdateDTO updatedto)
        {
            var osystem = _context.Osystems.Find(id);

            if (osystem != null)
            {
                osystem.Name=updatedto.Name;
                osystem.Version=updatedto.Version;
                osystem.UpdateTime= DateTime.Now;

                _context.Osystems.Update(osystem);
                _context.SaveChanges();
                return StatusCode(200, new { message = "siker", result = osystem });
            }
            return StatusCode(404, new { message = "Nem jó", result  = "" });
        }
    }
}