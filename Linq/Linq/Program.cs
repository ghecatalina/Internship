using Linq;
using System.Collections;
using System.Linq;

namespace Linq
{
    class Program
    {
        private static readonly IEnumerable<Animal> _animals = CreateAnimalList();
        private static readonly IEnumerable<Animal> _animals3 = CreateAnimalList();
        private static readonly IEnumerable<Animal> _animals2 = CreateAnimalList2();
        private static readonly IEnumerable<Zoo> _zoos = CreateZooList();
        private static readonly IEnumerable<Tiger> _tigers = CreateTigerList();

        private static IEnumerable<Tiger> CreateTigerList()
        {
            return new List<Tiger>
            {
                new Tiger {Name = "Tiger 1"},
                new Tiger {Name = "Tiger 2"}
            };
        }
        private static IEnumerable<Animal> CreateAnimalList()
        {
            return new List<Animal>
            {
        new Animal { Type = "Mammal", Name = "Alfred", Breed = "Lion", Age = 4, ZooName = "Tm Zoo" },
        new Animal { Type = "Bird", Name = "Chipi", Breed = "Peacock", Age = 1, ZooName = "Tm Zoo" },
        new Animal { Type = "Bird", Name = "Pablo", Breed = "Parrot", Age = 2, ZooName = "B Zoo" },
        new Animal { Type = "Fish", Name = "Nemo", Breed = "Zebrafish", Age = 4, ZooName = "Tm Zoo" },
        new Animal { Type = "Mammal", Name = "Mary", Breed = "Tiger", Age = 6, ZooName = "Tm Zoo" },
        new Animal { Type = "Fish", Name = "Dory", Breed = "Trout", Age = 4, ZooName = "B Zoo" },
        new Animal { Type = "Mammal", Name = "Teddy", Breed = "Bear", Age = 8, ZooName = "Tm Zoo" },
        new Animal { Type = "Fish", Name = "Amy", Breed = "Rainbowfish", Age = 4, ZooName = "Cj Zoo" },
            };
        }

        private static IEnumerable<Animal> CreateAnimalList2()
        {
            return new List<Animal>
            {
        new Animal { Type = "Mammal", Name = "Alfreda", Breed = "Lion", Age = 4, ZooName = "Tm Zoo" },
        new Animal { Type = "Bird", Name = "Chipiiii", Breed = "Peacock", Age = 1, ZooName = "Tm Zoo" },
        new Animal { Type = "Bird", Name = "Pablooooo", Breed = "Parrot", Age = 2, ZooName = "B Zoo" },
        new Animal { Type = "Fish", Name = "Nemooo", Breed = "Zebrafish", Age = 4, ZooName = "Tm Zoo" },
        new Animal { Type = "Mammal", Name = "Mary", Breed = "Tiger", Age = 6, ZooName = "Tm Zoo" },
        new Animal { Type = "Fish", Name = "Dory", Breed = "Trout", Age = 4, ZooName = "B Zoo" },
        new Animal { Type = "Mammal", Name = "Teddy", Breed = "Bear", Age = 8, ZooName = "Tm Zoo" },
        new Animal { Type = "Fish", Name = "Amyyyyy", Breed = "Rainbowfish", Age = 4, ZooName = "Cj Zoo" },
        new Animal { Type = "Fish", Name = "Amyyyyy", Breed = "Rainbowfish", Age = 4, ZooName = "Cj Zoo" },
        new Animal { Type = "Mammal", Name = "Alfreda", Breed = "Lion", Age = 4, ZooName = "Tm Zoo" },
            };
        }

        private static IEnumerable<Zoo> CreateZooList()
        {
            return new List<Zoo>
            {
                new Zoo { Name = "Tm Zoo", Employees = new List<string>{ "Ana", "Maria", "Vlad"}},
                new Zoo { Name = "B Zoo", Employees = new List<string>{ "Diana", "Adelin", "Mircea"}},
                new Zoo { Name = "Cj Zoo", Employees = new List<string>{ "Dan", "Daria", "Darian"}}
            };
        }

