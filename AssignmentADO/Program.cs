using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AssignmentADO
{
    class Program
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2BPKC13\SQLEXPRESS;Initial Catalog=PracticeDB;Persist Security Info=True;User ID=sa;Password=pass@word1");
        SqlCommand cmd = null;
        public void Add(int id,string name,int price,int stock)
        {
            try
            {
                cmd = new SqlCommand("Insert into product values(@id,@name,@price,@stock)", con);
                cmd.Parameters.AddWithValue("@id",id);
                cmd.Parameters.AddWithValue("@name",name);
                cmd.Parameters.AddWithValue("@price",price);
                cmd.Parameters.AddWithValue("@stock",stock);
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
        public void GetproductbyId(string id)
        {
            {
                try
                {
                    cmd = new SqlCommand("select *from product where id=@id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();

                        Console.WriteLine("ID:{0} Name:{1} Price:{2} stock:{3}",
                            dr["id"], dr["name"], dr["price"], dr["stock"]);

                    }
                    else
                        Console.WriteLine("Invalid Project Id");
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

        }

        public void Delete(int id)
        {
            try
            {
                cmd = new SqlCommand("Delete from product where @id=id", con);
                cmd.Parameters.AddWithValue("@id", id);
                //cmd.Parameters.AddWithValue("@name", name);
                //cmd.Parameters.AddWithValue("@price", price);
                //cmd.Parameters.AddWithValue("@stock", stock);
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
        public void update (int id, string name, int price, int stock)
        {
            try
            {
                cmd = new SqlCommand("update  product set id=@id,name=@name,price=@price,stock=@stock where id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@stock", stock);
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

        static void Main(string[] args)
        {
            Program obj = new Program();
           //  obj.Add(11,"Siddu",1200,2);
           // obj.GetproductbyId("11");
            //obj.Delete(11);
            obj.update(11, "siddu", 12000, 2);
            Console.ReadKey();
        }
    }
}
