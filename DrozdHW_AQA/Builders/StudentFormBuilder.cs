using DrozdHW_AQA.DTO.PracticeFormDTO;

namespace DrozdHW_AQA.Builders
{
    public class StudentFormBuilder
    {
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string email = string.Empty;
        private string gender = string.Empty;
        private string mobile = string.Empty;
        private DateTime dateOfBirth = DateTime.Today;
        private readonly List<string> subjects = new();
        private readonly List<string> hobbies = new();
        private string picturePath = string.Empty;
        private string currentAddress = string.Empty;
        private string state = string.Empty;
        private string city = string.Empty;

        public StudentFormBuilder WithFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public StudentFormBuilder WithLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public StudentFormBuilder WithEmail(string email)
        {
            this.email = email;
            return this;
        }

        public StudentFormBuilder WithGender(string gender)
        {
            this.gender = gender;
            return this;
        }

        public StudentFormBuilder WithMobile(string mobile)
        {
            this.mobile = mobile;
            return this;
        }

        public StudentFormBuilder WithDateOfBirth(DateTime dateOfBirth)
        {
            this.dateOfBirth = dateOfBirth;
            return this;
        }

        public StudentFormBuilder WithSubject(string subject)
        {
            subjects.Add(subject);
            return this;
        }

        public StudentFormBuilder WithHobby(string hobby)
        {
            hobbies.Add(hobby);
            return this;
        }

        public StudentFormBuilder WithPicture(string picturePath)
        {
            this.picturePath = picturePath;
            return this;
        }

        public StudentFormBuilder WithCurrentAddress(string currentAddress)
        {
            this.currentAddress = currentAddress;
            return this;
        }

        public StudentFormBuilder WithStateAndCity(string state, string city)
        {
            this.state = state;
            this.city = city;
            return this;
        }

        public StudentFormDTO Build()
        {
            return new StudentFormDTO(
                firstName,
                lastName,
                email,
                gender,
                mobile,
                dateOfBirth,
                new List<string>(subjects),
                new List<string>(hobbies),
                picturePath,
                currentAddress,
                state,
                city);
        }
    }
}
