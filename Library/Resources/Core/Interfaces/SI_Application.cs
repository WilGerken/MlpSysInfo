using System;
using System.Collections.Generic;
using SysInfo.Library.Common;

namespace SysInfo.Library.Resources.Core
{
    /// <summary>
    /// public interface for instance items
    /// </summary>
    public interface I_SI_APPLICATION
    {
        List<D_SI_APPLICATION> SelectList (F_SI_APPLICATION aFilter);
        void                   DeleteList (F_SI_APPLICATION aFilter);

        D_SI_APPLICATION SelectItem (K_SI_APPLICATION aKey);
        D_SI_APPLICATION InsertItem (D_SI_APPLICATION aDto);
        D_SI_APPLICATION UpdateItem (D_SI_APPLICATION aDto);
        void             DeleteItem (K_SI_APPLICATION aKey);
    }

    /// <summary>
    /// filter object for instance lists
    /// </summary>
    public class F_SI_APPLICATION : Data_F_Base
    {
        public EDomain?          domainID          { get; set; }
        public EApplicationType? applicationTypeID { get; set; }
        public EServerLevelType? serverLevelTypeID { get; set; }
        public int?              serverID          { get; set; }
        public string            applicationNm     { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public F_SI_APPLICATION() { }
    }

    /// <summary>
    /// key object for instance items
    /// </summary>
    public class K_SI_APPLICATION : Data_K_Base
    {
        public string applicationNm { get; set; }
    }

    /// <summary>
    /// data object for instance items
    /// </summary>
    public class D_SI_APPLICATION : Data_O_Base
    {
        // read-write
        public string           applicationNm     { get; set; }
        public int              serverID          { get; set; }
        public EApplicationType applicationTypeID { get; set; }
        public string           descTxt           { get; set; }

        // read-only
        public EDomain domainID           { get; set; }
        public string  domainNm           { get; set; }
        public string  serverNm           { get; set; }
        public string  applicationTypeTxt { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public D_SI_APPLICATION() : base() { }
    }
}
