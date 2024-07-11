using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.Data.SqlClient;

namespace Formulario
{
    /// <summary>
    /// Formulario principal de la aplicación.
    /// </summary>
    public partial class Formulario : Form
    {
        private Manzana _manzana;
        private Banana _banana;
        private Durazno _durazno;

        public Cajon<Manzana> _cajonManzanas;
        public Cajon<Banana> _cajonBananas;
        public Cajon<Durazno> _cajonDuraznos;

        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public Formulario()
        {
            InitializeComponent();
        }

        // <summary>
        /// Evento Load del formulario.
        /// </summary>
        private void Formulario_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Carrizo, Nicolas");
        }

        /// <summary>
        /// Evento click del boton Punto 1.
        /// Crea instancias de Manzana, Banana y Durazno, y muestra sus detalles en MessageBox.
        /// </summary>
        private void btnPunto1_Click(object sender, EventArgs e)
        {
            _manzana = new Manzana("Verde", 2, "Río Negro");
            _banana = new Banana("Amarillo", 5, "Ecuador");
            _durazno = new Durazno("Rojo", 2, 53);

            MessageBox.Show(_manzana.ToString());
            MessageBox.Show(_banana.ToString());
            MessageBox.Show(_durazno.ToString());
        }

        /// <summary>
        /// Evento click del boton Punto 2.
        /// Inicializa y muestra los cajones de Manzanas, Bananas y Duraznos.
        /// </summary>
        private void btnPunto2_Click(object sender, EventArgs e)
        {
            _cajonManzanas = new Cajon<Manzana>(1.58, 3);
            _cajonBananas = new Cajon<Banana>(15.96, 4);
            _cajonDuraznos = new Cajon<Durazno>(21.5, 1);

            _cajonManzanas += new Manzana("Roja", 1, "Neuquén");
            _cajonManzanas += _manzana;
            _cajonManzanas += new Manzana("Amarilla", 3, "San Juan");

            _cajonBananas += new Banana("Verde", 3, "Brasil");
            _cajonBananas += _banana;

            _cajonDuraznos += _durazno;

            MessageBox.Show(_cajonManzanas.ToString());
            MessageBox.Show(_cajonBananas.ToString());
            MessageBox.Show(_cajonDuraznos.ToString());
        }

        // Se debe de serializar la clase Manzana, indicando un mensaje con lo sucedido
        // Se debe de deserializar la clase Manzana y mostrar el objeto obtenido
        // Se debe de serializar el cajon de Manzanas

        /// <summary>
        /// Evento click del botón Punto 3.
        /// Serializa y deserializa una Manzana y un Cajón de Manzanas.
        /// </summary>
        private void btnPunto3_Click(object sender, EventArgs e)
        {
            Fruta aux = null;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\manzana.xml";
            string pathCajon = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\manzanaCajon.xml";
            // AGREGAR
            // Serealizacion implicita de manzana
            if (_manzana.Xml(path))
            {
                MessageBox.Show("Manzana serializada correctamente");
            }
            else
            {
                MessageBox.Show("Error al serializar el objeto Manzana");
            }

            if (((IDeserializar)_manzana).Xml(path,out aux))
            {
                MessageBox.Show(((Manzana)aux).ToString());
            }
            else
            {
                MessageBox.Show("Error en la deserialización el objeto Manzana");
            }

            // Serealizacion de cajon de manzanas
            if (_cajonManzanas.Xml(pathCajon))
            {
                MessageBox.Show("Cajón de manzanas serializada correctamente");
            }
            else
            {
                MessageBox.Show("Error en la serialización del cajón de manzanas");
            }
        }

        // Si se intenta agregar frutas al cajón y se supera la cantidad máxima,
        // se lanzará un CajonLlenoException, cuyo mensaje explicará lo sucedido.

