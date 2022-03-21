using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Animal
    {
        public string Type { get; set; }
        public string Breed { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string ZooName { get; set; }

        public void Speak()
        {
            Console.WriteLine("Animal speaks");
        }

        public override string ToString()
        {
            return $"Animal: {this.Name}, {this.Type}, {this.Breed}, age: {this.Age} zoo: {this.ZooName}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
                return false;
            else
            {
                Animal other = (Animal)obj;
                return this.Name.Equals(other.Name) 
                    && this.Type.Equals(other.Type)
                    && this.Breed.Equals(other.Breed)
                    && this.ZooName.Equals(other.ZooName)
                    && this.Age == other.Age;
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }

    public class Tiger : Animal
    {
        public void Speak()
        {
            Console.WriteLine("Tiger roars");
        }
    }

    public class Lion : Animal
    {

    }

    public class AnimalComparer : IEqualityComparer<Animal>
    {
        public bool Equals(Animal? x, Animal? y)
        {
            if (x== null || y == null)
                return false;
            return x.Equals(y);
        }

        public int GetHashCode([DisallowNull] Animal obj)
        {
            return obj.Name.GetHashCode();
        }
    }

    public static class AnimalExtension
    {
        public static bool IsMammal(this Animal a)
        {
            return a.Type.Equals("Mammal");
        }

        public static string CreateId(this Animal a)
        {
            return a.Type.Substring(0, 2) + a.Age + a.Name;
        }

        public static int GenerateValueFromName(this Animal a)
        {
            int val = 0;
            char[] chars = a.Name.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                val += chars[i];
            }
            return val;
        }
    }
}
