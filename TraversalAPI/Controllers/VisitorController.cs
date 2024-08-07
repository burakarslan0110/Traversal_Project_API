using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraversalAPI.DAL.Entities;
using TraversalAPI.DataAccessLayer.Context;

namespace TraversalAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public ActionResult VisitorList()
        {
            using(var context = new VisitorContext())
            {
                var values = context.Visitors.ToList();
                return Ok(values);
            }
        }

        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {

                    context.Add(visitor);
                    context.SaveChanges();
                    return Ok(context);
            }
        }

        [HttpGet("{id}")]
        public ActionResult VisitorGetByID(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if(values==null) return NotFound();
                else return Ok(values);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult VisitorDelete(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if(values==null) return NotFound();
                else
                {
                    context.Remove(values);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }

        [HttpPut]
        public IActionResult UpdateVisitor(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Find<Visitor>(visitor.VisitorID);
                if(values==null) return NotFound();
                else
                {
                    values.Name = visitor.Name;
                    values.Surname = visitor.Surname;
                    values.City = visitor.City;
                    values.Country = visitor.Country;
                    values.Email = visitor.Email;
                    context.Update(values);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}
