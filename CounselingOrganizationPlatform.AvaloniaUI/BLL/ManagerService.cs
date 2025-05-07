using Microsoft.Data.SqlClient;
using CounselingOrganizationPlatform.AvaloniaUI.DAL;

namespace CounselingOrganizationPlatform.AvaloniaUI.BLL
{
    public class ManagerService
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public bool AssignCounselor(int studentId, int counselorId)
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Assignments (StudentID, CounselorID, Status) VALUES (@StudentID, @CounselorID, 'Assigned')";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@CounselorID", counselorId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
