namespace DrozdHW_AQA.DTO.PracticeFormDTO;

public record StudentFormDTO(
    string FirstName,
    string LastName,
    string Email,
    string Gender,
    string Mobile,
    DateTime DateOfBirth,
    List<string> Subjects,
    List<string> Hobbies,
    string PicturePath,
    string CurrentAddress,
    string State,
    string City
);
