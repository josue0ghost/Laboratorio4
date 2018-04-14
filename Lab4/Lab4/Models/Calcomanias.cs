using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab4.Models
{
    public class Calcomanias
    {
        [Key]
        public int id {get; set;}
        public string name { get; set; }
        public string Faltantes { get; set; }
        public string Coleccionadas { get; set; }
        public string Cambios { get; set; }

    }
}