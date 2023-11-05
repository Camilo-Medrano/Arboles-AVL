using System;
using System.Text.RegularExpressions;


namespace AplicacionDeArbolesAVL
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string codigoCSharp = @"
	            int numero = 3;
	            string saludo = ""Hola, querido usuario"";
	            string nombre = ""Camilo Perez"";
	            string adjetivo = ""honorable"";
	            string siguiente = ""estimado usuario"";
	            string descripcion = ""humilde persona"";
	            string motivo = ""respuesta formal"";
	            double valor2 = 4.5;
	
	            // Ejemplo de operación aritmética válida
	            double resultado = numero + valor2;
	
	            // Actualización de la variable
	            valor2 = 3;
	            Console.WriteLine(valor2);
	
	            // Concatenación de cadenas de texto
	            string saludoFinal = saludo + "" Rodrigo. Le damos la bienvenida a nuestro sistema."";
	            Console.WriteLine(saludoFinal);
            ";

            AnalizadorSemantico analisisSemantico = new AnalizadorSemantico(codigoCSharp);
            analisisSemantico.AnalizarCodigo();
            ArbolDeSimbolos simbolos = analisisSemantico.ArbolDeSimbolos;

            Console.WriteLine("Código de main:");
            Console.WriteLine(codigoCSharp);
            Console.WriteLine();
            simbolos.ImprimirSubArbol(simbolos.Raiz,0,"R");
            Console.WriteLine();
            Console.WriteLine();

            string pattern = @"\b(\w+)\s+(\w+)\s*=\s*([^;]+);";

            MatchCollection matches = Regex.Matches(codigoCSharp, pattern);

            simbolos.PrintTree(simbolos.Raiz, "", true);


            Console.WriteLine("\n");
            foreach (Match match in matches)
            {
                Console.WriteLine($"Variable encontrada: {match.Groups[2].Value}, Tipo: {match.Groups[1].Value}, Valor: {match.Groups[3].Value}");
            }

            Console.Read();
        }
    }
}