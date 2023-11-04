using System;

namespace AplicacionDeArbolesAVL
{
    public class ArbolDeSimbolos
    {
        private Nodo raiz;

        public Nodo Raiz
        {
            get => raiz;
            set => raiz = value;
        }

        public ArbolDeSimbolos()
        {
            raiz = null;
        }
        
        int Altura(Nodo N) {
            if (N == null)
                return 0;
            return N.Altura;
        }
        
        int max(int a, int b) {
            return (a > b) ? a : b;
        }

        //METODOS DE BALANCEO
        
        Nodo rotarDerecha(Nodo y) {
            Nodo x = y.NodoIzquierdo;
            Nodo T2 = x.NodoDerecho;
            x.NodoDerecho = y;
            y.NodoIzquierdo = T2;
            y.Altura = max(Altura(y.NodoIzquierdo), Altura(y.NodoDerecho)) + 1;
            x.Altura = max(Altura(x.NodoIzquierdo), Altura(x.NodoDerecho)) + 1;
            return x;
        }

        Nodo rotarIzquierda(Nodo x) {
            Nodo y = x.NodoDerecho;
            Nodo T2 = y.NodoIzquierdo;
            y.NodoIzquierdo = x;
            x.NodoDerecho = T2;
            x.Altura = max(Altura(x.NodoIzquierdo), Altura(x.NodoDerecho)) + 1;
            y.Altura = max(Altura(y.NodoIzquierdo), Altura(y.NodoDerecho)) + 1;
            return y;
        }

        /// <summary>
        /// Obtener el factor de balanceo de un nodo
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        int getFactorBalanceo(Nodo N) {
            if (N == null)
                return 0;
            return Altura(N.NodoIzquierdo) - Altura(N.NodoDerecho);
        }

        /// <summary>
        /// Metodo para insertar un nodo y autobalancear el arbol
        /// </summary>
        /// <param name="simbolo"></param>
        /// <param name="nodo"></param>
        /// <returns></returns>
        public Nodo Insertar(Simbolo simbolo,Nodo nodo) {

            // Find the position and insert the nodo
            if (nodo == null)
                return (new Nodo(simbolo, null, null));
            if (String.CompareOrdinal(simbolo.Nombre, nodo.Simb.Nombre)<0)
                nodo.NodoIzquierdo = Insertar(simbolo, nodo.NodoIzquierdo);
            else if (string.CompareOrdinal(simbolo.Nombre, nodo.Simb.Nombre)>0)
                nodo.NodoDerecho = Insertar(simbolo, nodo.NodoDerecho);
            else
                return nodo;

            //Balanceo
            nodo.Altura = 1 + max(Altura(nodo.NodoIzquierdo), Altura(nodo.NodoDerecho));
            int balanceFactor = getFactorBalanceo(nodo);
            if (balanceFactor > 1) {
                if (String.CompareOrdinal(simbolo.Nombre, nodo.NodoIzquierdo.Simb.Nombre)<0) {
                    return rotarDerecha(nodo);
                } else if (String.CompareOrdinal(simbolo.Nombre, nodo.NodoIzquierdo.Simb.Nombre)>0) {
                    nodo.NodoIzquierdo = rotarIzquierda(nodo.NodoIzquierdo);
                    return rotarDerecha(nodo);
                }
            }
            if (balanceFactor < -1) {
                if (String.CompareOrdinal(simbolo.Nombre, nodo.NodoDerecho.Simb.Nombre)>0) {
                    return rotarIzquierda(nodo);
                } else if (String.CompareOrdinal(simbolo.Nombre, nodo.NodoDerecho.Simb.Nombre)<0) {
                    nodo.NodoDerecho = rotarDerecha(nodo.NodoDerecho);
                    return rotarIzquierda(nodo);
                }
            }
            return nodo;
        }
        
        //METODOS PARA MOSTRAR LOS DATOS
        
        /// <summary>
        /// Método que lo muestra en orden
        /// </summary>
        /// <param name="laRaiz">nodo a mostrar</param>
        public void EnOrden(Nodo laRaiz) 
        {
            if (laRaiz != null) 
            {
                EnOrden(laRaiz.NodoIzquierdo);
                laRaiz.MostrarNodo();
                EnOrden(laRaiz.NodoDerecho);
            }
        }
        
        /// <summary>
        /// Método que lo muestra en pre-orden 
        /// </summary>
        /// <param name="laRaiz">nodo a mostrar</param>
        public void PreOrden(Nodo laRaiz) {
            if (!(laRaiz == null)) {
                laRaiz.MostrarNodo();
                PreOrden(laRaiz.NodoIzquierdo);
                PreOrden(laRaiz.NodoDerecho);
            }
        }
        
        /// <summary>
        /// Metodo que lo muestra en post-orden
        /// </summary>
        /// <param name="laRaiz">nodo a mostrar</param>
        public void PostOrden(Nodo laRaiz) {
            if (!(laRaiz == null)) {
                PostOrden(laRaiz.NodoIzquierdo);
                PostOrden(laRaiz.NodoDerecho);
                laRaiz.MostrarNodo();
            }
        }
        
        //METODOS DE BUSQUEDA
        
        /// <summary>
        /// Método que encuentra el mínimo
        /// </summary>
        /// <returns>nodo con el nombre "menor"</returns>
        public Nodo EncontrarMin() {
            Nodo actual = raiz; 
            while (!(actual.NodoIzquierdo == null)) 
                actual = actual.NodoIzquierdo; 
            return actual;
        }
        
        /// <summary>
        /// Método que encuentra el máximo
        /// </summary>
        /// <returns>nodo con el nombre "mayor"</returns>
        public Nodo EncontrarMax() {
            Nodo actual = raiz;
            while (!(actual.NodoDerecho == null))
                actual = actual.NodoDerecho;
            return actual;
        }
        
        /// <summary>
        /// Método que busca a partir de un nombre dado
        /// </summary>
        /// <param name="llave">nombre a buscar</param>
        /// <returns>null si no se encontro</returns>
        public Nodo Encontrar(string llave) {
            Nodo actual = raiz;
            while (!actual.Simb.Nombre.Equals(llave)) {
                if (String.CompareOrdinal(llave,actual.Simb.Nombre)<0)
                    actual = actual.NodoIzquierdo;
                else
                    actual = actual.NodoDerecho;
                if (actual == null)
                    return null;
            }
            return actual;
        }
        
        public void printTree(Nodo currPtr, String indent, bool last) {
            if (currPtr != null) {
                Console.Write(indent);
                if (last) {
                    Console.Write("R----");
                    indent += "   ";
                } else {
                    Console.Write("L----");
                    indent += "|  ";
                }
                Console.WriteLine(currPtr.Simb.ToString());
                printTree(currPtr.NodoIzquierdo, indent, false);
                printTree(currPtr.NodoDerecho, indent, true);
            }
        }
    }
}