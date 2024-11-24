using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = [];
            bool endProgram = false;// Флаг для завершения программы
            do
            {   
                // Главное меню программы

                Console.WriteLine("Главное меню:");
                Console.WriteLine("1. Создать массив");
                Console.WriteLine("2. Напечатать массив");
                Console.WriteLine("3. Удалить элементы массива с четными номерами");
                Console.WriteLine("4. Добавить K элементов в конец массива");
                Console.WriteLine("5. Перестановка минимального и максимального элемента массива");
                Console.WriteLine("6. Поиск первого минимального элемента массива");
                Console.WriteLine("7. Сортировка массива (простое включение)");
                Console.WriteLine("8. Бинарный поиск в отсортированном массиве");
                Console.WriteLine("9. Выход");
                Console.Write("Выберите действие: ");

                // Считываем выбор пользователя
                int answer = IsInt();
                switch (answer)
                {
                    case 1:
                        Console.Clear(); // Очищаем консоль для удобства
                        arr = CreateArray(); // Создание массива
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Массив: "); // Печать массива
                        PrintArray(arr);
                        break;
                    case 3:
                        Console.Clear();
                        arr = DeleteElements(arr); // Удаление элементов с четными номерами
                        break;
                    case 4:
                        Console.Clear();
                        arr = AddElements(arr); // Добавление элементов в массив
                        break;
                    case 5:
                        Console.Clear();
                        SwapMinMax(arr); // Перестановка минимального и максимального элемента
                        break;
                    case 6:
                        Console.Clear();
                        FindFirstNegative(arr); // Поиск первого отрицательного элемента
                        break;
                    case 7:
                        Console.Clear();
                        Sort(arr); // Сортировка массива
                        break;
                    case 8:
                        Console.Clear();
                        BinarySearch(arr); // Бинарный поиск
                        break;
                    case 9:
                        endProgram = true; // Завершение программы
                        return;
                    default:
                        Console.WriteLine("Неверно выбрана опция"); // Обработка некорректного ввода
                        break;
                }
            } while (!endProgram);

        }
       
        static bool EmptyMasive(int[] arr) // Проверка массива на пустоту
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("Массив пустой!");
                PressToContinue();
                return true;
            }
            return false;
        }
        static void PressToContinue() // Функция для паузы программы
        {
            Console.WriteLine(); // Пустая строка для отступа
            Console.WriteLine("Нажмите Enter, чтобы продолжить");
            Console.ReadLine(); // Ждем, пока пользователь нажмет Enter
            Console.Clear();
        }

        static int IsInt() // Проверка корректности ввода целого числа
        {
            bool isConvert;
            while (true)
            {
                isConvert = int.TryParse(Console.ReadLine(), out int answer);
                if (isConvert)
                    return answer; // Если ввод успешен, возвращаем значение
                Console.WriteLine("Ошибка ввода. Попробуйте снова."); // Если ввод некорректен
            }

        }

        static int[] CreateArray() // Создание массива
        {
            int maxLength = 100000; // Максимально допустимая длина массива

            Console.WriteLine("Сформируйте массив!");
            Console.WriteLine();
            Console.Write("Выберите количество элементов: ");
            int n = IsInt();
            Console.WriteLine();

            // Проверяем, чтобы длина массива была в пределах допустимых значений
            while (n < 0 || n > maxLength)
            {
                Console.WriteLine($"Количестов элементов массива не должно превышать {maxLength}, а также не может быть отрицательным!");
                Console.Write("Введите количество элементов массива еще раз: ");
                n = IsInt();
            }

            // Создаем массив заданной длины
            int i;
            int[] arr = new int[n];

            if (arr.Length == 0)
            {
                Console.WriteLine("Пустой массив сформирован");
                PressToContinue();
            } // Если массив пустой, уведомляем пользователя

            else
            {
            way: // Метка для повторного выбора способа заполнения
                Console.WriteLine("Выберите метод заполнения: ");
                Console.WriteLine("1. Заполнить массив ДСЧ");
                Console.WriteLine("2. Заполнить массив с клавиатуры");
                Console.Write("Вы выбрали: ");
                int method = IsInt();
                Console.WriteLine();

                switch (method)
                {
                    case 1:
                        Random rnd = new();
                        for (i = 0; i < n; i++)
                            arr[i] = rnd.Next(-100, 100);
                        Console.WriteLine("Массив сформирован!");
                        PressToContinue();
                        break; // Заполняем массив случайными числами
                    case 2:
                        for (i = 0; i < n; i++)
                        {
                            Console.Write($"Введите элемент {i + 1}: ");
                            arr[i] = IsInt();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Массив сформирован!");
                        PressToContinue();
                        break; // Заполняем массив в ручную
                    default:
                        Console.WriteLine("Неверный выбор метода заполнения");
                        goto way; // Переход к повторному выбору метода
                }
            }
            return arr; // Возвращаем созданный массив
        }

        static void PrintArray(int[] arr) // Печать массива
        {          
            if (EmptyMasive(arr)) return; // Проверяем, пуст ли массив

            else
            {
                for (int i = 0; i < arr.Length; i++) // Перебираем элементы массива и выводим их
                {
                    Console.Write($"{arr[i]} ");
                }
                Console.WriteLine();
                PressToContinue();
            }

        }

        static int[] DeleteElements(int[] arr)// Удаление элементов массива с четными номерами
        {
            if (EmptyMasive(arr)) return arr; // Проверяем, пуст ли массив

            int[] result = new int[(arr.Length + 1) / 2]; // Создаем новый массив для нечетных элементов
            for (int i = 0, j = 0; i < arr.Length; i += 2, j++)
            {
                result[j] = arr[i]; // Копируем элементы с нечетными номерами
            }
            Console.Write("После удаления элементов с четными номерами массив выглядит так: ");
            PrintArray(result);
            return result; // Выводим новый массив
        }

        static int[] AddElements(int[] arr) // Добавление новых элементов в конец массива
        {
            int maxLength = 100000;

            if (arr.Length == maxLength) // Проверяем, достигнут ли предел массива
            {
                Console.WriteLine("Массив уже содержит максимальное количество элементов!");
                PressToContinue();
                return arr;
            }

            Console.Write("Введите количество элементов для добавления в массив: ");
            int n = IsInt();
            int[] newElements = new int[n];
            Console.WriteLine();

            if (newElements.Length == 0) // Проверяем, был ли создан пустой массив для добавления
            {
                Console.WriteLine("Вы не добавили элементов в массив!");
                PressToContinue();
                return arr;
            }

            else
            {
                while (n < 0 || n + arr.Length > maxLength) // Убеждаемся, что количество добавляемых элементов корректно
                {
                    Console.WriteLine($"Количестов элементов массива не должно превышать {maxLength}! Максимально допустимое количество элементов для добавления: {maxLength - arr.Length}");
                    Console.Write("Введите количество элементов массива еще раз: ");
                    n = IsInt();
                    newElements = new int[n];
                    Console.WriteLine();
                }

            // Выбор метода заполнения новых элементов
            way: 
                Console.WriteLine("1. Заполнить массив ДСЧ");
                Console.WriteLine("2. Заполнить массив с клавиатуры");
                Console.Write("Выберите метод заполнения: ");
                int method = IsInt();

                switch (method)
                {
                    case 1:
                        Random rnd = new();
                        for (int i = 0; i < n; i++)
                            newElements[i] = rnd.Next(-100, 100);
                        break;
                    case 2:
                        Console.WriteLine();
                        for (int i = 0; i < n; i++)
                        {
                            Console.Write($"Введите элемент {i + 1}: ");
                            newElements[i] = IsInt();
                        }
                        break;
                    default:
                        Console.WriteLine("Неверный выбор метода заполнения");
                        goto way; // Переход к выбору метода снова
                }

                int[] result = new int[arr.Length + n]; // Создаем новый массив, который объединяет исходный и добавленные элементы

                for (int i = 0; i < arr.Length; i++)
                {
                    result[i] = arr[i]; // Копируем исходный массив
                }

                for (int i = 0; i < newElements.Length; i++)
                {
                    result[arr.Length + i] = newElements[i]; // Добавляем новые элементы
                }
                Console.WriteLine();
                Console.Write($"После добавления {n} элементов в конец массива он выглядит так: ");
                PrintArray(result); // Печатаем новый массив
                return result; // Возвращаем результат
            }
        }

        static int[] SwapMinMax(int[] arr) // Перестановка минимального и максимального элементов массива
        {
            if (EmptyMasive(arr)) return arr; // Проверяем, пуст ли массив

            else
            {
                int minNumber = arr[0], maxNumber = arr[0];
                for (int i = 1; i < arr.Length; i++) // Поиск минимального и максимального элементов
                {
                    if (arr[i] < minNumber)
                    {
                        minNumber = arr[i];
                    }
                    if (arr[i] > maxNumber)
                    {
                        maxNumber = arr[i];
                    }
                }

                if (minNumber == maxNumber)// Если все элементы массива одинаковые, перестановка не требуется
                {
                    Console.WriteLine("Все элементы массива одинаковы. Перестановка не требуется.");
                    PressToContinue();
                    return arr;
                }

                int minCount = 0;
                int maxCount = 0;

                for (int i = 0; i < arr.Length; i++) // Считаем количество минимальных и максимальных элементов
                {
                    if (arr[i] == minNumber)
                    {
                        minCount++;
                    }
                    if (arr[i] == maxNumber)
                    {
                        maxCount++;
                    }
                }

                // Индексы всех минимальных и максимальных элементов
                int[] minIndexes = new int[minCount]; 
                int[] maxIndexes = new int[maxCount];

                int minIndex = 0;
                int maxIndex = 0;

                for (int i = 0; i < arr.Length; i++) // Заполняем массивы с индексами минимальных и максимальных элементов
                {
                    if (arr[i] == minNumber)
                    {
                        minIndexes[minIndex++] = i;
                    }
                    if (arr[i] == maxNumber)
                    {
                        maxIndexes[maxIndex++] = i;
                    }
                }

                int countNumber = Math.Min(minCount, maxCount); // Количество пар для замены

                for (int i = 0; i < countNumber; i++) // Переставляем минимальные и максимальные элементы попарно
                {
                    (arr[maxIndexes[i]], arr[minIndexes[i]]) = (arr[minIndexes[i]], arr[maxIndexes[i]]);
                }
            }
            Console.Write("После перестановки местами минимального и максимального элементов массива он выглядит так: ");
            PrintArray(arr); // Печатаем массив после перестановки
            return arr; // Возвращаем массив
        }

        static int FindFirstNegative(int[] arr) // Поиск первого отрицательного элемента массива
        {
            int comparisons = 0; // Счетчик сравнений
            bool finding = false; // Флаг для отслеживания, найден ли элемент

            if (EmptyMasive(arr)) return 0; // Проверяем, пуст ли массив

            for (int i = 0; i < arr.Length; ++i)
            {
                comparisons++; // Увеличиваем счетчик сравнений
                if (arr[i] < 0)
                {
                    Console.WriteLine($"Первый отрицательный элемент: {arr[i]}, его позиция: {i + 1}.");
                    finding = true; // Отмечаем, что элемент найден
                    break;
                }
            }

            if (!finding)
            {
                Console.WriteLine("Отрицательных элементов нет.");
            }

            Console.WriteLine($"Количество сравнений: {comparisons}");
            PressToContinue();
            return comparisons; // Возвращаем количество сравнений
        }
        static void Sort(int[] arr) // Сортировка массива методом простого включения
        {
            if (EmptyMasive(arr)) return; // Проверяем, пуст ли массив

            if (!IsSorted(arr)) // Если массив уже отсортирован, уведомляем пользователя
            {
                for (int i = 0; i < arr.Length; ++i) // Алгоритм сортировки методом простого включения
                {
                    int item = arr[i]; // Текущий элемент
                    int j = i - 1;

                    while (j >= 0 && item > arr[j]) // Смещаем элементы влево, чтобы найти место для текущего элемента
                    {
                        arr[j + 1] = arr[j];
                        j--;
                    }
                    arr[j + 1] = item; // Вставляем текущий элемент в нужное место
                }
                Console.WriteLine("После сортировки массив выглядит таким образом: ");
                PrintArray(arr); // Печатаем отсортированный массив
                return;
            }
            else
            {
                Console.WriteLine("Массив уже отсортирован!"); //Если массив отсортирован, уведомляешь пользователя об этом
                PressToContinue();
            }
        }

        static bool IsSorted(int[] arr) // Проверка, отсортирован ли массив
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                {
                    return false;
                } // Если найдено нарушение порядка, массив не отсортирован
            }
            return true; // Если порядок не нарушен, массив отсортирован
        }
        static void BinarySearch(int[] arr) // Бинарный поиск в отсортированном массиве
        {
            if (EmptyMasive(arr)) return; // Проверяем, пуст ли массив

            if (IsSorted(arr)) // Проверяем, отсортирован ли массив

            {

                Console.Write("Введите число для поиска: ");
                int findItem = IsInt(); // Число для поиска
                int left = 0; // Границы поиска
                int right = arr.Length - 1; // Границы поиска
                int comparisons = 0; // Счетчик сравнений
                

                do
                {
                    comparisons++; // Увеличиваем счетчик сравнений

                    int middle = (left + right) / 2; // Средний индекс

                    if (arr[middle] == findItem) // Проверяем, равен ли элемент в текущей позиции искомому
                    {
                        Console.WriteLine($"Элемент {findItem} находится на позиции: {middle + 1}");
                        Console.WriteLine($"Число сравнений: {comparisons}.");
                        PressToContinue();
                    }

                    else if (arr[middle] < findItem) // Если элемент в середине меньше искомого, сужаем диапазон поиска вправо
                    {
                        left = middle + 1; // Ищем в правой половине
                    }
                    else // Иначе сужаем диапазон поиска влево
                    {
                        right = middle;
                    }
                } while (left <= right); // Цикл выполняется, пока не останется один элемент

                // Если элемент не найден
                Console.WriteLine("Элемент не найден");
                Console.WriteLine($"Число сравнений: {comparisons}.");
                PressToContinue();
                return;
            }

            else // Если массив не отсортирован
            {
                Console.WriteLine("Массив не отсортирован! Сначала отсортируйте массив.");
                PressToContinue();
            }
        }
    }
}
