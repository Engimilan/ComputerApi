using System.ComponentModel.DataAnnotations.Schema;

namespace computerwebshop.models.DTOs
{
    public class AddNewComputerDTO
    {
        public string? Brand { get; set; }

        public string? Type { get; set; }

        public double Display { get; set; }

        public int Memory { get; set; }
        
        public Guid Osid {  get; set; }

    }
}
