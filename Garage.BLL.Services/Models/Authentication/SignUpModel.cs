namespace Garage.BLL.Services.Models.Authentication
{
    public class SignUpModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int DrivingExpirience { get; set; }
    }
}
