using System.ComponentModel.DataAnnotations;

namespace Dogukan_Kisecuklu_Odev_2.Entities
{
    public class Staff : IEntity // Boşta class kalmasın mantığıyla Staff clasına bir Entity olduğunu gösterildi
    {

        //Ödevde belirtilen propertyleri aldım ve hepsinde required attribute'unu kullanıldı
        [Required(ErrorMessage = "Please enter a ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a DateTime")]
        public DateTime DateofBirth { get; set; }

        [Required(ErrorMessage = "Please enter a Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a Email")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter a salary")]
        public double Salary { get; set; }
    }
}
