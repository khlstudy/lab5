using System;

// Абстрактний клас Parent, що описує платника податків
public abstract class Parent
{
    public abstract string Info(); // Абстрактний метод для повернення інформації про об'єкт
    public abstract double Metod(); // Абстрактний метод для обчислення податку
}

// Дочірній клас Child1, що описує фізичну особу
public class Child1 : Parent
{
    private double pole1; // загальний дохід
    private double pole2; // ставка податку (%)

    // Конструктор з двома параметрами
    public Child1(double income, double taxRate)
    {
        pole1 = income;
        pole2 = taxRate;
    }

    public override string Info()
    {
        return $"Фізична особа: Загальний дохід - {pole1}, Податкова ставка - {pole2}%";
    }

    public override double Metod()
    {
        return pole1 * pole2 / 100; // Обчислення податку
    }
}

// Дочірній клас Child2, що описує юридичну особу
public class Child2 : Parent
{
    private double pole3; // виручка від продажів
    private double pole4; // собівартість
    private double pole5; // додаткові витрати
    private double pole6; // ставка податку (%)

    // Конструктор з чотирма параметрами
    public Child2(double salesRevenue, double costPrice, double additionalExpenses, double taxRate)
    {
        pole3 = salesRevenue;
        pole4 = costPrice;
        pole5 = additionalExpenses;
        pole6 = taxRate;
    }

    public override string Info()
    {
        return $"Юридична особа: Виручка - {pole3}, Собівартість - {pole4}, Додаткові витрати - {pole5}, Податкова ставка - {pole6}%";
    }

    public override double Metod()
    {
        double profit = pole3 - pole4 - pole5; // Обчислення прибутку
        return profit * pole6 / 100; // Обчислення податку
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Random rnd = new Random();

        for (int i = 0; i < 5; i++)
        {
            // Випадковим чином визначаємо тип платника податків
            bool isChild1 = rnd.Next(0, 2) == 0;

            if (isChild1)
            {
                // Якщо особа фізична, визначаємо випадкові значення
                double income = rnd.Next(1000, 10000);
                double taxRate = rnd.Next(5, 30);

                Child1 person1 = new Child1(income, taxRate);
                Console.WriteLine(person1.Info());
                Console.WriteLine("Податок: " + person1.Metod());
            }
            else
            {
                // Якщо особа юридична, визначаємо випадкові значення
                double salesRevenue = rnd.Next(5000, 50000);
                double costPrice = rnd.Next(3000, 20000);
                double additionalExpenses = rnd.Next(1000, 5000);
                double taxRate = rnd.Next(5, 25);

                Child2 person2 = new Child2(salesRevenue, costPrice, additionalExpenses, taxRate);
                Console.WriteLine(person2.Info());
                Console.WriteLine("Податок: " + person2.Metod());
            }
        }
        Console.ReadLine();
    }
}
