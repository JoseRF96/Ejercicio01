using System;

class Calculator
{
    static void Main(string[] args)
    {
        int opcion = -1;
        while(opcion != 0)
        {
            try
            {
                Console.WriteLine("Indica el modo a utilizar");
                Console.WriteLine("1 - Modo manual");
                Console.WriteLine("2 - Modo automático");
                Console.WriteLine("0 - Salir");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ModoManual();
                        break;
                    case 2:
                        ModoAtomatico();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Introduce una opción valida");
                        break;
                }
            }catch(Exception ex){
                Console.WriteLine("Introduce un formato válido\n" + ex.Message);
            }


        }

        //Metodo que realiza el cálculo de forma manual
        //recibiendo dos valores y la operación a realizar
        void ModoManual()
        {
            try
            {
                string operacion;

                //Comprobamos que se ha introducido un carácter válido
                do
                {
                    Console.WriteLine("Indica el tipo de operación (+, -, /, *, ^) ");
                    operacion = Console.ReadLine();
                } while (operacion != "+" && operacion != "-" && operacion != "*" && operacion != "/" && operacion != "^");

                Console.WriteLine("Indica el primer valor: ");
                double valor1 = double.Parse(Console.ReadLine());

                Console.WriteLine("Indica el segundo valor: ");
                double valor2 = double.Parse(Console.ReadLine());

                double resultado = 0;
                switch (operacion)
                {
                    case "+":
                        resultado = valor1 + valor2;
                        break;
                    case "-":
                        resultado = valor1 - valor2;
                        break;
                    case "/":
                        if (valor2 == 0)
                        {
                            Console.WriteLine("No se puede dividir entre 0");
                        }
                        resultado = valor1 / valor2;
                        break;
                    case "*":
                        resultado = valor1 * valor2;
                        break;
                    case "^":
                        resultado = CalcularPotencia(valor1, valor2);
                        break;
                    default:
                        Console.WriteLine("Introduce una operación valida");
                        break;
                }

                Console.WriteLine($"{valor1} {operacion} {valor2} = {resultado}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Operación no valida. Introduzca un carácter correcto\n" + ex.Message);
            }
        }

        /*Método que realiza el calculo de forma automática,
        recibiendo una cadena y transformandola en dos números*/
        void ModoAtomatico()
        {
            Console.WriteLine("Indica la operación que desea hacer (ejemplo: 2^3)");
            string operacion = Console.ReadLine();

            try
            {

                string[] valores = operacion.Split('^');
                double valor1 = double.Parse(valores[0]);
                double valor2 = double.Parse(valores[1]);

                double resultado = CalcularPotencia(valor1, valor2);

                Console.WriteLine($"{valor1}^{valor2} = {resultado}");

            }
            catch(Exception ex)
            {
                Console.WriteLine("Operación no válida. Introduce valores como en el ejemplo\n" + ex.Message);
            }

        }

        /*Método que calcula la potencia recibiendo dos valores
         mediante un bucle for*/
        double CalcularPotencia(double numBase, double exponente)
        {
            double resultado = 1;
            for (int i = 1; i <= exponente; i++)
            {
                resultado *= numBase;
            }
            return resultado;
        }
    }
}
