using Insight.Database;
using Personas.ET.Settings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AccesoDatos.DM.Insight
{
    public class DMInsight
    {
        public static SqlConnection DefaultCon(ETSettings settings)
        {
            SqlInsightDbProvider.RegisterProvider();

            return new SqlConnection(settings.strCon);
        }
    }
}
