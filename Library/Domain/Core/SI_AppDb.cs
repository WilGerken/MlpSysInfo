using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysInfo.Library.Common;
using SysInfo.Library.Resources;
using SysInfo.Library.Resources.Core;
using Csla;

namespace SysInfo.Library.Domain
{
    /// --------------------------------------------------------------------------------------------------------------------
    /// Elements of the CS_InstanceType class family represent persistent objects identifying types of persistent store.  
    /// Known Instance Types are Oracle, SqlServer, MySql, and Palantir. 
    ///
    /// Modification History:
    /// 
    /// 12-Aug-2019 WG(CTG) Created
    /// 
    /// --------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Item Criteria
    /// </summary>
    [Serializable]
    public class SI_AppDb_ItemCriteria : ItemCriteria_Base<SI_AppDb_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<int?> ApplicationID_Property = RegisterProperty<int?>(c => c.ApplicationID);
        public int? ApplicationID
        {
            get { return ReadProperty(ApplicationID_Property); }
            set { LoadProperty(ApplicationID_Property, value); }
        }

        public static readonly PropertyInfo<int?> DatabaseID_Property = RegisterProperty<int?>(c => c.DatabaseID);
        public int? DatabaseID
        {
            get { return ReadProperty(DatabaseID_Property); }
            set { LoadProperty(DatabaseID_Property, value); }
        }

        public K_SI_APP_DB ToDto()
        {
            K_SI_APP_DB dto = new K_SI_APP_DB
            {
                applicationID = ApplicationID,
                databaseID    = DatabaseID
            };

            base.ToDto (dto);

            return dto;
        }

