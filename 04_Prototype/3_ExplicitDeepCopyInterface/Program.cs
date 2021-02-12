using System;

namespace _3_ExplicitDeepCopyInterface
{
    public interface IPrototype<T>
    {
        T Clone();
    }

    public class Address : IPrototype<Address>
    {
        public string StreetAddress, City, Country;

        public Address(string streetAddress, string city, string country)
        {
            StreetAddress = streetAddress ?? throw new ArgumentNullException(paramName: nameof(streetAddress));
            City = city ?? throw new ArgumentNullException(paramName: nameof(city));
            Country = country ?? throw new ArgumentNullException(paramName: nameof(country));
        }

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(City)}: {City}, {nameof(Country)}: {Country}";
        }

        public Address Clone()
        {
            return new Address(StreetAddress, City, Country);
        }
    }

    public class Employee : IPrototype<Employee>
    {
        public string Name;
        public Address Address;

        public Employee(string name, Address address)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Address = address ?? throw new ArgumentNullException(paramName: nameof(address));
        }

        public Employee Clone()
        {
            return new Employee(Name, Address.Clone());
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
    }

    public class Program
    {
        private static void Main(string[] args)
        {
            var john = new Employee("John", new Address("123 London Road", "London", "UK"));

            var chris = john.Clone();

            chris.Name = "Chris";
            Console.WriteLine(john);
            Console.WriteLine(chris);
        }
    }
}