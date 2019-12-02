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
    public class SI_Server_ItemCriteria : ItemCriteria_Base<SI_Server_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<string> ServerNm_Property = RegisterProperty<string>(c => c.ServerNm);
        public string ServerNm
        {
            get { return ReadProperty(ServerNm_Property); }
            set { LoadProperty(ServerNm_Property, value); }
        }

        public K_SI_SERVER ToDto()
        {
            K_SI_SERVER dto = new K_SI_SERVER
            {
                serverNm = ServerNm
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
    public class SI_Server_ListCriteria : ListCriteria_Base<SI_Server_ListCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<EDomain?> DomainID_Property = RegisterProperty<EDomain?>(c => c.DomainID);
        public EDomain? DomainID
        {
            get { return ReadProperty(DomainID_Property); }
            set { LoadProperty(DomainID_Property, value); }
        }

        public static readonly PropertyInfo<string> ServerNm_Property = RegisterProperty<string>(c => c.ServerNm);
        public string ServerNm
        {
            get { return ReadProperty(ServerNm_Property); }
            set { LoadProperty(ServerNm_Property, value); }
        }

        public F_SI_SERVER ToDto()
        {
            F_SI_SERVER dto = new F_SI_SERVER
            {
                domainID = DomainID,
                serverNm = ServerNm
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
    public class SI_Server_InfoItem : InfoItem_Base<SI_Server_InfoItem, SI_Server_ItemCriteria>
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

        public static readonly PropertyInfo<string> ServerNm_Property = RegisterProperty<string>(c => c.ServerNm);
        public string ServerNm
        {
            get { return ReadProperty(ServerNm_Property); }
            set { LoadProperty(ServerNm_Property, value); }
        }

        public static readonly PropertyInfo<string> VersionTxt_Property = RegisterProperty<string>(c => c.VersionTxt);
        public string VersionTxt
        {
            get { return ReadProperty(VersionTxt_Property); }
            set { LoadProperty(VersionTxt_Property, value); }
        }

        public static readonly PropertyInfo<string> DescTxt_Property = RegisterProperty<string>(c => c.DescTxt);
        public string DescTxt
        {
            get { return ReadProperty(DescTxt_Property); }
            set { LoadProperty(DescTxt_Property, value); }
        }

        public void FromDto (D_SI_SERVER dto)
        {
            DomainID   = dto.domainID;
            DomainNm   = dto.domainNm;
            ServerNm   = dto.serverNm;
            VersionTxt = dto.versionTxt;
            DescTxt    = dto.descTxt;

            base.FromDto (dto);
        }

        #endregion

        #region DataPortal

        [FetchChild]
        private void Child_Fetch (D_SI_SERVER dto) { FromDto (dto); }

        [Fetch]
        private void DataPortal_Fetch(SI_Server_ItemCriteria aKey)
        {
            using (var dalManager = DalFactory.GetManager (DalFactory.SI_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_SI_SERVER>();
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
    public class SI_Server_InfoList : InfoList_Base<SI_Server_InfoList, SI_Server_ListCriteria, SI_Server_InfoItem, SI_Server_ItemCriteria>
    {
        #region DataPortal

        [Fetch]
        private void DataPortal_Fetch(SI_Server_ListCriteria aCriteria)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;

            // add select option if given
            if (aCriteria.SelectOption_Value.HasValue)
            {
                Insert(0, DataPortal.FetchChild<SI_Server_InfoItem>(new D_SI_SERVER
                {
                    selectTxt = aCriteria.SelectOption_Text,
                    objectID = aCriteria.SelectOption_Value.Value
                }));
            }

            // add elements of list from persistent store
            using (var ctx = DalFactory.GetManager (DalFactory.SI_SCHEMA_NM))
            {
                var dal = ctx.GetProvider<I_SI_SERVER>();
                var list = dal.SelectList(aCriteria.ToDto());

                foreach (var item in list)
                    Add (DataPortal.FetchChild<SI_Server_InfoItem>(item));
            }

            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        #endregion
    }

    [Serializable]
    public class SI_Server_EditItem : EditItem_Base<SI_Server_EditItem, SI_Server_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<string> ServerNm_Property = RegisterProperty<string>(c => c.ServerNm);
        [Required]
        public string ServerNm
        {
            get { return GetProperty(ServerNm_Property); }
            set { SetProperty(ServerNm_Property, value); }
        }

        public static readonly PropertyInfo<EDomain> DomainID_Property = RegisterProperty<EDomain>(c => c.DomainID);
        [Required]
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

        public static readonly PropertyInfo<EServerLevelType> LevelTypeID_Property = RegisterProperty<EServerLevelType>(c => c.LevelTypeID);
        [Required]
        public EServerLevelType LevelTypeID
        {
            get { return GetProperty(LevelTypeID_Property); }
            set { SetProperty(LevelTypeID_Property, value); }
        }

        public static readonly PropertyInfo<string> LevelTypeTxt_Property = RegisterProperty<string>(c => c.LevelTypeTxt);
        public string LevelTypeTxt
        {
            get { return GetProperty(LevelTypeTxt_Property); }
            set { SetProperty(LevelTypeTxt_Property, value); }
        }

        public static readonly PropertyInfo<string> VersionTxt_Property = RegisterProperty<string>(c => c.VersionTxt);
        [Required]
        public string VersionTxt
        {
            get { return GetProperty(VersionTxt_Property); }
            set { SetProperty(VersionTxt_Property, value); }
        }

        public static readonly PropertyInfo<string> DescTxt_Property = RegisterProperty<string>(c => c.DescTxt);
        public string DescTxt
        {
            get { return GetProperty(DescTxt_Property); }
            set { SetProperty(DescTxt_Property, value); }
        }

        public void FromDto (D_SI_SERVER dto)
        {
            ServerNm    = dto.serverNm;
            DomainID    = dto.domainID;
            LevelTypeID = dto.levelTypeID;
            VersionTxt  = dto.versionTxt;
            DescTxt     = dto.descTxt;

            DomainNm     = dto.domainNm;
            LevelTypeTxt = dto.levelTypeTxt;

            base.FromDto(dto);
        }

        public D_SI_SERVER ToDto ()
        {
            D_SI_SERVER dto = new D_SI_SERVER
            {
                serverNm     = ServerNm,
                domainID     = DomainID,
                domainNm     = DomainNm,
                levelTypeID  = LevelTypeID,
                levelTypeTxt = LevelTypeTxt,
                versionTxt   = VersionTxt,
                descTxt      = DescTxt
            };

            base.ToDto(dto);

            return dto;
        }

        // readonly parent item (for access to detail)
        public static readonly PropertyInfo<SI_Domain_InfoItem> DomainItem_Property = RegisterProperty<SI_Domain_InfoItem>(c => c.DomainItem);
        public SI_Domain_InfoItem DomainItem
        {
            get
            {
                return LazyGetProperty (DomainItem_Property,
                    () => DataPortal.Fetch<SI_Domain_InfoItem>(new SI_Domain_ItemCriteria { ObjectID = (int) ReadProperty(DomainID_Property) }));
            }
            private set { LoadProperty(DomainItem_Property, value); }
        }

        // editable child list - SI_Application
        public static readonly PropertyInfo<SI_Application_EditList> ApplicationList_Property =
            RegisterProperty<SI_Application_EditList>(p => p.ApplicationList, RelationshipTypes.LazyLoad);
        public SI_Application_EditList ApplicationList
        {
            get
            {
                return LazyGetProperty(ApplicationList_Property,
                    () => DataPortal.Fetch<SI_Application_EditList>(new SI_Application_ListCriteria { ServerID = ReadProperty(ObjectID_Property) }));
            }
            private set { LoadProperty(ApplicationList_Property, value); }
        }

        // editable child list - SI_Database
        public static readonly PropertyInfo<SI_Database_EditList> DatabaseList_Property =
            RegisterProperty<SI_Database_EditList>(p => p.DatabaseList, RelationshipTypes.LazyLoad);
        public SI_Database_EditList DatabaseList
        {
            get
            {
                return LazyGetProperty(DatabaseList_Property,
                    () => DataPortal.Fetch<SI_Database_EditList>(new SI_Database_ListCriteria { ServerID = ReadProperty(ObjectID_Property) }));
            }
            private set { LoadProperty(DatabaseList_Property, value); }
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
        protected override void DataPortal_Create()
        {
            base.DataPortal_Create();
        }

        [Create]
        protected void DataPortal_Create(SI_Server_ItemCriteria aKey)
        {
            base.DataPortal_Create();

            if (aKey != null)
            {
                ServerNm = aKey.ServerNm;
            }
        }

        [CreateChild]
        protected override void Child_Create()
        {
            base.Child_Create();
        }

        [Fetch]
        private void DataPortal_Fetch(SI_Server_ItemCriteria aKey)
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_SI_SERVER>();
                var data = dal.SelectItem(aKey.ToDto());

                using (BypassPropertyChecks) { FromDto (data); }

                BusinessRules.CheckRules();
            }
        }

        [FetchChild]
        private void Child_Fetch(D_SI_SERVER dto) { FromDto(dto); }

        [Insert]
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                var dal  = dalManager.GetProvider<I_SI_SERVER>();
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
                var dal  = dalManager.GetProvider<I_SI_SERVER>();
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

                var dal  = dalManager.GetProvider<I_SI_SERVER>();
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

                var dal = dalManager.GetProvider<I_SI_SERVER>();
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
                var dal = dalManager.GetProvider<I_SI_SERVER>();

                dal.DeleteItem(new K_SI_SERVER { objectID = this.ObjectID });
            }
        }

        [DeleteSelfChild]
        private void Child_DeleteSelf()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                FieldManager.UpdateChildren(this);

                var dal = dalManager.GetProvider<I_SI_SERVER>();
                using (BypassPropertyChecks)
                {
                    dal.DeleteItem(new K_SI_SERVER { objectID = this.ObjectID });
                }
            }
        }

        #endregion
    }

    /// <summary>
    /// Unit of Work Getter
    /// </summary>
    [Serializable]
    public class SI_Server_EditItem_Getter : EditItem_Getter_Base<SI_Server_EditItem, SI_Server_ItemCriteria>
    {
        #region DataPortal

        [Fetch]
        protected override void DataPortal_Fetch(SI_Server_ItemCriteria aCriteria)
        {
            if (aCriteria.HasKey)
                EditItem = SI_Server_EditItem.GetItem(aCriteria);
            else
                EditItem = SI_Server_EditItem.NewItem(aCriteria);
        }

        #endregion
    }

    /// <summary>
    /// Editable List
    /// </summary>
    [Serializable]
    public class SI_Server_EditList : EditList_Base<SI_Server_EditList, SI_Server_ListCriteria, SI_Server_EditItem, SI_Server_ItemCriteria>
    {
        #region DataPortal

        [Fetch]
        private void DataPortal_Fetch(SI_Server_ListCriteria aCriteria)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;

            using (var ctx = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                var dal = ctx.GetProvider<I_SI_SERVER>();
                var list = dal.SelectList(aCriteria.ToDto());

                foreach (var item in list)
                    Add(DataPortal.FetchChild<SI_Server_EditItem>(item));
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
