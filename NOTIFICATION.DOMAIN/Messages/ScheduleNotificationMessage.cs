using NOTIFICATION.DOMAIN.Entities;

namespace Notification.DOMAIN.Messages
{
    public class AppointmentNotification
    {
        public Doctor Doctor { get; } // Nome do médico
        public Patient Patient { get; }
        public DateTime AppointmentDate { get; }
        public TimeSpan AppointmentTime { get; }
        public string Message { get; set; }
        public string MessagePatient { get; set; }


        public AppointmentNotification
        (
            Doctor doctor,
            Patient patient,
            DateTime appointmentDate,
            TimeSpan appointmentTime
        )
        {
            Doctor = doctor;
            Patient = patient;
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;

            Message = BuildMessageDoctor();
            MessagePatient = BuildMessagePatient();
        }

        private string BuildMessageDoctor()
        {
            return $"Olá, Dr. {Doctor.Name}!\n" +
                   $"Você tem uma nova consulta marcada!\n" +
                   $"Paciente: {Patient.Name}.\n" +
                   $"Data e horário: {AppointmentDate.ToShortDateString()} às {AppointmentTime}.";
        }

        private string BuildMessagePatient()
        {
            return $"Olá, {Patient.Name}!\n" +
                   $"Sua consulta foi marcada com sucesso!\n" +
                   $"Médico: Dr. {Doctor.Name}.\n" +
                   $"Data e horário: {AppointmentDate.ToShortDateString()} às {AppointmentTime}.";
        }
    }
}
