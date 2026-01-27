using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace OOP_Day1
{
    class UserProfile
    {
        public string Username;
        public string Email;
        private string Password;

        public UserProfile(string username, string email, string passaword)
        {
            Username = username;
            Password = passaword;

            if (isVaidEmail(email)) {
                Email = email;
            }
            else
            {
                throw new Exception("Email is invalid");
            }
        }

        public bool isVaidEmail(string email)
        {

            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
        }
        public void setNewPassword(string password)
        {
            Password = password;
        }
        public string getPassword()
        {
            return Password;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Username: {Username}, Email: {Email}, Password: {Password}");
        }

    }
    internal class Secure_User_Profile
    {
        public static void Main()
        {
            try { 
                UserProfile user1 = new UserProfile("Aayush-Panchasara", "aayushpanchasara@gmail.com", "A@yush15");
                //UserProfile user1 = new UserProfile("Aayush-Panchasara", "Invalid email", "A@yush15");
                Console.WriteLine($"Username: {user1.Username}"); //Able to access because it defined using public access modifier

                //Console.WriteLine($"Password: {user1.Password}"); //Unable to access password field because has private access modifiers.

                Console.WriteLine($"Password: {user1.getPassword()}"); //With the help of getter and setter you able to access the field.

                user1.DisplayInfo();
            } catch (Exception ex) 
            { 
                Console.WriteLine($"Exception: {ex.Message}");
            }


        }
    }
}
