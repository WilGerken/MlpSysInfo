using System;
using System.Collections.Generic;
using SysInfo.Library.Common;

namespace SysInfo.Library.Resources.Core
{
    /// <summary>
    /// public interface for instance items
    /// </summary>
    public interface I_SI_DOMAIN
    {
        List<D_SI_DOMAIN> SelectList (F_SI_DOMAIN aFilter);
        void              DeleteList (F_SI_DOMAIN aFilter);

        D_SI_DOMAIN SelectItem (K_SI_DOMAIN aKey);
        D_SI_DOMAIN InsertItem (D_SI_DOMAIN aDto);
        D_SI_DOMAIN UpdateItem (D_SI_DOMAIN aDto);
        void        DeleteItem (K_SI_DOMAIN aKey);
    }

    /// <summary>
    /// filter object for instance lists
    /// </summary>
    public class F_SI_DOMAIN : Data_F_Base
    {
        public string   domainNm { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public F_SI_DOMAIN() { }
    }

    /// <summary>
    /// key object for instance items
    /// </summary>
    public class K_SI_DOMAIN : Data_K_Base
    {
        public string domainNm { get; set; }
    }

    /// <summary>
    /// data object for instance items
    /// </summary>
    public class D_SI_DOMAIN : Data_O_Base
    {
        // read-write
        public string    domainNm     { get; set; }
        public string    descTxt      { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public D_SI_DOMAIN() : base() { }
    }
}
