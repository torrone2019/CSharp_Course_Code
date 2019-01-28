using System;
using System.Drawing;

public class Member_Data
{

    /// <summary>
    /// 
    /// </summary>

    enum BodyType
    {
        Slim,
        Medium,
        BigandBeautiful
    }

    enum MemberShipStatus
    {   
        Active,
        Guest,
        Suspended,
        Terminated,
        Trail
    }

    enum SexType
    {
        Female,
        Male
    }

    private static int lastAMemnberNumber = 0;
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
    public DateTime CreateDate { get; }
    /*
     * DOB: date of birth: Current time - DOB = Age
     */
    public DateTime DOB { get; set; }
    public string EmailAddress { get; set; }
    public MemberShipStatus MemberShip { get; set; }
    public SexType Sex { get; set; }
    public BodyType Body { get; set;  }
    public Image[] Pictures { get; set; } 
        
    #endregion

    #region Constructors

    #endregion
    public Member_Data()
	{
	}
}
