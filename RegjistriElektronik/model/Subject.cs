using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegjistriElektronik
{
    public class Subject
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public Subject(string name)
        {
            Name = name;
            IsActive = true; // Subjects are initially active (open)
        }

        public void ToggleStatus()
        {
            IsActive = !IsActive;  // Toggle the status from active to inactive (open to closed)
        }

        public override string ToString()
        {
            return $"{Name} - {(IsActive ? "Active" : "Inactive")}";
        }
    }
}
