using System;

class Ar
{
    private int n;          // Кількість елементів в масиві
    private int[] a;        // Одновимірний цілочисельний масив
    private int k;          // Кількість позитивних елементів масиву

    // Конструктор 1
    public Ar(int a, int b, int x)
    {
        Random random = new Random();
        n = random.Next(1, 101);  // Випадкова кількість елементів від 1 до 100
        this.a = new int[n];
        for (int i = 0; i < n; i++)
        {
            this.a[i] = (random.Next(0, 2) == 0 ? -1 : 1) * random.Next(a, b + 1) * x;
            if (this.a[i] > 0)
            {
                k++;
            }
        }
    }

    // Конструктор 2
    public Ar(int a, int b)
    {
        Random random = new Random();
        n = random.Next(1, 101);  // Випадкова кількість елементів від 1 до 100
        this.a = new int[n];
        for (int i = 0; i < n; i++)
        {
            this.a[i] = (random.Next(0, 2) == 0 ? -1 : 1) * random.Next(a, b + 1);
            if (this.a[i] > 0)
            {
                k++;
            }
        }
    }

    // Властивість для отримання кількості позитивних елементів масиву
    public int K
    {
        get { return k; }
    }

    // Властивість для читання поля n
    public int N
    {
        get { return n; }
    }

    // Метод для виведення масиву на екран
    public void Print()
    {
        Console.WriteLine("Елементи масиву:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"{a[i]} ");
        }
        Console.WriteLine();
    }

    // Метод для знаходження індексу числа максимального по модулю
    public int MaxModIndex()
    {
        int maxMod = Math.Abs(a[0]);
        int maxModIndex = 0;

        for (int i = 1; i < n; i++)
        {
            if (Math.Abs(a[i]) > maxMod)
            {
                maxMod = Math.Abs(a[i]);
                maxModIndex = i;
            }
        }

        return maxModIndex;
    }

    // Метод для обчислення суми модулів елементів масиву від i1 до i2 включно
    public int Sum(int i1, int i2)
    {
        if (i1 < 0)
        {
            i1 = 0;
        }
        if (i2 >= n)
        {
            i2 = n - 1;
        }

        int sum = 0;
        for (int i = i1; i <= i2; i++)
        {
            sum += Math.Abs(a[i]);
        }

        return sum;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Виберіть конструктор (1 або 2):");
        int constructorChoice = int.Parse(Console.ReadLine());

        if (constructorChoice == 1)
        {
            Console.WriteLine("Введіть a:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть b:");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть x:");
            int x = int.Parse(Console.ReadLine());
            Ar array = new Ar(a, b, x);
            array.Print();
            Console.WriteLine($"Кількість позитивних елементів: {array.K}");
            int maxModIndex = array.MaxModIndex();
            Console.WriteLine($"Індекс числа максимального по модулю: {maxModIndex}");
            if (maxModIndex != 0)
            {
                int sum = array.Sum(0, maxModIndex - 1);
                Console.WriteLine($"Сума модулів елементів лівіше індексу {maxModIndex}: {sum}");
            }
            else
            {
                Console.WriteLine("Перший елемент масиву має індекс 0.");
            }
        }
        else if (constructorChoice == 2)
        {
            Console.WriteLine("Введіть a:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть b:");
            int b = int.Parse(Console.ReadLine());
            Ar array = new Ar(a, b);
            array.Print();
            Console.WriteLine($"Кількість позитивних елементів: {array.K}");
            int maxModIndex = array.MaxModIndex();
            Console.WriteLine($"Індекс числа максимального по модулю: {maxModIndex}");
            if (maxModIndex != 0)
            {
                int sum = array.Sum(0, maxModIndex - 1);
                Console.WriteLine($"Сума модулів елементів лівіше індексу {maxModIndex}: {sum}");
            }
            else
            {
                Console.WriteLine("Перший елемент масиву має індекс 0.");
            }
        }
        else
        {
            Console.WriteLine("Неправильний вибір конструктора.");
        }
    }
}
