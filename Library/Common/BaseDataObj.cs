using System;
using System.Linq;

namespace SysInfo.Library.Common
{
    /// <summary>
    /// base class for filter objects
    /// </summary>
    public abstract class Data_F_Base
    {
        public int?  objectID   { get; set; }
        public int?  selectedID { get; set; }
        public bool? activeYn   { get; set; }

        public int?  userID     { get; set; }
    }

    /// <summary>
    /// base class for keys
    /// </summary>
    public abstract class Data_K_Base
    {
        public int? objectID { get; set; }
    }

    /// <summary>
    /// base class for data objects
    /// </summary>
    public abstract class Data_O_Base
    {
        public int      objectID     { get; set; }
        public string   selectTxt    { get; set; }
        public bool     activeYn     { get; set; }
        public string   createByUid  { get; set; }
        public string   createByNm   { get; set; }
        public DateTime createOnDts  { get; set; }
        public string   updateByUid  { get; set; }
        public string   updateByNm   { get; set; }
        public DateTime updateOnDts  { get; set; }
        public byte[]   versionKey { get; set; }

        protected Data_O_Base ()
        {
            objectID    = Ref.NewID;
            activeYn    = true;
            selectTxt   = string.Empty;
            createByUid = updateByUid = AppInfo.UserUid;
            createByNm  = string.Empty;
            createOnDts = updateOnDts = DateTime.Now;
            updateByNm  = string.Empty;
        }

        /// <summary>
        /// compare sqlserver version keys (ROWVERSION = byte[])
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public bool IsVersionKey (byte[] arg) { return (versionKey != null && ((byte[]) versionKey).SequenceEqual<byte>(arg)); }
    }
}
