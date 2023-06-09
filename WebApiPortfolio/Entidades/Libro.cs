﻿using System.ComponentModel.DataAnnotations;
using WebApiPortfolio.Validaciones;

namespace WebApiPortfolio.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        [PrimeraLetraMayuscula]
        [StringLength(maximumLength: 250)]
        public string Titulo { get; set; }
    }
}
