using System;

namespace AplicacionDeArbolesAVL
{
    public class Nodo
    {
        private Simbolo simb;
        private Nodo nodoIzquierdo;
        private Nodo nodoDerecho;
        private int altura;

        public Nodo()
        {
            simb = null;
            nodoIzquierdo = null;
            nodoDerecho = null;
            altura = 0;
        }

        public Nodo(Simbolo simb, Nodo nodoIzquierdo, Nodo nodoDerecho)
        {
            this.simb = simb;
            this.nodoIzquierdo = nodoIzquierdo;
            this.nodoDerecho = nodoDerecho;
        }

        public Simbolo Simb
        {
            get => simb;
            set => simb = value;
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

        public void MostrarNodo()
        {
            Console.Write("\n"+simb.ToString()+" ");
        }
    }
}