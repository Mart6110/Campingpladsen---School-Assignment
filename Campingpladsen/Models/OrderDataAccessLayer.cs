using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Campingpladsen.Models
{
    public class OrderDataAccessLayer
    {
        string connectionString = "Data Source=LAPTOP-FKGM1G4E;Initial Catalog=Campingpladsen;Integrated Security=True";

        // To view all order details
        public IEnumerable<Order> GetAllOrder()
        {
            List<Order> lstorder = new List<Order>();

            // Making a new connection to the database
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // opens the connection
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                // Looping through the data in our table customer
                while (rdr.Read())
                {
                    Order order = new Order();

                    order.ID = Convert.ToInt32(rdr["Order_Id"]);
                    order.Total_Prise = Convert.ToInt32(rdr["Total_Prise"]);
                    order.Adult = Convert.ToInt32(rdr["Adult"]);
                    order.child = Convert.ToInt32(rdr["child"]);
                    order.Dog = Convert.ToInt32(rdr["Dog"]);
                    order.Spot_Id = Convert.ToInt32(rdr["Spot_Id"]);
                    order.Customer_id = Convert.ToInt32(rdr["Customer_id"]);

                    lstorder.Add(order);
                }
                // Closing the connection
                con.Close();
            }
            return lstorder;
        }

        // To add new order record
        public void AddOrder(Order order)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Total_Prise", order.Total_Prise);
                cmd.Parameters.AddWithValue("@Adult", order.Adult);
                cmd.Parameters.AddWithValue("@child", order.child);
                cmd.Parameters.AddWithValue("@Dog", order.Dog);
                cmd.Parameters.AddWithValue("@Spot_Id", order.Spot_Id);
                cmd.Parameters.AddWithValue("@Customer_id", order.Customer_id);

                // opens the connection
                con.Open();
                cmd.ExecuteNonQuery();
                // Closing the connection
                con.Close();
            }
        }

        // To update the records of the particular order
        public void UpdateOrder(Order order)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Order_Id", order.ID);
                cmd.Parameters.AddWithValue("@Total_Prise", order.Total_Prise);
                cmd.Parameters.AddWithValue("@Adult", order.Adult);
                cmd.Parameters.AddWithValue("@child", order.child);
                cmd.Parameters.AddWithValue("@Dog", order.Dog);
                cmd.Parameters.AddWithValue("@Spot_Id", order.Spot_Id);
                cmd.Parameters.AddWithValue("@Customer_id", order.Customer_id);

                // opens the connection
                con.Open();
                cmd.ExecuteNonQuery();
                // Closing the connection
                con.Close();
            }
        }

        // Get the details of a particular order
        public Order GetOrderData(int? id)
        {
            Order order = new Order();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM [Order] WHERE Order_Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                // opens the connection
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    order.ID = Convert.ToInt32(rdr["Order_Id"]);
                    order.Total_Prise = Convert.ToInt32(rdr["Total_Prise"]);
                    order.Adult = Convert.ToInt32(rdr["Adult"]);
                    order.child = Convert.ToInt32(rdr["child"]);
                    order.Dog = Convert.ToInt32(rdr["Dog"]);
                    order.Spot_Id = Convert.ToInt32(rdr["Spot_Id"]);
                    order.Customer_id = Convert.ToInt32(rdr["Customer_id"]);
                }
            }
            return order;
        }

        // To delete the record on a particular order
        public void DeleteOrder(int? id)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Order_Id", id);

                // opens the connection
                con.Open();
                cmd.ExecuteNonQuery();
                // Closing the connection
                con.Close();
            }
        }
    }
}
