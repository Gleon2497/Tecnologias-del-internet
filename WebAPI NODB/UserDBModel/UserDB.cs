using System;
using System.Data.SqlClient;
using System.Text;
using UserDomain;

namespace UserDBModel
{
    public class UserDB
    {

        private string ConnectionString;
        public UserDB(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public IEnumerable<User> GetUsers()
        { 
            var userList = new List<User>();
            using (SqlConnection connection = new SqlConnection(this.ConnectionString)) 
            {
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("===============================\n");

                connection.Open();

                String sql = "SELECT USERNAME,PASSWORD,FSNAME,LASTNAME,EMAIL,PHONE,DOBIRTHDAY FROM DBO.UMUSER"; //Objetos y consultas a colocar

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader()) 
                    {
                        while (reader.Read()) 
                        {
                            User userTemp = new User();
                            userTemp.UserName = reader.GetString(0);
                            userTemp.Password = reader.GetString(1);
                            userTemp.FSName = reader.GetString(2);
                            userTemp.LastName = reader.GetString(3);
                            userTemp.Email = reader.GetString(4);
                            userTemp.Phone = reader.GetDecimal(5).ToString();
                            userTemp.DOBirthday = reader.GetDateTime(6);

                        userList.Add(userTemp);
                        }
                    }
                }               
            }
            return userList;
        }

        public void createUser(User user) 
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("===============================\n");

                connection.Open();//Abrir la coneccion con la base de datos

                String sql = @"INSERT INTO DBO.UMUSER (USERNAME,PASSWORD,FSNAME,LASTNAME,EMAIL,PHONE,DOBIRTHDAY) VALUES
                ('" + user.UserName + "'," +
                "'" + user.Password + "'," +
                "'" + user.FSName + "'," +
                "'" + user.LastName + "'," +
                "'" + user.Email + "'," +
                "'" + user.Phone + "'," +
                "'" + user.DOBirthday.ToString("yyyy-MM-dd") + "')"; //Objetos y consultas a colocar

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void updateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("===============================\n");

                connection.Open();//Abrir la coneccion con la base de datos

                String sql = @"UPDATE DBO.UMUSER SET
                PASSWORD" + user.Password + "'," +
                "FSNAME" + user.FSName + "'," +
                "LASTNAME" + user.LastName + "'," +
                "EMAIL" + user.Email + "'," +
                "PHONE" + user.Phone + "'," +
                "DOBIRTHDAY" + user.DOBirthday.ToString("yyyy-MM-dd") + "') WHERE" +
                "USERNAME=''"; //Objetos y consultas a colocar

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}