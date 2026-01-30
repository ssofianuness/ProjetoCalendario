using System;

namespace ProjetoCalendario.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }

        public void Validate()
        {
            if (End <= Start)
                throw new Exception("A data de fim deve ser superior à de início.");
        }
    }
}
