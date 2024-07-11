using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfaz para serializar objetos a XML.
    /// </summary>
    public interface ISerializar
    {
        /// <summary>
        /// Serializa el objeto actual a un archivo XML en la ubicacion especificada.
        /// </summary>
        /// <param name="path">Ruta del archivo XML donde se va a serializar el objeto.</param>
        /// <returns>True si serializa, False de lo contrario.</returns>
        bool Xml(string path);
    }
}
