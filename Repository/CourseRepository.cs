namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class CourseRepository : BaseRepository, ICourseRepository
    {
        private const string GetCourseListProcedure = "spGetCourseList";
        private const string InsertCourseProcedure = "InsertCourse";
        private const string InsertPrerequisiteProcedure = "InsertPrerequisite";
        private const string GetPrerequisiteProcedure = "GetAllPrerequisite";
        private const string DeleteCourseProcedure = "DeleteCourse";
        private const string DeletePrerequisiteProcedure = "DeletePostAndPrerequisite";
        private const string UpdatePrerequisiteProcedure = "UpdatePrerequisite";
        private const string UpdateCourseProcedure = "UpdateCourse";
        /*private const string InsertCapeProcedure = "InsertCape";
        private const string UpdateCapeProcedure = "UpdateCapeRating";
        private const string DeleteCapeProcedure = "DeleteCapeRating";
        private const string GetCapeProcedure = "GetCapeRating";*/

        public List<Course> GetCourseList(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var courseList = new List<Course>();

            try
            {
                var adapter = new SqlDataAdapter(GetCourseListProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                                  };

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var course = new Course
                                     {
                                         CourseId = dataSet.Tables[0].Rows[i]["course_id"].ToString(),
                                         Title = dataSet.Tables[0].Rows[i]["course_title"].ToString(),
                                         CourseLevel =
                                             (CourseLevel)
                                             Enum.Parse(
                                                 typeof(CourseLevel),
                                                 dataSet.Tables[0].Rows[i]["course_level"].ToString()),
                                         Description = dataSet.Tables[0].Rows[i]["course_description"].ToString()
                                     };
                    courseList.Add(course);
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

            return courseList;
        }

        public List<Prerequisite> GetPrerequisite(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var prereqList = new List<Prerequisite>();
            
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(GetPrerequisiteProcedure, conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet prereqDS = new DataSet();
                adapter.Fill(prereqDS);

                if (prereqDS.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < prereqDS.Tables[0].Rows.Count; i++)
                {
                    var prereq = new Prerequisite
                    {
                        prereq_course = (int) prereqDS.Tables[0].Rows[i]["pre_course"],
                        prereq_title = prereqDS.Tables[0].Rows[i]["precourse_title"].ToString(),
                        postreq_course = (int) prereqDS.Tables[0].Rows[i]["post_course"],
                        postreq_title = prereqDS.Tables[0].Rows[i]["postcourse_title"].ToString()
                    };
                    prereqList.Add(prereq);
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

            return prereqList;
        }

        public void InsertPrerequisite(ref List<string> errors, int course_id, int prereq_id)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(InsertPrerequisiteProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@post_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@pre_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@post_id"].Value = course_id;
                adapter.SelectCommand.Parameters["@pre_id"].Value = prereq_id;

                DataSet prereqDS = new DataSet();
                adapter.Fill(prereqDS);
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

        public int InsertCourse(ref List<string> errors, int course_id, string title, string level, string description)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(InsertCourseProcedure, conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int, 32));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_title", SqlDbType.VarChar, 32));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_level", SqlDbType.VarChar, 32));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_description", SqlDbType.VarChar, 32));

                adapter.SelectCommand.Parameters["@course_id"].Value = course_id;
                adapter.SelectCommand.Parameters["@course_title"].Value = title;
                adapter.SelectCommand.Parameters["@course_level"].Value = level;
                adapter.SelectCommand.Parameters["@course_description"].Value = description;
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return 1;
        }

        public int DeleteCourse(ref List<string> errors, int course_id, string title)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(DeleteCourseProcedure, conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int, 32));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_title", SqlDbType.VarChar, 32));
                
                adapter.SelectCommand.Parameters["@course_id"].Value = course_id;
                adapter.SelectCommand.Parameters["@course_title"].Value = title;
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return 1;
        }

        public void DeletePrerequisite(ref List<string> errors, int course_id, int prereq_id)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeletePrerequisiteProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType
                            =
                            CommandType
                            .StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@prereq_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@course_id"].Value = course_id;
                adapter.SelectCommand.Parameters["@prereq_id"].Value = prereq_id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
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

        public int UpdateCourse(ref List<string> errors, int course_id, string title, string level, string description)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(UpdateCourseProcedure, conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int, 32));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_title", SqlDbType.VarChar, 32));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_level", SqlDbType.VarChar, 32));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_description", SqlDbType.VarChar, 32));

                adapter.SelectCommand.Parameters["@course_id"].Value = course_id;
                adapter.SelectCommand.Parameters["@course_title"].Value = title;
                adapter.SelectCommand.Parameters["@course_level"].Value = level;
                adapter.SelectCommand.Parameters["@course_description"].Value = description;
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return 1;
        }

        public void UpdatePrerequisite(ref List<string> errors, int course_id, int prereq_id)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(UpdatePrerequisiteProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType
                            =
                            CommandType
                            .StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@new_pre_id", SqlDbType.Int));
                
                adapter.SelectCommand.Parameters["@course_id"].Value = course_id;
                adapter.SelectCommand.Parameters["@new_pre_id"].Value = prereq_id;
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
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

        /*public int UpdateCapeRating(ref List<string> errors, string stud_id, int instr_id, int sched_id, int rating)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(UpdateCapeProcedure, conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@stud_id", SqlDbType.VarChar, 32));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instr_id", SqlDbType.Int, 32));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@sched_id", SqlDbType.Int, 32));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@rating", SqlDbType.Int, 32));

                adapter.SelectCommand.Parameters["@stud_id"].Value = stud_id;
                adapter.SelectCommand.Parameters["@instr_id"].Value = instr_id;
                adapter.SelectCommand.Parameters["@sched_id"].Value = sched_id;
                adapter.SelectCommand.Parameters["@rating"].Value = rating;
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return 1;
        }

        public int DeleteCapeRating(ref List<string> errors, string stud_id, int instr_id, int sched_id)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(DeleteCapeProcedure, conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@stud_id", SqlDbType.VarChar, 32));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instr_id", SqlDbType.Int, 32));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@sched_id", SqlDbType.Int, 32));

                adapter.SelectCommand.Parameters["@stud_id"].Value = stud_id;
                adapter.SelectCommand.Parameters["@instr_id"].Value = instr_id;
                adapter.SelectCommand.Parameters["@sched_id"].Value = sched_id;
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return 1;
        }

        public int InsertCapeRating(ref List<string> errors, string stud_id, int instr_id, int sched_id, int rating)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(InsertCapeProcedure, conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@stud_id", SqlDbType.VarChar, 32));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instr_id", SqlDbType.Int, 32));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@sched_id", SqlDbType.Int, 32));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@rating", SqlDbType.Int, 32));

                adapter.SelectCommand.Parameters["@stud_id"].Value = stud_id;
                adapter.SelectCommand.Parameters["@instr_id"].Value = instr_id;
                adapter.SelectCommand.Parameters["@sched_id"].Value = sched_id;
                adapter.SelectCommand.Parameters["@rating"].Value = rating;
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return 1;
        }

        public int GetCapeRating(ref List<string> errors, string stud_id, int instr_id, int sched_id)
        {
            var conn = new SqlConnection(ConnectionString);
            int rating = -1;
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(GetCapeProcedure, conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@stud_id", SqlDbType.VarChar, 32));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instr_id", SqlDbType.Int, 32));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@sched_id", SqlDbType.Int, 32));

                adapter.SelectCommand.Parameters["@stud_id"].Value = stud_id;
                adapter.SelectCommand.Parameters["@instr_id"].Value = instr_id;
                adapter.SelectCommand.Parameters["@sched_id"].Value = sched_id;

                DataSet capeDS = new DataSet();
                adapter.Fill(capeDS);

                if (capeDS.Tables[0].Rows.Count == 0)
                {
                    return -1;
                }
                for (var i = 0; i < capeDS.Tables[0].Rows.Count; i++)
                {

                    rating = (int)capeDS.Tables[0].Rows[i]["rating"];
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

            return rating;
        }*/
    }
}
