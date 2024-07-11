using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    // <summary>
    /// Excepción personalizada que se lanza cuando se intenta agregar elementos a un cajon que ya está lleno.
    /// </summary>
    public class CajonLLenoException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CajonLLenoException"/> con un mensaje de error especificado.
        /// </summary>
        /// <param name="mensaje">El mensaje que describe el error.</param>
        public CajonLLenoException(string mensaje) : base(mensaje)
        {

        }

    }
}
