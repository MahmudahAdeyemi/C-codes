// Number 1
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using LinqExample;

var listOfInt = new List<int>();
var evennumbers = listOfInt.Where(x => x % 2 == 0).ToList();

// Number 2
var listOfStrings = new List<string>();
var ascending = listOfStrings.OrderBy(x => x).ToList();


void Arrange()=> listOfStrings.OrderBy(x => x);


// Number 5
var max = listOfInt.Max(x => x);

void Min()  => listOfInt.Min();

// Number 4

var listOfStudent = new List<Student>();
var listOfCourse = new List<Course>();
var newlist = 
            from student in listOfStudent
            from course in listOfCourse
            where student.Id == course.StudentId
            select new 
            {
                Id = student.Id,
                Name = student.Name,
                StudentCourse = course.Name
            };

// Number 6
listOfStrings.RemoveAll(x =>x.Contains('a'));

void Remove() => listOfStrings.RemoveAll(x => x.Contains('a'));

// Number 7
int count = listOfInt.Where(x=> x> 10).ToList().Count;

int Sum() => listOfInt.Where(x => x >10).Sum();

// Number 8
var distinct = listOfInt.Distinct().ToList();

List<int> Distinct() => listOfInt.Distinct().ToList();

// Number 9
var longeststring = listOfStrings.Single(x => x.Length == listOfStrings.Select(x => x.Length).ToList().Max());

string Shortesttring() => listOfStrings.Single(x => x.Length == listOfStrings.Select(x => x.Length).ToList().Min());


// Number 10
var graterThan5 = listOfInt.Where(x => x >5).ToList();
var lessThan5 = listOfInt.Where(x => x < 5).ToList();

List<int> GraterThan5() => listOfInt.Where(x => x >5).ToList();
List<int> LessThan5() => listOfInt.Where(x => x<5).ToList();