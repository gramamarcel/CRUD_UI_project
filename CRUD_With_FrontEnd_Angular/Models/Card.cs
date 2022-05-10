using System.ComponentModel.DataAnnotations;

namespace CRUD_With_FrontEnd_Angular.Models
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }
        public string CardNumber { get; set; }
        public string Proprietar_Card { get; set; }
        public int Luna_expirarii { get; set; }
        public int Anul_expirarii { get; set; }
        public int CVV_code { get; set; }


    }
}
