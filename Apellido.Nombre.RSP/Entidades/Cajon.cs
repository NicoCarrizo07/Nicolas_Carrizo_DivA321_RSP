using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Delegado para el evento que se dispara cuando el precio total del cajon es + 55.
    /// </summary>
    /// <param name="sender">Objeto que dispara el evento.</param>
    public delegate void PrecioExtendido(object sender);

    /// <summary>
    /// Clase generica que representa un cajon de frutas.
    /// </summary>
    /// <typeparam name="T">Tipo de elemento que contiene el cajon.</typeparam>
    public class Cajon<T>
    {

        protected int _capacidad;
        protected double _precioUnitario;
        protected List<T> _elementos;
        public event PrecioExtendido eventoPrecio;

        /// <summary>
        /// Propiedad que obtiene la lista de elementos en el cajon.
        /// </summary>
        public List<T> Elementos
        {
            get { return _elementos; }
            set { _elementos = value; }
        }

        /// <summary>
        /// Propiedad que calcula el precio total de los elementos en el cajon y dispara el evento
        /// si el precio supera los 55.
        /// </summary>
        public double PrecioTotal
        {
            get
            {
                double precioTotal = _elementos.Count * _precioUnitario;
                if (precioTotal > 55 && eventoPrecio != null)
                {
                    eventoPrecio(precioTotal);
                }
                return precioTotal;
            }
            set { }
        }

        /// <summary>
        /// Constructor por defecto que inicializa la lista de elementos.
        /// </summary>
        public Cajon()
        {

            _elementos = new List<T>();
            
        }

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase Cajon con la capacidad especificada.
        /// </summary>
        /// <param name="capacidad">Capacidad máxima del cajón.</param>
        public Cajon(int capacidad) : this()
        {

            _capacidad = capacidad;
        }

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase Cajon con la capacidad y precio unitario especificados.
        /// </summary>
        /// <param name="precioUnitario">Precio unitario de cada elemento en el cajon.</param>
        /// <param name="capacidad">Capacidad maxima del cajon.</param>
        public Cajon(double precioUnitario, int capacidad) : this(capacidad)
        {
            _precioUnitario = precioUnitario;
        }

        /// <summary>
        /// Metodo que serializa el objeto Cajon a un archivo XML en una ruta especificada.
        /// </summary>
        /// <param name="path">Ruta donde se guardara el archivo XML.</param>
        /// <returns>True si la serializacion fue exitosa, false en caso contrario.</returns>
        public bool Xml(string path)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Cajon<T>));
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
        /// Sobrecarga del operador + que agrega un elemento al cajon si no se ha alcanzado la capacidad maxima.
        /// Lanza una excepcion si el cajon esta lleno.
        /// </summary>
        /// <param name="cajon">Cajon al que se agrega el elemento.</param>
        /// <param name="elemento">Elemento que se agrega al cajon.</param>
        /// <returns>El cajon con el nuevo elemento agregado.</returns>
        /// <exception cref="CajonLLenoException">Se lanza si el cajon ya esta lleno.</exception>
        public static Cajon<T> operator +(Cajon<T> cajon, T elemento)
        {

            if (cajon._elementos.Count < cajon._capacidad)
            {
                cajon._elementos.Add(elemento);
            }
            else
            {
                throw new CajonLLenoException("El cajón ya se encuentra lleno!");
            }

            return cajon;
        }

        /// <summary>
        /// Sobrescribe el metodo ToString para retornar la información del cajon.
        /// </summary>
        /// <returns>Cadena con la informacion del cajon.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Capacidad: {_capacidad}");
            sb.AppendLine($"Cantidad total de elementos: {_elementos.Count}");
            sb.AppendLine($"Precio Total: {PrecioTotal}");
            sb.AppendLine($"**************************************");
            sb.AppendLine("           Lista de Frutas");
            sb.AppendLine($"**************************************\n");
            foreach (T elemento in _elementos)
            {
                sb.AppendLine(elemento.ToString());
                sb.AppendLine($"------------------------------------");
            }

            return sb.ToString();
        }







    }
}
