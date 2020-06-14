using System;

namespace PracticeTask4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в приложение по вычислению по схеме Горнера многочлена с комплексными коэффициентами!");

            // Введем степень многочлена
            Console.WriteLine("\nВведите степень многочлена");
            uint n = InputUint();
            Complex[] coefs = new Complex[n + 2];

            // Ввод коэффициентов
            Console.WriteLine("\nВведите коэффициенты");
            Console.WriteLine("Введите коэффициент x");
            double x = InputDouble();
            Console.WriteLine("Введите коэффициент y");
            double y = InputDouble();
            coefs[0] = new Complex(x, y);


            // Предлагаем пользователю ввести коэффициенты двумя способами
            Console.WriteLine("\nВыберите способ ввода коэффициентов a и b");
            Console.WriteLine("1 - Сгенерировать случайные коэффициенты a и b");
            Console.WriteLine("2 - Ввести коэффициенты a и b с клавиатуры");
            int choice = InputInt(1, 2);

            switch (choice)
            {
                case 1:
                    // Генерация случайных коэффициентов
                    RandomCoefs(ref coefs);
                    break;
                case 2:
                    // Ввод коэффициентов с клавиатуры
                    InputCoefs(ref coefs);
                    break;
            }

            // Выводим коэффициенты
            PrintCoefs(coefs);

            // Считаем многочлен по схеме Горнера и выводим результат
            Complex gorner = Gorner(coefs);
            Console.WriteLine($"\nЗначение многочлена при заданных значениях x и y равно {gorner}");

            Console.WriteLine("\nЗавершение работы в приложении по вычислению по схеме Горнера многочлена с комплексными коэффициентами");

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }

        // Вычисление многочлена по схеме Горнера
        public static Complex Gorner(Complex[] coefs)
        {
            Complex x = coefs[0];
            Complex result = coefs[^1];

            for (int i = coefs.Length - 1; i > 1; i--)
                result = result * x + coefs[i - 1];

            return result;
        }

        // Печать коэффициентов многочлена
        private static void PrintCoefs(Complex[] coefs)
        {
            Console.WriteLine("\nКоэффициенты x и y:");
            Console.WriteLine($"{coefs[0].Re}, {coefs[0].Im}");

            Console.WriteLine("\nКоэффициенты при реальных частях комплексных членов:");
            for (int i = 1; i < coefs.Length; i++)
                Console.WriteLine($"a{i - 1} = {coefs[i].Re}");

            Console.WriteLine("\nКоэффициенты при мнимых частях комплексных членов:");
            for (int i = 1; i < coefs.Length; i++)
                Console.WriteLine($"b{i - 1} = {coefs[i].Im}");
        }

        // Генерация случайных коэффициентов
        public static void RandomCoefs(ref Complex[] array)
        {
            for (int i = 1; i < array.Length; i++)
                array[i] = new Complex();
        }

        // Ввод коэффициентов с клавиатуры
        private static void InputCoefs(ref Complex[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                Console.WriteLine($"\nВведите коэффициент a{i - 1}:");
                double a = InputDouble();
                Console.WriteLine($"Введите коэффициент b{i - 1}:");
                double b = InputDouble();
                array[i] = new Complex(a, b);
            }
        }

        // Ввод целого положительного числа
        private static uint InputUint()
        {
            uint number;
            bool check;
            do
            {
                Console.Write("Ввод: ");
                check = uint.TryParse(Console.ReadLine(), out number);
                if (!check)
                    Console.WriteLine("Ошибка! Введите целое положительное число");
            } while (!check);
            return number;
        }

        // Ввод целого числа с ограничениями
        private static int InputInt(int min, int max)
        {
            int number;
            bool check;
            do
            {
                Console.Write("Ввод: ");
                check = int.TryParse(Console.ReadLine(), out number) && number >= min && number <= max;
                if (!check)
                    Console.WriteLine($"Ошибка! Введите целое число в пределах от {min} до {max} (включительно)");
            } while (!check);
            return number;
        }

        // Ввод действительного числа
        private static double InputDouble()
        {
            double number;
            bool check;
            do
            {
                Console.Write("Ввод: ");
                check = double.TryParse(Console.ReadLine(), out number);
                if (!check)
                    Console.WriteLine("Ошибка! Введите вещественное число");
            } while (!check);
            return number;
        }

        // Класс комплексных чисел
        public class

        Complex
        {
            private static readonly Random random = new Random();

            public Complex()
            {
                Re = random.NextDouble() * random.Next(-100, 100);
                Im = random.NextDouble() * random.Next(-100, 100);
            }

            public Complex(double Re, double Im)
            {
                this.Re = Re;
                this.Im = Im;
            }

            // Реальная часть комплексного числа
            public double Re { get; }

            // Мнимая часть комплексного числа
            public double Im { get; }

            public override string ToString()
            {
                return (Re >= 0 ? Re.ToString() : " - " + Math.Abs(Re).ToString()) + (Im >= 0 ? " + " + Im.ToString() + "i" : " - " + Math.Abs(Re).ToString() + "i");
            }

            public static Complex operator +(Complex a, Complex b)
            {
                return new Complex(a.Re + b.Re, a.Im + b.Im);
            }

            public static Complex operator *(Complex a, Complex b)
            {
                return new Complex(a.Re * b.Re - a.Im * b.Im, a.Im * b.Re + a.Re * b.Im);
            }
        }
    }
}