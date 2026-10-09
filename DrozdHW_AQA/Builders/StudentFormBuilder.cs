using DrozdHW_AQA.Models.PracticeForm;

namespace DrozdHW_AQA.Builders
{
    public class StudentFormBuilder
    {
        private readonly StudentFormModel student = new();

        public StudentFormBuilder WithFirstName(string firstName)
        {
            student.FirstName = firstName;
            return this;
        }

        public StudentFormBuilder WithLastName(string lastName)
        {
            student.LastName = lastName;
            return this;
        }

        public StudentFormBuilder WithEmail(string email)
        {
            student.Email = email;
            return this;
        }

        public StudentFormBuilder WithGender(string gender)
        {
            student.Gender = gender;
            return this;
        }

        public StudentFormBuilder WithMobile(string mobile)
        {
            student.Mobile = mobile;
            return this;
        }

        public StudentFormBuilder WithDateOfBirth(DateTime dateOfBirth)
        {
            student.DateOfBirth = dateOfBirth;
            return this;
        }

        public StudentFormBuilder WithSubject(string subject)
        {
            student.Subjects.Add(subject);
            return this;
        }

        public StudentFormBuilder WithHobby(string hobby)
        {
            student.Hobbies.Add(hobby);
            return this;
        }

        public StudentFormBuilder WithPicture(string picturePath)
        {
            student.PicturePath = picturePath;
            return this;
        }

        public StudentFormBuilder WithCurrentAddress(string currentAddress)
        {
            student.CurrentAddress = currentAddress;
            return this;
        }

        public StudentFormBuilder WithStateAndCity(string state, string city)
        {
            student.State = state;
            student.City = city;
            return this;
        }

        public StudentFormModel Build()
        {
            return student;
        }
    }
}
