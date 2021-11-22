using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FranCars.Shared.Models
{
    public class Cars
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Location { get; set; }

        public List<Vehicle> Vehicles { get; set; }

        [ForeignKey("Warehouses")]
        public int WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }
    }
}
