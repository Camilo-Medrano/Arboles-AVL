namespace AplicacionDeArbolesAVL
{
    public class Simbolo
    {
        private string nombre;
        private string tipo;
        private string ambito;
        private string otrosDatos;

        /// <summary>
        /// Constructor sin parámetros
        /// </summary>
        public Simbolo()
        {
            nombre = null;
            tipo = null;
            ambito = null;
            otrosDatos = null;
        }

        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="tipo"></param>
        /// <param name="ambito"></param>
        /// <param name="otrosDatos"></param>
        public Simbolo(string nombre, string tipo, string ambito, string otrosDatos)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.ambito = ambito;
            this.otrosDatos = otrosDatos;
        }

        // METODOS SET Y GET
        
        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public string Tipo
        {
            get => tipo;
            set => tipo = value;
        }

        public string Ambito
        {
            get => ambito;
            set => ambito = value;
        }

        public string OtrosDatos
        {
            get => otrosDatos;
            set => otrosDatos = value;
        }

        /// <summary>
        /// Método ToString
        /// </summary>
        /// <returns>string con todos los datos de simbolo</returns>
        public override string ToString()
        {
            return string.Format("Nombre: {0}, Tipo: {1}, Ambito: {2}, Otros Datos: {3}", nombre, tipo, ambito, otrosDatos);
        }
    }
}