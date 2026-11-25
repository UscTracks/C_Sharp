using System;
using System.Collections.Generic;
using System.Text;

namespace USCTracks__sec3
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }

    }
}
