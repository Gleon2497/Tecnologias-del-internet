using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDomain;

namespace UserBussiness
{
    public class UserB
    {
        public UserB()
        {
        }

        public User getUser()
        {
            User user = new User();

            user.UserName = "gleon";
            user.Password = "ABC123";
            user.FSName = "Gustavo Alejandro";
            user.LastName = "León Pulido";
            user.Email = "est.gustavo.leon@unimilitar.edu.co";
            user.Phone = "31115558";
            user.DOBirthday = DateTime.Parse("1997/07/08");
            user.Age = get_age(user.DOBirthday);

            return user;
        }

        public int get_age(DateTime dob) 
        {
            int age = 0;
            age = DateTime.Now.Subtract(dob).Days;
            age = age / 365;
            return age;
        }


    }
}
