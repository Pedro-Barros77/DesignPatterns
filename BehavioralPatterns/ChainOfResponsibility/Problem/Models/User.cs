using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.Problem.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public bool IsModerator { get; set; }

        public User(Guid id, string name, int age, bool isActive, bool isModerator)
        {
            Id = id;
            Name = name;
            Age = age;
            IsActive = isActive;
            IsModerator = isModerator;
        }
    }
}
