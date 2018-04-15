using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab4.Models
{
    public class ValCalcomanias
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Identificador")]
        public string name { get; set; }
        [Display(Name = "Pais o Especial")]
        public string pais { get; set; }
        [Display(Name = "Numero de Estampa")]
        public string etiqueta { get; set; }
        [Display(Name = "Valor(True or False)")]
        public bool valor { get; set; }
        [Display(Name = "Valor(True or False)")]
        public string SValor { get; set; }
    }
}