using System.Text;

namespace hw9pt1
{
    delegate void MessageDelegate(string message);
    delegate double MathOperation(double a, double b);
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zad 1");
            Console.OutputEncoding = Encoding.UTF8;
            MessageDelegate showMessage;
            showMessage = PrintMessage;
            showMessage("повідомлення через делегат");
            showMessage = ShowAlert;
            showMessage("інший метод виклику через делегат");
            Console.WriteLine("Zad 2");
            MathOperation operation;

            operation = Add;
            Console.WriteLine("Додавання: " + operation(5, 3));
            operation = Subtract;
            Console.WriteLine("Віднімання: " + operation(5, 3));
            operation = Multiply;
            Console.WriteLine("Множення: " + operation(5, 3));
            Console.WriteLine("Zad 3");

            Predicate<int> isEven = n => n % 2 == 0;
            Predicate<int> isOdd = n => n % 2 != 0;
            Predicate<int> isPrime = IsPrime;
            Predicate<int> isFibonacci = IsFibonacci;

            int number = 13;

            Console.WriteLine($"{number} парне? {isEven(number)}");
            Console.WriteLine($"{number} непарне? {isOdd(number)}");
            Console.WriteLine($"{number} просте? {isPrime(number)}");
            Console.WriteLine($"{number} число Фібоначчі? {isFibonacci(number)}");

            Console.WriteLine("Zad 4");
            MathOperation add = Add;
            MathOperation subtract = Subtract;
            MathOperation multiply = Multiply;
            double result1 = add.Invoke(10, 5);
            double result2 = subtract.Invoke(10, 5);
            double result3 = multiply.Invoke(10, 5);
            Console.WriteLine("Результат додавання через Invoke: " + result1);
            Console.WriteLine("Результат віднімання через Invoke: " + result2);
            Console.WriteLine("Результат множення через Invoke: " + result3);

        }
        static void PrintMessage(string msg)
        {
            Console.WriteLine("PrintMessage: " + msg);
        }

        static void ShowAlert(string msg)
        {
            Console.WriteLine("ShowAlert: " + msg);
        }
        static double Add(double a, double b) => a + b;
        static double Subtract(double a, double b) => a - b;
        static double Multiply(double a, double b) => a * b;
        static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        static bool IsFibonacci(int n)
        {
            int a = 0, b = 1;
            while (b < n)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }
            return n == b || n == 0;
        }
    }
}
