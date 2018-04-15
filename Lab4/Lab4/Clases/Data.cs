using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab4.Models;

namespace Lab4.Clases
{
    public class Data
    {
        private static Data instance = null;

        public static Data Instance
        {
            get
            {
                if (instance == null) instance = new Data();
                return instance;
            }
        }
        public Dictionary<string, Calcomanias> coleccion = new Dictionary<string, Calcomanias>();
        public Dictionary<string, ValCalcomanias> ValoresColeccion = new Dictionary<string, ValCalcomanias>();
    }
}