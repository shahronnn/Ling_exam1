using _001Task;
using _001Task.Data;

await using var dataContext = new DataContext();


Console.WriteLine(" Good look 😊😊😊 ");

//1
//Напишите запрос LINQ, чтобы получить всех людей, живущих в городе с населением более 3 000 000 человек.
//Write a LINQ query to retrieve all the people who live in a city with a population greater than 3 000 000

var list = from c in dataContext.Cities
join p in dataContext.Peoples on c.Id equals p.CityId
where c.Population >= 3000000
select new {c.Name, p.FirstName, p.LastName};

foreach (var p in list)
{
    System.Console.WriteLine(p.Name + " '" + p.FirstName + " " + p.LastName + "'");
}
System.Console.WriteLine();

//2
//Получите все города со средней численностью населения в соответствующей стране
//Retrieve all cities with their respective country's average population

var list2 = from c in dataContext.Countries
join city in dataContext.Cities on c.Id equals city.CountryId
select new {c.Name, c};  
// savol nofahmo ustod

//3
//Получите города с самым высоким населением в каждой стране
//Retrieve the cities with the highest population in each country

var list3 = (from coun in dataContext.Countries
join c in dataContext.Cities on coun.Id equals c.CountryId
orderby c.Population
select new{country= coun.Name, name = c.Name}).Take(1);

foreach (var c in list3)
{
    System.Console.WriteLine(c.country + " " + c.name);
}
//4
//Получите среднее население городов в каждой стране
//Retrieve the average population of cities in each country

// var list4 = from coun in dataContext.Countries
// join c in dataContext.Cities on coun.Id equals c.CountryId;


//5
//Получить все города, в которых есть человек по имени "Марк".
//Retrieve all cities that have a person with by name "Mark"
System.Console.WriteLine();
var list5 = from p in dataContext.Peoples
join c in dataContext.Cities on p.CityId equals c.Id
where p.FirstName == "Mark" || p.LastName == "Mark"
select c;
foreach (var c in list5)
{
    System.Console.WriteLine(c.Name);
}

//6
//Получить всех людей вместе с соответствующими названиями городов и стран
//Retrieve all people along with their associated city and country names
System.Console.WriteLine();
var list6 = from p in dataContext.Peoples
join c in dataContext.Cities on p.CityId equals c.Id
join coun in dataContext.Countries on c.CountryId equals coun.Id
select new{p.FirstName, p.LastName,city = c.Name,country = coun.Name};
foreach (var p in list6)
{
    System.Console.WriteLine($"[{p.FirstName + " " + p.LastName}] {p.city} {p.country}");
}
//7
//Получите все города вместе с соответствующими названиями стран, используя свойство навигации
//Retrieve all cities along with their associated country names using a navigation property



//8
//Получить всех людей вместе с связанными с ними городом и страной.
//Retrieve all people along with their associated city and country 
System.Console.WriteLine();
var list8 = from p in dataContext.Peoples
join c in dataContext.Cities on p.CityId equals c.Id
join coun in dataContext.Countries on c.CountryId equals coun.Id
select new{p.FirstName, p.LastName,city = c.Name,country = coun.Name};
foreach (var p in list8)
{
    System.Console.WriteLine($"[{p.FirstName + " " + p.LastName}] {p.city} {p.country}");
}
//9
//Получить всех людей, живущих в "USA".
//Retrieve all people living in  "USA".
System.Console.WriteLine(); 
var list9 = from p in dataContext.Peoples
join c in dataContext.Cities on p.CityId equals c.Id
join coun in dataContext.Countries on c.CountryId equals coun.Id
where coun.Name == "USA"
select new{p.FirstName, p.LastName};

foreach (var p in list9)
{
    System.Console.WriteLine(p.FirstName + " " + p.LastName);
}

//10
//Получить всех людей вместе с соответствующим населением города и страны
//Retrieve all people along with their associated city and country populations 

var list10 = from p in dataContext.Peoples
join c in dataContext.Cities on p.CityId equals c.Id
join coun in dataContext.Countries on c.CountryId equals coun.Id
select new{p.FirstName, p.LastName, c.Population};
foreach (var p in list10)
{
    System.Console.WriteLine($"[{p.FirstName} {p.LastName}]     {p.Population}");
}



