using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HandonADO
{
    class Program
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2BPKC13\SQLEXPRESS;Initial Catalog=PracticeDB;User ID=sa;Password=pass@word1");
        SqlCommand cmd = null;
        public void Add()
        {
            try
            {
                cmd = new SqlCommand("Insert into project values(@id,@pname,@sdate)", con);
                cmd.Parameters.AddWithValue("@id", "P0001");
                cmd.Parameters.AddWithValue("@pname", "Boing2");
                cmd.Parameters.AddWithValue("@sdate", "12219");
               // cmd.Parameters.AddWithValue("@edate", DateTime.Parse("12.6.19"));
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                con.Close();

            }
        }
        public void GetProjectById(string pid)
        {
            try
            {
                cmd = new SqlCommand("Select *from Project where project_no=@pid", con);
                cmd.Parameters.AddWithValue("@pid", pid);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    dr.Read();
                    Console.WriteLine("ID:{1} Name:{1} SDate{2} EDate{3}",
                        dr["project_no"], dr["project_name"], dr["Budget"]);
                }
                else
                { Console.WriteLine("Invalid projectID"); }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                con.Close();
            }
        }
        static void Main(string[] args)
        {
                Program obj = new Program();
            obj.Add();
            obj.GetProjectById("P0008");
            Console.ReadKey();
        }
    }
}
