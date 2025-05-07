using System.Data.SqlClient;
using CounselingOrganizationPlatform.DAL;

namespace CounselingOrganizationPlatform.BLL
{
    public class CounselorService
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public bool SubmitReport(int counselorId, int studentId, string progress, string challenges)
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO CounselorReports (CounselorID, StudentID, ProgressSummary, Challenges) VALUES (@CounselorID, @StudentID, @ProgressSummary, @Challenges)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CounselorID", counselorId);
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@ProgressSummary", progress);
                    cmd.Parameters.AddWithValue("@Challenges", challenges);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
