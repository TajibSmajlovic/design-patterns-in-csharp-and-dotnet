using System;

namespace _4_FluentBuilderInheritanceWithRecursiveGenerics
{
    public class Person
    {
        public string Name;

        public string Position;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    internal class Builder : PersonJobBuilder<Builder>
    { /* degenerate */ }

    internal abstract class PersonBuilder<SELF>
      where SELF : PersonBuilder<SELF>
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    internal class PersonInfoBuilder<SELF> : PersonBuilder<PersonInfoBuilder<SELF>>
      where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    internal class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
      where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }

    public class Program
    {
        private static void Main(string[] args)
        {
            var builder = new Builder();
            builder.Called("test").WorksAsA("Radii");
        }
    }
}