using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace WpfApp
{
    public class User
    {
        public string Id { get; set; }
        public string Login { get; set; }

        public User(string id, string login)
        {
            Id = id;
            Login = login;
        }

        public User()
        {
        }

        
    }
}
