using System;

namespace API.Models
{
    public class Door
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public bool IsOpen { get; set; }
        public bool IsLocked
        {
            get;
            set;
        }
    }
}
