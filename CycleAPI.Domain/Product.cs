using System.ComponentModel.DataAnnotations.Schema;

namespace CycleAPI.Domain
{
    //definimos el producto con sus atributos
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ? Name { get; set; }
        public int ? Price { get; set; }
        public string ? Description { get; set; }
        public string ? Category { get; set; }
        public string ? Image { get; set; }
        public bool? State { get; set; }
    }
}
