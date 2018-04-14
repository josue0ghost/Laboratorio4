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
        public List<int> Faltantes { get; set; }
        public List<int> Coleccionadas { get; set; }
        public List<int> Cambios { get; set; }

    }
}