using System;
using Microsoft.Extensions.Logging;

namespace SysInfo.Library.Common
{
    public enum AppUser { Admin = 0, Staff }
    public enum AppRole { Any = 0, Admin, Staff, Guest }

    // NOTE: need to match persistent store
    public enum EDomain          { None = 0, BlueLand, RedLand }
    public enum EDatabaseType    { None = 0, SqlServer, Azure, Oracle, MySql }
    public enum EApplicationType { None = 0, Web, Desktop, Console }
    public enum EServerLevelType { None = 0, Devl, Test, Prod }

    public partial class Ref
    {
        public static ILoggerFactory Log { get; set; }

        // ID for new domain objects
        public const int NewID   = -1;
        public const int AdminID = 1;
        public const int GuestID = 2;

        public const string NewUid   = "-NEW-";
        public const string AdminUid = "ADMIN";
        public const string GuestUid = "GUEST";

        // select options
        public int eNone = -1;
        public int eAny  =  0;

        // success/failure
        public const string SuccessTxt  = "Success";
        public const string FailureTxt  = "Failure";
        public const string NoResultTxt = "No Result";

        // valid/invalid
        public const string ValidTxt    = "Valid";
        public const string InvalidTxt  = "Invalid";
    }
}
