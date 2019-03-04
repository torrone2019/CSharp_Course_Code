using System;
using System.Drawing;
using SSS_Exceptions;

public class Member_Data
{

    /// <summary>
    /// Enums
    /// </summary>

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

    enum MemberShipType
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

    private static int lastMemnberNumber = 0;

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
    public float Height { get; set; }
    public float Weight { get; set; }
    public string ScreenName { get; set; }
    public HairColorType HairColor { get; set; }
    public EyeColorType EyeColor { get; set; }
    public DateTime CreateDate { get; }
    /*
     * DOB: date of birth: Current time - DOB = Age
     */
    public DateTime DOB { get; set; }
    public string EmailAddress { get; set; }
    public MemberShipType MemberShip { get; set; }
    public SexType Sex { get; set; }
    public BodyType Body { get; set; }
    public Image[] Pictures { get; set; }

    #endregion

    #region Methods
    /*
    * Methods
    */

    var _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
   
    private bool IsUSZipCode(string zipCode)
    {
        var validZipCode = false;
        if (Regex.Match(zipCode, _usZipRegEx).Success)
        {
            validZipCode = true;
        }
        return validZipCode;
    }

private bool ValidiateZipcode (int Zipcode)
    {
        if (IsUSZipCode)
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

private bool ValidiateHeight(int HeightFeetPart,  int HeightInchPart)
    {
        try
        {
            Height = CalculateHeight(HeightPartFeet, HeightPartInch);
            return true;
        }
        catch (Exception e)
        {
            // Process all other exceptions
            Console.WriteLine(e.Message);
            return false;
        }
        catch (ZeroHeightException e)
        {
            return false;
        }
        catch (InvalidHeightException e)
        {
            return false;
        }
    }

    public int CalculateHeight(int HeightFeetPart, int HeightInchPart)
    {
        TotalHeightInInches = (HeightFeetPart * 12) + HeightInchPart;
        if (Height == 0)
        {
            Console.WriteLine(" Invalid Height, Height must be between 4 ft 0 inches and 7 ft 0 inches");
            throw new ZeroHeightException(Height);
        }
        else if (48 < Height > 84)
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
        else if (100 < Weight > 300)
        {
            throw new InvalidWeightException(Weight);
        }
        else
        {
            return true;
        }
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
        DateTime deltaTime = 0;
        DateTime currentTime = DateTime.Now;

        GetAge(DOB);

        if (21 < age > 60)
        {
            Console.WriteLine(" Invalid Age, the age must be between 21 and 60");
            return false;
        }
    }

    public bool ValidiateEmail(string emailaddress)
    {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
    }

    private bool ValidiateScreenName(string ScreenName)
    {
        /*
         *    Check if ScreenName is Null or Empty
         */

        if (IsNullOrEmpty(ScreenName))
        {
            throw new ScreenNameNullException(ScreenName);
        }
        else if (CheckIfScreenNameAvailable(ScreenName))
        {
            return true;
        }
        else
        {
            throw new ScreenNameInUseException(ScreenName);
        }
    }

    public bool CheckIfScreenNameAvailable(string ScName)
    /*
     *    Loop thru all entries in the ScreenNames array
     */
    {
        foreach (int i in ScreenNameArray)
        {
            if (ScName = ScreenNameArray[i])
            {
                return false;
            }
            return true;
        }
    }

    public bool UploadPictures(Image Picture, int indx, int PictureIndx)
    {
        /*
         *    Put the pictures in the Member's account
         */
        Members[indx].Picture[PictureIndx] = Pictures;
    }

    #endregion
}
