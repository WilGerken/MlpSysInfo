using System;
using System.Collections.Generic;
using SysInfo.Library.Common;

namespace SysInfo.Library.Resources.Core
{
    /// <summary>
    /// public interface for instance items
    /// </summary>
    public interface I_SI_DATABASE_TYPE
    {
        List<D_SI_DATABASE_TYPE> SelectList (F_SI_DATABASE_TYPE aFilter);
        void                     DeleteList (F_SI_DATABASE_TYPE aFilter);

        D_SI_DATABASE_TYPE SelectItem (K_SI_DATABASE_TYPE aKey);
        D_SI_DATABASE_TYPE InsertItem (D_SI_DATABASE_TYPE aDto);
        D_SI_DATABASE_TYPE UpdateItem (D_SI_DATABASE_TYPE aDto);
        void               DeleteItem (K_SI_DATABASE_TYPE aKey);
    }

    /// <summary>
    /// filter object for instance lists
    /// </summary>
    public class F_SI_DATABASE_TYPE : Data_F_Base
    {
        public string typeCd { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public F_SI_DATABASE_TYPE() { }
    }

    /// <summary>
    /// key object for instance items
    /// </summary>
    public class K_SI_DATABASE_TYPE : Data_K_Base
    {
        public string typeCd { get; set; }
    }

    /// <summary>
    /// data object for instance items
    /// </summary>
    public class D_SI_DATABASE_TYPE : Data_O_Base
    {
        // read-write
        public string typeCd  { get; set; }
        public string typeTxt { get; set; }
        public string descTxt { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public D_SI_DATABASE_TYPE() : base() { }
    }
}