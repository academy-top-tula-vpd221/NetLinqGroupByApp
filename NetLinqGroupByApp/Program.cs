using NetLinqGroupByApp;

List<Employee> employees = new List<Employee>()
{
    new() { Name = "Joe", Company = "Yandex" },
    new() { Name = "Bob", Company = "Mail Group" },
    new() { Name = "Sam", Company = "Ozon" },
    new() { Name = "Ben", Company = "Yandex" },
    new() { Name = "Tim", Company = "Ozon" },
    new() { Name = "Tom", Company = "Mail Group" },
    new() { Name = "Leo", Company = "Avito" },
    new() { Name = "Jim", Company = "Yandex" },
};

var emplsCompO = from e in employees
                 group e by e.Company;

foreach(var c in emplsCompO)
{
    Console.WriteLine(c.Key);
    foreach(var e in c)
        Console.WriteLine($"\t{e.Name}");
}
Console.WriteLine();

var emplsCompM = employees.GroupBy(e => e.Company);
foreach (var c in emplsCompM)
{
    Console.WriteLine(c.Key);
    foreach (var e in c)
        Console.WriteLine($"\t{e.Name}");
}
Console.WriteLine();


var emplsCompCountO = from e in employees
                      group e by e.Company into empl
                      select new
                      {
                          Company = empl.Key,
                          Count = empl.Count()
                      };

foreach (var c in emplsCompCountO)
{
    Console.WriteLine($"{c.Company} - {c.Count}");
    
}
Console.WriteLine();

var emplsCompCountM = employees.GroupBy(e => e.Company)
                               .Select(empl => new
                               {
                                   Company = empl.Key,
                                   Count = empl.Count()
                               });
foreach (var c in emplsCompCountM)
{
    Console.WriteLine($"{c.Company} - {c.Count}");

}
Console.WriteLine();


var emplsCompCountEmplO = from e in employees
                      group e by e.Company into empl
                      select new
                      {
                          Company = empl.Key,
                          Count = empl.Count(),
                          Employees = from e in empl
                                      select e
                      };

foreach (var c in emplsCompCountEmplO)
{
    Console.WriteLine($"{c.Company} - {c.Count}");
    foreach(var e in c.Employees)
        Console.WriteLine($"\t{e.Name}");
}
Console.WriteLine();

var emplsCompCountEmplM = employees.GroupBy(e => e.Company)
                                   .Select(empl => new
                                   {
                                       Company = empl.Key,
                                       Count = empl.Count(),
                                       Employees = empl.Select(e => e)
                                   });

foreach (var c in emplsCompCountEmplM)
{
    Console.WriteLine($"{c.Company} - {c.Count}");
    foreach (var e in c.Employees)
        Console.WriteLine($"\t{e.Name}");
}
Console.WriteLine();