        static void PrintLoop<T>(IEnumerable<T> collec)
        {
            foreach (var item in collec)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            Zoo zoo = new Zoo { Name = "Tm Zoo" };
            var year4 = _animals.Where(animal => animal.Age == 4);
            var first2 = _animals.Take(2);
            var skipfirst2 = _animals.Skip(2);
            var age3 = _animals.Select(animal => animal.Age = 3);
            var joinZoos = _animals.Join(
                _zoos,
                animal => animal.ZooName,
                zoo => zoo.Name,
                (animal, zoo) => new
                {
                    AnimalName = animal.Name,
                    ZooName = zoo.Name,
                });
            //PrintLoop(joinZoos);
            var groupJoin = _zoos.GroupJoin(
                _animals,
                zoo => zoo.Name,
                animal => animal.ZooName,
                (zoo, animalsGroup) => new
                {
                    Animals = animalsGroup,
                    ZooName = zoo.Name,
                });
            /*foreach(var item in groupJoin)
            {
                Console.WriteLine(item.ZooName);
                PrintLoop(item.Animals);
            }*/
            //PrintLoop(groupJoin);

            var orderedByAgeD = _animals.OrderByDescending(animal => animal.Age);

            var orderByName = _animals.OrderBy(animal => animal.Name);

            var reversed = _animals.OrderBy(_animal => _animal.Name).Reverse();

            var concatList = _animals.Concat(_animals2);

            var unionList = _animals.Union(_animals2, new AnimalComparer());

            var intersectList = _animals.Intersect(_animals2, new AnimalComparer());

            var exceptList = _animals.Except(_animals2, new AnimalComparer());
            
            //var array = _animals.ToArray();

            var list = _animals.ToList();

            var dic = _animals.ToDictionary(animal => animal.Name);

            /*foreach (KeyValuePair<string, Animal> kvp in dic)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }*/

            var firsAge6 = _animals.First(animal => animal.Age == 6);
            //Console.WriteLine(firsAge6);

            var lastAge4 = _animals.Last(animal => animal.Age == 4);
            //Console.WriteLine(lastAge4);

            var singleAge8 = _animals.Single(animal => animal.Age == 8);
            //Console.WriteLine(singleAge8);

            var elemAt4 = _animals.ElementAt(4);
            //Console.WriteLine(elemAt4);

            var cntAge4 = _animals.Count(animal => animal.Age == 4);
            //Console.WriteLine(cntAge4);

            var min = _animals.Min(animal => animal.Age);
            //Console.WriteLine(min);

            var noOfMammals = _animals.Sum(animal =>
            {
                if (animal.Type.Equals("Mammal"))
                    return 1;
                else
                    return 0;
            });
            //Console.WriteLine($"No of mammals: {noOfMammals}");

            var avarageAge = _animals.Average(animal => animal.Age);
            //Console.WriteLine(avarageAge);

            var contains = _animals.Contains(new Animal { Type = "Mammal", Name = "Teddy", Breed = "Bear", Age = 8, ZooName = "Tm Zoo" }, new AnimalComparer());
            //Console.WriteLine(contains);

            var ageSmallerThan3 = _animals.Any(animal => animal.Age < 0);
            //Console.WriteLine(ageSmallerThan3);

            var ageGreaterThan0 = _animals.All(animal => animal.Age > 0);
            //Console.WriteLine(ageGreaterThan0);

            var listsEqual = _animals.SequenceEqual(_animals3);
            //Console.WriteLine(listsEqual);

            var repeatEl3 = Enumerable.Repeat(_animals.ElementAt(3), 4);

            var range = Enumerable.Range(0, 34);
            //PrintLoop(range);

            /*foreach (var animal in _animals)
            {
                Console.WriteLine(animal.IsMammal() + " " + animal.CreateId() + " " + animal.GenerateValueFromName());
            }*/

            var groupByType = _animals.GroupBy(animal => animal.Type);
            /*foreach (IGrouping<string, Animal> animalGroup in groupByType)
            {
                Console.WriteLine(animalGroup.Key);
                PrintLoop(animalGroup);
            }*/

            ILookup<string, Animal> lookup = _animals
                .ToLookup(
                animal => animal.ZooName,
                animal => animal);
            /*foreach(IGrouping<string, Animal> group in lookup)
            {
                Console.WriteLine(group.Key);
                PrintLoop(group);
            }*/

            IList genericList = new ArrayList();
            genericList.Add(new Animal { Type = "Mammal", Name = "Alfred", Breed = "Lion", Age = 4, ZooName = "Tm Zoo" });
            genericList.Add("un animal");
            genericList.Add(3);
            genericList.Add(new Animal { Type = "Bird", Name = "Chipi", Breed = "Peacock", Age = 1, ZooName = "Tm Zoo" });

            var animalList = genericList.OfType<Animal>();
            //PrintLoop(animalList);

            var orderedList = _animals
                .OrderBy(_animals => _animals.ZooName)
                .ThenBy(animal => animal.Name);
            //PrintLoop(orderedList);

            IEnumerable<int> indexes = Enumerable.Range(1, _animals.Count());
            var indexedList = indexes.Zip(_animals.OrderBy(animal => animal.Name), (first, second) => first + " - " + second);
            //PrintLoop(indexedList);
            
            var selManyList = _zoos.SelectMany(zoo => zoo.Employees, (zoo, employee) => new {ZooName = zoo.Name, Employee = employee});
            //PrintLoop(selManyList);

            var onlyBirds = _animals
                .OrderBy(animal => animal.Type)
                .TakeWhile(animal => animal.Type.Equals("Bird"));
            //PrintLoop(onlyBirds);

            var noBirds = _animals
                .OrderBy(animal => animal.Type)
                .SkipWhile(animal => animal.Type.Equals("Bird"));
            //PrintLoop(noBirds);

            var distinct = _animals2.Distinct();
            //PrintLoop(distinct);

            //var noOfFish = _animals.Sum(animal => animal.Type.Equals("Fish") ? 1 : 0);
            var noOfFish = _animals
                .Where(animal => animal.Type.Equals("Fish"))
                .Sum(animal => 1);
            //Console.WriteLine(noOfFish);

            var castList = _tigers.Cast<Animal>();
            /*foreach (var animal in castList)
            {
                animal.Speak();
            }*/

            //numele angajatilor care lucrează la zoo-ul în care este animalul cu numele Alfred
            /*var employess = _zoos
                .Join(
                _animals,
                zoo => zoo.Name,
                animal => animal.ZooName,
                (zoo, animal) => new
                {
                    EmployeesNames = zoo.Employees,
                    AnimalName = animal.Name
                })
                .Where(group => group.AnimalName.Equals("Alfred"))
                .Select(groups => groups.EmployeesNames).ToList();*/

            //Prob 1
            var array = new int[] { 8, 2, 3, 3, 5, 6, 5, 8, 9, 10, 1, 12, 2, 2, 25, 8, 16, 2 };

            var cnt = array
                .GroupBy(n => n)
                .Select(group => new 
                {
                    numar = group.Key,
                    repetitii = group.Count()
                });
            PrintLoop(cnt);
            Console.WriteLine();
            //Prob 2
            var max = array
                .GroupBy(n => n)
                .Select(group => new
                {
                    Numar = group.Key,
                    repetitii = group.Count()
                })
                .MaxBy(group => group.repetitii);
                
                
            Console.WriteLine(max);
            Console.WriteLine();

            //Prob 3
            string[] first = new string[] { "hello", "hi", "max", "good evening", "good day", "good morning", "goodbye" }; 
            string[] second = new string[] { "whatsup", "how are you", "hello", "bye", "maybe", "hi" };
            var intersectionH = first
                .Intersect(second)
                .Where(str => str.ElementAt(0) == 'h');
            PrintLoop(intersectionH);
            Console.WriteLine();

            //Prob 4
            var str = first
                .Concat(second)
                .Aggregate("", (prev, next) => prev + next.ElementAt(next.Length - 1));
            Console.WriteLine(str);
            Console.WriteLine();

            //Prob 5
            var totalEmployee = _zoos.Sum(zoo => zoo.Employees.Count());
            Console.WriteLine(totalEmployee);
        }
    }
}