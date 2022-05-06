using System;
using System.Collections.Generic;
using System.Text;

namespace Personas.ET.Mensajes
{
    public class DTRespuesta <T>
    {
        public T Data { get; set; }
        public DTMensaje Mensaje { get; set; }
    }
}
