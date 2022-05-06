using AccesoDatos.DM.Datos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Personas.DT.Mensajes;
using Personas.ET.Mensajes;
using Personas.ET.Personas;
using Personas.ET.Settings;
using Personas.Soporte.Recursos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personas.NG.Perssonas
{
    public class NGPersonas : INGPersonas
    {

        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnviroment;
        
        ETSettings settings = new ETSettings();

        public NGPersonas(IConfiguration configuration, IHostingEnvironment hostingEnviroment)
        {
            _configuration = configuration;
            _hostingEnviroment = hostingEnviroment;       
            settings.strCon = Environment.GetEnvironmentVariable("stringConn");

        }
        public DTRespuesta<IList<DTPersonas>> ConsultarPersona()
        {

            DTRespuesta<IList<DTPersonas>> respuesta = new DTRespuesta<IList<DTPersonas>>();
            DTMensaje mensaje = new DTMensaje();

            try
            {
                DTPersonas persona = new DTPersonas();
                IList<DTPersonas> dtPersonas = new DMDatos<DTPersonas>().consultar(Procedimientos.SpConsultar, persona, settings);
                respuesta.Data = dtPersonas;
            }
            catch (Exception ex)
            {

                mensaje.mensaje = mensajes.mensaje4;
                mensaje.Error = false;

                respuesta.Mensaje = mensaje;
                respuesta.Data = null;
            }

            return respuesta;
        }
    }
}
