using System;
using System.Collections.Generic;
using SysInfo.Library.Common;

namespace SysInfo.Library.Resources.Core
{
    /// <summary>
    /// public interface for instance items
    /// </summary>
    public interface I_SI_APP_DB
    {
        List<D_SI_APP_DB> SelectList (F_SI_APP_DB aFilter);
        void              DeleteList (F_SI_APP_DB aFilter);

        D_SI_APP_DB SelectItem (K_SI_APP_DB aKey);
        D_SI_APP_DB InsertItem (D_SI_APP_DB aDto);
        D_SI_APP_DB UpdateItem (D_SI_APP_DB aDto);
        void        DeleteItem (K_SI_APP_DB aKey);
    }

    /// <summary>
    /// filter object for instance lists
    /// </summary>
    public class F_SI_APP_DB : Data_F_Base
    {
        public EDomain?          appDomainID          { get; set; }
        public int?              appServerID          { get; set; }
        public EServerLevelType? appServerLevelTypeID { get; set; }
        public int?              applicationID        { get; set; }
        public EApplicationType? applicationTypeID    { get; set; }
        public EDomain?          dbDomainID           { get; set; }
        public int?              dbServerID           { get; set; }
        public EServerLevelType? dbServerLevelTypeID  { get; set; }
        public int?              databaseID           { get; set; }
        public EDatabaseType?    databaseTypeID       { get; set; }
        public int?              dbLinkID             { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public F_SI_APP_DB() { }
    }

    /// <summary>
    /// key object for instance items
    /// </summary>
    public class K_SI_APP_DB : Data_K_Base
    {
        public int? applicationID { get; set; }
        public int? databaseID    { get; set; }
    }

    /// <summary>
    /// data object for instance items
    /// </summary>
    public class D_SI_APP_DB : Data_O_Base
    {
        // read-write
        public int    applicationID { get; set; }
        public int    databaseID    { get; set; }
        public int?   dbLinkID      { get; set; }
        public string descTxt       { get; set; }

        // read-only
        public EDomain          appDomainID           { get; set; }
        public string           appDomainNm           { get; set; }
        public int              appServerID           { get; set; }
        public string           appServerNm           { get; set; }
        public EServerLevelType appServerLevelTypeID  { get; set; }
        public string           appServerLevelTypeTxt { get; set; }
        public string           applicationNm         { get; set; }
        public EApplicationType applicationTypeID     { get; set; }
        public string           applicationTypeTxt    { get; set; }
        public EDomain          dbDomainID            { get; set; }
        public string           dbDomainNm            { get; set; }
        public int              dbServerID            { get; set; }
        public string           dbServerNm            { get; set; }
        public EServerLevelType dbServerLevelTypeID   { get; set; }
        public string           dbServerLevelTypeTxt  { get; set; }
        public string           databaseNm            { get; set; }
        public EDatabaseType    databaseTypeID        { get; set; }
        public string           databaseTypeTxt       { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public D_SI_APP_DB() : base() { }
    }
}
