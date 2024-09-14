using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using My_phone_book.Repository;

namespace My_phone_book.Services
{
    internal class ContactRepository :IContactRepository

    {
        private string ConnectionString = "Data Source=DESKTOP-87REVCG\\SOLTAN;Initial Catalog=PhoneBook-DB;User Id=sa;Password=12345";

        public DataTable SelectAll()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
                string Query = "select * from MyPhoneBook";
                SqlDataAdapter adapter = new SqlDataAdapter(Query,connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;

        }

        public DataTable SelectRow(int contactId)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string Query = "select * from MyPhoneBook where ContactID=" + contactId;
            SqlDataAdapter adapter = new SqlDataAdapter(Query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        

        public bool Insert(string name, string family, int age, string mobile, string email, string address)
        {
            SqlConnection connection=new SqlConnection(ConnectionString);
            try
            {
                string Query =
                    "Insert into MyPhoneBook(Name,Family,Age,Mobile,Email,Address) values(@Name,@Family,@Age,@Mobile,@Email,@Address)";
                SqlDataAdapter adapter = new SqlDataAdapter(Query, connection);
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Address", address);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Update(int contactId, string name, string family, int age, string mobile, string email, string address)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                string Query =
                    "Update MyPhoneBook set Name=@name,Family=@family,Age=@age,Mobile=@mobile,Email=@email,Address=@address where ContactId=@contactid";
                SqlCommand command = new SqlCommand(Query, conn);
                command.Parameters.AddWithValue("@contactid", contactId);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@family", family);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@mobile", mobile);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@address", address);
                conn.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

        }

        public bool Delete(int contactId)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                string Query = "Delete From MyPhoneBook where ContactId=@ID";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@ID", contactId);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable Search(string parameter)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string Query = "select * from MyPhoneBook where Name like @parameter or Family like @parameter";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@parameter", "%" + parameter + "%");
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}
