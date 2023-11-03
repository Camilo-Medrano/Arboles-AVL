using System;

namespace AplicacionDeArbolesAVL
{
    public class ArbolDeSimbolos
    {
        private Nodo raiz;

        public ArbolDeSimbolos()
        {
            raiz = null;
        }

        /// <summary>
        /// Método Insertar
        /// </summary>
        /// <param name="s">Simbolo a insertar</param>
        /// <param name="n">nodo actual</param>
        /// <returns>Nodo en el cual fue insertado</returns>
        public Nodo Insertar(Simbolo s, Nodo n)
        {
            if (n == null)
            {
                n = new Nodo(s, null, null);
            }
            else if (string.CompareOrdinal(s.Nombre,n.Simb.Nombre) < 0) {
                n.NodoIzquierdo = Insertar(s, n.NodoIzquierdo);
                if ((n.NodoIzquierdo.Altura - n.NodoDerecho.Altura) == 2)
                    n = RotarConNodoIzquierdoHijo(n);
                else
                    n = DobleConNodoIzquierdoHijo(n);
            }
            else if (string.CompareOrdinal(s.Nombre,n.Simb.Nombre) > 0)
            {
                n.NodoDerecho = Insertar(s, n.NodoDerecho);
                if ((n.NodoDerecho.Altura - n.NodoIzquierdo.Altura) == 2)
                {
                    if (string.CompareOrdinal(s.Nombre, n.NodoDerecho.Simb.Nombre) > 0)
                        n = RotarConNodoDerechoHijo(n);
                    else
                        n = DobleConNodoDerechoHijo(n);
                }
            }
            
            n.Altura = Math.Max(n.NodoIzquierdo.Altura, n.NodoDerecho.Altura) + 1; 
            return n;
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
        
        /// <summary>
        /// Borra un nodo del arbol
        /// </summary>
        /// <param name="llave">nombre del simbolo del nodo a borrar</param>
        /// <returns>false si no se borro</returns>
        public bool Borrar(string llave)
        {
            Nodo actual = raiz;
            Nodo padre = raiz;
            bool esNodoIzquierdoHijo = true;
            
            while (!actual.Simb.Nombre.Equals(llave))
            {
                padre = actual;
                if (String.CompareOrdinal(llave,actual.Simb.Nombre)<0)
                {
                    esNodoIzquierdoHijo = true;
                    actual = actual.NodoIzquierdo;
                }
                else 
                {
                    esNodoIzquierdoHijo = false;
                    actual = actual.NodoDerecho;
                }
                if (actual == null)
                    return false;
            }

            if ((actual.NodoIzquierdo == null) && (actual.NodoDerecho == null))
            {
                if (actual == raiz)
                    raiz = null;
                else if (esNodoIzquierdoHijo)
                    padre.NodoIzquierdo = null;
                else
                    padre.NodoDerecho = null;
            }
            else if (actual.NodoDerecho == null)
            {
                if (actual == raiz)
                    raiz = actual.NodoIzquierdo;
                else if (esNodoIzquierdoHijo)
                    padre.NodoIzquierdo = actual.NodoIzquierdo;
                else
                    padre.NodoDerecho = actual.NodoDerecho;
            }
            else if (actual.NodoIzquierdo == null)
            {
                if (actual == raiz)
                    raiz = actual.NodoDerecho;
                else if (esNodoIzquierdoHijo)
                    padre.NodoIzquierdo = padre.NodoDerecho;
                else
                    padre.NodoDerecho = actual.NodoDerecho;
            }
            else
            {
                Nodo heredero = GetHeredero(actual);
                if (actual == raiz)
                    raiz = heredero;
                else if (esNodoIzquierdoHijo)
                    padre.NodoIzquierdo = heredero;
                else
                    padre.NodoDerecho = heredero;
                heredero.NodoIzquierdo = actual.NodoIzquierdo;
            }
            return true;
        }
        
        /// <summary>
        /// Método para encontrar el heredero de un nodo a borrar
        /// </summary>
        /// <param name="borrarNodo">nodo a borrar</param>
        /// <returns>nodo heredero</returns>
        public Nodo GetHeredero(Nodo borrarNodo) {
            Nodo herederoPadre = borrarNodo;
            Nodo heredero = borrarNodo;
            Nodo actual = borrarNodo.NodoDerecho;
            while (!(actual == null)) {
                herederoPadre = actual;
                heredero = actual;
                actual = actual.NodoIzquierdo;
            }
            if (!(heredero == borrarNodo.NodoDerecho)) {
                herederoPadre.NodoIzquierdo = heredero.NodoDerecho;
                heredero.NodoDerecho = borrarNodo.NodoDerecho;
            }
            return heredero;
        }

        //METODOS DE BALANCEO
        
        private Nodo RotarConNodoIzquierdoHijo(Nodo n2) {
            Nodo n1 = n2.NodoIzquierdo;
            n2.NodoIzquierdo = n1.NodoDerecho;
            n1.NodoDerecho = n2;
            n2.Altura = Math.Max(n2.NodoIzquierdo.Altura, n2.NodoDerecho.Altura) + 1;
            n1.Altura = Math.Max(n1.NodoIzquierdo.Altura, n2.Altura) + 1;
            return n1;
        }
        private Nodo RotarConNodoDerechoHijo(Nodo n1) {
            Nodo n2 = n1.NodoDerecho;
            n1.NodoDerecho = n2.NodoIzquierdo;
            n2.NodoIzquierdo = n1;
            n1.Altura = Math.Max(n1.NodoIzquierdo.Altura, n1.NodoDerecho.Altura) + 1;
            n2.Altura = Math.Max(n2.NodoDerecho.Altura, n1.Altura) + 1;
            return n2;
        }
        
        private Nodo DobleConNodoIzquierdoHijo(Nodo n3) {
            n3.NodoIzquierdo = RotarConNodoDerechoHijo(n3.NodoIzquierdo);
            return RotarConNodoIzquierdoHijo(n3);
        }
        
        private Nodo DobleConNodoDerechoHijo(Nodo n1) {
            n1.NodoDerecho = RotarConNodoIzquierdoHijo(n1.NodoDerecho);
            return RotarConNodoDerechoHijo(n1);
        }
    }
}