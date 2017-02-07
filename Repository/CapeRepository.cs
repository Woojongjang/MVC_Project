namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class CapeRepository : BaseRepository, ICapeRepository
    {
        private const string GetCapeRatingProcedure = "GetCapeRating";
        private const string UpdateCapeRatingProcedure = "UpdateCapeRating";
        private const string DeleteCapeRatingProcedure = "DeleteCapeRating";
        private const string InsertCapeRatingProcedure = "InsertCapeRating";
        private const string GetCapeStudentProcedure = "GetCapeStudent";
        private const string GetCapeInstructorProcedure = "GetCapeInstructor";

        public int GetCapeRating(string stud_id, int instr_id, int sched_id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            int capeRating = 0;

            try
            {
                var adapter = new SqlDataAdapter(GetCapeRatingProcedure, conn);

                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@stud_id", SqlDbType.Int));
                    adapter.SelectCommand.Parameters["@stud_id"].Value = stud_id;
                if (instr_id > 0)
                {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@instr_id", SqlDbType.Int));
                    adapter.SelectCommand.Parameters["@instr_id"].Value = instr_id;
                }
                if (sched_id > 0)
                {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@sched_id", SqlDbType.Int));
                    adapter.SelectCommand.Parameters["@sched_id"].Value = sched_id;
                }

                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return -1;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    capeRating = Convert.ToInt32(dataSet.Tables[0].Rows[i]["rating"].ToString());
                   
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return capeRating;
        }

        public void UpdateCapeRating(string stud_id, int instr_id, int sched_id, int rating, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
          
            try
            {
                var adapter = new SqlDataAdapter(GetCapeRatingProcedure, conn);

                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@stud_id", SqlDbType.Int));
                    adapter.SelectCommand.Parameters["@stud_id"].Value = stud_id;
                if (instr_id > 0)
                {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@instr_id", SqlDbType.Int));
                    adapter.SelectCommand.Parameters["@instr_id"].Value = instr_id;
                }
                if (sched_id > 0)
                {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@sched_id", SqlDbType.Int));
                    adapter.SelectCommand.Parameters["@sched_id"].Value = sched_id;
                }

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@rating", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@rating"].Value = sched_id;

                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public void DeleteCapeRating(string stud_id, int instr_id, int sched_id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteCapeRatingProcedure, conn);

                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@stud_id", SqlDbType.Int));
                    adapter.SelectCommand.Parameters["@stud_id"].Value = stud_id;
                if (instr_id > 0)
                {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@instr_id", SqlDbType.Int));
                    adapter.SelectCommand.Parameters["@instr_id"].Value = instr_id;
                }
                if (sched_id > 0)
                {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@sched_id", SqlDbType.Int));
                    adapter.SelectCommand.Parameters["@sched_id"].Value = sched_id;
                }

                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public void InsertCapeRating(string stud_id, int instr_id, int sched_id, int rating, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(InsertCapeRatingProcedure, conn);

                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@stud_id", SqlDbType.Int));
                    adapter.SelectCommand.Parameters["@stud_id"].Value = stud_id;
                if (instr_id > 0)
                {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@instr_id", SqlDbType.Int));
                    adapter.SelectCommand.Parameters["@instr_id"].Value = instr_id;
                }
                if (sched_id > 0)
                {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@sched_id", SqlDbType.Int));
                    adapter.SelectCommand.Parameters["@sched_id"].Value = sched_id;
                }

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@rating", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@rating"].Value = sched_id;

                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public List<Cape> GetCapeStudent(string stud_id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var studentCapeList = new List<Cape>();

            try
            {
                var adapter = new SqlDataAdapter(GetCapeStudentProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@stud_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters["@stud_id"].Value = stud_id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var studentCape = new Cape
                    {
                        studentID = dataSet.Tables[0].Rows[i]["stud_id"].ToString(),
                        instructorID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["instr_id"].ToString()),
                        ScheduleId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["sched_id"].ToString()),
                        CapeRating = Convert.ToInt32(dataSet.Tables[0].Rows[i]["rating"].ToString())
                    };
                    studentCapeList.Add(studentCape);
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return studentCapeList;
        }

        public List<Cape> GetCapeInstructor(int instr_id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var studentCapeList = new List<Cape>();

            try
            {
                var adapter = new SqlDataAdapter(GetCapeInstructorProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                if (instr_id > 0)
                {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@instr_id", SqlDbType.Int));
                    adapter.SelectCommand.Parameters["@instr_id"].Value = instr_id;
                }

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var studentCape = new Cape
                    {
                        studentID = dataSet.Tables[0].Rows[i]["stud_id"].ToString(),
                        instructorID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["instr_id"].ToString()),
                        ScheduleId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["sched_id"].ToString()),
                        CapeRating = Convert.ToInt32(dataSet.Tables[0].Rows[i]["rating"].ToString())
                    };
                    studentCapeList.Add(studentCape);
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return studentCapeList;
        }
    }
}
