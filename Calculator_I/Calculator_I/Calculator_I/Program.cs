using System;

namespace Calculator_I
{
    class Program
    {
        static void Menu()
        {
            Console.WriteLine("Программа <-----Калькулятор---->");
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Сложение");
            Console.WriteLine("2. Вычитание");
            Console.WriteLine("3. Умножение");
            Console.WriteLine("4. Деление");
            Console.WriteLine("5. Получение остатка от деления");
            Console.WriteLine("6. Возведение в степень");
            Console.WriteLine("7. Извлечение квадратного корня");
            Console.WriteLine("8. Извлечение корня n-ной степени");
            Console.WriteLine("9. Выход");
        }
        static void Main(string[] args)
        {
            bool isCorrectFirst = false, isCorrectSecond = false, isCorrectOperation = false;
            int firstNumber = 0, secondNumber = 0, operationNumber = 0;
            string numbers = string.Empty;
            string operation = string.Empty;
            const int exitNumber = 9;
            
            do
            {
                do
                {
                    Menu();
                    Console.WriteLine("Введите номер требуемой операции:");
                    operation = Console.ReadLine().Trim();
                    isCorrectOperation = int.TryParse(operation, out operationNumber);
                    if(!isCorrectOperation)
                    {
                        Console.WriteLine("Введенные данные не являются номером операции");
                    }
                    if((operationNumber < 1 || operationNumber > exitNumber) && isCorrectOperation)
                    {
                        Console.WriteLine("Не найдена операция с таким номером");
                    }
                } while (!isCorrectOperation || operationNumber < 1 || operationNumber > exitNumber);
                do
                {
                    if(operationNumber.Equals(7))
                    {
                        Console.WriteLine("Введите число:");
                        string numberString = Console.ReadLine().Trim();
                        isCorrectFirst = int.TryParse(numberString, out firstNumber);
                        isCorrectSecond = true;
                        if (!isCorrectFirst)
                        {
                            Console.WriteLine("Некорректный формат ввода");
                        }
                    }
                    else if(!operationNumber.Equals(exitNumber))
                    {
                        Console.WriteLine("Введите два числа через пробел:");
                        do
                        {
                            numbers = Console.ReadLine().Trim();
                            if (numbers.IndexOf(" ") == -1)
                                Console.WriteLine("Пожалуйста, используйте пробел в качестве разделителя для двух целых чисел");
                        } while (numbers.IndexOf(" ") == -1);
                        var firstNumberString = numbers.Substring(0, numbers.IndexOf(" "));
                        var secondNumberString = numbers.Substring(numbers.IndexOf(" "));
                        isCorrectFirst = int.TryParse(firstNumberString, out firstNumber);
                        isCorrectSecond = int.TryParse(secondNumberString, out secondNumber);
                        if (!isCorrectFirst || !isCorrectSecond)
                        {
                            Console.WriteLine("Некорректный формат ввода");
                        }
                        numbers = string.Empty;
                    }
                } while ((!isCorrectFirst || !isCorrectSecond) && !operationNumber.Equals(exitNumber));
                if (operationNumber.Equals(1))
                {
                    Console.WriteLine($"Результат: {firstNumber + secondNumber}");
                }
                else if (operationNumber.Equals(2))
                {
                    Console.WriteLine($"Результат: {firstNumber - secondNumber}");
                }
                else if (operationNumber.Equals(3))
                {
                    Console.WriteLine($"Результат: {firstNumber * secondNumber}");
                }
                else if (operationNumber.Equals(4))
                {
                    if(secondNumber.Equals(0))
                    {
                        Console.WriteLine("Деление на 0 невозможно");
                    }
                    else
                    {
                        Console.WriteLine($"Результат: {(float)firstNumber / (float)secondNumber}");
                    }
                }
                else if (operationNumber.Equals(5))
                {
                    if (secondNumber.Equals(0))
                    {
                        Console.WriteLine("Получение остатка от деления на 0 невозможно");
                    }
                    else
                    {
                        Console.WriteLine($"Результат: {firstNumber % secondNumber}");
                    }
                }
                else if (operationNumber.Equals(6))
                {
                    Console.WriteLine($"Результат: {System.Math.Pow(firstNumber, secondNumber)}");
                }
                else if (operationNumber.Equals(7))
                {
                    Console.WriteLine($"Результат: {System.Math.Sqrt(firstNumber)}");
                }
                else if(operationNumber.Equals(8))
                {
                    Console.WriteLine($"Результат: {System.Math.Pow((double)firstNumber, (double)1 /secondNumber)}");
                }
                else if (operationNumber.Equals(exitNumber))
                {
                    Console.WriteLine("Осуществляется выход из программы");
                }
                else
                {
                    Console.WriteLine("Запрашиваемая операция не существует, либо не еще не реализована");
                }
            } while (!operationNumber.Equals(exitNumber));
        }
    }
}
