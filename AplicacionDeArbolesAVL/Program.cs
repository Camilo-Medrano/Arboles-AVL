using System;

namespace AplicacionDeArbolesAVL
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ArbolDeSimbolos arbol = new ArbolDeSimbolos();
            Simbolo lineaCero = new Simbolo();
            lineaCero.Nombre = "zapato";
            lineaCero.Ambito = "private";
            lineaCero.Tipo = "string";
            lineaCero.OtrosDatos = "vans";

            Simbolo lineaUno = new Simbolo();
            lineaUno.Nombre = "precio";
            lineaUno.Ambito = "private";
            lineaUno.Tipo = "float";
            lineaUno.OtrosDatos = "105.7";
            
            Simbolo lineaDos = new Simbolo();
            lineaDos.Nombre = "talla";
            lineaDos.Ambito = "private";
            lineaDos.Tipo = "float";
            lineaDos.OtrosDatos = "11.5";
            
            Simbolo lineaTres = new Simbolo();
            lineaTres.Nombre = "durabilidadMeses";
            lineaTres.Ambito = "private";
            lineaTres.Tipo = "int";
            lineaTres.OtrosDatos = "13";
            
            Simbolo lineaCuatro = new Simbolo();
            lineaCuatro.Nombre = "usados";
            lineaCuatro.Ambito = "private";
            lineaCuatro.Tipo = "bool";
            lineaCuatro.OtrosDatos = "true";
            
            arbol.Raiz = arbol.Insertar(lineaCero, arbol.Raiz);
            arbol.Raiz = arbol.Insertar(lineaUno, arbol.Raiz);
            arbol.Raiz = arbol.Insertar(lineaDos, arbol.Raiz);
            arbol.Raiz = arbol.Insertar(lineaTres, arbol.Raiz);
            arbol.Raiz = arbol.Insertar(lineaCuatro, arbol.Raiz);
            arbol.EnOrden(arbol.Raiz);
            Console.WriteLine("\n\n"+ arbol.Raiz.Simb.ToString());
            Console.WriteLine("\nImpresión del arbol AVL\n\n");
            arbol.printTree(arbol.Raiz,"",true);
        }
    }
}
