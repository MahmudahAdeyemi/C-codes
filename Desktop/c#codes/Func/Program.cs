// See https://aka.ms/new-console-template for more

Add adder = DelegateExample.Sum;

adder(4,5);

Func<int,int,int> func = (a,b)=>{
    return a  + b;
};

func(6,11);
Func<int,int,int> func2 = (a,b) => a +b;

func2(8,9);

var calc = new Calculator(func);
var avg = calc.Avg(5,4);

Action<int> action = (a) => Console.WriteLine(a);

action(10);

Predicate<int> predicateEven = (a) => a % 2 == 0;

var isEven = predicateEven(11);

Func<int, int, int> func3 = DelegateExample.Sum;
func3(4,6);

var p = new Person();
p.Name = "Ade";
Console.WriteLine(p.Complexion);