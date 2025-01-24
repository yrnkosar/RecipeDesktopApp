using System;
using System.Data.SqlClient;

namespace yazlabdeneme
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    
                    Console.WriteLine("Veritabaný baðlantýsý baþarýlý.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Veritabanýna baðlanýlamadý: " + ex.Message);
                }

            }
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GirisEkrani());
        }
    }
}