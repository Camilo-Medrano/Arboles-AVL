namespace AplicacionDeArbolesAVL
{
    public class Simbolo
    {
        private string nombre;
        private string tipo;
        private string ambito;
        private string otrosDatos;

        public Simbolo()
        {
            nombre = null;
            tipo = null;
            ambito = null;
            otrosDatos = null;
        }

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

        public override string ToString()
        {
            return string.Format("Nombre: {0}, Tipo: {1}, Ambito: {2}, Otros Datos: {3}", nombre, tipo, ambito, otrosDatos);
        }
    }
}