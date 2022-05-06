using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Personas.DT.Mensajes;
using Personas.ET.Mensajes;
using Personas.ET.Personas;
using Personas.NG.Perssonas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Personas.Controllers
{
        [Route("api/personas")]
         [ApiController]
    public class PersonasController : ControllerBase
        {
        private INGPersonas objPersona;
        private readonly IWebHostEnvironment _hostingEnviroment;
        private readonly IHttpContextAccessor _accessor;
        private readonly IConfiguration _configuration;
        
        private readonly string usuario;
        private readonly string Clave;


        public PersonasController(IConfiguration configuration, INGPersonas IPersonas, IWebHostEnvironment hostingEnviroment, IHttpContextAccessor accessor)
        {
            objPersona = IPersonas;
            _hostingEnviroment = hostingEnviroment;
            _configuration = configuration;
            _accessor = accessor;

            var ctx = _accessor.HttpContext;

            if (ctx != null && ctx.Request != null && ctx.Request.Headers != null)
            {
                string authentication = ctx.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.FirstOrDefault();
                if (!string.IsNullOrEmpty(authentication))
                {
                    string[] svcCredentials = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(authentication.Replace("Basic ", ""))).Split(':');
                    if (svcCredentials.Length == 2)
                    {
                        usuario = svcCredentials[0];
                        Clave = svcCredentials[1];
                    }
                }
            }
        }


        [HttpGet]
        [Route("ConsultarPersonas")]
        [EnableCors("AllowOrigin")]

        public ActionResult<DTRespuesta<IList<DTPersonas>>> ConsultarPersona()
        {

            DTRespuesta<IList<DTPersonas>> respuesta = new DTRespuesta<IList<DTPersonas>>();
            DTMensaje mensaje = new DTMensaje();

            

            try
            {
                if (Environment.GetEnvironmentVariable("Usuario").Equals(usuario) && Environment.GetEnvironmentVariable("Clave").Equals(Clave))
                {
                    respuesta = objPersona.ConsultarPersona();

                    mensaje.mensaje = mensajes.mensaje_1;
                    mensaje.Error = false;

                    respuesta.Mensaje = mensaje;
                }
                else
                {
                    mensaje.mensaje = mensajes.mensaje_1;
                    mensaje.Error = false;

                    respuesta.Mensaje = mensaje;
                    respuesta.Data = null;
                }
            }
            catch (Exception ex)
            {
                mensaje.mensaje = mensajes.mensaje3;
                mensaje.Error = false;

                respuesta.Mensaje = mensaje;
                respuesta.Data = null;

            }
            return respuesta;
        }

    }
 }

