using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Campingpladsen.Models
{
    public class PriceDataAccessLayer
    {
        string connectionString = "Data Source=LAPTOP-FKGM1G4E;Initial Catalog=Campingpladsen;Integrated Security=True";

        // To View all price details
        public IEnumerable<Price> GetAllPrice()
        {
            List<Price> lstprice = new List<Price>();

            // Making a new connection to the database
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllPrice", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // opens the connection
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Price price = new Price();

                    price.ID = Convert.ToInt32(rdr["Price_Id"]);
                    price.Price_name = rdr["Price_Name"].ToString();
                    price.High_Season_Price = Convert.ToInt32(rdr["High_Season_Price"]);
                    price.Low_Season_Price = Convert.ToInt32(rdr["Low_Season_Price"]);

                    lstprice.Add(price);
                }
                // Closing the connection
                con.Close();
            }
            return lstprice;
        }

        // To Add new price record
        public void AddPrice(Price price)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddPrice", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Price_Name", price.Price_name);
                cmd.Parameters.AddWithValue("@High_Season_Price", price.High_Season_Price);
                cmd.Parameters.AddWithValue("@Low_Season_Price", price.Low_Season_Price);

                // opens the connection
                con.Open();
                cmd.ExecuteNonQuery();
                // Closing the connection
                con.Close();
            }
        }

        // To Update the records of a particular price
        public void UpdatePrice(Price price)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdatePrice", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Price_id", price.ID);
                cmd.Parameters.AddWithValue("@Price_Name", price.Price_name);
                cmd.Parameters.AddWithValue("@High_Season_Price", price.High_Season_Price);
                cmd.Parameters.AddWithValue("@Low_Season_Price", price.Low_Season_Price);

                // opens the connection
                con.Open();
                cmd.ExecuteNonQuery();
                // Closing the connection
                con.Close();
            }
        }

        // Get the details of a particular price
        public Price GetPriceData(int? id)
        {
            Price price = new Price();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM [Price] WHERE Price_Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                // opens the connection
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    price.ID = Convert.ToInt32(rdr["Price_id"]);
                    price.Price_name = rdr["Price_name"].ToString();
                    price.High_Season_Price = Convert.ToInt32(rdr["High_Season_Price"]);
                    price.Low_Season_Price = Convert.ToInt32(rdr["Low_Season_Price"]);
                }
            }
            return price;
        }

        // To Delete the record on a particular price
        public void DeletePrice(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeletePrice", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Price_id", id);

                // opens the connection
                con.Open();
                cmd.ExecuteNonQuery();
                // Closing the connection
                con.Close();
            }
        }
    }
}
