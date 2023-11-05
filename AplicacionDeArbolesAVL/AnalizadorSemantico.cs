using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace AplicacionDeArbolesAVL
{
    public class AnalizadorSemantico
    {
        private string codigo;
        private ArbolDeSimbolos arbolDeSimbolos = new ArbolDeSimbolos();

        public AnalizadorSemantico(string codigo)
        {
            this.codigo = codigo;
        }

        public void AnalizarCodigo()
        {
            string pattern = @"\b(\w+)\s+(\w+)\s*=\s*([^;]+);"; // Expresión regular para identificar declaraciones de variables

            MatchCollection matches = Regex.Matches(codigo, pattern);

            foreach (Match match in matches)
            {
                if (match.Groups.Count > 1)
                {
                    string nombre = match.Groups[2].Value;
                    string tipo = match.Groups[1].Value;
                    string ambito = "main"; //por propósitos de simplificación
                    string otrosDatos = "=" + match.Groups[3].Value;
                    Simbolo nuevoSimbolo = new Simbolo(nombre, tipo, ambito, otrosDatos);

                    if (!arbolDeSimbolos.VerificarPresenciaSimbolo(nuevoSimbolo.Nombre))
                    {
                        arbolDeSimbolos.Raiz = arbolDeSimbolos.Insertar(nuevoSimbolo, arbolDeSimbolos.Raiz);
                    }
                }
            }
        }
        public ArbolDeSimbolos ArbolDeSimbolos
        {
            get => arbolDeSimbolos;
        }

    }
}