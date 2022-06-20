using System;
using System.Data.SqlClient;

namespace ConsoleApp3
{
    class Program
    {
        

        static void Main(string[] args)
        {
            int choose;
            do
            {
                ShowMenu();
                choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        CreateData();
                        break;
                    case 2:
                        UpdateData();
                        break;
                    case 3:
                        DeleteData();
                        break;
                    case 4:
                        GetData();
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        Console.WriteLine("End");
                        break;
                    default:
                        Console.WriteLine("Press Again!");
                        break;
                }
            } while (choose != 7);
            
            
        }

        

        public static void ShowMenu()
        {
            Console.WriteLine("==========Actions==========");
            Console.WriteLine("1.Add product");
            Console.WriteLine("2.Edit product");
            Console.WriteLine("3.Delete product");
            Console.WriteLine("4.View all product");
            Console.WriteLine("5.Search product by ID");
            Console.WriteLine("6.Search product by Name");
            Console.WriteLine("7.END");
            
        }
        public static void GetData()
        {
            ConnectionDb connectionDb = new ConnectionDb();
            SqlConnection conn = connectionDb.GetConnection();
            string query = "SELECT * FROM product";

            SqlCommand command = new SqlCommand(query,conn);

            conn.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("ID :"+ reader[0] +" Product name : " + reader[1] + " Desc : " + reader[2] + " Price : "+reader[3]);
            }
            conn.Close();



        }
        public static void CreateData()
        {
            
            Console.WriteLine("Nhap ten san pham :");
            string proName = Console.ReadLine();
            Console.WriteLine("Nhap mo ta san pham :");
            string ProDesc = Console.ReadLine();
            Console.WriteLine("Nhap gia san pham :");
            int price = int.Parse(Console.ReadLine());

            ConnectionDb connectionDb = new ConnectionDb();
            SqlConnection conn = connectionDb.GetConnection();
            string query = "INSERT INTO Product VALUES(@proName,@ProDesc,@price)";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@proName",proName);
            command.Parameters.AddWithValue("@ProDesc", ProDesc);
            command.Parameters.AddWithValue("@price", price);

            conn.Open();
            int dataCount = command.ExecuteNonQuery();

            Console.WriteLine("Them {0} ban ghi thanh cong" , dataCount);
            conn.Close();
        }
        
        public static void UpdateData()
        {
            Console.WriteLine("Nhap ID san pham :");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap ten san pham: ");
            string name = Console.ReadLine();
            Console.WriteLine("Nhap mieu ta san pham : ");
            string desc = Console.ReadLine();
            Console.WriteLine("Nhap gia san pham :");
            int price = int.Parse(Console.ReadLine());
            ConnectionDb connectionDb = new ConnectionDb();
            SqlConnection conn = connectionDb.GetConnection();
            string query = "UPDATE product SET proName = @name, ProDesc = @prodesc , price = @price WHERE id = @id";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@prodesc", desc);
            command.Parameters.AddWithValue("@price", price);
            conn.Open();
            int dataCount = command.ExecuteNonQuery();

            Console.WriteLine("Update {0} ban ghi thanh cong", dataCount);
            conn.Close();
        }
        public static void DeleteData()
        {
            Console.WriteLine("Nhap ten san pham : ");
            string name = Console.ReadLine();

            ConnectionDb connectionDb = new ConnectionDb();
            SqlConnection conn = connectionDb.GetConnection();
            string query = "DELETE FROM product WHERE proName = @name";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue(@name, name);
            conn.Open();
            int dataCount = command.ExecuteNonQuery();

            Console.WriteLine("Delete {0} ban ghi thanh cong", dataCount);
            conn.Close();
        }
    }
}
