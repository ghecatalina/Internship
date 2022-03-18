using Linq;
using System.Linq;

namespace Linq
{
    class Program
    {
        private static readonly IEnumerable<Animal> _animals = CreateAnimalList();
        private static readonly IEnumerable<Animal> _animals2 = CreateAnimalList2();
        private static readonly IEnumerable<Zoo> _zoos = CreateZooList();
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
            };
        }

        private static IEnumerable<Zoo> CreateZooList()
        {
            return new List<Zoo>
            {
                new Zoo { Name = "Tm Zoo"},
                new Zoo { Name = "B Zoo"},
                new Zoo { Name = "Cj Zoo"}
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

            var array = _animals.ToArray();

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
            //Console.WriteLine(noOfMammals);

            var avarageAge = _animals.Average(animal => animal.Age);
            //Console.WriteLine(avarageAge);

            var contains = _animals.Contains(new Animal { Type = "Mammal", Name = "Teddy", Breed = "Bear", Age = 8, ZooName = "Tm Zoo" });
            //Console.WriteLine(contains);

            var ageSmallerThan3 = _animals.Any(animal => animal.Age < 0);
            //Console.WriteLine(ageSmallerThan3);

            var ageGreaterThan0 = _animals.All(animal => animal.Age > 0);
            //Console.WriteLine(ageGreaterThan0);

            var listsEqual = _animals.SequenceEqual(_animals2);
            //Console.WriteLine(listsEqual);

            var repeatEl3 = Enumerable.Repeat(_animals.ElementAt(3), 4);

            var range = Enumerable.Range(0, 34);
            //PrintLoop(range);

            foreach (var animal in _animals)
            {
                Console.WriteLine(animal.IsMammal() + " " + animal.CreateId() + " " + animal.GenerateValueFromName());
            }
        }
    }
}