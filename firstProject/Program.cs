//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        //Console.WriteLine("Hello, World!");
//        //string stringVar = "Hello World! from kashish!";
//        //int intVar = 100;
//        //float floatVar = 10.2f;
//        //char charVar = 'A';
//        //bool boolVar = true;
//        //decimal d = 2;
//        //Console.WriteLine(stringVar);
//        //Console.WriteLine(Byte.MaxValue);
//        //Console.WriteLine(Int32.MaxValue);

//        char[] arr = { 'k', 'a', 's', 'h', 'i', 's', 'h' };
//        string str1 = new string(arr);
//        Console.Write(str1);
//        Console.WriteLine();
//        for (int i = 0; i < arr.Length; i++)
//        {
//            Console.WriteLine(arr[i]);
//        }
//        Console.WriteLine("2nd loop");
//        for (int i = 0; i < arr.Length; i++)
//        {
//            Console.Write(arr[i]);
//        }
//    }
//}


//namespace NumericalOperation
//{
//    class Addition
//    {
//        static int add(int x, int y)
//        {
//            return x + y;
//        }
//        static void Main(string[] args)
//        {
//            //Addition a = new Addition();
//            Subtraction s = new Subtraction();
//            Console.WriteLine("Give 2 integers");
//            int x = Convert.ToInt32(Console.ReadLine());
//            int y = Convert.ToInt32(Console.ReadLine());
//            int ans = s.sub(x, y);
//            Console.WriteLine("Addition:"+ add(x,y) );
//            //Console.WriteLine(); 
//            Console.WriteLine($"The difference of {x} and {y} is {ans}");
//        }
//    }

//    class Subtraction
//    {
//        public int sub(int x, int y)
//        {
//            return x - y;
//        }
//    }
//}


//using System.Collections;

//class Product
//{
//    public string Name { get; }
//    public double Price { get; }

//    //constructor
//    public Product(string name, double price)
//    {
//        Name = name;    
//        Price = price;
//    }

//}

//class Program
//{
//    static Product searchProduct(ArrayList al, string sk)
//    {
//        foreach (Product p in al)
//        {
//            if (p.Name.Equals(sk, StringComparison.OrdinalIgnoreCase))
//            {
//                return p;
//            }
//        }
//        return null;
//    }

//    static void Main()
//    {
//        ArrayList prod = new ArrayList();

//        prod.Add(new Product("Chocolate", 100));
//        prod.Add(new Product("Ice creame", 50));
//        prod.Add(new Product("Chocolate2", 100));
//        prod.Add(new Product("Ice creame2", 50));
//        prod.Add(new Product("Chocolate3", 100));
//        prod.Add(new Product("Ice creame3", 50));
//        prod.Add(new Product("Chocolate4", 100));
//        prod.Add(new Product("Ice creame4", 50));

//        //foreach(Product p in prod)
//        //{
//        //    Console.WriteLine(p.Name + " costs:"+p.Price);
//        //}

//        string sk = Console.ReadLine();
//        Product result = searchProduct(prod, sk);
//        if (result != null)
//        {
//            Console.WriteLine(result.Name + " price:" + result.Price);
//        }
//        else
//        {
//            Console.WriteLine("not found");
//        }

//    }
//}


//lambda
//using System;
//using System.Runtime.CompilerServices;

//List<int> l1 = new List<int> { 1, 2, 3, 4, 5, 6 };
//List<int> even = l1.Where(x => x % 2 == 0).ToList();
//Console.WriteLine(string.Join(" ", even));

//List<string> l2 = new List<string> { "apple", "box", "bat", "banana", "ant" };
//l2.Sort((a, b) => a.Length.CompareTo(b.Length));
//Console.WriteLine(string.Join(" ", l2)); //box bat ant apple banana

//List<int> l3 = new List<int> { 2, 9, 4, 8, 1, 3, 7, 5, 6 };
//var res = l3.Where(a => a > 5).OrderByDescending(b => b).ToList();
//Console.WriteLine(string.Join(" ", res));


////Function -- parameter  --> 3 parameter  --> 2i/p, 1 o/p  o/p is compilsory
//Func<int, int, int> add = (x,y) => x + y;
//Console.WriteLine(add(1,2));

//Func<string, string> print = (name) => "Welcome " + name;
//Console.WriteLine(print("Abc"));

////action
//Action<string> print1 = (name)=>Console.WriteLine(name);
//print1("Kashish");


////Predicate
//Predicate<int> check = a => a > 0;
//Console.WriteLine(check(7));

//Predicate<string> check = a => a.StartsWith("a");
//Console.WriteLine(check("kashish"));
//Console.WriteLine(check("Abc"));
//var ans = l2.FindAll(check).ToList();
//Console.WriteLine(string.Join(" ",ans));//ant apple

//Func<int, int> square = (a) => a * a;
//var res2 = l1.Select(square).ToList();
//Console.WriteLine(string.Join(" ",res2));

//Predicate<int> isPrime =  a => a>1 &&
//Enumerable.Range(2, Convert.ToInt32(Math.Sqrt(a) -1)).All(x => a % x != 0);
//var res3 = l1.FindAll(a => isPrime(a)).ToList();
//Console.WriteLine(string.Join(", ", res3));


//var res4 = l2.GroupBy(a => a[0]);  //group by returns dict
//foreach (var g in res4)
//{
//    Console.WriteLine(g.Key + " " + string.Join(" ", g));
//}  
//b box bat banana
//a ant apple

