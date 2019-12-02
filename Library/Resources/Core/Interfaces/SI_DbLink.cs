using System;
using System.Collections.Generic;
using SysInfo.Library.Common;

namespace SysInfo.Library.Resources.Core
{
    /// <summary>
    /// public interface for instance items
    /// </summary>
    public interface I_SI_DB_LINK
    {
        List<D_SI_DB_LINK> SelectList (F_SI_DB_LINK aFilter);
        void               DeleteList (F_SI_DB_LINK aFilter);

        D_SI_DB_LINK SelectItem (K_SI_DB_LINK aKey);
        D_SI_DB_LINK InsertItem (D_SI_DB_LINK aDto);
        D_SI_DB_LINK UpdateItem (D_SI_DB_LINK aDto);
        void         DeleteItem (K_SI_DB_LINK aKey);
    }

    /// <summary>
    /// filter object for instance lists
    /// </summary>
    public class F_SI_DB_LINK : Data_F_Base
    {
        public EDomain?          sourceDomainID          { get; set; }
        public int?              sourceServerID          { get; set; }
        public EServerLevelType? sourceServerLevelTypeID { get; set; }
        public int?              sourceDatabaseID        { get; set; }
        public EDatabaseType?    sourceDatabaseTypeID    { get; set; }
        public EDomain?          targetDomainID          { get; set; }
        public int?              targetServerID          { get; set; }
        public EServerLevelType? targetServerLevelTypeID { get; set; }
        public int?              targetDatabaseID        { get; set; }
        public EDatabaseType?    targetDatabaseTypeID    { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public F_SI_DB_LINK() { }
    }

    /// <summary>
    /// key object for instance items
    /// </summary>
    public class K_SI_DB_LINK : Data_K_Base
    {
        public int? sourceDatabaseID { get; set; }
        public int? targetDatabaseID { get; set; }
    }

    /// <summary>
    /// data object for instance items
    /// </summary>
    public class D_SI_DB_LINK : Data_O_Base
    {
        // read-write
        public int    sourceDatabaseID { get; set; }
        public int    targetDatabaseID { get; set; }
        public string descTxt          { get; set; }

        // read-only
        public EDomain          sourceDomainID           { get; set; }
        public string           sourceDomainNm           { get; set; }
        public int              sourceServerID           { get; set; }
        public string           sourceServerNm           { get; set; }
        public EServerLevelType sourceServerLevelTypeID  { get; set; }
        public string           sourceServerLevelTypeTxt { get; set; }
        public string           sourceDatabaseNm         { get; set; }
        public EDatabaseType    sourceDatabaseTypeID     { get; set; }
        public string           sourceDatabaseTypeTxt    { get; set; }

        public EDomain          targetDomainID           { get; set; }
        public string           targetDomainNm           { get; set; }
        public int              targetServerID           { get; set; }
        public string           targetServerNm           { get; set; }
        public EServerLevelType targetServerLevelTypeID  { get; set; }
        public string           targetServerLevelTypeTxt { get; set; }
        public string           targetDatabaseNm         { get; set; }
        public EDatabaseType    targetDatabaseTypeID     { get; set; }
        public string           targetDatabaseTypeTxt    { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public D_SI_DB_LINK() : base() { }
    }
}
