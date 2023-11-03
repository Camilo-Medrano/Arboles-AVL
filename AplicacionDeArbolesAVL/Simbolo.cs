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
    }
}