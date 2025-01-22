using System;

namespace RegjistriElektronik
{
    internal class AcademicYear
    {
        public AcademicYear(string v)
        {
        }

        public bool IsOpen { get; internal set; }
        public bool IsActive { get; private set; }

        internal void ToggleStatus()
        {
            IsActive = !IsActive;
           
        }
    }
}