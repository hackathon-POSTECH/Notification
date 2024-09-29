namespace NOTIFICATION.APPLICATION.DTOs;

public interface PatientResponseDTO
{
    Guid Id { get; set; }
    string Name { get; set; }
    string Email { get; set; }
    string Phone { get; set; }
}
