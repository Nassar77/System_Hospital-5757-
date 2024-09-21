using System.ComponentModel.DataAnnotations;


namespace HospitalSystem.DAL.Entity
{
    public class Room
    {
        [Key]
        public int ID { get; set; }
        public string? RName { get; set; }
        public int Capacity { get; set; } // Total capacity of the room
       
    }
}

