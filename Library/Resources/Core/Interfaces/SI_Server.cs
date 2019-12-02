using System;
using System.Collections.Generic;
using SysInfo.Library.Common;

namespace SysInfo.Library.Resources.Core
{
    /// <summary>
    /// public interface for instance items
    /// </summary>
    public interface I_SI_SERVER
    {
        List<D_SI_SERVER> SelectList (F_SI_SERVER aFilter);
        void              DeleteList (F_SI_SERVER aFilter);

        D_SI_SERVER SelectItem (K_SI_SERVER aKey);
        D_SI_SERVER InsertItem (D_SI_SERVER aDto);
        D_SI_SERVER UpdateItem (D_SI_SERVER aDto);
        void        DeleteItem (K_SI_SERVER aKey);
    }

    /// <summary>
    /// filter object for instance lists
    /// </summary>
    public class F_SI_SERVER : Data_F_Base
    {
        public string   serverNm { get; set; }
        public EDomain? domainID { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public F_SI_SERVER() { }
    }

    /// <summary>
    /// key object for instance items
    /// </summary>
    public class K_SI_SERVER : Data_K_Base
    {
        public string serverNm { get; set; }
    }

    /// <summary>
    /// data object for instance items
    /// </summary>
    public class D_SI_SERVER : Data_O_Base
    {
        // read-write
        public string           serverNm    { get; set; }
        public EDomain          domainID    { get; set; }
        public EServerLevelType levelTypeID { get; set; }
        public string           versionTxt  { get; set; }
        public string           descTxt     { get; set; }

        // read-only
        public string domainNm     { get; set; }
        public string levelTypeTxt { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public D_SI_SERVER() : base() { }
    }
}
