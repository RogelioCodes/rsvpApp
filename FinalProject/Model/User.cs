using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Model
{
    public class User
    {
        //referenced from https://www.youtube.com/watch?reload=9&v=eAZ4kPf5eTc
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string Username, string Password) 
        {
            this.Username = Username;
            this.Password = Password;
        }

        public bool CheckPassword()
        {
            if (!this.Username.Equals("") && !this.Password.Equals(""))
                return true;
            else
                return false;
        }
    }
}
