# Health&Med Notification Service - Hackathon Project

## Overview

This project is part of a Health&Med Hackathon, focused on developing a backend service to facilitate medical consultation scheduling. The service is built in .NET Core and handles user (doctor and patient) registration, authentication, scheduling management, and notifications, including real-time conflict validation and email notifications to doctors.

### Main Objective
To create a scalable, reliable, and concurrent system for scheduling medical consultations. The service supports:
- Doctor and Patient registration
- Authentication
- Scheduling
- Email notifications for doctors when a consultation is booked

### Email Notification Content
- **Subject:** "Health&Med - Nova consulta agendada"
- **Body:**
  ```
  Olá, Dr. {doctor_name}!
  Você tem uma nova consulta marcada!
  Paciente: {patient_name}.
  Data e horário: {date} às {time}.
  ```

## Non-Functional Requirements
1. **Concurrent Scheduling Support**
   - The system must handle multiple simultaneous access requests, ensuring that only one booking is made per time slot.
   
2. **Real-Time Schedule Conflict Validation**
   - The system checks in real-time for conflicting bookings to avoid overlapping appointments.

## Tech Stack
- **.NET Core** for backend service
- **RabbitMQ** for message queueing, used to handle asynchronous tasks like email notifications
- **PostgreSQL** for database management
- **Docker** for containerization and deployment
- **Entity Framework Core** for data access
- **FluentValidation** for input validation
- **MediatR** for managing requests and command/query separation

## Features

### 1. Doctor and Patient Registration
Implemented via API endpoints that allow users to register and securely store their data in PostgreSQL.

### 2. Authentication
Utilizes JWT tokens for secure authentication of doctors and patients.

### 3. Scheduling
Patients can view available slots and book appointments. The system uses RabbitMQ to send appointment notifications to doctors once a booking is made.

### 4. Email Notification
The system sends an email to the doctor after a patient schedules a consultation using the RabbitMQ messaging system for decoupling this process from the main flow.

## Setup & Installation

### Prerequisites
- .NET 6 SDK
- Docker & Docker Compose
- RabbitMQ
- PostgreSQL

### Steps to Run

1. **Clone the repository:**
   ```bash
   git clone https://github.com/hackathon-POSTECH/Notification.git
   ```

2. **Set up environment variables:**
   Create a `.env` file based on the provided `.env.example` file, and configure the RabbitMQ and PostgreSQL settings.

3. **Run the application using Docker Compose:**
   ```bash
   docker-compose up --build
   ```

4. **Database migration:**
   After the containers are up, run the database migrations:
   ```bash
   dotnet ef database update
   ```

5. **Access the API:**
   The API will be accessible at `http://localhost:5000`.

## CI/CD Pipeline
The CI/CD pipeline ensures the deployment of the service through automated tests and builds. Integration with a continuous integration system, such as GitHub Actions, automatically triggers the pipeline on every push.

## Testing
Unit tests cover core functionalities, including scheduling validation and user authentication.

Run the tests:
```bash
dotnet test
```

## Contributors
- Health&Med Hackathon Team (FIAP SOAT students)

## License
This project is licensed under the MIT License.
