using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemasFacturas.Models
{
    public enum TipoIdentificacion
    {
        [Display(Name = "Cédula Física")]
        Física = 1,
        [Display(Name = "Cédula Jurídica")]
        Jurídica = 2,
        [Display(Name = "DIMEX")]
        DIMEX = 3,
        [Display(Name = "NITE")]
        NITE = 4
    }
}
