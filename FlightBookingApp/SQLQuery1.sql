select * from Users
select * from Agents
select * from Admins
INSERT INTO Users (UserId, password, UserName, Email, UserPhone, CreatedAt, UpdatedAt)
VALUES
('U001', 'password1', 'John Doe', 'john.doe@example.com', '1234567890', GETDATE(), GETDATE()),
('U002', 'password2', 'Jane Smith', 'jane.smith@example.com', '0987654321', GETDATE(), GETDATE()),
('U003', 'password3', 'Sam Brown', 'sam.brown@example.com', '1231231234', GETDATE(), GETDATE()),
('U004', 'password4', 'Emily Clark', 'emily.clark@example.com', '2342342345', GETDATE(), GETDATE()),
('U005', 'password5', 'Michael White', 'michael.white@example.com', '3453453456', GETDATE(), GETDATE());

INSERT INTO Agents (agentId, password, AgentName, Email, AgentPhone, City, Location, CommissionRate, CreatedAt, UpdatedAt)
VALUES
('A001', 'password1', 'Alice Johnson', 'alice.johnson@example.com', '1234567890', 'New York', 'Manhattan', 0.10, GETDATE(), GETDATE()),
('A002', 'password2', 'Bob Martin', 'bob.martin@example.com', '0987654321', 'Los Angeles', 'Downtown', 0.12, GETDATE(), GETDATE()),
('A003', 'password3', 'Charlie Brown', 'charlie.brown@example.com', '2342342345', 'Chicago', 'South Side', 0.15, GETDATE(), GETDATE()),
('A004', 'password4', 'Diana Green', 'diana.green@example.com', '3453453456', 'San Francisco', 'Bay Area', 0.18, GETDATE(), GETDATE()),
('A005', 'password5', 'Ethan White', 'ethan.white@example.com', '4564564567', 'Miami', 'Beachfront', 0.20, GETDATE(), GETDATE());

INSERT INTO Admins (AdminId, AdminName, AdminPwd, AdminEmail)
VALUES
('AD01', 'John Smith', 'adminPassword123', 'john.smith@example.com');

SELECT * FROM AirportDetails
INSERT INTO AirportDetails(IataCode, AirportName, City, Country, Type)
VALUES
('JFK', 'John F. Kennedy International Airport', 'New York', 'USA', 'International'),
('LHR', 'London Heathrow Airport', 'London', 'United Kingdom', 'International'),
('DXB', 'Dubai International Airport', 'Dubai', 'UAE', 'International'),
('LAX', 'Los Angeles International Airport', 'Los Angeles', 'USA', 'International'),
('ORD', 'O Hare International Airport', 'Chicago', 'USA', 'International');

SELECT * FROM FlightDetails
INSERT INTO FlightDetails (FlightNumber, Airline, FlightType, PriceEconomy, PriceBusiness, PriceFirst, TotalSeats)
VALUES
('AA101', 'American Airlines', 'Domestic', 200.00, 450.00, 800.00, 150),
('DL202', 'Delta Airlines', 'International', 300.00, 600.00, 1200.00, 180),
('UA303', 'United Airlines', 'Domestic', 220.00, 500.00, 950.00, 200),
('BA404', 'British Airways', 'International', 350.00, 700.00, 1300.00, 220),
('AF505', 'Air France', 'International', 280.00, 550.00, 1100.00, 160);

SELECT * FROM FlightSchedules
INSERT INTO FlightSchedules (ScheduleId, FlightNumber, DepartureTime, ArrivalTime, Duration, DepartureLoc, ArrivalLocation)
VALUES
('S001', 'AA101', '2024-12-15 10:00:00', '2024-12-15 13:00:00', '03:00:00', 'New York', 'Los Angeles'),
('S002', 'DL202', '2024-12-16 12:00:00', '2024-12-16 16:00:00', '04:00:00', 'Los Angeles', 'London'),
('S003', 'UA303', '2024-12-17 08:00:00', '2024-12-17 11:30:00', '03:30:00', 'Chicago', 'San Francisco'),
('S004', 'BA404', '2024-12-18 14:30:00', '2024-12-18 18:00:00', '03:30:00', 'San Francisco', 'London'),
('S005', 'AF505', '2024-12-19 17:00:00', '2024-12-19 21:00:00', '04:00:00', 'Paris', 'New York');

SELECT * FROM UserBookings
INSERT INTO UserBookings (BookingId, UserId, FlightNumber, TicketPrice, BookingDate, SeatNumber, BookingStatus)
VALUES
('B001', 'U001', 'AA101', 250.00, '2024-12-10 08:30:00', '12A', 'Confirmed'),
('B002', 'U002', 'DL202', 400.00, '2024-12-12 10:00:00', '15B', 'Cancelled'),
('B003', 'U003', 'UA303', 300.00, '2024-12-14 14:45:00', '18C', 'Cancelled'),
('B004', 'U004', 'BA404', 350.00, '2024-12-16 17:30:00', '20D', 'Confirmed'),
('B005', 'U005', 'AF505', 450.00, '2024-12-18 09:00:00', '25E', 'Confirmed');

SELECT * FROM AgentBookings
INSERT INTO AgentBookings (BookingId, AgentId, UserName, FlightNumber, SeatNumber, TicketPrice, BookingDate, CommissionEarned, BookingStatus)
VALUES
('AB001', 'A001', 'John Doe', 'AA101', '12A', 250.00, '2024-12-10 08:30:00', 25.00, 'Confirmed'),
('AB002', 'A002', 'Jane Smith', 'DL202', '15B', 400.00, '2024-12-12 10:00:00', 40.00, 'Cancelled'),
('AB003', 'A003', 'Samuel Green', 'UA303', '18C', 300.00, '2024-12-14 14:45:00', 30.00, 'Cancelled'),
('AB004', 'A004', 'Emily White', 'BA404', '20D', 350.00, '2024-12-16 17:30:00', 35.00, 'Confirmed'),
('AB005', 'A005', 'Michael Brown', 'AF505', '25E', 450.00, '2024-12-18 09:00:00', 45.00, 'Confirmed');

Select * from AuthenticateAgents
INSERT INTO AuthenticateAgents ( password, ApplicantName, ApplicantEmail, ApplicantPhone, ApplicantCity, ApplicantLocation, CommissionRate, ApprovalStatus)
VALUES
( 'password123', 'Alice Johnson', 'alice.johnson@example.com', '1234567890', 'New York', 'Manhattan', 0.10, 'Pending'),
( 'password456', 'Bob Martin', 'bob.martin@example.com', '0987654321', 'Los Angeles', 'Downtown', 0.12, 'Pending'),
( 'password789', 'Charlie Brown', 'charlie.brown@example.com', '2345678901', 'Chicago', 'South Side', 0.15, 'Pending');






