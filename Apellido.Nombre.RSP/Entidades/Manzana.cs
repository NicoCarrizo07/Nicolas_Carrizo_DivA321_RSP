using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Manzana))]
    [XmlInclude(typeof(Fruta))]

    /// <summary>
    /// Clase que representa una Manzana, que hereda de Fruta e implementa ISerializar y IDeserializar.
    /// </summary>
    public class Manzana : Fruta, ISerializar, IDeserializar
    {
        protected string _provinciaOrigen;

        // <summary>
        /// Indica si la manzana tiene carozo.
        /// </summary>
        public override bool TieneCarozo
        {
            get { return false; }
            set { }
        }

        /// <summary>
        /// Provincia de origen de la manzana.
        /// </summary>
        public string ProvinciaOrigen
        {
            get { return _provinciaOrigen; }
            set { _provinciaOrigen = value; }
        }

        /// <summary>
        /// Nombre de la fruta (siempre devuelve "Manzana").
        /// </summary>
        public string Nombre
        {
            get { return "Manzana"; }
        }

        /// <summary>
        /// Constructor por defecto de Manzana.
        /// </summary>
        public Manzana() { }

        // <summary>
        /// Constructor parametrizado de Manzana.
        /// </summary>
        /// <param name="color">Color de la manzana.</param>
        /// <param name="peso">Peso de la manzana.</param>
        /// <param name="provinciaOrigen">Provincia de origen de la manzana.</param>
        public Manzana(string color, double peso, string provinciaOrigen) : base(color, peso)
        {
            _provinciaOrigen = provinciaOrigen;

        }

        /// <summary>
        /// Serializa la manzana a un archivo XML en la ruta especificada.
        /// </summary>
        /// <param name="path">Ruta del archivo XML donde se va a serializar la manzana.</param>
        /// <returns>True si serializa, False de lo contrario..</returns>
        public bool Xml(string path)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Manzana));
                using (StreamWriter writer = new StreamWriter(path))
                {
                    serializer.Serialize(writer, this);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Deserializa una manzana desde un archivo XML en la ruta especificada.
        /// </summary>
        /// <param name="path">Ruta del archivo XML donde se encuentra la manzana serializada.</param>
        /// <param name="fruta">Fruta deserializada.</param>
        /// <returns>True si deserializa, False de lo contrario.</returns>
        bool IDeserializar.Xml(string path, out Fruta fruta)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Manzana));
                using (StreamReader reader = new StreamReader(path))
                {
                    fruta = (Fruta)serializer.Deserialize(reader);
                }
                return true;
            }
            catch
            {
                fruta = null;
                return false;
            }
        }

        /// <summary>
        /// Metodo protegido que construye una cadena con la informacion de la manzana.
        /// </summary>
        /// <returns>Cadena con la información de la manzana.</returns>
        protected override string FrutasToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Fruta: {Nombre}");
            sb.AppendLine(base.FrutasToString());
            sb.AppendLine($"Provincia de origen: {_provinciaOrigen}");

            return sb.ToString();

        }

        /// <summary>
        /// Sobrescribe el metodo ToString para retornar la informacion de la manzana.
        /// </summary>
        /// <returns>Cadena con la informacion de la manzana.</returns>
        public override string ToString()
        {
            return FrutasToString();
        }

    }
}
