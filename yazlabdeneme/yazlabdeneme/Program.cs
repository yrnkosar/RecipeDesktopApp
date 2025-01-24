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
                    
                    Console.WriteLine("Veritabanı bağlantısı başarılı.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Veritabanına bağlanılamadı: " + ex.Message);
                }

            }
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GirisEkrani());
        }
    }
}