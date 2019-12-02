using System;
using System.Collections.Generic;
using SysInfo.Library.Common;

namespace SysInfo.Library.Resources.Core
{
    /// <summary>
    /// public interface for instance items
    /// </summary>
    public interface I_SI_DATABASE
    {
        List<D_SI_DATABASE> SelectList (F_SI_DATABASE aFilter);
        void                DeleteList (F_SI_DATABASE aFilter);

        D_SI_DATABASE SelectItem (K_SI_DATABASE aKey);
        D_SI_DATABASE InsertItem (D_SI_DATABASE aDto);
        D_SI_DATABASE UpdateItem (D_SI_DATABASE aDto);
        void          DeleteItem (K_SI_DATABASE aKey);
    }

    /// <summary>
    /// filter object for instance lists
    /// </summary>
    public class F_SI_DATABASE : Data_F_Base
    {
        public EDomain?          domainID          { get; set; }
        public int?              serverID          { get; set; }
        public EServerLevelType? serverLevelTypeID { get; set; }
        public string            databaseNm        { get; set; }
        public EDatabaseType?    databaseTypeID    { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public F_SI_DATABASE() { }
    }

    /// <summary>
    /// key object for instance items
    /// </summary>
    public class K_SI_DATABASE : Data_K_Base
    {
        public string databaseNm { get; set; }
    }

    /// <summary>
    /// data object for instance items
    /// </summary>
    public class D_SI_DATABASE : Data_O_Base
    {
        // read-write
        public string        databaseNm      { get; set; }
        public int           serverID        { get; set; }
        public EDatabaseType databaseTypeID  { get; set; }
        public string        descTxt         { get; set; }

        // read-only
        public EDomain domainID        { get; set; }
        public string  domainNm        { get; set; }
        public string  serverNm        { get; set; }
        public string  databaseTypeTxt { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public D_SI_DATABASE() : base() { }
    }
}
