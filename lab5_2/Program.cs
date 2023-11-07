using System;

public interface IParent
{
    string Info();
    double Metod1();
    double Metod2();
}

public class Child1 : IParent
{
    private double pole1;
    private double pole2;
    private double pole3;

    public Child1(double a, double b, double c)
    {
        pole1 = a;
        pole2 = b;
        pole3 = c;
    }

    public string Info()
    {
        return $"Паралелепіпед: a={pole1}, b={pole2}, c={pole3}";
    }

    public double Metod1()
    {
        return 2 * (pole1 * pole2 + pole2 * pole3 + pole3 * pole1);
    }

    public double Metod2()
    {
        return pole1 * pole2 * pole3;
    }
}

public class Child2 : IParent
{
    private double pole4;
    private double pole5;

    public Child2(double radius, double height)
    {
        pole4 = radius;
        pole5 = height;
    }

    public string Info()
    {
        return $"Конус: Радіус={pole4}, висота={pole5}";
    }

    public double Metod1()
    {
        double l = Math.Sqrt(pole4 * pole4 + pole5 * pole5);
        return Math.PI * pole4 * (pole4 + l);
    }

    public double Metod2()
    {
        return (Math.PI * pole4 * pole4 * pole5) / 3;
    }
}

public class Child3 : IParent
{
    private double pole6;

    public Child3(double radius)
    {
        pole6 = radius;
    }

    public string Info()
    {
        return $"Сфера: Радіус={pole6}";
    }

    public double Metod1()
    {
        return 4 * Math.PI * pole6 * pole6;
    }

    public double Metod2()
    {
        return (4 * Math.PI * pole6 * pole6 * pole6) / 3;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        for (int y = 0; y < 5; y++)
        {
            for (int i = 0; i < 5; i++)
            {
                IParent obj = null;

                int shapeType = rnd.Next(1, 4);

                if (shapeType == 1)
                {
                    double a = rnd.Next(1, 50);
                    double b = rnd.Next(1, 50);
                    double c = rnd.Next(1, 50);
                    obj = new Child1(a, b, c);
                }
                else if (shapeType == 2)
                {
                    double radius = rnd.Next(1, 50);
                    double height = rnd.Next(1, 50);
                    obj = new Child2(radius, height);
                }
                else if (shapeType == 3)
                {
                    double r = rnd.Next(1, 50);
                    obj = new Child3(r);
                }

                Console.WriteLine(obj.Info());
                Console.WriteLine($"S={obj.Metod1().ToString("F", System.Globalization.CultureInfo.InvariantCulture)} V={obj.Metod2().ToString("F", System.Globalization.CultureInfo.InvariantCulture)}");
                Console.WriteLine();
            }
                
            Console.ReadLine();
        }
    }
}
