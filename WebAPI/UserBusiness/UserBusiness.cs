using UserDomain;
using UserDBModel;
namespace UserBusiness
{
    public class UserB
    {
        public UserB()
        { 
        }

        public User getUser ()
        { 
            User user = new User();

            user.UserName = "gpiedrahita";
            user.Password = "ABC123";
            user.FSName = "Gabriel Ricardo";
            user.LastName = "Piedrahita Solorzano";
            user.Email = "gabriel.piedrahita@unimilitar.edu.co";
            user.Phone = "3508994766";
            user.DOBirthday = DateTime.Parse("1987/10/14");
            user.Age = get_age(user.DOBirthday);

            return user;
        }

        private int get_age(DateTime dob)
        {
            int age = 0;
            age = DateTime.Now.Subtract(dob).Days;
            age = age / 365;
            return age;
        }

        public IEnumerable<User> getUsersDB(string ConnectionString)
        {
            UserDB userDB = new UserDB(ConnectionString);
            
            IEnumerable<User> users = new List<User>();
            users= userDB.getUsers();

            foreach (User user in users)
            { 
                user.Age= get_age(user.DOBirthday);
            }

            return users;
        }

        public void createUser(User user, string ConnectionString)
        {
            UserDB userDB = new UserDB(ConnectionString);
            userDB.createUser(user);
        }

        public void updateUser(User user, string ConnectionString)
        {
            UserDB userDB = new UserDB(ConnectionString);
            userDB.updateUser(user);
        }

        public void deleteUser(String userName, string ConnectionString)
        {
            UserDB userDB = new UserDB(ConnectionString);
            userDB.deleteUser(userName);
        }

    }
}