//Dictionary<int, string> dt = new Dictionary<int, string>
//{
//    {1, "apple"},
//    {2, "bat" },
//    {3, "box" },
//    {4, "kite" },
//    {5, "zoo" }
//};

//var r = dt.Where(x => x.Key > 3);  //[4, kite] [5, zoo]
//var r1 = dt.Values.ToList();  //apple bat box kite zoo
//var r2 = dt.Select(x => x.Key).ToList(); //1 2 3 4 5
//var r3 = l1.OrderBy(a => a).FirstOrDefault(a => a > 5);  //6
//var r4 = l1.FirstOrDefault(a => a > 5);  //6
//var r5 = l1.OrderBy(a => a).Any(a => a > 5); //True

//Console.WriteLine(string.Join(" ", r));  
//Console.WriteLine(string.Join(" ", r1));
//Console.WriteLine(string.Join(" ", r2));
//Console.WriteLine(string.Join(" ", r3));
//Console.WriteLine(string.Join(" ", r4));
//Console.WriteLine(string.Join(" ", r5));



//class Employee
//{
//    public int Id { get; set; } 
//    public string Name { get; set; }
//    public string Dept { get; set; }
//    public double Salary {  get; set; }


//public static void Main()
//{
//    List<Employee> l = new List<Employee>
//    { 
//        new Employee{Id=101, Name = "Kashish", Dept="CSE", Salary=35000},
//        new Employee{Id=101, Name = "Sisha", Dept="ECE", Salary=34000},
//        new Employee{Id=101, Name = "Manya", Dept="CSE", Salary=33000},
//        new Employee{Id=101, Name = "Smiti", Dept="CSIT", Salary=32000}

//    };

//var emp = l.Where(a => a.Dept == "CSE").ToList();
//foreach(Employee e in emp)
//{
//    Console.WriteLine(e.Name);
//}

//var emp2 =  l.OrderByDescending(a => a.Salary).ToList();
//foreach (Employee e in emp2)
//{
//    Console.WriteLine(e.Name + " " + e.Salary);
//}

//var emp3 = l.Select(a => new {a.Name, a.Dept}).ToList();
//emp3.ForEach(a => Console.WriteLine(a.Name + " " + a.Dept));

//var emp4 = l.GroupBy(a => a.Dept);
//foreach (var e in emp4)
//{
//    var x = e.ToList();
//    Console.WriteLine(e.Key);
//    x.ForEach(a => Console.WriteLine(a.Name));
//    Console.WriteLine();
//}

//var emp5 = l.FirstOrDefault(a => a.Dept == "CSE");
//Console.WriteLine(emp5.Name + " "+ emp5.Dept);


//double totalSalary = l.Sum(a => a.Salary);
//double avgSalary = l.Average(a => a.Salary);
//double minSalary = l.Min(a => a.Salary);

//Console.WriteLine(string.Format("{0:f2}", totalSalary));
//Console.WriteLine(Math.Round(avgSalary));
//Console.WriteLine(minSalary.ToString());

//var maxSalary = l.Max(a => a.Salary);
//var emp6 = l.Where(a => a.Salary == maxSalary).Select(a => a.Name).ToList();
//Console.WriteLine( string.Join(", ", emp6));


//    }
//}


//public delegate int Delcalculation(int a, int b);

//public class Calculate
//{
//    public int add(int x, int y)
//    {
//        return x + y;   
//    }
//    public int subtract(int x, int y) { return x - y; }

//    Func<int, int, int> mul = (a,b) =>  a * b; 

//    public static void Main()
//    {
//        Calculate calc = new Calculate();
//        Delcalculation addOp = new Delcalculation(calc.add);
//        Console.WriteLine(addOp(1, 2));
//        Delcalculation mulOP = new Delcalculation(calc.mul);
//        Console.WriteLine(mulOP(3, 2));
//    }
//}

/*
public delegate bool check1(int n);
public delegate void check2(int n);
public class Program
{
    public void calculation(List<int> l, check1 ch)
    {
        foreach (var i in l)
        {
            if (ch(i))
            {
                Console.WriteLine(i);
            }
        }
    }
    public static bool IsEven(int number)
    {
        return number % 2 == 0;
    }
    public static void print(int n)
    {
        Console.WriteLine(n);
    }

    public static void Main()
    {
        Program p = new Program();
        List<int> l = new List<int> { 1,2,3,4,5,6,7,8,9};
        //1st
        p.calculation(l, x => x%2 == 0);
        //2nd
        check1 ch = IsEven;
        var evenNumbers = l.Where(n => ch(n)).ToList();
        Console.WriteLine(string.Join(", ", evenNumbers));
        //3rd
        check2 printDel = print;
        l.Where(n => n%2 == 0).ToList().ForEach(a => printDel(a));
    }
}

*/


/*
//delegate  --> Event

using System;

public delegate void NotifyEventHandler(string msg);

class Program
{
    //event
    public event NotifyEventHandler n;

    //method
    public void RaiseEvent(string msg)
    {
        n?.Invoke(msg);
    }

    public void DisplayMessage(string msg)
    {
        Console.WriteLine(msg);
    }

    static void Main()
    {
        Program p1 = new Program();
        p1.n += p1.DisplayMessage;
        p1.RaiseEvent("hello from p1");

        Program p2 = new Program();
        p2.n += p2.DisplayMessage;
        p2.RaiseEvent("hello from p2");

        p1.n -= p1.DisplayMessage;
    }
}
*/

