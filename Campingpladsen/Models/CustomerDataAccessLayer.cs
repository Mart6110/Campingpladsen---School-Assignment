using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CampingPladsen.Models
{
    public class CustomerDataAccessLayer
    {
        string connectionString = "Data Source=LAPTOP-FKGM1G4E;Initial Catalog=Campingpladsen;Integrated Security=True";

        // To view all customers detailes
        public IEnumerable<Customer> GetAllCustomers()
        {
            List<Customer> lstCustomer = new List<Customer>();

            // Making a new connection to the database
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // opens the connection
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                // Looping through the data in our table customer
                while (rdr.Read())
                {
                    Customer customer = new Customer();

                    customer.ID = Convert.ToInt32(rdr["Customer_id"]);
                    customer.Firstname = rdr["Firstname"].ToString();
                    customer.Lastname = rdr["Lastname"].ToString();
                    customer.Address = rdr["Address"].ToString();
                    customer.Email = rdr["Email"].ToString();
                    customer.Phone = rdr["Phone"].ToString();

                    lstCustomer.Add(customer);
                }
                // Closing the connection
                con.Close();
            }
            return lstCustomer;
        }

        // To add new customer to record
        public void AddCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Firstname", customer.Firstname);
                cmd.Parameters.AddWithValue("@Lastname", customer.Lastname);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Phone", customer.@Phone);

                // opens the connection
                con.Open();
                cmd.ExecuteNonQuery();
                // Closing the connection
                con.Close();
            }
        }

        // To update the records of a particular customer
        public void UpdateCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Customer_id", customer.ID);
                cmd.Parameters.AddWithValue("@Firstname", customer.Firstname);
                cmd.Parameters.AddWithValue("@Lastname", customer.Lastname);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Phone", customer.@Phone);

                // opens the connection
                con.Open();
                cmd.ExecuteNonQuery();
                // Closing the connection
                con.Close();
            }
        }

        // Get the details of a particular customer
        public Customer GetCustomerData(int? id)
        {
            Customer customer = new Customer();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM [Customer] WHERE Customer_id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                // opens the connection
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    customer.ID = Convert.ToInt32(rdr["Customer_id"]);
                    customer.Firstname = rdr["Firstname"].ToString();
                    customer.Lastname = rdr["Lastname"].ToString();
                    customer.Address = rdr["Address"].ToString();
                    customer.Email = rdr["Email"].ToString();
                    customer.Phone = rdr["Phone"].ToString();
                }
            }
            return customer;
        }

        // To delete the record on a particular customer
        public void DeleteCustomer(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Customer_id", id);

                // opens the connection
                con.Open();
                cmd.ExecuteNonQuery();
                // Closing the connection
                con.Close();
            }
        }
    }
}
