using Dogukan_Kisecuklu_Odev_2.Entities;
using Dogukan_Kisecuklu_Odev_2.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Dogukan_Kisecuklu_Odev_2.Controllers
{
    public class CommonResponse<Entity>
    {
        public bool Success { get; set; } = true; // default olarak true döndürülen Success property'si
        public List<string> Error { get; set; } // Error listesi
        public Entity Data { get; set; } // Entity türünde Data property'si
        public CommonResponse()
        {
            //Boş bir constructor method
        }
        public CommonResponse(Entity data)
        {

            Data = data;
            //Entity türünde data isteyen constructor method
        }
        public CommonResponse(List<string> error)
        {
            Error = error;
            Success = false;
            //Error isteyen ve Success işlemini false'a çeviren constructor method
        }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        IValidation _validation; // Tüm validasyon işlemleri için kullanılan _validation
        List<Staff> staffs; // Constructor içinde kullanılacak staffs listesi
        public StaffController()
        {

            staffs = new List<Staff>()
            {
                new Staff
                {
                    Id = 1,
                    Name = "Huseyin",
                    LastName = "Zerdali",
                    DateofBirth = new DateTime(1999,3,30),
                    Email = "dogukan.kisecuklu@gmail.com",
                    PhoneNumber = "+905380360731",
                    Salary = 5000
                },
                new Staff
                {
                    Id = 2,
                    Name = "Mazlum",
                    LastName = "Şahin",
                    DateofBirth = new DateTime(1999,3,30),
                    Email = "mazlum.kisecuklu@gmail.com",
                    PhoneNumber = "+905380360731",
                    Salary = 3000
                },
                new Staff
                {
                    Id = 3,
                    Name = "Batuhan",
                    LastName = "Öztürk",
                    DateofBirth = new DateTime(1999,3,30),
                    Email = "yusuf.kisecuklu@gmail.com",
                    PhoneNumber = "+905380360731",
                    Salary = 2000
                },
            };
            // Constructor içinde oluşturulan list
        }
        [HttpGet]
        [Route("GetAll")]
        public CommonResponse<List<Staff>> GetAll()
        {
            return new CommonResponse<List<Staff>> { Data = staffs, Success = true };
            // Datanın alındığı ve success'i true döndürülen Get apisi
        }

        [HttpGet("GetById")]
        public CommonResponse<Staff> GetById([FromQuery] int id)
        {
            Staff staff = staffs.Where(x => id == x.Id).FirstOrDefault(); //Kullanıcının girdiği staff listte var mı diye kontrolünü sağlayan LINQ kodu

            if (staff == null)
            {
                List<string> errors = new List<string>();
                errors.Add("Couldn't find the ID");
                return new CommonResponse<Staff> { Success = false, Error = errors };
                //Eğer yoksa bir errors oluşturup ID bulunamadı hatası döndürüldü
            }
            else
            {
                return new CommonResponse<Staff> { Success = true, Data = staff };
                //Eğer sistemde varsa true döndürüp datayı gösterecek kod
            }

        }

        [HttpPost]
        [Route("AddStaff")]
        public CommonResponse<Staff> Post([FromQuery] Staff input)
        {

            Staff staff = staffs.Where(x => input.Id == x.Id).FirstOrDefault(); //Kullanıcının oluşturacağı ID daha önce kullanılmamışsa çalışacak olan kod
            if (staff == null)
            {
                staff = new Staff
                {
                    Id = input.Id,
                    Name = input.Name,
                    LastName = input.LastName,
                    DateofBirth = input.DateofBirth,
                    Email = input.Email,
                    PhoneNumber = input.PhoneNumber,
                    Salary = input.Salary
                }; // Kullanıcının girdiği değerleri eşleştirildi.
                _validation = new Validation(staff); //Validation'a oluşturduğu staff yollandı.

                List<string> errors = _validation.Validate(); // Tüm validate işlemleri kontrol edildi
                if (errors.Count == 0)
                {
                    staffs.Add(staff);
                    return new CommonResponse<Staff> { Success = true, Data = staff };
                    //Eğer hata 0 ise yeni Staff oluşturuldu 
                }
                else
                {

                    return new CommonResponse<Staff> { Success = false, Error = errors, Data = staff };
                    // Hata veya hataları var ise kullanıcıya hataları döndürüldü
                }

            }
            else
            {
                List<string> errors = new List<string>();
                errors.Add("The ID you entered is already registered in the system.");
                return new CommonResponse<Staff> { Success = false, Error = errors };
                //Kullanıcıya girdiği ID sistemde zaten kayıtlı olduğu bilgisi döndürüldü
            }

        }

        [HttpPut]
        [Route("UpdateStaff")]
        public CommonResponse<Staff> Put(int id, [FromQuery] Staff input)
        {
            Staff staff = staffs.Where(x => id == x.Id).FirstOrDefault();//Kullanıcının güncelleyeceği ID sistemde var mı kontrolü yapıldı.
            if (staff == null)
            {
                List<string> errors = new List<string>();
                errors.Add("Couldn't find the ID.");
                return new CommonResponse<Staff> { Success = false, Error = errors };
                //Eğer ID yoksa sistemde bulunamadı hatası döndürüldü

            }
            else
            {
                staffs.Remove(staff);
                staffs.Add(input);
                return new CommonResponse<Staff> { Success = true, Data = input };
                // ID var ise eski bilgi silinip yerine yeni bilgiler eklendi.

            }
        }

        [HttpDelete]
        [Route("DeleteStaff")]
        public CommonResponse<Staff> Delete([FromQuery] int id)
        {
            Staff staff = staffs.Where(x => id == x.Id).FirstOrDefault();
            if (staff == null)
            {
                List<string> errors = new List<string>();
                errors.Add("Couldn't find the ID.");
                return new CommonResponse<Staff> { Success = false, Error = errors };
                //Eğer ID yoksa sistemde bulunamadı hatası döndürüldü

            }
            else
            {
                staffs.Remove(staff);
                return new CommonResponse<Staff> { Success = true };
                // ID var ise eski bilgi silindi
            }
        }

    }
}