        #endregion
    }

    /// <summary>
    /// List Criteria
    /// </summary>
    [Serializable]
    public class SI_AppDb_ListCriteria : ListCriteria_Base<SI_AppDb_ListCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<EDomain?> AppDomainID_Property = RegisterProperty<EDomain?>(c => c.AppDomainID);
        public EDomain? AppDomainID
        {
            get { return ReadProperty(AppDomainID_Property); }
            set { LoadProperty(AppDomainID_Property, value); }
        }

        public static readonly PropertyInfo<int?> AppServerID_Property = RegisterProperty<int?>(c => c.AppServerID);
        public int? AppServerID
        {
            get { return ReadProperty(AppServerID_Property); }
            set { LoadProperty(AppServerID_Property, value); }
        }

        public static readonly PropertyInfo<EServerLevelType?> AppServerLevelTypeID_Property = RegisterProperty<EServerLevelType?>(c => c.AppServerLevelTypeID);
        public EServerLevelType? AppServerLevelTypeID
        {
            get { return ReadProperty(AppServerLevelTypeID_Property); }
            set { LoadProperty(AppServerLevelTypeID_Property, value); }
        }

        public static readonly PropertyInfo<int?> ApplicationID_Property = RegisterProperty<int?>(c => c.ApplicationID);
        public int? ApplicationID
        {
            get { return ReadProperty(ApplicationID_Property); }
            set { LoadProperty(ApplicationID_Property, value); }
        }

        public static readonly PropertyInfo<EApplicationType?> ApplicationTypeID_Property = RegisterProperty<EApplicationType?>(c => c.ApplicationTypeID);
        public EApplicationType? ApplicationTypeID
        {
            get { return ReadProperty(ApplicationTypeID_Property); }
            set { LoadProperty(ApplicationTypeID_Property, value); }
        }

        public static readonly PropertyInfo<EDomain?> DbDomainID_Property = RegisterProperty<EDomain?>(c => c.DbDomainID);
        public EDomain? DbDomainID
        {
            get { return ReadProperty(DbDomainID_Property); }
            set { LoadProperty(DbDomainID_Property, value); }
        }

        public static readonly PropertyInfo<int?> DbServerID_Property = RegisterProperty<int?>(c => c.DbServerID);
        public int? DbServerID
        {
            get { return ReadProperty(DbServerID_Property); }
            set { LoadProperty(DbServerID_Property, value); }
        }

        public static readonly PropertyInfo<EServerLevelType?> DbServerLevelTypeID_Property = RegisterProperty<EServerLevelType?>(c => c.DbServerLevelTypeID);
        public EServerLevelType? DbServerLevelTypeID
        {
            get { return ReadProperty(DbServerLevelTypeID_Property); }
            set { LoadProperty(DbServerLevelTypeID_Property, value); }
        }

        public static readonly PropertyInfo<int?> DatabaseID_Property = RegisterProperty<int?>(c => c.DatabaseID);
        public int? DatabaseID
        {
            get { return ReadProperty(DatabaseID_Property); }
            set { LoadProperty(DatabaseID_Property, value); }
        }

        public static readonly PropertyInfo<EDatabaseType?> DatabaseTypeID_Property = RegisterProperty<EDatabaseType?>(c => c.DatabaseTypeID);
        public EDatabaseType? DatabaseTypeID
        {
            get { return ReadProperty(DatabaseTypeID_Property); }
            set { LoadProperty(DatabaseTypeID_Property, value); }
        }

        public static readonly PropertyInfo<int?> DbLinkID_Property = RegisterProperty<int?>(c => c.DbLinkID);
        public int? DbLinkID
        {
            get { return ReadProperty(DbLinkID_Property); }
            set { LoadProperty(DbLinkID_Property, value); }
        }

        public F_SI_APP_DB ToDto ()
        {
            F_SI_APP_DB dto = new F_SI_APP_DB
            {
                appDomainID          = AppDomainID,
                appServerID          = AppServerID,
                appServerLevelTypeID = AppServerLevelTypeID,
                applicationID        = ApplicationID,
                applicationTypeID    = ApplicationTypeID,
                dbDomainID           = DbDomainID,
                dbServerID           = DbServerID,
                dbServerLevelTypeID  = DbServerLevelTypeID,
                databaseID           = DatabaseID,
                databaseTypeID       = DatabaseTypeID,
                dbLinkID             = DbLinkID
            };

            base.ToDto (dto);

            return dto;
        }

        #endregion
    }

    /// <summary>
    /// ReadOnly Item
    /// </summary>
    [Serializable]
    public class SI_AppDb_InfoItem : InfoItem_Base<SI_AppDb_InfoItem, SI_AppDb_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<EDomain> AppDomainID_Property = RegisterProperty<EDomain>(c => c.AppDomainID);
        public EDomain AppDomainID
        {
            get { return ReadProperty(AppDomainID_Property); }
            set { LoadProperty(AppDomainID_Property, value); }
        }

        public static readonly PropertyInfo<string> AppDomainNm_Property = RegisterProperty<string>(c => c.AppDomainNm);
        public string AppDomainNm
        {
            get { return ReadProperty(AppDomainNm_Property); }
            set { LoadProperty(AppDomainNm_Property, value); }
        }

        public static readonly PropertyInfo<int> AppServerID_Property = RegisterProperty<int>(c => c.AppServerID);
        public int AppServerID
        {
            get { return ReadProperty(AppServerID_Property); }
            set { LoadProperty(AppServerID_Property, value); }
        }

        public static readonly PropertyInfo<string> AppServerNm_Property = RegisterProperty<string>(c => c.AppServerNm);
        public string AppServerNm
        {
            get { return ReadProperty(AppServerNm_Property); }
            set { LoadProperty(AppServerNm_Property, value); }
        }

        public static readonly PropertyInfo<EServerLevelType> AppServerLevelTypeID_Property = RegisterProperty<EServerLevelType>(c => c.AppServerLevelTypeID);
        public EServerLevelType AppServerLevelTypeID
        {
            get { return ReadProperty(AppServerLevelTypeID_Property); }
            set { LoadProperty(AppServerLevelTypeID_Property, value); }
        }

        public static readonly PropertyInfo<string> AppServerLevelTypeTxt_Property = RegisterProperty<string>(c => c.AppServerLevelTypeTxt);
        public string AppServerLevelTypeTxt
        {
            get { return ReadProperty(AppServerLevelTypeTxt_Property); }
            set { LoadProperty(AppServerLevelTypeTxt_Property, value); }
        }

        public static readonly PropertyInfo<string> ApplicationNm_Property = RegisterProperty<string>(c => c.ApplicationNm);
        public string ApplicationNm
        {
            get { return ReadProperty(ApplicationNm_Property); }
            set { LoadProperty(ApplicationNm_Property, value); }
        }

        public static readonly PropertyInfo<EApplicationType> ApplicationTypeID_Property = RegisterProperty<EApplicationType>(c => c.ApplicationTypeID);
        public EApplicationType ApplicationTypeID
        {
            get { return ReadProperty(ApplicationTypeID_Property); }
            set { LoadProperty(ApplicationTypeID_Property, value); }
        }

        public static readonly PropertyInfo<string> ApplicationTypeTxt_Property = RegisterProperty<string>(c => c.ApplicationTypeTxt);
        public string ApplicationTypeTxt
        {
            get { return ReadProperty(ApplicationTypeTxt_Property); }
            set { LoadProperty(ApplicationTypeTxt_Property, value); }
        }

        public static readonly PropertyInfo<EDomain> DbDomainID_Property = RegisterProperty<EDomain>(c => c.DbDomainID);
        public EDomain DbDomainID
        {
            get { return ReadProperty(DbDomainID_Property); }
            set { LoadProperty(DbDomainID_Property, value); }
        }

        public static readonly PropertyInfo<string> DbDomainNm_Property = RegisterProperty<string>(c => c.DbDomainNm);
        public string DbDomainNm
        {
            get { return ReadProperty(DbDomainNm_Property); }
            set { LoadProperty(DbDomainNm_Property, value); }
        }

        public static readonly PropertyInfo<int> DbServerID_Property = RegisterProperty<int>(c => c.DbServerID);
        public int DbServerID
        {
            get { return ReadProperty(DbServerID_Property); }
            set { LoadProperty(DbServerID_Property, value); }
        }

        public static readonly PropertyInfo<string> DbServerNm_Property = RegisterProperty<string>(c => c.DbServerNm);
        public string DbServerNm
        {
            get { return ReadProperty(DbServerNm_Property); }
            set { LoadProperty(DbServerNm_Property, value); }
        }

        public static readonly PropertyInfo<EServerLevelType> DbServerLevelTypeID_Property = RegisterProperty<EServerLevelType>(c => c.DbServerLevelTypeID);
        public EServerLevelType DbServerLevelTypeID
        {
            get { return ReadProperty(DbServerLevelTypeID_Property); }
            set { LoadProperty(DbServerLevelTypeID_Property, value); }
        }

        public static readonly PropertyInfo<string> DbServerLevelTypeTxt_Property = RegisterProperty<string>(c => c.DbServerLevelTypeTxt);
        public string DbServerLevelTypeTxt
        {
            get { return ReadProperty(DbServerLevelTypeTxt_Property); }
            set { LoadProperty(DbServerLevelTypeTxt_Property, value); }
        }

        public static readonly PropertyInfo<string> DatabaseNm_Property = RegisterProperty<string>(c => c.DatabaseNm);
        public string DatabaseNm
        {
            get { return ReadProperty(DatabaseNm_Property); }
            set { LoadProperty(DatabaseNm_Property, value); }
        }

        public static readonly PropertyInfo<EApplicationType> DatabaseTypeID_Property = RegisterProperty<EApplicationType>(c => c.DatabaseTypeID);
        public EApplicationType DatabaseTypeID
        {
            get { return ReadProperty(DatabaseTypeID_Property); }
            set { LoadProperty(DatabaseTypeID_Property, value); }
        }

        public static readonly PropertyInfo<string> DatabaseTypeTxt_Property = RegisterProperty<string>(c => c.DatabaseTypeTxt);
        public string DatabaseTypeTxt
        {
            get { return ReadProperty(DatabaseTypeTxt_Property); }
            set { LoadProperty(DatabaseTypeTxt_Property, value); }
        }

        public static readonly PropertyInfo<string> DescTxt_Property = RegisterProperty<string>(c => c.DescTxt);
        public string DescTxt
        {
            get { return ReadProperty(DescTxt_Property); }
            set { LoadProperty(DescTxt_Property, value); }
        }

        public void FromDto (D_SI_APP_DB dto)
        {
            AppDomainID           = dto.appDomainID;
            AppDomainNm           = dto.appDomainNm;
            AppServerID           = dto.appServerID;
            AppServerNm           = dto.appServerNm;
            AppServerLevelTypeID  = dto.appServerLevelTypeID;
            AppServerLevelTypeTxt = dto.appServerLevelTypeTxt;
            ApplicationNm         = dto.applicationNm;
            ApplicationTypeID     = dto.applicationTypeID;
            ApplicationTypeTxt    = dto.applicationTypeTxt;
            DbDomainID            = dto.dbDomainID;
            DbDomainNm            = dto.dbDomainNm;
            DbServerID            = dto.dbServerID;
            DbServerNm            = dto.dbServerNm;
            DbServerLevelTypeID   = dto.dbServerLevelTypeID;
            DbServerLevelTypeTxt  = dto.dbServerLevelTypeTxt;
            ApplicationNm         = dto.applicationNm;
            ApplicationTypeID     = dto.applicationTypeID;
            ApplicationTypeTxt    = dto.applicationTypeTxt;
            DescTxt               = dto.descTxt;

            base.FromDto (dto);
        }

        #endregion

        #region DataPortal

        [FetchChild]
        private void Child_Fetch (D_SI_APP_DB dto) { FromDto (dto); }

        [Fetch]
        private void DataPortal_Fetch(SI_AppDb_ItemCriteria aKey)
        {
            using (var dalManager = DalFactory.GetManager (DalFactory.SI_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_SI_APP_DB>();
                var data = dal.SelectItem (aKey.ToDto());

                FromDto (data);
            }
        }

        #endregion
    }

    /// <summary>
    /// ReadOnly List
    /// </summary>
    [Serializable]
    public class SI_AppDb_InfoList : InfoList_Base<SI_AppDb_InfoList, SI_AppDb_ListCriteria, SI_AppDb_InfoItem, SI_AppDb_ItemCriteria>
    {
        #region DataPortal

        [Fetch]
        private void DataPortal_Fetch(SI_AppDb_ListCriteria aCriteria)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;

            // add select option if given
            if (aCriteria.SelectOption_Value.HasValue)
            {
                Insert(0, DataPortal.FetchChild<SI_AppDb_InfoItem>(new D_SI_APP_DB
                {
                    selectTxt = aCriteria.SelectOption_Text,
                    objectID = aCriteria.SelectOption_Value.Value
                }));
            }

            // add elements of list from persistent store
            using (var ctx = DalFactory.GetManager (DalFactory.SI_SCHEMA_NM))
            {
                var dal = ctx.GetProvider<I_SI_APP_DB>();
                var list = dal.SelectList(aCriteria.ToDto());

                foreach (var item in list)
                    Add (DataPortal.FetchChild<SI_AppDb_InfoItem>(item));
            }

            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        #endregion
    }

    [Serializable]
    public class SI_AppDb_EditItem : EditItem_Base<SI_AppDb_EditItem, SI_AppDb_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<int> ApplicationID_Property = RegisterProperty<int>(c => c.ApplicationID);
        [Required]
        public int ApplicationID
        {
            get { return GetProperty(ApplicationID_Property); }
            set { SetProperty(ApplicationID_Property, value); }
        }

        public static readonly PropertyInfo<string> ApplicationNm_Property = RegisterProperty<string>(c => c.ApplicationNm);
        public string ApplicationNm
        {
            get { return GetProperty(ApplicationNm_Property); }
            set { SetProperty(ApplicationNm_Property, value); }
        }

        public static readonly PropertyInfo<int> DatabaseID_Property = RegisterProperty<int>(c => c.DatabaseID);
        [Required]
        public int DatabaseID
        {
            get { return GetProperty(DatabaseID_Property); }
            set { SetProperty(DatabaseID_Property, value); }
        }

        public static readonly PropertyInfo<string> DatabaseNm_Property = RegisterProperty<string>(c => c.DatabaseNm);
        public string DatabaseNm
        {
            get { return GetProperty(DatabaseNm_Property); }
            set { SetProperty(DatabaseNm_Property, value); }
        }

        public static readonly PropertyInfo<int?> DbLinkID_Property = RegisterProperty<int?>(c => c.DbLinkID);
        public int? DbLinkID
        {
            get { return GetProperty(DbLinkID_Property); }
            set { SetProperty(DbLinkID_Property, value); }
        }

        public static readonly PropertyInfo<string> DescTxt_Property = RegisterProperty<string>(c => c.DescTxt);
        public string DescTxt
        {
            get { return GetProperty(DescTxt_Property); }
            set { SetProperty(DescTxt_Property, value); }
        }

        public void FromDto (D_SI_APP_DB dto)
        {
            ApplicationID = dto.applicationID;
            DatabaseID    = dto.databaseID;
            DbLinkID      = dto.dbLinkID;
            DescTxt       = dto.descTxt;

            ApplicationNm = dto.applicationNm;
            DatabaseNm    = dto.databaseNm;

            base.FromDto (dto);
        }

        public D_SI_APP_DB ToDto ()
        {
            D_SI_APP_DB dto = new D_SI_APP_DB
            {
                applicationID = ApplicationID,
                applicationNm = ApplicationNm,
                databaseID    = DatabaseID,
                databaseNm    = DatabaseNm,
                dbLinkID      = DbLinkID,
                descTxt       = DescTxt
            };

            base.ToDto (dto);

            return dto;
        }

        // readonly parent item (for access to detail)
        public static readonly PropertyInfo<SI_Application_InfoItem> ApplicationItem_Property = RegisterProperty<SI_Application_InfoItem>(c => c.ApplicationItem);
        public SI_Application_InfoItem ApplicationItem
        {
            get
            {
                return LazyGetProperty (ApplicationItem_Property,
                    () => DataPortal.Fetch<SI_Application_InfoItem>(new SI_Application_ItemCriteria { ObjectID = ReadProperty (ApplicationID_Property) }));
            }
            private set { LoadProperty (ApplicationItem_Property, value); }
        }

        // readonly parent item (for access to detail)
        public static readonly PropertyInfo<SI_Database_InfoItem> DatabaseItem_Property = RegisterProperty<SI_Database_InfoItem>(c => c.DatabaseItem);
        public SI_Database_InfoItem DatabaseItem
        {
            get
            {
                return LazyGetProperty(DatabaseItem_Property,
                    () => DataPortal.Fetch<SI_Database_InfoItem>(new SI_Database_ItemCriteria { ObjectID = ReadProperty(DatabaseID_Property) }));
            }
            private set { LoadProperty(DatabaseItem_Property, value); }
        }

        #endregion

        #region Methods

        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();
        }

        #endregion

        #region DataPortal

        [RunLocal]
        [Create]
        protected override void DataPortal_Create ()
        {
            base.DataPortal_Create ();
        }

        [Create]
        protected void DataPortal_Create (SI_AppDb_ItemCriteria aKey)
        {
            base.DataPortal_Create();

            if (aKey != null)
            {
                ApplicationID = aKey.ApplicationID.HasValue ? aKey.ApplicationID.Value : Ref.NewID;
                DatabaseID    = aKey.DatabaseID.HasValue    ? aKey.DatabaseID.Value    : Ref.NewID;
            }
        }

        [CreateChild]
        protected override void Child_Create()
        {
            base.Child_Create();
        }

        [Fetch]
        private void DataPortal_Fetch (SI_AppDb_ItemCriteria aKey)
        {
            using (var dalManager = DalFactory.GetManager (DalFactory.SI_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_SI_APP_DB>();
                var data = dal.SelectItem(aKey.ToDto());

                using (BypassPropertyChecks) { FromDto (data); }

                BusinessRules.CheckRules();
            }
        }

        [FetchChild]
        private void Child_Fetch(D_SI_APP_DB dto) { FromDto(dto); }

        [Insert]
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                var dal  = dalManager.GetProvider<I_SI_APP_DB>();
                var data = dal.InsertItem(ToDto());

                using (BypassPropertyChecks) { FromDto (data); }

                FieldManager.UpdateChildren(this);
            }
        }

        [InsertChild]
        private void Child_Insert()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                var dal  = dalManager.GetProvider<I_SI_APP_DB>();
                var data = dal.InsertItem(ToDto());

                using (BypassPropertyChecks) { FromDto (data); }

                FieldManager.UpdateChildren(this);
            }
        }

        [Update]
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                UpdateOnDts = DateTime.Now;
                UpdateByUid = AppInfo.UserUid;

                var dal  = dalManager.GetProvider<I_SI_APP_DB>();
                var data = dal.UpdateItem(ToDto());

                using (BypassPropertyChecks) { FromDto (data); }

                FieldManager.UpdateChildren(this);
            }
        }

        [UpdateChild]
        private void Child_Update()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                UpdateOnDts = DateTime.Now;
                UpdateByUid = AppInfo.UserUid;

                var dal = dalManager.GetProvider<I_SI_APP_DB>();
                var data = dal.UpdateItem(ToDto());

                using (BypassPropertyChecks) { FromDto (data); }

                FieldManager.UpdateChildren(this);
            }
        }

        [DeleteSelf]
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_SI_APP_DB>();

                dal.DeleteItem(new K_SI_APP_DB { objectID = this.ObjectID });
            }
        }

        [DeleteSelfChild]
        private void Child_DeleteSelf()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                FieldManager.UpdateChildren(this);

                var dal = dalManager.GetProvider<I_SI_APP_DB>();
                using (BypassPropertyChecks)
                {
                    dal.DeleteItem(new K_SI_APP_DB { objectID = this.ObjectID });
                }
            }
        }

        #endregion
    }

    /// <summary>
    /// Unit of Work Getter
    /// </summary>
    [Serializable]
    public class SI_AppDb_EditItem_Getter : EditItem_Getter_Base<SI_AppDb_EditItem, SI_AppDb_ItemCriteria>
    {
        #region DataPortal

        [Fetch]
        protected override void DataPortal_Fetch(SI_AppDb_ItemCriteria aCriteria)
        {
            if (aCriteria.HasKey)
                EditItem = SI_AppDb_EditItem.GetItem(aCriteria);
            else
                EditItem = SI_AppDb_EditItem.NewItem(aCriteria);
        }

        #endregion
    }

    /// <summary>
    /// Editable List
    /// </summary>
    [Serializable]
    public class SI_AppDb_EditList : EditList_Base<SI_AppDb_EditList, SI_AppDb_ListCriteria, SI_AppDb_EditItem, SI_AppDb_ItemCriteria>
    {
        #region DataPortal

        [Fetch]
        private void DataPortal_Fetch(SI_AppDb_ListCriteria aCriteria)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;

            using (var ctx = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                var dal = ctx.GetProvider<I_SI_APP_DB>();
                var list = dal.SelectList(aCriteria.ToDto());

                foreach (var item in list)
                    Add(DataPortal.FetchChild<SI_AppDb_EditItem>(item));
            }

            RaiseListChangedEvents = rlce;
        }

        [Update]
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                Child_Update();
            }
        }

        #endregion
    }
}
