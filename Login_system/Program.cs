using System;
using System.Collections.Generic;

namespace Login_system
{
    internal class Program
    {
        private static List<User> users = new List<User>();

        static void Main(string[] args)
        {
            Console.WriteLine("                       ##########################################");
            Console.WriteLine("                       ##                                      ##");
            Console.WriteLine("                       ##  Welcome to Zphorium's application   ##");
            Console.WriteLine("                       ##                                      ##");
            Console.WriteLine("                       ##########################################");
            Console.WriteLine();
            Console.WriteLine("Our available commands :");
            Console.WriteLine();
            Console.WriteLine("/register");
            Console.WriteLine("/login");
            Console.WriteLine("/exit");

            while(true)
            {
                Console.WriteLine();
                Console.Write("Enter command : ");
                string command = Console.ReadLine();

                if(command == "/register")
                {
                    Console.Write("Please add user's name :");
                    string name = Console.ReadLine();

                    Console.Write("Please add user's surname :");
                    string lastName = Console.ReadLine();

                    Console.Write("Please add user's email :");
                    string email = Console.ReadLine();

                    Console.Write("Please add user's pasword :");
                    string pasword = Console.ReadLine();

                    Console.Write("Enter your pasword again :");
                     string paswordGuard = Console.ReadLine();

                    AddNewUser(name, lastName, email , pasword);



                }

                else if (command == "/login")
                {
                    Console.Write("Please ener your email :");
                    string targetEmail = Console.ReadLine();

                    Console.Write("Please ener your pasword :");
                    string targetPasword = Console.ReadLine();

                    

                    if (!HaveTargetEmailOnBase(targetEmail))
                    {
                        Console.WriteLine("Your email is not found");
                        continue;
                    }
                    else if (!IsTargetPaswordTrue(targetPasword))
                    {
                        Console.WriteLine("Your pasword is not correct");
                        continue;
                    }
                   
                    Console.WriteLine("Welcome to your account");                   

                }

                else if (command == "/exit")
                {
                    Console.WriteLine("Thanks for using our application!");
                    break;
                }

                else
                {
                    Console.WriteLine("Command not found, please enter command from list!");
                    Console.WriteLine();
                }    

              
            }

        }

           public static void AddNewUser(string name, string lastName, string email, string pasword)
           {
           
             User person = new User(name, lastName, email , pasword);
                 users.Add(person);

             string paswordGuard = Console.ReadLine();

            if ( paswordGuard == pasword)
             {
                 Console.WriteLine("You successfully registered, now you can login with your new account!");
             }
             else
             {
                Console.WriteLine("Your email or pasword is not correct ");
             }

            }

          public static bool HaveTargetEmailOnBase(string targetEmail)
          {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Email == targetEmail)
                {
                    return true;
                }
                return false;
            }       
            return false;
            
          }
          public static bool IsTargetPaswordTrue(string targetPasword)
          {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Pasword == targetPasword)
                {
                    return true;
                }
                return false;
            }
            return false;
          }


        class User
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Pasword { get; set; }



            public User(string name, string lastName, string email, string pasword)
            {
                if(IsNameCorrect(name) & IsLastNameCorrect(lastName) & IsEmailCorrect(email))
                {
                  Name = name;
                  LastName = lastName;
                  Email = email;
                  Pasword = pasword;

                }
                               
            }
            public bool IsNameCorrect(string name)
            {
                
                if (!IsTextLengthCorrect(name,3,30 ))
                {
                    Console.WriteLine("The length of your name must be between 3-30 letters. ");
                    return false;
                }

                if (!IsLetters(name))
                {
                    Console.WriteLine("You have to use only letters when writing your name.");
                    return false;
                }

                return true;
            }

            public bool IsLastNameCorrect(string lastname)
            {

                if (!IsTextLengthCorrect(lastname, 5, 20))
                {
                    Console.WriteLine("The length of your lastname must be between 5-20 letters. ");
                    Console.WriteLine();
                    return false;
                }

                if (!IsLetters(lastname))
                {
                    Console.WriteLine("You have to use only letters when writing your lastname.");
                    Console.WriteLine();
                    return false;
                }

                return true;
            }

            public bool IsEmailCorrect(string email)
            {
                if (!HaveEmailChar(email))
                {
                    Console.WriteLine("Your need use '@' when youe write your e-mail");
                    Console.WriteLine();
                    
                    return false;

                }
                return true;
            }

            public string GetFullName()
            {
                return Name + " " + LastName;
            }

            

        }


        ////////////////// Methods

        public static bool IsLetters(string text)
        {
            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            foreach (char targerCharacter in text)
            {
                bool isTargetLetterFound = false;

                foreach (char letter in letters)
                {
                    if (letter == targerCharacter)
                    {
                        isTargetLetterFound = true;
                        break;
                    }
                }

                if (!isTargetLetterFound)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsTextLengthCorrect(string text, int startLength, int endLength)
        {
            if (!(text.Length >= startLength && text.Length <= endLength))
            {
                return false;
            }

            return true;
        }

        public static bool HaveEmailChar(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {

               if (text[i] == '@')
                {
                    return true;
                    
                }
                return false;
            }
            return false;
            
        }
            
    }
}
