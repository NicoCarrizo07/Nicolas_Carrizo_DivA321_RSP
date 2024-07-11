using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un Durazno, hereda de la clase Fruta.
    /// </summary>
    public class Durazno : Fruta
    {
        protected int _cantPelusa;

        /// <summary>
        /// Obtiene la cantidad de pelusa del durazno.
        /// </summary>
        public int CantidadPelusa
        {
            get { return _cantPelusa; }
            set { _cantPelusa = value; }
        }

        /// <summary>
        /// Indica si el durazno tiene carozo.
        /// </summary>
        public override bool TieneCarozo
        {
            get { return true; }
            set { }
        }

        /// <summary>
        /// Obtiene el nombre de la fruta, que es "Durazno".
        /// </summary>s
        public string Nombre
        {
            get { return "Durazno"; }
        }

        // <summary>
        /// Inicializa una nueva instancia de la clase Durazno con el color, peso y cantidad de pelusa especificados.
        /// </summary>
        /// <param name="color">El color del durazno.</param>
        /// <param name="peso">El peso del durazno.</param>
        /// <param name="cantPelusa">La cantidad de pelusa del durazno.</param>
        public Durazno(string color, double peso, int cantPelusa) : base(color, peso)
        {
            _cantPelusa = cantPelusa;

        }


        /// <summary>
        /// Devuelve una cadena que representa el durazno.
        /// </summary>
        /// <returns>Una cadena que representa el durazno.</returns>
        protected override string FrutasToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Fruta: {Nombre}");
            sb.AppendLine(base.FrutasToString());
            sb.AppendLine($"Cantidad de pelusa: {_cantPelusa}");

            return sb.ToString();

        }

        /// <summary>
        /// Sobrescribe el metodo ToString para retornar la informacion del durazno.
        /// </summary>
        /// <returns>Cadena con la informacion del durazno.</returns>
        public override string ToString()
        {
            return this.FrutasToString();
        }



    }
}
