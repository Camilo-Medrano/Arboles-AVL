namespace AplicacionDeArbolesAVL
{
    public class Nodo
    {
        private Simbolo simbolo;
        private Nodo nodoIzquierdo;
        private Nodo nodoDerecho;
        private int altura;

        public Nodo()
        {
        }

        public Simbolo Simbolo
        {
            get => simbolo;
            set => simbolo = value;
        }

        public Nodo NodoIzquierdo
        {
            get => nodoIzquierdo;
            set => nodoIzquierdo = value;
        }

        public Nodo NodoDerecho
        {
            get => nodoDerecho;
            set => nodoDerecho = value;
        }

        public int Altura
        {
            get => altura;
            set => altura = value;
        }
    }
}