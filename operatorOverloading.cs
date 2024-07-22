using System;
using System.Collections.Generic;

public class ComplexNumber{
  public double Real {get; set;}
  public double Imaginary {get; set;}

  public ComplexNumber(double real, double imaginary)
  {
    Real = real;
    Imaginary = imaginary;
  }

  public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b){
    return new ComplexNumber (a.Real + b.Real , a.Imaginary + b.Imaginary);
  }

  public override string ToString()
  {
    return $"{Real} {Imaginary}";
  }
}


//Dynamic Array 
public class DynamicArray<T>{
  private List<T> _items;

  public DynamicArray()
  {
    _items = new List<T>();
  }

  public void Add(T item){
    _items.Add(item);
  }

  public T this[int index]{
    get {return _items[index];}
    set { _items[index] = value;}
  }

  public int Length {
    get {return _items.Count;}
  }

}

class Program {
  public static void Main (string[] args) {
    ComplexNumber c1= new ComplexNumber(1.5,2.5);
    ComplexNumber c2= new ComplexNumber(3.5,4.5);

    ComplexNumber c3= c1+c2;

    Console.WriteLine(c3);

    DynamicArray<int> array = new DynamicArray<int>();
    array.Add(1);
    array.Add(2);
    array.Add(3);
    array[2] = 5;
    Console.WriteLine(array[2]); // Output: 1
    Console.WriteLine(array.Length); // 
 
    
  }
}