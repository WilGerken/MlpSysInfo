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
    public class SI_Database_ItemCriteria : ItemCriteria_Base<SI_Database_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<string> DatabaseNm_Property = RegisterProperty<string>(c => c.DatabaseNm);
        public string DatabaseNm
        {
            get { return ReadProperty(DatabaseNm_Property); }
            set { LoadProperty(DatabaseNm_Property, value); }
        }

        public K_SI_DATABASE ToDto()
        {
            K_SI_DATABASE dto = new K_SI_DATABASE
            {
                databaseNm = DatabaseNm
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
    public class SI_Database_ListCriteria : ListCriteria_Base<SI_Database_ListCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<EDomain?> DomainID_Property = RegisterProperty<EDomain?>(c => c.DomainID);
        public EDomain? DomainID
        {
            get { return ReadProperty(DomainID_Property); }
            set { LoadProperty(DomainID_Property, value); }
        }

        public static readonly PropertyInfo<int?> ServerID_Property = RegisterProperty<int?>(c => c.ServerID);
        public int? ServerID
        {
            get { return ReadProperty(ServerID_Property); }
            set { LoadProperty(ServerID_Property, value); }
        }

        public static readonly PropertyInfo<EServerLevelType?> ServerLevelTypeID_Property = RegisterProperty<EServerLevelType?>(c => c.ServerLevelTypeID);
        public EServerLevelType? ServerLevelTypeID
        {
            get { return ReadProperty(ServerLevelTypeID_Property); }
            set { LoadProperty(ServerLevelTypeID_Property, value); }
        }

        public static readonly PropertyInfo<string> DatabaseNm_Property = RegisterProperty<string>(c => c.DatabaseNm);
        public string DatabaseNm
        {
            get { return ReadProperty(DatabaseNm_Property); }
            set { LoadProperty(DatabaseNm_Property, value); }
        }

        public static readonly PropertyInfo<EDatabaseType?> DatabaseTypeID_Property = RegisterProperty<EDatabaseType?>(c => c.DatabaseTypeID);
        public EDatabaseType? DatabaseTypeID
        {
            get { return ReadProperty(DatabaseTypeID_Property); }
            set { LoadProperty(DatabaseTypeID_Property, value); }
        }

        public F_SI_DATABASE ToDto ()
        {
            F_SI_DATABASE dto = new F_SI_DATABASE
            {
                domainID          = DomainID,
                serverID          = ServerID,
                serverLevelTypeID = ServerLevelTypeID,
                databaseNm        = DatabaseNm,
                databaseTypeID    = DatabaseTypeID
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
    public class SI_Database_InfoItem : InfoItem_Base<SI_Database_InfoItem, SI_Database_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<EDomain> DomainID_Property = RegisterProperty<EDomain>(c => c.DomainID);
        public EDomain DomainID
        {
            get { return ReadProperty(DomainID_Property); }
            set { LoadProperty(DomainID_Property, value); }
        }

        public static readonly PropertyInfo<string> DomainNm_Property = RegisterProperty<string>(c => c.DomainNm);
        public string DomainNm
        {
            get { return ReadProperty(DomainNm_Property); }
            set { LoadProperty(DomainNm_Property, value); }
        }

        public static readonly PropertyInfo<int> ServerID_Property = RegisterProperty<int>(c => c.ServerID);
        public int ServerID
        {
            get { return ReadProperty(ServerID_Property); }
            set { LoadProperty(ServerID_Property, value); }
        }

        public static readonly PropertyInfo<string> ServerNm_Property = RegisterProperty<string>(c => c.ServerNm);
        public string ServerNm
        {
            get { return ReadProperty(ServerNm_Property); }
            set { LoadProperty(ServerNm_Property, value); }
        }

        public static readonly PropertyInfo<string> DatabaseNm_Property = RegisterProperty<string>(c => c.DatabaseNm);
        public string DatabaseNm
        {
            get { return ReadProperty(DatabaseNm_Property); }
            set { LoadProperty(DatabaseNm_Property, value); }
        }

        public static readonly PropertyInfo<EDatabaseType> DatabaseTypeID_Property = RegisterProperty<EDatabaseType>(c => c.DatabaseTypeID);
        public EDatabaseType DatabaseTypeID
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

        public void FromDto (D_SI_DATABASE dto)
        {
            DomainID        = dto.domainID;
            DomainNm        = dto.domainNm;
            ServerID        = dto.serverID;
            ServerNm        = dto.serverNm;
            DatabaseNm      = dto.databaseNm;
            DatabaseTypeID  = dto.databaseTypeID;
            DatabaseTypeTxt = dto.databaseTypeTxt;
            DescTxt         = dto.descTxt;

            base.FromDto (dto);
        }

        #endregion

        #region DataPortal

        [FetchChild]
        private void Child_Fetch (D_SI_DATABASE dto) { FromDto (dto); }

        [Fetch]
        private void DataPortal_Fetch(SI_Database_ItemCriteria aKey)
        {
            using (var dalManager = DalFactory.GetManager (DalFactory.SI_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_SI_DATABASE>();
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
    public class SI_Database_InfoList : InfoList_Base<SI_Database_InfoList, SI_Database_ListCriteria, SI_Database_InfoItem, SI_Database_ItemCriteria>
    {
        #region DataPortal

        [Fetch]
        private void DataPortal_Fetch(SI_Database_ListCriteria aCriteria)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;

            // add select option if given
            if (aCriteria.SelectOption_Value.HasValue)
            {
                Insert(0, DataPortal.FetchChild<SI_Database_InfoItem>(new D_SI_DATABASE
                {
                    selectTxt = aCriteria.SelectOption_Text,
                    objectID = aCriteria.SelectOption_Value.Value
                }));
            }

            // add elements of list from persistent store
            using (var ctx = DalFactory.GetManager (DalFactory.SI_SCHEMA_NM))
            {
                var dal = ctx.GetProvider<I_SI_DATABASE>();
                var list = dal.SelectList(aCriteria.ToDto());

                foreach (var item in list)
                    Add (DataPortal.FetchChild<SI_Database_InfoItem>(item));
            }

            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        #endregion
    }

    [Serializable]
    public class SI_Database_EditItem : EditItem_Base<SI_Database_EditItem, SI_Database_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<EDomain> DomainID_Property = RegisterProperty<EDomain>(c => c.DomainID);
        public EDomain DomainID
        {
            get { return GetProperty(DomainID_Property); }
            set { SetProperty(DomainID_Property, value); }
        }

        public static readonly PropertyInfo<string> DomainNm_Property = RegisterProperty<string>(c => c.DomainNm);
        public string DomainNm
        {
            get { return GetProperty(DomainNm_Property); }
            set { SetProperty(DomainNm_Property, value); }
        }

        public static readonly PropertyInfo<int> ServerID_Property = RegisterProperty<int>(c => c.ServerID);
        [Required]
        public int ServerID
        {
            get { return GetProperty(ServerID_Property); }
            set { SetProperty(ServerID_Property, value); }
        }

        public static readonly PropertyInfo<string> ServerNm_Property = RegisterProperty<string>(c => c.ServerNm);
        public string ServerNm
        {
            get { return GetProperty(ServerNm_Property); }
            set { SetProperty(ServerNm_Property, value); }
        }

        public static readonly PropertyInfo<string> DatabaseNm_Property = RegisterProperty<string>(c => c.DatabaseNm);
        [Required]
        public string DatabaseNm
        {
            get { return GetProperty(DatabaseNm_Property); }
            set { SetProperty(DatabaseNm_Property, value); }
        }

        public static readonly PropertyInfo<EDatabaseType> DatabaseTypeID_Property = RegisterProperty<EDatabaseType>(c => c.DatabaseTypeID);
        [Required]
        public EDatabaseType DatabaseTypeID
        {
            get { return GetProperty(DatabaseTypeID_Property); }
            set { SetProperty(DatabaseTypeID_Property, value); }
        }

        public static readonly PropertyInfo<string> DatabaseTypeTxt_Property = RegisterProperty<string>(c => c.DatabaseTypeTxt);
        public string DatabaseTypeTxt
        {
            get { return GetProperty(DatabaseTypeTxt_Property); }
            set { SetProperty(DatabaseTypeTxt_Property, value); }
        }

        public static readonly PropertyInfo<string> DescTxt_Property = RegisterProperty<string>(c => c.DescTxt);
        public string DescTxt
        {
            get { return GetProperty(DescTxt_Property); }
            set { SetProperty(DescTxt_Property, value); }
        }

        public void FromDto (D_SI_DATABASE dto)
        {
            ServerID        = dto.serverID;
            ServerNm        = dto.serverNm;
            ServerID        = dto.serverID;
            ServerNm        = dto.serverNm;
            DatabaseNm      = dto.databaseNm;
            DatabaseTypeID  = dto.databaseTypeID;
            DatabaseTypeTxt = dto.databaseTypeTxt;
            DescTxt         = dto.descTxt;

            base.FromDto (dto);
        }

        public D_SI_DATABASE ToDto ()
        {
            D_SI_DATABASE dto = new D_SI_DATABASE
            {
                domainID        = DomainID,
                domainNm        = DomainNm,
                serverID        = ServerID,
                serverNm        = ServerNm,
                databaseNm      = DatabaseNm,
                databaseTypeID  = DatabaseTypeID,
                databaseTypeTxt = DatabaseTypeTxt,
                descTxt         = DescTxt
            };

            base.ToDto (dto);

            return dto;
        }

        // readonly parent item (for access to detail)
        public static readonly PropertyInfo<SI_Server_InfoItem> ServerItem_Property = RegisterProperty<SI_Server_InfoItem>(c => c.ServerItem);
        public SI_Server_InfoItem ServerItem
        {
            get
            {
                return LazyGetProperty (ServerItem_Property,
                    () => DataPortal.Fetch<SI_Server_InfoItem>(new SI_Server_ItemCriteria { ObjectID = ReadProperty (ServerID_Property) }));
            }
            private set { LoadProperty (ServerItem_Property, value); }
        }

        // editable child list - SI_AppDb
        public static readonly PropertyInfo<SI_AppDb_EditList> AppDbList_Property =
            RegisterProperty<SI_AppDb_EditList>(p => p.AppDbList, RelationshipTypes.LazyLoad);
        public SI_AppDb_EditList AppDbList
        {
            get
            {
                return LazyGetProperty(AppDbList_Property,
                    () => DataPortal.Fetch<SI_AppDb_EditList>(new SI_AppDb_ListCriteria { DatabaseID = ReadProperty(ObjectID_Property) }));
            }
            private set { LoadProperty(AppDbList_Property, value); }
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
        protected void DataPortal_Create (SI_Database_ItemCriteria aKey)
        {
            base.DataPortal_Create();

            if (aKey != null)
            {
                DatabaseNm = aKey.DatabaseNm;
            }
        }

        [CreateChild]
        protected override void Child_Create()
        {
            base.Child_Create();
        }

        [Fetch]
        private void DataPortal_Fetch (SI_Database_ItemCriteria aKey)
        {
            using (var dalManager = DalFactory.GetManager (DalFactory.SI_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_SI_DATABASE>();
                var data = dal.SelectItem(aKey.ToDto());

                using (BypassPropertyChecks) { FromDto (data); }

                BusinessRules.CheckRules();
            }
        }

        [FetchChild]
        private void Child_Fetch(D_SI_DATABASE dto) { FromDto(dto); }

        [Insert]
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                var dal  = dalManager.GetProvider<I_SI_DATABASE>();
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
                var dal  = dalManager.GetProvider<I_SI_DATABASE>();
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

                var dal  = dalManager.GetProvider<I_SI_DATABASE>();
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

                var dal = dalManager.GetProvider<I_SI_DATABASE>();
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
                var dal = dalManager.GetProvider<I_SI_DATABASE>();

                dal.DeleteItem(new K_SI_DATABASE { objectID = this.ObjectID });
            }
        }

        [DeleteSelfChild]
        private void Child_DeleteSelf()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                FieldManager.UpdateChildren(this);

                var dal = dalManager.GetProvider<I_SI_DATABASE>();
                using (BypassPropertyChecks)
                {
                    dal.DeleteItem(new K_SI_DATABASE { objectID = this.ObjectID });
                }
            }
        }

        #endregion
    }

    /// <summary>
    /// Unit of Work Getter
    /// </summary>
    [Serializable]
    public class SI_Database_EditItem_Getter : EditItem_Getter_Base<SI_Database_EditItem, SI_Database_ItemCriteria>
    {
        #region DataPortal

        [Fetch]
        protected override void DataPortal_Fetch(SI_Database_ItemCriteria aCriteria)
        {
            if (aCriteria.HasKey)
                EditItem = SI_Database_EditItem.GetItem(aCriteria);
            else
                EditItem = SI_Database_EditItem.NewItem(aCriteria);
        }

        #endregion
    }

    /// <summary>
    /// Editable List
    /// </summary>
    [Serializable]
    public class SI_Database_EditList : EditList_Base<SI_Database_EditList, SI_Database_ListCriteria, SI_Database_EditItem, SI_Database_ItemCriteria>
    {
        #region DataPortal

        [Fetch]
        private void DataPortal_Fetch(SI_Database_ListCriteria aCriteria)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;

            using (var ctx = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                var dal = ctx.GetProvider<I_SI_DATABASE>();
                var list = dal.SelectList(aCriteria.ToDto());

                foreach (var item in list)
                    Add(DataPortal.FetchChild<SI_Database_EditItem>(item));
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
