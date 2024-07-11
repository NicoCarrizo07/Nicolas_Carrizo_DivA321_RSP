using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa una Banana, hereda de la clase Fruta.
    /// </summary>
    public class Banana : Fruta
    {
        protected string _paisOrigen;

        // <summary>
        /// Propiedad que obtiene el pais de origen de la banana.
        /// </summary>
        public string PaisOrigen
        {
            get { return _paisOrigen; }
            set { _paisOrigen = value; }
        }

        /// <summary>
        /// Propiedad que indica si la banana tiene carozo o no.
        /// </summary>
        public override bool TieneCarozo
        {
            get { return false; }
            set { }
        }

        /// <summary>
        /// Propiedad que obtiene el nombre de la fruta. Siempre retorna "Banana".
        /// </summary>
        public string Nombre
        {
            get
            {
                return "Banana";
            }
        }

        /// <summary>
        /// Constructor por defecto de la clase Banana.
        /// </summary>
        public Banana() { }

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase Banana con los valores especificados.
        /// </summary>
        /// <param name="color">Color de la banana.</param>
        /// <param name="peso">Peso de la banana.</param>
        /// <param name="paisOrigen">Pais de origen de la banana.</param>
        public Banana(string color, double peso, string paisOrigen) : base(color, peso)
        {
            _paisOrigen = paisOrigen;

        }

        /// <summary>
        /// Metodo protegido que construye una cadena con la informacinn de la banana.
        /// </summary>
        /// <returns>Cadena con la información de la banana.</returns>
        protected override string FrutasToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Fruta: {Nombre}");
            sb.AppendLine(base.FrutasToString());
            sb.AppendLine($"Pais de origen: {_paisOrigen}");

            return sb.ToString();

        }

        /// <summary>
        /// Sobrescribe el metodo ToString para retornar la informacion de la banana.
        /// </summary>
        /// <returns>Cadena con la informaciosn de la banana.</returns>
        public override string ToString()
        {
            return this.FrutasToString();
        }


    }
}
