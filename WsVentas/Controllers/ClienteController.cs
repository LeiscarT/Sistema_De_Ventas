using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WsVentas.Models;
using WsVentas.Models.Response;
using WsVentas.Models.Request;

namespace WsVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Response response = new Response();

            try
            {

                using (SistemaDeVentasContext db = new SistemaDeVentasContext())
                {
                    var list = db.Clientes.ToList();
                    response.Exito = 1;
                    response.Data = list;
                   
                }

            }

            catch(Exception ex)
            {
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]

        public IActionResult Add(ClienteRequest oModel)
        {
            Response response = new Response();

            try
            {
                using (SistemaDeVentasContext db = new SistemaDeVentasContext())
                {
                    Cliente oCliente = new Cliente();

                    oCliente.Nombre = oModel.Nombre;
                    db.Clientes.Add(oCliente);
                    db.SaveChanges();

                    response.Exito = 1;
                }

            }

            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]

        public IActionResult edit (ClienteRequest oModel)
        {
            Response response = new Response();
            try
            {
                using (SistemaDeVentasContext db = new SistemaDeVentasContext()) {
                    Cliente oCliente = db.Clientes.Find(oModel.Id);
                    oCliente.Nombre = oModel.Nombre;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    response.Exito = 1;

                        }
            }
            catch (Exception ex)
            {

                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete ("{Id}")]

        public IActionResult delete(int id)
        {
            Response response = new Response();
            try
            {
                using(SistemaDeVentasContext db = new SistemaDeVentasContext())
                {
                    Cliente cliente = db.Clientes.Find(id);
                    db.Remove(cliente);
                    db.SaveChanges();
                    response.Exito = 1;
                }
            }
            catch (Exception ex )
            {

                response.Mensaje = ex.Message;
            }

            return Ok(response);

        }


    }
}
