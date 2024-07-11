using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfaz para deserializar objetos desde XML.
    /// </summary>
    public interface IDeserializar
    {
        // <summary>
        /// Deserializa un objeto de tipo Fruta desde un archivo XML.
        /// </summary>
        /// <param name="path">Ruta del archivo XML.</param>
        /// <param name="fruta">Objeto de tipo Fruta deserializado (parámetro de salida).</param>
        /// <returns>True si deserializa, False de lo contrario.</returns>
        bool Xml(string path, out Fruta fruta);
    }
}
