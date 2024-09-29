namespace Notification.DOMAIN.Messages
{
    public class AppointmentNotificationMessage
    {
        public Guid Doctor { get; }
        public Guid Patient { get; }
        public DateTime AppointmentDate { get; }
        public TimeSpan AppointmentTime { get; }

        public AppointmentNotificationMessage
        (
            Guid doctor,
            Guid patient,
            DateTime appointmentDate,
            TimeSpan appointmentTime
        )
        {
            Doctor = doctor;
            Patient = patient;
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;
        }
    }
}
