using System;


public class Car
{
    public string model;

    public Car(string model)
    {
        this.model = model;
    }
}

public class Person
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}

public class Point
{
    public int x, y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    // copy constructor 
    public Point(Point p)
    {
        this.x = p.x;
        this.y = p.y;
    }
}


//fraction class 
public class Fraction
{
    private int numerator;
    private int denominator;

    public Fraction(int numerator, int denominator)
    {
        this.denominator = denominator;
        this.numerator = numerator;
    }


    public Fraction Add(Fraction other)
    {
        int num = this.numerator * other.denominator + other.numerator * this.denominator;
        int den = this.denominator * other.denominator;

        return new Fraction(num, den);
    }

    public override string ToString()
    {
        return $"{numerator}/{denominator}";
    }
}

class Program
{
    public static void Main(string[] args)
    {

        Car myCar = new Car("Toyata");
        Console.WriteLine(myCar.model);

        Person person = new Person();
        person.Name = "John";
        Console.WriteLine(person.Name);

        Point p1 = new Point(10, 15);
        Point p2 = new Point(p1);
        Console.WriteLine("x: {0}, y: {1}", p2.x, p2.y);

        Fraction f1 = new Fraction(1, 2);
        Fraction f2 = new Fraction(1, 3);

        Fraction result = f1.Add(f2);
        Console.WriteLine(result);
    }
}