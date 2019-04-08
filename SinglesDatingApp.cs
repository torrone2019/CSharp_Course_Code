using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DatingApp
{
   static class SinglesDating
    {
        private static List<MemberAccount> memberAccounts = new List<MemberAccount>();

        public static MemberAccount CreateMember(string screenname, string emailaddress,
            DateTime dateofbirth, SexType sex = SexType.Male, HairColorType HairColor = HairColorType.RatherNotSay,
            EyeColorType eyeColor = EyeColorType.RatherNotSay, int height = 0, int weight =0,
            BodyType bodytype = BodyType.RatherNotSay, string ZipCode = "")
        {
            var account = new MemberAccount
            {
                ScreenName = screenname,
                EmailAddress = emailaddress,
                DOB = dateofbirth,
                Sex = sex,
                HairColor = HairColor,
                EyeColor = eyeColor,
                Height = height,
                MsgCount = 0,
                Weight = weight
            };

            memberAccounts.Add(account);
            return account;
        }

        public static bool CheckIfScreenNameAvailable(string ScName)
        /*
         *    Check if the ScreenName is available
         */
        {
            if (string.IsNullOrEmpty(ScName))
            {
                throw new ScreenNameNullException(ScName);
            }
            else if (memberAccounts.Exists(account => account.ScreenName == ScName))
            {
                Console.WriteLine("ScreenName $(account.ScreenName) exists already.");
                return true;
            }
            else
            {
                return false;
            }
        }

        public static IEnumerable<MemberAccount> GetAllMembers(string emailAddress)
        {
            return memberAccounts.Where(account => account.EmailAddress == emailAddress);
        }

        public static IEnumerable<MemberAccount> BrowseMembers(string yourScreenName, int lowerAge, int maxAge,
                                                               int ZipCode, BodyType browseBodyType)
        {

            var theBrowseResults = memberAccounts.Where(account => (account.ZipCode == ZipCode) &&
                                                                   (MemberAccount.CalculateAge(account.DOB) >= lowerAge) &&
                                                                   (MemberAccount.CalculateAge(account.DOB) <= maxAge) &&
                                                                   (account.Body == browseBodyType));

            foreach (MemberAccount result in theBrowseResults)
            {
                Console.WriteLine(result.ScreenName);
            }
            return theBrowseResults;
        }

        public static string ChatWithMember(string yourScreenName, string theirScreenName, string msg)
        {

            MemberAccount yourAccount = memberAccounts.Single(account => account.ScreenName == yourScreenName);
            MemberAccount theirAccount = memberAccounts.Single(account => account.ScreenName == theirScreenName);

            if (string.IsNullOrEmpty(yourAccount.EmailAddress))
            {
                return Convert.ToString(DateTime.UtcNow) + "false: your Account EmailAddress:" + yourScreenName + " does not exist";
            }

            if (string.IsNullOrEmpty(theirAccount.EmailAddress))
            {
                return Convert.ToString(DateTime.UtcNow) + "false: their Account EmailAddress:" + theirScreenName + " does not exist";
            }

            int count = theirAccount.MsgCount;
            theirAccount.MsgBuffer[count] = yourAccount.ScreenName + msg;
            theirAccount.MsgCount = count+1;
            return Convert.ToString(DateTime.UtcNow) + "True:" +  yourScreenName + " sent " + msg + " to " + theirScreenName;
            
        }

        public static bool DeleteMember(string screenName)
        {
            memberAccounts.Where(account => account.EmailAddress == screenName);
            if (memberAccounts.Exists(account => account.ScreenName == screenName))
            {
                memberAccounts.RemoveAll(account => account.ScreenName == screenName);
                Console.WriteLine("Member $(account.ScreenName) exists and is deleted");
                return true;
            }
            else
            {
                Console.WriteLine("Member $(screenName) does not exists and is not deleted");
                return false;
            }
        }
    }
}