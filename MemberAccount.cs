using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Drawing;

namespace DatingApp
{
    /// <summary>
    /// Enums
    /// </summary>
    enum GUIOperation
    {
        Add,
        Browse,
        Chat,
        Delete
    }

    enum EyeColorType
    {
        Blue,
        Brown,
        DarkBrown,
        Green,
        Grey,
        Hazel,
        Other,
        RatherNotSay
    }

    enum HairColorType
    {
        Black,
        Brown,
        Blond,
        Grey,
        Red,
        White,
        Other,
        RatherNotSay
    }

    enum BodyType
    {
        Slim,
        Medium,
        BigandBeautiful,
        Other,
        RatherNotSay
    }

    enum MembershipType
    {
        Active,
        Guest,
        Suspended,
        Terminated,
        Trial
    }

    enum SexType
    {
        Female,
        Male
    }

    class MemberAccount
    {

        private static int lastMemberNumber = 0;

        private static int SeattleZipCode = 98052;

        #region Properties
        /// <summary>
        /// MembershipNummber
        /// </summary>
        public int MembershipNumber { get; }
        /*
         * ZipCode
         */
        public int ZipCode { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string ScreenName { get; set; }
        public HairColorType HairColor { get; set; }
        public EyeColorType EyeColor { get; set; }
        public DateTime CreateDate { get; }
        /*
         * DOB: date of birth: Current time - DOB = Age
         */
        public DateTime DOB { get; set; }
        public string EmailAddress { get; set; }
        public MembershipType Membership { get; set; }
        public SexType Sex { get; set; }
        public BodyType Body { get; set; }
        public string[] MsgBuffer { get; set; }
        public int MsgCount { get; set; }
        // public Image[] newImage { get; set; }

        #endregion

        #region Constructors

        public MemberAccount()
        {
            MembershipNumber = ++lastMemberNumber;
            CreateDate = DateTime.UtcNow;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Put money into the account
        /// </summary>
        /// <param name="amount"></param>

        private bool IsUSZipCode(string zipCode)
        {
            var validZipCode = false;
            var _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";

            if (Regex.Match(zipCode, _usZipRegEx).Success)
            {
                validZipCode = true;
            }
            return validZipCode;
        }

        private bool ValidiateZipcode(string Zipcode)
        {
            if (IsUSZipCode(Zipcode))
            {
                // This needs to be fix in the next version of the code. Use a method alreay written.
                //Console.WriteLine(" Invalid Zip Code, the Zip Code must be in the Seattle Washington State Area");
                return true;
            }
            else
            {
                Console.WriteLine(" Invalid Zip Code, the Zip Code is not a valid US Zip Code");
                return false;
            }
        }

        private bool ValidiateHeight(int HeightFeetPart, int HeightInchPart)
        {
            try
            {
                Height = CalculateHeight(HeightFeetPart, HeightInchPart);
                return true;
            }
            catch (ZeroHeightException e)
            {
                return false;
            }
            catch (InvalidHeightException e)
            {
                return false;
            }
            catch (Exception e)
            {
                // Process all other exceptions
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public int CalculateHeight(int HeightFeetPart, int HeightInchPart)
        {
            int TotalHeightInInches = (HeightFeetPart * 12) + HeightInchPart;
            if (TotalHeightInInches == 0)
            {
                Console.WriteLine(" Invalid Height, Height must be between 4 ft 0 inches and 7 ft 0 inches");
                throw new ZeroHeightException(TotalHeightInInches);
            }
            else if ((TotalHeightInInches < 48) || (TotalHeightInInches > 84))
            {
                throw new InvalidHeightException(Height);
            }
            else
            {
                return TotalHeightInInches;
            }
        }

        private bool ValidiateWeight(int Weight)
        {
            if (Weight == 0)
            {
                throw new ZeroWeightException(Weight);
            }
            else if ((Weight < 100) || (Weight > 300))
            {
                throw new InvalidWeightException(Weight);
            }
            else
            {
                return true;
            }
        }

        /// <summary>  
        /// For calculating only age  
        /// </summary>  
        /// <param name="dateOfBirth">Date of birth</param>  
        /// <returns> age e.g. 26</returns>  
        public static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

        public static string GetAge(DateTime dob)
        {
            DateTime todayDateUtc = DateTime.UtcNow;
            DateTime pastYearDate;
            int years = 0;
            string age;
            int days;

            if (DateTime.UtcNow > dob)
            {
                years = new DateTime(DateTime.UtcNow.Subtract(dob).Ticks).Year - 1;
            }

            pastYearDate = dob.AddYears(years);
            days = todayDateUtc.Subtract(pastYearDate).Days;
            age = years + " years " + days + " days";

            return age;
        }

        private bool ValidiateDOB(DateTime DOB)
        {
            // DateTime deltaTime = 0;
            // DateTime currentTime = DateTime.Now;

            int age = Convert.ToInt32(GetAge(DOB));

            if ((age < 21) || (age > 60))
            {
                Console.WriteLine(" Invalid Age, the age must be between 21 and 60");
                return false;
            }
            return true;
        }

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        // public bool UploadPictures(Image Picture, int indx, int PictureIndx)
        // {
            /*
             *    Put the pictures in the Member's account
             */
            // Members[indx].Picture[PictureIndx] = Pictures;
            // return true;
        // }

        #endregion
    }
}