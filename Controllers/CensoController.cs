using apiRESTAdminUsuarioTADS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apiRESTAdminUsuarioTADS.Controllers
{
    public class CensoController : ApiController
    {
        // Definición del arreglo de objetos
        public static clsCenso[] objCenso = null;

        // Constructor para inicializar el arreglo
        public CensoController()
        {
            if (objCenso == null)
            {
                objCenso = new clsCenso[5];
                for (int i = 0; i < objCenso.Length; i++)
                {
                    objCenso[i] = new clsCenso();
                }
            }
        }

        // GET: api/Censo
        [HttpGet]
        public IEnumerable<clsCenso> Get()
        {
            return objCenso;
        }

        // GET: api/Censo/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var elemento = objCenso.FirstOrDefault(c => c.id == id);
            if (elemento == null || elemento.id == 0)
            {
                return NotFound(); // 404 si no lo encuentra
            }
            return Ok(elemento);
        }

        // POST: api/Censo?posicion=0
        [HttpPost]
        public string Post(int posicion, [FromBody] clsCenso modelo)
        {
            string ban = "";

            if (posicion >= 0 && posicion <= 4)
            {
                objCenso[posicion].id = modelo.id;
                objCenso[posicion].curp = modelo.curp;
                objCenso[posicion].nombre = modelo.nombre;
                objCenso[posicion].apellidoPaterno = modelo.apellidoPaterno;
                objCenso[posicion].apellidoMaterno = modelo.apellidoMaterno;
                objCenso[posicion].direccion = modelo.direccion;
                objCenso[posicion].actividadEconomica = modelo.actividadEconomica;
                ban = "1";
            }
            else
            {
                ban = "0";
            }

            return ban;
        }

        // PUT: api/Censo?posicion=0
        [HttpPut]
        public string Put(int posicion, [FromBody] clsCenso modelo)
        {
            string ban;

            if (objCenso != null)
            {
                if (posicion >= 0 && posicion <= 4)
                {
                    objCenso[posicion].id = modelo.id;
                    objCenso[posicion].curp = modelo.curp;
                    objCenso[posicion].nombre = modelo.nombre;
                    objCenso[posicion].apellidoPaterno = modelo.apellidoPaterno;
                    objCenso[posicion].apellidoMaterno = modelo.apellidoMaterno;
                    objCenso[posicion].direccion = modelo.direccion;
                    objCenso[posicion].actividadEconomica = modelo.actividadEconomica;
                    ban = "1";
                }
                else
                {
                    ban = "0";
                }
            }
            else
            {
                ban = "-1";
            }

            return ban;
        }

        // DELETE: api/Censo?posicion=0
        [HttpDelete]
        public string Delete(int posicion)
        {
            string ban;

            if (objCenso != null)
            {
                if (posicion >= 0 && posicion <= 4)
                {
                    objCenso[posicion].id = 0;
                    objCenso[posicion].curp = null;
                    objCenso[posicion].nombre = null;
                    objCenso[posicion].apellidoPaterno = null;
                    objCenso[posicion].apellidoMaterno = null;
                    objCenso[posicion].direccion = null;
                    objCenso[posicion].actividadEconomica = null;
                    ban = "1";
                }
                else
                {
                    ban = "0";
                }
            }
            else
            {
                ban = "-1";
            }

            return ban;
        }
    }
}
