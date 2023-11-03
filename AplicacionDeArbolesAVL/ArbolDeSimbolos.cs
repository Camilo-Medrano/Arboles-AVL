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
        /// Insertar nuevo simbolo
        /// </summary>
        /// <param name="s"></param>
        public void Insertar(Simbolo s)
        {
            Nodo nuevoNodo = new Nodo();
            nuevoNodo.Simb = s;
            if (raiz == null)
                raiz = nuevoNodo;
            else
            {
                Nodo actual = raiz;
                Nodo padre;
                while (true)
                {
                    padre = actual;
                    if (String.CompareOrdinal(s.Nombre, actual.Simb.Nombre)<0)
                    {
                        actual = actual.NodoIzquierdo;
                        if (actual == null)
                        {
                            padre.NodoIzquierdo = nuevoNodo;
                            break;
                        }
                        
                    }
                    else 
                    {
                        actual = actual.NodoDerecho; 
                        if (actual == null) 
                        {
                            padre.NodoDerecho = nuevoNodo; 
                            break;
                        }
                    }
                }
            }
        }
        
        
        public void EnOrden(Nodo laRaiz) 
        {
            if (laRaiz != null) 
            {
                EnOrden(laRaiz.NodoIzquierdo);
                laRaiz.MostrarNodo();
                EnOrden(laRaiz.NodoDerecho);
            }
        }
        
        public void PreOrden(Nodo laRaiz) {
            if (!(laRaiz == null)) {
                laRaiz.MostrarNodo();
                PreOrden(laRaiz.NodoIzquierdo);
                PreOrden(laRaiz.NodoDerecho);
            }
        }
        
        public void PostOrden(Nodo laRaiz) {
            if (!(laRaiz == null)) {
                PostOrden(laRaiz.NodoIzquierdo);
                PostOrden(laRaiz.NodoDerecho);
                laRaiz.MostrarNodo();
            }
        }
        
        public string EncontrarMin() {
            Nodo actual = raiz; 
            while (!(actual.NodoIzquierdo == null)) 
                actual = actual.NodoIzquierdo; 
            return actual.Simb.Nombre;
        }
        
        public string EncontrarMax() {
            Nodo actual = raiz;
            while (!(actual.NodoDerecho == null))
                actual = actual.NodoDerecho;
            return actual.Simb.Nombre;
        }
        
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