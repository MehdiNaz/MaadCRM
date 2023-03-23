namespace Domain.Models;

public class Banner
{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte Show { get; set; }
        public string Extension { get; set; }
        public string Link { get; set; }
        public int Category { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateCreated { get; set; }
        public byte[] Rowversion { get; set; }
    }