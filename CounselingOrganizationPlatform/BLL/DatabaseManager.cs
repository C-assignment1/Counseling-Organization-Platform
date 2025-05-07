using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CounselingOrganizationPlatform.DAL;

namespace CounselingOrganizationPlatform.BLL
{
    public class DatabaseManager
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        // User CRUD operations
        public bool CreateUser(string name, string email, string passwordHash, string role)
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Users (Name, Email, PasswordHash, Role) VALUES (@Name, @Email, @PasswordHash, @Role)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    cmd.Parameters.AddWithValue("@Role", role);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public DataTable GetUsers()
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT UserID, Name, Email, Role FROM Users";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public bool UpdateUser(int userId, string name, string email, string role)
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Users SET Name = @Name, Email = @Email, Role = @Role WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteUser(int userId)
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Users WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        public DataTable GetServicePackages()
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT PackageID, Name, Description, Price FROM ServicePackages";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public bool CreateServicePackage(string name, string description, decimal price)
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO ServicePackages (Name, Description, Price) VALUES (@Name, @Description, @Price)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Price", price);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateServicePackage(int packageId, string name, string description, decimal price)
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE ServicePackages SET Name = @Name, Description = @Description, Price = @Price WHERE PackageID = @PackageID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@PackageID", packageId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteServicePackage(int packageId)
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM ServicePackages WHERE PackageID = @PackageID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PackageID", packageId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // CRUD for Students
        public DataTable GetStudents()
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT StudentID, UserID, Country, DegreeLevel, AcademicBackground, FieldOfStudy, TestScores, PackageID, PaymentStatus FROM Students";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public bool CreateStudent(int userId, string country, string degreeLevel, string academicBackground, string fieldOfStudy, string testScores, int packageId, bool paymentStatus)
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Students (UserID, Country, DegreeLevel, AcademicBackground, FieldOfStudy, TestScores, PackageID, PaymentStatus) 
                                 VALUES (@UserID, @Country, @DegreeLevel, @AcademicBackground, @FieldOfStudy, @TestScores, @PackageID, @PaymentStatus)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Parameters.AddWithValue("@DegreeLevel", degreeLevel);
                    cmd.Parameters.AddWithValue("@AcademicBackground", academicBackground);
                    cmd.Parameters.AddWithValue("@FieldOfStudy", fieldOfStudy);
                    cmd.Parameters.AddWithValue("@TestScores", testScores);
                    cmd.Parameters.AddWithValue("@PackageID", packageId);
                    cmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateStudent(int studentId, int userId, string country, string degreeLevel, string academicBackground, string fieldOfStudy, string testScores, int packageId, bool paymentStatus)
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE Students SET UserID = @UserID, Country = @Country, DegreeLevel = @DegreeLevel, AcademicBackground = @AcademicBackground, 
                                 FieldOfStudy = @FieldOfStudy, TestScores = @TestScores, PackageID = @PackageID, PaymentStatus = @PaymentStatus WHERE StudentID = @StudentID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Parameters.AddWithValue("@DegreeLevel", degreeLevel);
                    cmd.Parameters.AddWithValue("@AcademicBackground", academicBackground);
                    cmd.Parameters.AddWithValue("@FieldOfStudy", fieldOfStudy);
                    cmd.Parameters.AddWithValue("@TestScores", testScores);
                    cmd.Parameters.AddWithValue("@PackageID", packageId);
                    cmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus);
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteStudent(int studentId)
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Students WHERE StudentID = @StudentID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // CRUD for Payments
        public DataTable GetPayments()
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT PaymentID, UserID, PackageID, Amount, PaymentStatus, TransactionID FROM Payments";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public bool CreatePayment(int userId, int packageId, decimal amount, bool paymentStatus, string transactionId)
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Payments (UserID, PackageID, Amount, PaymentStatus, TransactionID) 
                                 VALUES (@UserID, @PackageID, @Amount, @PaymentStatus, @TransactionID)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@PackageID", packageId);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus);
                    cmd.Parameters.AddWithValue("@TransactionID", transactionId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdatePayment(int paymentId, int userId, int packageId, decimal amount, bool paymentStatus, string transactionId)
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE Payments SET UserID = @UserID, PackageID = @PackageID, Amount = @Amount, PaymentStatus = @PaymentStatus, TransactionID = @TransactionID 
                                 WHERE PaymentID = @PaymentID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@PackageID", packageId);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus);
                    cmd.Parameters.AddWithValue("@TransactionID", transactionId);
                    cmd.Parameters.AddWithValue("@PaymentID", paymentId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeletePayment(int paymentId)
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Payments WHERE PaymentID = @PaymentID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PaymentID", paymentId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
