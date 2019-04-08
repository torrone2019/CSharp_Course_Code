using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Drawing;

namespace DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Welcome to the Seattle Sofware Singles");
            int Response = 0;
            string screenName = "";
            bool ScreenNameIsTaken = true;

            while (true)
            {
                    Console.WriteLine("Welcome to the Seattle Sofware Singles");
                    Console.WriteLine("Menu 1: Add Member ");
                    Console.WriteLine("     2: Browse");
                    Console.WriteLine("     3: Chat with Member");
                    Console.WriteLine("     4: Delete Your Account");
                    Console.WriteLine("     5: Exit this App");
                    Console.WriteLine("Please Enter Your Selection:");

                    Response = Convert.ToInt32(Console.ReadLine());

                    switch (Response)
                    {
                        case 0:
                            Console.WriteLine("Thank you for visiting Seattle Software Singles");
                            break;
                        case 1:
                            Console.WriteLine("Welcome to the Seattle Sofware Singles");

                            while (ScreenNameIsTaken)
                            {
                                   Console.WriteLine("Please Enter a Screen Name:");
                                   screenName = Console.ReadLine();
                                   ScreenNameIsTaken = SinglesDating.CheckIfScreenNameAvailable(screenName);
                            }

                            Console.WriteLine("Please Enter Your Sex:");
                            var SexTypes = Enum.GetNames(typeof(SexType));
                            for (var i = 0; i < SexTypes.Length; i++)
                            {
                                 Console.WriteLine($"{i + 1},{SexTypes[i]}");
                            }
                            var MemberSex = Enum.Parse<SexType>(Console.ReadLine());

                            Console.WriteLine("Please Enter Your Eye Color:");
                            var EyeColorTypes = Enum.GetNames(typeof(EyeColorType));
                            for (var i = 0; i < EyeColorTypes.Length; i++)
                            {
                                 Console.WriteLine($"{i + 1},{EyeColorTypes[i]}");
                            }
                            var EyeColor = Enum.Parse<EyeColorType>(Console.ReadLine());

                            Console.WriteLine("Please Enter Your Hair Color:");
                            var HairColorTypes = Enum.GetNames(typeof(HairColorType));
                            for (var i = 0; i < HairColorTypes.Length; i++)
                            {
                                 Console.WriteLine($"{i + 1},{HairColorTypes[i]}");
                            }
                            var HairColor = Enum.Parse<HairColorType>(Console.ReadLine());

                            Console.WriteLine("Please Enter your Height in the ft. part ");
                            int HeightFtPart = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please Enter your Height in the inches part ");
                            int HeightInPart = Convert.ToInt32(Console.ReadLine());
                            int heightTotalInches = (HeightFtPart * 12) + HeightInPart;

                            Console.WriteLine("Please Enter Your Weight in lbs:");
                            int weight = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Please Enter Your Body Type:");
                            var BodyTypes = Enum.GetNames(typeof(BodyType));
                            for (var i = 0; i < BodyTypes.Length; i++)
                            {
                                 Console.WriteLine($"{i + 1},{BodyTypes[i]}");
                            }
                            var memberBodyType = Enum.Parse<BodyType>(Console.ReadLine());

                            Console.WriteLine("Please Enter Your Date of Birth:");
                            DateTime DOB = Convert.ToDateTime(Console.ReadLine());

                            Console.WriteLine("Please Enter Your Email Address:");
                            string emailAddress = Console.ReadLine();

                            Console.WriteLine("Please Enter Your ZipCode:");
                            string ZipCode = Console.ReadLine();
 
                            SinglesDating.CreateMember(screenName, emailAddress, DOB, MemberSex, HairColor, EyeColor,
                                                       heightTotalInches, weight, memberBodyType, ZipCode);
                            break;
                        case 2:
                            Console.WriteLine("Please Enter Your Screen Name:");
                            string yourScreenName = Console.ReadLine();
                            Console.WriteLine("Enter the minimum Age of your search");
                            int lowerAge = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the maximun Age of your search");
                            int upperAge = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter the Zip Code of your Search");
                            int zipCode = Convert.ToInt32(Console.ReadLine());
                       
                            Console.WriteLine("Enter Body Type");
                            BodyTypes = Enum.GetNames(typeof(BodyType));
                            for (var i = 0; i < BodyTypes.Length; i++)
                            {
                                 Console.WriteLine($"{i + 1},{BodyTypes[i]}");
                            }
                            var browseBodyType = Enum.Parse<BodyType>(Console.ReadLine());
                           
                            SinglesDating.BrowseMembers(yourScreenName, lowerAge, upperAge, zipCode, browseBodyType);
                            break;
                        case 3:
                            Console.WriteLine("Please Enter Your ScreenName:");
                            yourScreenName = Console.ReadLine();
                            Console.WriteLine("Please Enter the Other Person Screen Name:");
                            string theirScreenName = Console.ReadLine();
                            Console.WriteLine("Please Enter Your Message");
                            string msgBuffer = Console.ReadLine();
                            SinglesDating.ChatWithMember(yourScreenName, theirScreenName, msgBuffer);
                            break;
                        case 4:
                            Console.WriteLine(" Enter your Screen Name");
                            yourScreenName = Console.ReadLine();
                            Console.WriteLine(" Are you sure you want to Delete this account? y/n");
                            var ans = Console.ReadLine();
                            if (string.Equals(ans, 'y'))
                            {
                               SinglesDating.DeleteMember(yourScreenName);
                               Console.WriteLine(" Account Deleted ");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Thank you for visiting Seattle Software Singles: Good Bye");
                            return;      
                        default:
                            Console.WriteLine("Error: Invalid GUI Response");
                            break;
                    }
            }   
        }
    }
}
