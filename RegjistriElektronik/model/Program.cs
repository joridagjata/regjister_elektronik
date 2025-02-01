using System;
using System.Data.SqlClient;
using System.Text;
using System.Text.Json;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace RegjistriElektronik
{
    internal static class Program
    {
        // Connection string to your database
        private static readonly string connectionString = @"Data Source=DESKTOP-1USP24N\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;TrustServerCertificate=True";

        [STAThread]
        static void Main(string[] args)
        {
            Thread httpServerThread = new Thread(StartHttpServer);
            httpServerThread.IsBackground = true;
            httpServerThread.Start();

            // Start the main Windows Forms application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void StartHttpServer()
        {
            HttpListener httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:8080/"); // Listen on localhost at port 8080
            httpListener.Start();
            Console.WriteLine("HTTP Server started. Listening for requests on http://localhost:8080/");

            while (true)
            {
                try
                {
                    // Wait for HTTP requests
                    HttpListenerContext context = httpListener.GetContext();
                    HandleRequest(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in HTTP server: " + ex.Message);
                }
            }
        }

        private static void HandleRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            if (request.HttpMethod == "POST" && request.Url.AbsolutePath == "/insertPjesemarrjeStudenti")
            {
                // Read the request body to get the cardId
                string requestBody;
                using (var reader = new System.IO.StreamReader(request.InputStream, request.ContentEncoding))
                {
                    requestBody = reader.ReadToEnd();
                }

                // Deserialize the JSON request to extract the cardId
                var requestData = JsonSerializer.Deserialize<RequestData>(requestBody);
                if (string.IsNullOrEmpty(requestData?.CardId))
                {
                    response.StatusCode = (int) HttpStatusCode.BadRequest;
                    byte[] errorBuffer = Encoding.UTF8.GetBytes("Error: Missing 'cardId' parameter.");
                    response.OutputStream.Write(errorBuffer, 0, errorBuffer.Length);
                }
                else
                {
                    try
                    {
                        InsertPjesemarrjeToDatabase(requestData.CardId, requestData.Lenda, requestData.Grupi, requestData.DitaEJaves);

                        // Respond with success
                        response.StatusCode = (int)HttpStatusCode.OK;
                        byte[] successBuffer = Encoding.UTF8.GetBytes("Pjesemarrja e studentit u shtua.");
                        response.OutputStream.Write(successBuffer, 0, successBuffer.Length);
                    }
                    catch (Exception ex)
                    {
                        // Handle database errors
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        byte[] errorBuffer = Encoding.UTF8.GetBytes("Error: " + ex.Message);
                        response.OutputStream.Write(errorBuffer, 0, errorBuffer.Length);
                    }
                }
            }
            else
            {
                // Respond with a 404 for unknown endpoints
                response.StatusCode = (int)HttpStatusCode.NotFound;
                byte[] errorBuffer = Encoding.UTF8.GetBytes("Error: Endpoint not found.");
                response.OutputStream.Write(errorBuffer, 0, errorBuffer.Length);
            }

            // Close the response
            response.OutputStream.Close();
        }

        private static void InsertPjesemarrjeToDatabase(string cardId, string lenda, string grupi, string ditaEJaves)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = " INSERT INTO PJESEMARRJA (STUDENT_ID, ORAR_MESIMOR_ID, PREZENT, KOHA_E_CHECKIN) " +
                    " VALUES (" +
                    " (SELECT ID FROM STUDENT WHERE CARD_ID = @cardId) , " +
                    " ( SELECT o.ID FROM ORAR_MESIMOR o " +
                    "       INNER JOIN LENDET l on l.ID = o.LENDA_ID " +
                    "       INNER JOIN GROUPS g ON g.ID = o.GROUP_ID " +
                    "       WHERE l.EMER = @lenda AND g.CODE = @grupi and o.DITA_E_JAVES = @ditaEJaves and STATUS = 1 ), " +
                    " 1, CAST(GETDATE() AS DATE)" +
                    ")" +
                    "";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cardId", cardId);
                    command.Parameters.AddWithValue("@lenda", lenda);
                    command.Parameters.AddWithValue("@grupi", grupi);
                    command.Parameters.AddWithValue("@ditaEJaves", ditaEJaves);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                    {
                        throw new Exception("Ka ndodhur nje gabim: Pjesemarrja e studentit nuk u shtua!");
                    }
                }
            }
        }

        private class RequestData
        {
            public string Lenda { get; set; }
            public string Grupi { get; set; }
            public string DitaEJaves { get; set; }
            public string CardId { get; set; }
        }
    }
}
