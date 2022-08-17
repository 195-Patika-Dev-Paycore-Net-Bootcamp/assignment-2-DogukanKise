namespace Dogukan_Kisecuklu_Odev_2.Utils
{
    public interface IValidation // IValidation interface'i oluşturuldu bu sayede ileride eklenecek diğer validasyon türlerini de içinde
                                 // bu fonksiyonları kullanabilecek
    {
        //Kullanıcının girdiği LastName kontrolünü yapacak olan fonksiyon
        bool CheckLastName();

        //Kullanıcının girdiği Name kontrolünü yapacak olan fonksiyon
        bool CheckName();

        //Kullanıcının girdiği DateTime kontrolünü yapacak olan fonksiyon
        bool CheckDateTime();

        //Kullanıcının girdiği Salary kontrolünü yapacak olan fonksiyon
        bool CheckSalary();

        //Kullanıcının girdiği PhoneNumber kontrolünü yapacak olan fonksiyon
        bool CheckPhoneNumber();

        //Kullanıcının girdiği E-mail kontrolünü yapacak olan fonksiyon
        bool CheckEmail();

        //Kullanıcının girdiği tüm değerlerin en son kontrolünü yapacak olan fonksiyon
        List<string> Validate();

    }
}
