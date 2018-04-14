using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Lab4.Clases
{
    public class JsonConverter<T, X>
    {
        public List<Dictionary<T, X>> datosJson(Stream ruta)
        {
            try
            {
                List<Dictionary<T,X>> info;
                StreamReader lector1 = new StreamReader(ruta);
                string infoJson = lector1.ReadToEnd();
                info = JsonConvert.DeserializeObject<List<Dictionary<T,X>>>(infoJson);
                lector1.Close();
                return info;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}