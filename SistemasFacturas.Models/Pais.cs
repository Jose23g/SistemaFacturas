﻿using System.ComponentModel.DataAnnotations;

namespace SistemasFacturas.Models
{
    public class Pais
    {
        [Key]
        public int Id_pais { get; set; }
        public string Nombre_Pais { get; set; }
    }
}
