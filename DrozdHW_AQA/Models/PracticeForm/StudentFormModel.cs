namespace DrozdHW_AQA.Models.PracticeForm
{
    public class StudentFormModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.Today;
        public List<string> Subjects { get; set; } = new();
        public List<string> Hobbies { get; set; } = new();
        public string PicturePath { get; set; } = string.Empty;
        public string CurrentAddress { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
