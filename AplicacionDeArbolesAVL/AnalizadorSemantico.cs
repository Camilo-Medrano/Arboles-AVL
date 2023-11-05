using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace AplicacionDeArbolesAVL
{
    public class AnalizadorSemantico
    {
        private string codigo;
        private ArbolDeSimbolos arbolDeSimbolos = new ArbolDeSimbolos();

        /// <summary>
        /// Constructor con un parámetro
        /// </summary>
        /// <param name="codigo">String con el código del main</param>
        public AnalizadorSemantico(string codigo)
        {
            this.codigo = codigo;
        }

        /// <summary>
        /// Analizador del código mediante expresiones regulares
        /// </summary>
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
        
        /// <summary>
        /// Metodo get para ArbolDeSimbolos
        /// </summary>
        public ArbolDeSimbolos ArbolDeSimbolos
        {
            get => arbolDeSimbolos;
        }

    }
}