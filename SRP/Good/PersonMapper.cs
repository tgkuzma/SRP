using System;
using SRP.Domain;

namespace SRP.Good
{
    public class PersonMapper
    {
        public Person Map(string[] propertiesToMap)
        {
            return new Person
            {
                LastName = propertiesToMap[0],
                FirstName = propertiesToMap[1],
                Birthday = DateTime.Parse(propertiesToMap[2])
            };
        } 
    }
}