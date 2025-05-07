CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Email NVARCHAR(255) UNIQUE,
    PasswordHash NVARCHAR(255),
    Role NVARCHAR(50) CHECK (Role IN ('Student', 'Manager', 'Counselor'))
);

CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY,
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    Country NVARCHAR(100),
    DegreeLevel NVARCHAR(50),
    AcademicBackground NVARCHAR(500),
    FieldOfStudy NVARCHAR(100),
    TestScores NVARCHAR(50),
    PackageID INT,
    PaymentStatus BIT
);

CREATE TABLE ServicePackages (
    PackageID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Description NVARCHAR(500),
    Price DECIMAL(10,2)
);

CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY,
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    PackageID INT FOREIGN KEY REFERENCES ServicePackages(PackageID),
    Amount DECIMAL(10,2),
    PaymentStatus BIT,
    TransactionID NVARCHAR(100)
);

CREATE TABLE Assignments (
    AssignmentID INT PRIMARY KEY IDENTITY,
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
    CounselorID INT FOREIGN KEY REFERENCES Users(UserID),
    Status NVARCHAR(50)
);

CREATE TABLE CounselorReports (
    ReportID INT PRIMARY KEY IDENTITY,
    CounselorID INT FOREIGN KEY REFERENCES Users(UserID),
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
    ProgressSummary NVARCHAR(1000),
    Challenges NVARCHAR(1000),
    ReportDate DATETIME DEFAULT GETDATE()
);
