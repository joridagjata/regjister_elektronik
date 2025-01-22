using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RegjistriElektronik
{
    public class LessonPlan
    {
        public string Title { get; set; }
        public List<Subject> Subjects { get; set; }
        public bool IsOpen { get; set; }

        public LessonPlan(string title)
        {
            Title = title;
            Subjects = new List<Subject>();
            IsOpen = false; // Lesson plans are initially closed
        }

        public void ToggleStatus()
        {
            IsOpen = !IsOpen;  // Toggle the lesson plan status
        }

        public override string ToString()
        {
            return $"{Title} - {(IsOpen ? "Open" : "Closed")}";
        }
    }

}
