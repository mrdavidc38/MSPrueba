using Personas.ET.Mensajes;
using Personas.ET.Personas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personas.NG.Perssonas
{
    public interface INGPersonas
    {
       public DTRespuesta<IList<DTPersonas>> ConsultarPersona();
    }
}
