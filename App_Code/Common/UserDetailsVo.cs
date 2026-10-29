using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDetailsVo
/// </summary>
public class UserDetailsVo
{
    # region Property Declaration

    public string intUserid { get; set; }
    public string Userid { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public string Userlevel { get; set; }
    public string Usertype { get; set; }
    public string Usercode { get; set; }
    public string Status { get; set; }
    public string Formname { get; set; }
    public int DistrictID { get; set; }
    public string Defaultpasswordflag { get; set; }
    #endregion

    #region Property declaration for entrepreneur

    public int intentrepreneurid { get; set; }
    public string entrepreneurFirstname { get; set; }
    public string entrepreneurLastname { get; set; }
    public string entrepreneurEmail { get; set; }
    public string entrepreneurAddress { get; set; }
    public string entrepreneurLocation { get; set; }
    public string entrepreneurPANcardno { get; set; }
    public string entrepreneurMobileNo { get; set; }
    public string entrepreneurusername { get; set; }
    public string entrepreneurAadharNo { get; set; }

    #endregion

    public UserDetailsVo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

}