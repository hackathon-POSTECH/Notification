namespace NOTIFICATION.APPLICATION.DTOs;

public interface DoctorResponseDTO
{
    Guid Id { get; set; }
    string Name { get; set; }
    string Email { get; set; }
    string Phone { get; set; }
}
