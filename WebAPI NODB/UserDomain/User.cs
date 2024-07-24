namespace UserDomain
{

    //CREATE TABLE UMUSER
    //(
    //USERNAME VARCHAR(50),
    //PASSWORD VARCHAR(50),
    //FSNAME VARCHAR(100),
    //LASTNAME VARCHAR(100),
    //EMAIL VARCHAR(200),
    //PHONE NUMERIC(18,0),
    //DOBIRTHDAY DATE
    //)

    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FSName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DOBirthday { get; set; }

        public int Age { get; set; }

    }
}