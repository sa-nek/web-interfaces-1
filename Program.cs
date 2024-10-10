using System.Text;

//Кодування УКР
Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

//Цикл меню
while (true)
{
    Console.WriteLine("Виберіть пункт меню:");
    Console.WriteLine("1. Вивести кількість слів із тексту \"Lorem ipsum\".");
    Console.WriteLine("2. Виконати математичну операцію.");
    Console.WriteLine("3. Вийти.");

    //Змінна вибору
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            PrintWordsFromLoremIpsum();
            break;
        case "2":
            PerformMathOperation();
            break;
        case "3":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Невірний вибір. Спробуйте знову.");
            break;
    }
}

//Метод для виведення слів
static void PrintWordsFromLoremIpsum()
{
    try
    {
        string filePath = "lorem.txt"; // Шлях до файлу з текстом
        //Відкриття файлу
        if (File.Exists(filePath))
        {
            string text = File.ReadAllText(filePath);
            Console.WriteLine("Введіть кількість слів для виводу:");
            if (int.TryParse(Console.ReadLine(), out int wordCount))
            {
                //Виведення слів
                string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < wordCount && i < words.Length; i++)
                {
                    Console.Write(words[i] + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Некоректне число.");
            }
        }
        else
        {
            Console.WriteLine("Файл не знайдено.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Помилка: {ex.Message}");
    }
}

// Функція для виконання математичної операції - додавання двох чисел
static void PerformMathOperation()
{
    Console.WriteLine("Введіть перше число:");
    if (double.TryParse(Console.ReadLine(), out double num1))
    {
        Console.WriteLine("Введіть друге число:");
        if (double.TryParse(Console.ReadLine(), out double num2))
        {
            //Додавання
            double result = num1 + num2;
            Console.WriteLine($"Результат: {result}");
        }
        else
        {
            Console.WriteLine("Некоректне число.");
        }
    }
    else
    {
        Console.WriteLine("Некоректне число.");
    }
}