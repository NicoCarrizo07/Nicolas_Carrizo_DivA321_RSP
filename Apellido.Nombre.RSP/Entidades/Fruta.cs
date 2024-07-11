using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase abstracta que representa una fruta.
    /// </summary>
    public abstract class Fruta
    {
        protected string _color;
        protected double _peso;

        // <summary>
        /// Obtiene el color de la fruta.
        /// </summary>
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        /// <summary>
        /// Propiedad de lecutra y escritura de Peso
        /// </summary>
        public double Peso
        {
            get { return _peso; }
            set { _peso = value; }
        }

        /// <summary>
        /// Indica si la fruta tiene carozo.
        /// </summary>
        public abstract bool TieneCarozo
        {
            get; set;
        }

        /// <summary>
        /// Constructor por defecto de la clase Fruta.
        /// </summary>
        public Fruta()
        { }

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase Fruta con el color y peso especificados.
        /// </summary>
        /// <param name="color">Color de la fruta.</param>
        /// <param name="peso">Peso de la fruta.</param>
        public Fruta(string color, double peso)
        {
            _color = color;
            _peso = peso;
        }

        /// <summary>
        /// Metodo que devuelve una cadena que representa los atributos basicos de la fruta (color, peso y si tiene carozo).
        /// </summary>
        /// <returns>Cadena que representa los atributos basicos de la fruta.</returns>
        protected virtual string FrutasToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Color: {_color}");
            stringBuilder.AppendLine($"Peso: {_peso}");
            if (TieneCarozo)
            {
                stringBuilder.AppendLine("Tiene carozo: si");
            }
            else
            {
                stringBuilder.AppendLine("Tiene carozo: no");
            }

            return stringBuilder.ToString();

        }


    }
}
