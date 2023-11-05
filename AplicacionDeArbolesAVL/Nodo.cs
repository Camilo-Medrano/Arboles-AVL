using System;

namespace AplicacionDeArbolesAVL
{
    public class Nodo
    {
        private Simbolo simb;
        private Nodo nodoIzquierdo;
        private Nodo nodoDerecho;
        private int altura;

        /// <summary>
        /// Constructor sin parámetros
        /// </summary>
        public Nodo()
        {
            simb = null;
            nodoIzquierdo = null;
            nodoDerecho = null;
            altura = 0;
        }
        
        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="simb">Simbolo a ingresar</param>
        /// <param name="nodoIzquierdo">Nodo izquierdo</param>
        /// <param name="nodoDerecho">Nodo derecho</param>
        public Nodo(Simbolo simb, Nodo nodoIzquierdo, Nodo nodoDerecho)
        {
            this.simb = simb;
            this.nodoIzquierdo = nodoIzquierdo;
            this.nodoDerecho = nodoDerecho;
        }

        //METODOS SET Y GET DE LOS ATRIBUTOS
        
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

        /// <summary>
        /// Muestra en un string lo que contiene el simbolo del nodo
        /// </summary>
        public void MostrarNodo()
        {
            Console.Write("\n"+simb.ToString()+" ");
        }
    }
}