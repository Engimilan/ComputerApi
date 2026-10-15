using computerwebshop.models;
using computerwebshop.models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace computerwebshop.Controllers
{
    [Route("Computer")]
    [ApiController]
    public class ComputerController : Controller
    {

        public ComputerShopDbContext context = new();
        [HttpGet("Getall")]

        public object GetallComputer()
        {
            var computers = context.Comps.ToList();

            if (computers.Count > 0)
            {
                return StatusCode(200, new { message = "JÓ", result= computers });
            }

            return StatusCode(404, new { message = "NEM JÓ" , result = computers });
        }

        [HttpGet("GetById")]

        public object GetById([FromQuery] Guid id) 
        {
            var computers = context.Comps.SingleOrDefault(x => x.Id == id);

            if (computers != null)
            {
                return StatusCode(200, new { message = "JÓ", result = computers });
            }

            return StatusCode(404, new { message = "NEM JÓ", result = computers });
        }

        [HttpPost("NewComputer")]

        public object NewComputer([FromBody]AddNewComputerDTO addnewcomp )
        {
            var computers = new Comp
            {
                Id = Guid.NewGuid(),
                Brand = addnewcomp.Brand,
                Type = addnewcomp.Type,
                Display = addnewcomp.Display,
                Memory = addnewcomp.Memory,
                CreatedTime = DateTime.Now,
                Osid = addnewcomp.Osid
            };

            if (computers != null)
            {
                context.Comps.Add(computers);
                context.SaveChanges();

                return StatusCode(201, new { message = "JÓ", result = computers });
            }

            return StatusCode(400, new { message = "NEM JÓ", result = computers });

        }

        [HttpPut("UpdateComp")]
        public object UpdateComputer([FromQuery] Guid id, [FromBody] UpdateComputer updatecomp)
        {

            var computers = context.Comps.Find(id);
       
            if (computers != null)
            {
                computers.Brand = updatecomp.Brand;
                computers.Type = updatecomp.Type;
                computers.Display = updatecomp.Display;
                computers.Memory = updatecomp.Memory;

                context.Comps.Add(computers);
                context.SaveChanges();

                return StatusCode(201, new { message = "JÓ", result = computers });
            }

            return StatusCode(400, new { message = "NEM JÓ", result = computers });

        }

        [HttpDelete]
        public object DeleteById([FromQuery] Guid id)
        {
            var computers = context.Comps.FirstOrDefault(x => x.Id == id);

            if (computers != null)
            {
                context.Comps.Remove(computers);
                context.SaveChanges();
                return StatusCode(204);
            }

            return StatusCode(404, new { message = "NEM JÓ", result = computers });
        }

        [HttpGet("OsWithComputers")]

        public object AllOsComputers()
        {
            var valami = context.Osystems.Include(x =>x.Computers);

            return StatusCode(200, new { message = "JÓ", result = valami });
        }

        [HttpGet("GetOsComputers")]

        public object GetOsComputer()
        {
            var compos = context.Comps.Join(context.Osystems, c => c.Osid, o => o.Id, (c , o) => new {c, o.Name, o.Version});

            return StatusCode(200, new { message = "JÓ", result = compos });
        }




    }
}
