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
    public class SI_DbLink_ItemCriteria : ItemCriteria_Base<SI_DbLink_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<int?> SourceDatabaseID_Property = RegisterProperty<int?>(c => c.SourceDatabaseID);
        public int? SourceDatabaseID
        {
            get { return ReadProperty(SourceDatabaseID_Property); }
            set { LoadProperty(SourceDatabaseID_Property, value); }
        }

        public static readonly PropertyInfo<int?> TargetDatabaseID_Property = RegisterProperty<int?>(c => c.TargetDatabaseID);
        public int? TargetDatabaseID
        {
            get { return ReadProperty(TargetDatabaseID_Property); }
            set { LoadProperty(TargetDatabaseID_Property, value); }
        }

        public K_SI_DB_LINK ToDto()
        {
            K_SI_DB_LINK dto = new K_SI_DB_LINK
            {
                sourceDatabaseID = SourceDatabaseID,
                targetDatabaseID = TargetDatabaseID
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
    public class SI_DbLink_ListCriteria : ListCriteria_Base<SI_DbLink_ListCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<EDomain?> SourceDomainID_Property = RegisterProperty<EDomain?>(c => c.SourceDomainID);
        public EDomain? SourceDomainID
        {
            get { return ReadProperty(SourceDomainID_Property); }
            set { LoadProperty(SourceDomainID_Property, value); }
        }

        public static readonly PropertyInfo<int?> SourceServerID_Property = RegisterProperty<int?>(c => c.SourceServerID);
        public int? SourceServerID
        {
            get { return ReadProperty(SourceServerID_Property); }
            set { LoadProperty(SourceServerID_Property, value); }
        }

        public static readonly PropertyInfo<EServerLevelType?> SourceServerLevelTypeID_Property = RegisterProperty<EServerLevelType?>(c => c.SourceServerLevelTypeID);
        public EServerLevelType? SourceServerLevelTypeID
        {
            get { return ReadProperty(SourceServerLevelTypeID_Property); }
            set { LoadProperty(SourceServerLevelTypeID_Property, value); }
        }

        public static readonly PropertyInfo<int?> SourceDatabaseID_Property = RegisterProperty<int?>(c => c.SourceDatabaseID);
        public int? SourceDatabaseID
        {
            get { return ReadProperty(SourceDatabaseID_Property); }
            set { LoadProperty(SourceDatabaseID_Property, value); }
        }

        public static readonly PropertyInfo<EDatabaseType?> SourceDatabaseTypeID_Property = RegisterProperty<EDatabaseType?>(c => c.SourceDatabaseTypeID);
        public EDatabaseType? SourceDatabaseTypeID
        {
            get { return ReadProperty(SourceDatabaseTypeID_Property); }
            set { LoadProperty(SourceDatabaseTypeID_Property, value); }
        }

        public static readonly PropertyInfo<EDomain?> TargetDomainID_Property = RegisterProperty<EDomain?>(c => c.TargetDomainID);
        public EDomain? TargetDomainID
        {
            get { return ReadProperty(TargetDomainID_Property); }
            set { LoadProperty(TargetDomainID_Property, value); }
        }

        public static readonly PropertyInfo<int?> TargetServerID_Property = RegisterProperty<int?>(c => c.TargetServerID);
        public int? TargetServerID
        {
            get { return ReadProperty(TargetServerID_Property); }
            set { LoadProperty(TargetServerID_Property, value); }
        }

        public static readonly PropertyInfo<EServerLevelType?> TargetServerLevelTypeID_Property = RegisterProperty<EServerLevelType?>(c => c.TargetServerLevelTypeID);
        public EServerLevelType? TargetServerLevelTypeID
        {
            get { return ReadProperty(TargetServerLevelTypeID_Property); }
            set { LoadProperty(TargetServerLevelTypeID_Property, value); }
        }

        public static readonly PropertyInfo<int?> TargetDatabaseID_Property = RegisterProperty<int?>(c => c.TargetDatabaseID);
        public int? TargetDatabaseID
        {
            get { return ReadProperty(TargetDatabaseID_Property); }
            set { LoadProperty(TargetDatabaseID_Property, value); }
        }

        public static readonly PropertyInfo<EDatabaseType?> TargetDatabaseTypeID_Property = RegisterProperty<EDatabaseType?>(c => c.TargetDatabaseTypeID);
        public EDatabaseType? TargetDatabaseTypeID
        {
            get { return ReadProperty(TargetDatabaseTypeID_Property); }
            set { LoadProperty(TargetDatabaseTypeID_Property, value); }
        }

        public F_SI_DB_LINK ToDto ()
        {
            F_SI_DB_LINK dto = new F_SI_DB_LINK
            {
                sourceDomainID          = SourceDomainID,
                sourceServerID          = SourceServerID,
                sourceServerLevelTypeID = SourceServerLevelTypeID,
                sourceDatabaseID        = SourceDatabaseID,
                sourceDatabaseTypeID    = SourceDatabaseTypeID,
                targetDomainID          = TargetDomainID,
                targetServerID          = TargetServerID,
                targetServerLevelTypeID = TargetServerLevelTypeID,
                targetDatabaseID        = TargetDatabaseID,
                targetDatabaseTypeID    = TargetDatabaseTypeID
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
    public class SI_DbLink_InfoItem : InfoItem_Base<SI_DbLink_InfoItem, SI_DbLink_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<EDomain> SourceDomainID_Property = RegisterProperty<EDomain>(c => c.SourceDomainID);
        public EDomain SourceDomainID
        {
            get { return ReadProperty(SourceDomainID_Property); }
            set { LoadProperty(SourceDomainID_Property, value); }
        }

        public static readonly PropertyInfo<string> SourceDomainNm_Property = RegisterProperty<string>(c => c.SourceDomainNm);
        public string SourceDomainNm
        {
            get { return ReadProperty(SourceDomainNm_Property); }
            set { LoadProperty(SourceDomainNm_Property, value); }
        }

        public static readonly PropertyInfo<int> SourceServerID_Property = RegisterProperty<int>(c => c.SourceServerID);
        public int SourceServerID
        {
            get { return ReadProperty(SourceServerID_Property); }
            set { LoadProperty(SourceServerID_Property, value); }
        }

        public static readonly PropertyInfo<string> SourceServerNm_Property = RegisterProperty<string>(c => c.SourceServerNm);
        public string SourceServerNm
        {
            get { return ReadProperty(SourceServerNm_Property); }
            set { LoadProperty(SourceServerNm_Property, value); }
        }

        public static readonly PropertyInfo<EServerLevelType> SourceServerLevelTypeID_Property = RegisterProperty<EServerLevelType>(c => c.SourceServerLevelTypeID);
        public EServerLevelType SourceServerLevelTypeID
        {
            get { return ReadProperty(SourceServerLevelTypeID_Property); }
            set { LoadProperty(SourceServerLevelTypeID_Property, value); }
        }

        public static readonly PropertyInfo<string> SourceServerLevelTypeTxt_Property = RegisterProperty<string>(c => c.SourceServerLevelTypeTxt);
        public string SourceServerLevelTypeTxt
        {
            get { return ReadProperty(SourceServerLevelTypeTxt_Property); }
            set { LoadProperty(SourceServerLevelTypeTxt_Property, value); }
        }

        public static readonly PropertyInfo<int> SourceDatabaseID_Property = RegisterProperty<int>(c => c.SourceDatabaseID);
        public int SourceDatabaseID
        {
            get { return ReadProperty(SourceDatabaseID_Property); }
            set { LoadProperty(SourceDatabaseID_Property, value); }
        }

        public static readonly PropertyInfo<string> SourceDatabaseNm_Property = RegisterProperty<string>(c => c.SourceDatabaseNm);
        public string SourceDatabaseNm
        {
            get { return ReadProperty(SourceDatabaseNm_Property); }
            set { LoadProperty(SourceDatabaseNm_Property, value); }
        }

        public static readonly PropertyInfo<EDatabaseType> SourceDatabaseTypeID_Property = RegisterProperty<EDatabaseType>(c => c.SourceDatabaseTypeID);
        public EDatabaseType SourceDatabaseTypeID
        {
            get { return ReadProperty(SourceDatabaseTypeID_Property); }
            set { LoadProperty(SourceDatabaseTypeID_Property, value); }
        }

        public static readonly PropertyInfo<string> SourceDatabaseTypeTxt_Property = RegisterProperty<string>(c => c.SourceDatabaseTypeTxt);
        public string SourceDatabaseTypeTxt
        {
            get { return ReadProperty(SourceDatabaseTypeTxt_Property); }
            set { LoadProperty(SourceDatabaseTypeTxt_Property, value); }
        }

        public static readonly PropertyInfo<EDomain> TargetDomainID_Property = RegisterProperty<EDomain>(c => c.TargetDomainID);
        public EDomain TargetDomainID
        {
            get { return ReadProperty(TargetDomainID_Property); }
            set { LoadProperty(TargetDomainID_Property, value); }
        }

        public static readonly PropertyInfo<string> TargetDomainNm_Property = RegisterProperty<string>(c => c.TargetDomainNm);
        public string TargetDomainNm
        {
            get { return ReadProperty(TargetDomainNm_Property); }
            set { LoadProperty(TargetDomainNm_Property, value); }
        }

        public static readonly PropertyInfo<int> TargetServerID_Property = RegisterProperty<int>(c => c.TargetServerID);
        public int TargetServerID
        {
            get { return ReadProperty(TargetServerID_Property); }
            set { LoadProperty(TargetServerID_Property, value); }
        }

        public static readonly PropertyInfo<string> TargetServerNm_Property = RegisterProperty<string>(c => c.TargetServerNm);
        public string TargetServerNm
        {
            get { return ReadProperty(TargetServerNm_Property); }
            set { LoadProperty(TargetServerNm_Property, value); }
        }

        public static readonly PropertyInfo<EServerLevelType> TargetServerLevelTypeID_Property = RegisterProperty<EServerLevelType>(c => c.TargetServerLevelTypeID);
        public EServerLevelType TargetServerLevelTypeID
        {
            get { return ReadProperty(TargetServerLevelTypeID_Property); }
            set { LoadProperty(TargetServerLevelTypeID_Property, value); }
        }

        public static readonly PropertyInfo<string> TargetServerLevelTypeTxt_Property = RegisterProperty<string>(c => c.TargetServerLevelTypeTxt);
        public string TargetServerLevelTypeTxt
        {
            get { return ReadProperty(TargetServerLevelTypeTxt_Property); }
            set { LoadProperty(TargetServerLevelTypeTxt_Property, value); }
        }

        public static readonly PropertyInfo<int> TargetDatabaseID_Property = RegisterProperty<int>(c => c.TargetDatabaseID);
        public int TargetDatabaseID
        {
            get { return ReadProperty(TargetDatabaseID_Property); }
            set { LoadProperty(TargetDatabaseID_Property, value); }
        }

        public static readonly PropertyInfo<string> TargetDatabaseNm_Property = RegisterProperty<string>(c => c.TargetDatabaseNm);
        public string TargetDatabaseNm
        {
            get { return ReadProperty(TargetDatabaseNm_Property); }
            set { LoadProperty(TargetDatabaseNm_Property, value); }
        }

        public static readonly PropertyInfo<EDatabaseType> TargetDatabaseTypeID_Property = RegisterProperty<EDatabaseType>(c => c.TargetDatabaseTypeID);
        public EDatabaseType TargetDatabaseTypeID
        {
            get { return ReadProperty(TargetDatabaseTypeID_Property); }
            set { LoadProperty(TargetDatabaseTypeID_Property, value); }
        }

        public static readonly PropertyInfo<string> TargetDatabaseTypeTxt_Property = RegisterProperty<string>(c => c.TargetDatabaseTypeTxt);
        public string TargetDatabaseTypeTxt
        {
            get { return ReadProperty(TargetDatabaseTypeTxt_Property); }
            set { LoadProperty(TargetDatabaseTypeTxt_Property, value); }
        }

        public static readonly PropertyInfo<string> DescTxt_Property = RegisterProperty<string>(c => c.DescTxt);
        public string DescTxt
        {
            get { return ReadProperty(DescTxt_Property); }
            set { LoadProperty(DescTxt_Property, value); }
        }

        public void FromDto (D_SI_DB_LINK dto)
        {
            SourceDomainID           = dto.sourceDomainID;
            SourceDomainNm           = dto.sourceDomainNm;
            SourceServerID           = dto.sourceServerID;
            SourceServerNm           = dto.sourceServerNm;
            SourceServerLevelTypeID  = dto.sourceServerLevelTypeID;
            SourceServerLevelTypeTxt = dto.sourceServerLevelTypeTxt;
            SourceDatabaseNm         = dto.sourceDatabaseNm;
            SourceDatabaseTypeID     = dto.sourceDatabaseTypeID;
            SourceDatabaseTypeTxt    = dto.sourceDatabaseTypeTxt;
            TargetDomainID           = dto.targetDomainID;
            TargetDomainNm           = dto.targetDomainNm;
            TargetServerID           = dto.targetServerID;
            TargetServerNm           = dto.targetServerNm;
            TargetServerLevelTypeID  = dto.targetServerLevelTypeID;
            TargetServerLevelTypeTxt = dto.targetServerLevelTypeTxt;
            TargetDatabaseNm         = dto.targetDatabaseNm;
            TargetDatabaseTypeID     = dto.targetDatabaseTypeID;
            TargetDatabaseTypeTxt    = dto.targetDatabaseTypeTxt;
            DescTxt                  = dto.descTxt;

            base.FromDto (dto);
        }

        #endregion

        #region DataPortal

        [FetchChild]
        private void Child_Fetch (D_SI_DB_LINK dto) { FromDto (dto); }

        [Fetch]
        private void DataPortal_Fetch(SI_DbLink_ItemCriteria aKey)
        {
            using (var dalManager = DalFactory.GetManager (DalFactory.SI_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_SI_DB_LINK>();
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
    public class SI_DbLink_InfoList : InfoList_Base<SI_DbLink_InfoList, SI_DbLink_ListCriteria, SI_DbLink_InfoItem, SI_DbLink_ItemCriteria>
    {
        #region DataPortal

        [Fetch]
        private void DataPortal_Fetch(SI_DbLink_ListCriteria aCriteria)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;

            // add select option if given
            if (aCriteria.SelectOption_Value.HasValue)
            {
                Insert(0, DataPortal.FetchChild<SI_DbLink_InfoItem>(new D_SI_DB_LINK
                {
                    selectTxt = aCriteria.SelectOption_Text,
                    objectID = aCriteria.SelectOption_Value.Value
                }));
            }

            // add elements of list from persistent store
            using (var ctx = DalFactory.GetManager (DalFactory.SI_SCHEMA_NM))
            {
                var dal = ctx.GetProvider<I_SI_DB_LINK>();
                var list = dal.SelectList(aCriteria.ToDto());

                foreach (var item in list)
                    Add (DataPortal.FetchChild<SI_DbLink_InfoItem>(item));
            }

            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        #endregion
    }

    [Serializable]
    public class SI_DbLink_EditItem : EditItem_Base<SI_DbLink_EditItem, SI_DbLink_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<int> SourceDatabaseID_Property = RegisterProperty<int>(c => c.SourceDatabaseID);
        [Required]
        public int SourceDatabaseID
        {
            get { return GetProperty(SourceDatabaseID_Property); }
            set { SetProperty(SourceDatabaseID_Property, value); }
        }

        public static readonly PropertyInfo<string> SourceDatabaseNm_Property = RegisterProperty<string>(c => c.SourceDatabaseNm);
        public string SourceDatabaseNm
        {
            get { return GetProperty(SourceDatabaseNm_Property); }
            set { SetProperty(SourceDatabaseNm_Property, value); }
        }

        public static readonly PropertyInfo<int> TargetDatabaseID_Property = RegisterProperty<int>(c => c.TargetDatabaseID);
        [Required]
        public int TargetDatabaseID
        {
            get { return GetProperty(TargetDatabaseID_Property); }
            set { SetProperty(TargetDatabaseID_Property, value); }
        }

        public static readonly PropertyInfo<string> TargetDatabaseNm_Property = RegisterProperty<string>(c => c.TargetDatabaseNm);
        public string TargetDatabaseNm
        {
            get { return GetProperty(TargetDatabaseNm_Property); }
            set { SetProperty(TargetDatabaseNm_Property, value); }
        }

        public static readonly PropertyInfo<string> DescTxt_Property = RegisterProperty<string>(c => c.DescTxt);
        public string DescTxt
        {
            get { return GetProperty(DescTxt_Property); }
            set { SetProperty(DescTxt_Property, value); }
        }

        public void FromDto (D_SI_DB_LINK dto)
        {
            SourceDatabaseID = dto.sourceDatabaseID;
            TargetDatabaseID = dto.targetDatabaseID;
            DescTxt          = dto.descTxt;

            SourceDatabaseNm = dto.sourceDatabaseNm;
            TargetDatabaseNm = dto.targetDatabaseNm;

            base.FromDto (dto);
        }

        public D_SI_DB_LINK ToDto ()
        {
            D_SI_DB_LINK dto = new D_SI_DB_LINK
            {
                sourceDatabaseID = SourceDatabaseID,
                sourceDatabaseNm = SourceDatabaseNm,
                targetDatabaseID = TargetDatabaseID,
                targetDatabaseNm = TargetDatabaseNm,
                descTxt          = DescTxt
            };

            base.ToDto (dto);

            return dto;
        }

        // readonly parent item (for access to detail)
        public static readonly PropertyInfo<SI_Database_InfoItem> SourceDatabaseItem_Property = RegisterProperty<SI_Database_InfoItem>(c => c.SourceDatabaseItem);
        public SI_Database_InfoItem SourceDatabaseItem
        {
            get
            {
                return LazyGetProperty (SourceDatabaseItem_Property,
                    () => DataPortal.Fetch<SI_Database_InfoItem>(new SI_Database_ItemCriteria { ObjectID = ReadProperty (SourceDatabaseID_Property) }));
            }
            private set { LoadProperty (SourceDatabaseItem_Property, value); }
        }

        // readonly parent item (for access to detail)
        public static readonly PropertyInfo<SI_Database_InfoItem> TargetDatabaseItem_Property = RegisterProperty<SI_Database_InfoItem>(c => c.TargetDatabaseItem);
        public SI_Database_InfoItem TargetDatabaseItem
        {
            get
            {
                return LazyGetProperty(TargetDatabaseItem_Property,
                    () => DataPortal.Fetch<SI_Database_InfoItem>(new SI_Database_ItemCriteria { ObjectID = ReadProperty(TargetDatabaseID_Property) }));
            }
            private set { LoadProperty(TargetDatabaseItem_Property, value); }
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
        protected void DataPortal_Create (SI_DbLink_ItemCriteria aKey)
        {
            base.DataPortal_Create();

            if (aKey != null)
            {
                SourceDatabaseID = aKey.SourceDatabaseID.HasValue ? aKey.SourceDatabaseID.Value : Ref.NewID;
                TargetDatabaseID = aKey.TargetDatabaseID.HasValue ? aKey.TargetDatabaseID.Value : Ref.NewID;
            }
        }

        [CreateChild]
        protected override void Child_Create()
        {
            base.Child_Create();
        }

        [Fetch]
        private void DataPortal_Fetch (SI_DbLink_ItemCriteria aKey)
        {
            using (var dalManager = DalFactory.GetManager (DalFactory.SI_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_SI_DB_LINK>();
                var data = dal.SelectItem(aKey.ToDto());

                using (BypassPropertyChecks) { FromDto (data); }

                BusinessRules.CheckRules();
            }
        }

        [FetchChild]
        private void Child_Fetch(D_SI_DB_LINK dto) { FromDto(dto); }

        [Insert]
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                var dal  = dalManager.GetProvider<I_SI_DB_LINK>();
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
                var dal  = dalManager.GetProvider<I_SI_DB_LINK>();
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

                var dal  = dalManager.GetProvider<I_SI_DB_LINK>();
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

                var dal = dalManager.GetProvider<I_SI_DB_LINK>();
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
                var dal = dalManager.GetProvider<I_SI_DB_LINK>();

                dal.DeleteItem(new K_SI_DB_LINK { objectID = this.ObjectID });
            }
        }

        [DeleteSelfChild]
        private void Child_DeleteSelf()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                FieldManager.UpdateChildren(this);

                var dal = dalManager.GetProvider<I_SI_DB_LINK>();
                using (BypassPropertyChecks)
                {
                    dal.DeleteItem(new K_SI_DB_LINK { objectID = this.ObjectID });
                }
            }
        }

        #endregion
    }

    /// <summary>
    /// Unit of Work Getter
    /// </summary>
    [Serializable]
    public class SI_DbLink_EditItem_Getter : EditItem_Getter_Base<SI_DbLink_EditItem, SI_DbLink_ItemCriteria>
    {
        #region DataPortal

        [Fetch]
        protected override void DataPortal_Fetch(SI_DbLink_ItemCriteria aCriteria)
        {
            if (aCriteria.HasKey)
                EditItem = SI_DbLink_EditItem.GetItem(aCriteria);
            else
                EditItem = SI_DbLink_EditItem.NewItem(aCriteria);
        }

        #endregion
    }

    /// <summary>
    /// Editable List
    /// </summary>
    [Serializable]
    public class SI_DbLink_EditList : EditList_Base<SI_DbLink_EditList, SI_DbLink_ListCriteria, SI_DbLink_EditItem, SI_DbLink_ItemCriteria>
    {
        #region DataPortal

        [Fetch]
        private void DataPortal_Fetch(SI_DbLink_ListCriteria aCriteria)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;

            using (var ctx = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                var dal = ctx.GetProvider<I_SI_DB_LINK>();
                var list = dal.SelectList(aCriteria.ToDto());

                foreach (var item in list)
                    Add(DataPortal.FetchChild<SI_DbLink_EditItem>(item));
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
