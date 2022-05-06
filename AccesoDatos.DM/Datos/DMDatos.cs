using Insight.Database;
using Personas.ET.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.DM.Datos
{
    public class DMDatos <T>
    {
        public  IList<T> consultar(string sp, object entity, ETSettings settings)
        {
            IList<T> response = Insight.DMInsight.DefaultCon(settings).Query<T>(sp,entity, commandTimeout: 3000);

            return response;
        }
    }
}
