using System;
using System.Drawing;

public class Member_Data
{

    /// <summary>
    /// 
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
    #region Properties
    /// <summary>
    /// AcccountNummber
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
    public EyeColorType  EyeColor { get; set; }
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

}