        /// <summary>
        /// Evento click del boton Punto 4.
        /// Intenta agregar un Durazno al cajon de Duraznos, captura y muestra cualquier excepcion.
        /// </summary>
        private void btnPunto4_Click(object sender, EventArgs e)
        {

            try
            {
                _cajonDuraznos += _durazno;
            }
            catch (CajonLLenoException ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        //Si el precio total del cajon supera los 55 pesos, se disparará el evento EventoPrecio. 
        //caso contrario, mostrará la fecha (con hora, minutos y segundos) y el total del precio del cajón.

        /// <summary>
        /// Evento click del boton Punto 5.
        /// Intenta agregar Bananas al cajon de Bananas, captura y muestra cualquier excepcion.
        /// Muestra la fecha y el precio total del cajon de Bananas en caso de éxito.
        /// </summary>
        private void btnPunto5_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date = DateTime.Now;
                _cajonBananas += new Banana("Verde", 2, "Argentina");
                _cajonBananas += new Banana("Amarilla", 4, "Ecuador");
                //_cajonBananas += new Banana("Amarilla", 2, "Ecuador");

                MessageBox.Show("Fecha: " + date.ToString("dd/MM/yyyy HH:mm:ss") + " - Precio total: $" + _cajonBananas.PrecioTotal.ToString());
            }
            catch(CajonLLenoException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Obtener de la base de datos (lab_msp) el listado de frutas
        //Implementar el método ObtenerListadoFrutas():string utilizando excepciones. 

        // <summary>
        /// Metodo para obtener el listado de frutas desde la base de datos.
        /// Retorna el listado en formato de cadena o una cadena vacia si ocurre un error.
        /// </summary>
        private string ObtenerListadoFrutas()
        {
            string conexion = "Data Source=NICO\\SQLEXPRESS;Initial Catalog=lab_rsp;Integrated Security=True"; 
            StringBuilder listadoFrutas = new StringBuilder();

            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();
                    string query = "SELECT * FROM frutas";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listadoFrutas.AppendLine($"{reader["id"]}, {reader["nombre"]}, {reader["peso"]}, {reader["precio"]}");
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener el listado de frutas: " + ex.Message);
                return string.Empty;
            }

            return listadoFrutas.ToString();
        }

        /// <summary>
        /// Evento click del boton Punto 6.
        /// Obtiene el listado de frutas desde la base de datos y lo muestra en un MessageBox.
        /// </summary>
        private void btnPunto6_Click(object sender, EventArgs e)
        {
            string listado = ObtenerListadoFrutas();
            if (!string.IsNullOrEmpty(listado))
            {
                MessageBox.Show($"Listado de frutas obtenido:\n\n{ listado}");
            }
        }

        //Agregar en la base de datos las frutas del formulario (_manzana, _banana y _durazno).
        //Implementar el método AgregarFrutas():bool utilizando excepciones. 
        //Indicar con un mensaje lo sucedo, si se pudo agregar datos o no.

        /// <summary>
        /// Metodo para agregar las frutas (_manzana, _banana y _durazno) en la base de datos.
        /// Retorna true si se agregaron correctamente, false si hubo un error.
        /// </summary>
        private bool AgregarFrutas()
        {
            string conexion = "Data Source=NICO\\SQLEXPRESS;Initial Catalog=lab_rsp;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();

                    string query = "INSERT INTO frutas (nombre, peso, precio) VALUES (@Nombre, @Peso, @Precio)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (_manzana != null)
                        {
                            command.Parameters.Add(new SqlParameter("@Nombre", "Manzana"));
                            command.Parameters.Add(new SqlParameter("@Peso", _manzana.Peso));
                            command.Parameters.Add(new SqlParameter("@Precio", 1.58)); 
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }

                        if (_banana != null)
                        {
                            command.Parameters.Add(new SqlParameter("@Nombre", "Banana"));
                            command.Parameters.Add(new SqlParameter("@Peso", _banana.Peso));
                            command.Parameters.Add(new SqlParameter("@Precio", 15.96)); 
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }

                        if (_durazno != null)
                        { 
                            command.Parameters.Add(new SqlParameter("@Nombre", "Durazno"));
                            command.Parameters.Add(new SqlParameter("@Peso", _durazno.Peso));
                            command.Parameters.Add(new SqlParameter("@Precio", 21.5));
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                    }
                }

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al agregar las frutas: " + ex.Message);
                return false;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Error: Una o mas frutas no estan inicializadas. " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Evento click del boton Punto 7.
        /// Agrega las frutas (_manzana, _banana y _durazno) en la base de datos y muestra un mensaje indicando el resultado.
        /// </summary>
        private void btnPunto7_Click(object sender, EventArgs e)
        {
            if (AgregarFrutas())
            {
                MessageBox.Show("Las frutas fueron agregadas correctamente a la base de datos");
            }
            else
            {
                MessageBox.Show("Hubo un problema al agregar las frutas.");
            }
        }
    }
}
