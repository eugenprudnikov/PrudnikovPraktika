﻿using System;

class Money
{
    private long rubles; // рубли
    private byte kopecks; // копейки

    public Money()
    {
        rubles = 0;
        kopecks = 0;
    }

    public Money(long r, byte k)
    {
        rubles = r;
        kopecks = (byte)(k % 100); // ограничиваем копейки до 99
    }

    public void DisplayAmount()
    {
        Console.WriteLine($"{rubles},{kopecks} рублей");
    }

    public static Money operator +(Money m1, Money m2)
    {
        long totalRubles = m1.rubles + m2.rubles;
        byte totalKopecks = (byte)((m1.kopecks + m2.kopecks) % 100);
        return new Money(totalRubles, totalKopecks);
    }

    // Операция вычитания
    public static Money Subtract(Money m1, Money m2)
    {
        long resultRubles = m1.rubles - m2.rubles;
        byte resultKopecks = (byte)((m1.kopecks - m2.kopecks) % 100);
        return new Money(resultRubles, resultKopecks);
    }

    // Операция деления суммы на дробное число
    public static Money DivideByDouble(Money m, double divisor)
    {
        long resultRubles = (long)(m.rubles / divisor);
        byte resultKopecks = (byte)((m.kopecks / divisor) % 100);
        return new Money(resultRubles, resultKopecks);
    }

    // Операция умножения на дробное число
    public static Money MultiplyByDouble(Money m, double factor)
    {
        long resultRubles = (long)(m.rubles * factor);
        byte resultKopecks = (byte)((m.kopecks * factor) % 100);
        return new Money(resultRubles, resultKopecks);
    }

    // Операция сравнения
    public static string Compare(Money m1, Money m2)
    {
        int comparisonResult = m1.rubles.CompareTo(m2.rubles);
        if (comparisonResult == 0)
        {
            comparisonResult = m1.kopecks.CompareTo(m2.kopecks);
        }

        if (comparisonResult < 0)
        {
            return $"{m1.rubles},{m1.kopecks} < {m2.rubles},{m2.kopecks}";
        }
        else if (comparisonResult > 0)
        {
            return $"{m1.rubles},{m1.kopecks} > {m2.rubles},{m2.kopecks}";
        }
        else
        {
            return $"{m1.rubles},{m1.kopecks} = {m2.rubles},{m2.kopecks}";
        }
    }

    // Ввод суммы с клавиатуры
    public static Money ReadMoneyFromConsole()
    {
        Console.Write("Введите сумму рублей: ");
        long rubles = long.Parse(Console.ReadLine());

        Console.Write("Введите сумму копеек: ");
        byte kopecks = byte.Parse(Console.ReadLine());

        return new Money(rubles, kopecks);
    }

    // Пример использования:
    static void Main()
    {
        Console.WriteLine("Введите первую сумму:");
        Money money1 = ReadMoneyFromConsole();

        Console.WriteLine("Введите вторую сумму:");
        Money money2 = ReadMoneyFromConsole();


        Console.WriteLine("Сумма:");
        Money sum = money1 + money2;
        sum.DisplayAmount();


        Console.WriteLine("Разница:");
        Money difference = Money.Subtract(money1, money2);
        difference.DisplayAmount();

        Console.WriteLine("Введите число для деления");
        Double del = Convert.ToDouble(Console.ReadLine());


        Console.WriteLine("Частное:");
        Money divided = Money.DivideByDouble(money1, del);
        divided.DisplayAmount();

        Console.WriteLine("Введите число для умножения");
        Double umnozh = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Произведение:");
        Money multiplied = Money.MultiplyByDouble(money2, umnozh);
        multiplied.DisplayAmount();
            
        string comparisonResult = Compare(money1, money2);
        Console.WriteLine($"Сравнение: {comparisonResult}");
        Console.ReadKey(); //Код для отмены сворачивания окна при конце кода
    }
}
