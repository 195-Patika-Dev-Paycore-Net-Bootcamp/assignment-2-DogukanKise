using Dogukan_Kisecuklu_Odev_2.Entities;
using System.Text.RegularExpressions;

namespace Dogukan_Kisecuklu_Odev_2.Utils
{
    public class Validation : IValidation
    {
        Staff _staff; //Constructor method için değişken oluşturdum
        public Validation(Staff staff)
        {
            this._staff = staff; //Validation her çağırıldığında staff isteyecek
        }


        Regex validatePhoneNumberRegex = new Regex(@"^\+(?:[0-9]●?){6,14}[0-9]$"); //Phone number için regex +90 5380360731(Alan kodundan sonra boşluk
                                                                                   //bırakmak gerekiyor)

        Regex validateEmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");// Email kullanımı için regex
        public bool CheckLastName()
        {
            //Eğer LastName 5ten büyük 120den küçükse ve özel karakter almıyorsa true döndürecek alıyorsa false döndürecek
            if (_staff.LastName.Length > 5 && _staff.LastName.Length < 120 && _staff.LastName.IndexOfAny(new char[] { '*', '&', '#', '!', '!' }) == -1)
            {
                return true;
            }
            else
                return false;
        }
        public bool CheckName()
        {
            //Eğer Name 5ten büyük 120den küçükse ve özel karakter almıyorsa true döndürecek alıyorsa false döndürecek
            if (_staff.Name.Length > 5 && _staff.Name.Length < 120 && _staff.LastName.IndexOfAny(new char[] { '*', '&', '#', '!', '!' }) == -1)
            {
                return true;
            }
            else
                return false;
        }
        public bool CheckDateTime()
        {
            // Kullanıcının girdiğim tarih 11/11/1945 ve 10/10/2022 arasındaysa true değilse false döndürecek(Swaggerda 1999-30-03 şeklinde giriliyor)
            if (_staff.DateofBirth > new DateTime(1945, 11, 11) && _staff.DateofBirth < new DateTime(2002, 10, 10))
            {
                return true;
            }
            else
                return false;
        }

        public bool CheckSalary()
        {
            // Kullanıcının girdiği maaş 2000 ve 9000 arasındaysa true değilse false döndürecek
            if (_staff.Salary > 2000 && _staff.Salary < 9000)
            {
                return true;
            }
            else
                return false;
        }
        public bool CheckPhoneNumber()
        {
            //Yukarda oluşturduğum phone number regex kullanıcının girdiği phone number ile eşleşmiyorsa true eşleşiyorsa false döndürecek
            if (!validatePhoneNumberRegex.IsMatch(_staff.PhoneNumber))
            {
                return true;
            }
            else
                return false;
        }
        public bool CheckEmail()
        {
            //Yukarda oluşturduğum email regex kullanıcının girdiği e-mail ile eşleşmiyorsa true eşleşiyorsa false döndürecek
            if (!validateEmailRegex.IsMatch(_staff.PhoneNumber))
            {
                return true;
            }
            else
                return false;
        }
        public List<string> Validate()
        {
            //Kullanıcı giriş yaparken birden fazla hata alabilir diye bir hata listesi oluşturdum
            List<string> errors = new List<string>();
            if (!CheckDateTime()) errors.Add("Date of birth must be beetwen 10-10-2002 and 11-11-1945");//Eğer datetime yanlış girilmişse error listesine eklenecek
            if (!CheckName()) errors.Add("Name must be beetwen 5-120 characters");//Eğer name yanlış girilmişse error listesine eklenecek
            if (!CheckLastName()) errors.Add("Last name must be beetwen 5-120 characters");//Eğer LastName yanlış girilmişse error listesine eklenecek
            if (!CheckEmail()) errors.Add("Incorrect e-mail");//Eğer Email yanlış girilmişse error listesine eklenecek
            if (!CheckPhoneNumber()) errors.Add("Incorrect phone number"); //Eğer Phonenumber yanlış girilmişse error listesine eklenecek
            if (!CheckSalary()) errors.Add("Salary must be beetwen 2000-9000");//Eğer salary yanlış girilmişse error listesine eklenecek

            return errors; //En sonunda hata listesini döndürecek
        }
    }
}
