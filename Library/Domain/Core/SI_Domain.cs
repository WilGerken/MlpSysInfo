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
    public class SI_Domain_ItemCriteria : ItemCriteria_Base<SI_Domain_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<string> DomainNm_Property = RegisterProperty<string>(c => c.DomainNm);
        public string DomainNm
        {
            get { return ReadProperty(DomainNm_Property); }
            set { LoadProperty(DomainNm_Property, value); }
        }

        public K_SI_DOMAIN ToDto()
        {
            K_SI_DOMAIN dto = new K_SI_DOMAIN
            {
                domainNm = DomainNm
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
    public class SI_Domain_ListCriteria : ListCriteria_Base<SI_Domain_ListCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<string> DomainNm_Property = RegisterProperty<string>(c => c.DomainNm);
        public string DomainNm
        {
            get { return ReadProperty(DomainNm_Property); }
            set { LoadProperty(DomainNm_Property, value); }
        }

        public F_SI_DOMAIN ToDto()
        {
            F_SI_DOMAIN dto = new F_SI_DOMAIN
            {
                domainNm = DomainNm
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
    public class SI_Domain_InfoItem : InfoItem_Base<SI_Domain_InfoItem, SI_Domain_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<string> DomainNm_Property = RegisterProperty<string>(c => c.DomainNm);
        public string DomainNm
        {
            get { return ReadProperty(DomainNm_Property); }
            set { LoadProperty(DomainNm_Property, value); }
        }

        public static readonly PropertyInfo<string> DescTxt_Property = RegisterProperty<string>(c => c.DescTxt);
        public string DescTxt
        {
            get { return ReadProperty(DescTxt_Property); }
            set { LoadProperty(DescTxt_Property, value); }
        }

        public void FromDto (D_SI_DOMAIN dto)
        {
            DomainNm = dto.domainNm;
            DescTxt  = dto.descTxt;

            base.FromDto (dto);
        }

        #endregion

        #region DataPortal

        [FetchChild]
        private void Child_Fetch (D_SI_DOMAIN dto) { FromDto (dto); }

        [Fetch]
        private void DataPortal_Fetch(SI_Domain_ItemCriteria aKey)
        {
            using (var dalManager = DalFactory.GetManager (DalFactory.SI_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_SI_DOMAIN>();
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
    public class SI_Domain_InfoList : InfoList_Base<SI_Domain_InfoList, SI_Domain_ListCriteria, SI_Domain_InfoItem, SI_Domain_ItemCriteria>
    {
        #region DataPortal

        [Fetch]
        private void DataPortal_Fetch(SI_Domain_ListCriteria aCriteria)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;

            // add select option if given
            if (aCriteria.SelectOption_Value.HasValue)
            {
                Insert(0, DataPortal.FetchChild<SI_Domain_InfoItem>(new D_SI_DOMAIN
                {
                    selectTxt = aCriteria.SelectOption_Text,
                    objectID = aCriteria.SelectOption_Value.Value
                }));
            }

            // add elements of list from persistent store
            using (var ctx = DalFactory.GetManager (DalFactory.SI_SCHEMA_NM))
            {
                var dal = ctx.GetProvider<I_SI_DOMAIN>();
                var list = dal.SelectList(aCriteria.ToDto());

                foreach (var item in list)
                    Add (DataPortal.FetchChild<SI_Domain_InfoItem>(item));
            }

            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        #endregion
    }

    [Serializable]
    public class SI_Domain_EditItem : EditItem_Base<SI_Domain_EditItem, SI_Domain_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<string> DomainNm_Property = RegisterProperty<string>(c => c.DomainNm);
        [Required]
        public string DomainNm
        {
            get { return GetProperty(DomainNm_Property); }
            set { SetProperty(DomainNm_Property, value); }
        }

        public static readonly PropertyInfo<string> DescTxt_Property = RegisterProperty<string>(c => c.DescTxt);
        public string DescTxt
        {
            get { return GetProperty(DescTxt_Property); }
            set { SetProperty(DescTxt_Property, value); }
        }

        public void FromDto (D_SI_DOMAIN dto)
        {
            DomainNm = dto.domainNm;
            DescTxt  = dto.descTxt;

            base.FromDto(dto);
        }

        public D_SI_DOMAIN ToDto ()
        {
            D_SI_DOMAIN dto = new D_SI_DOMAIN
            {
                domainNm = DomainNm,
                descTxt = DescTxt
            };

            base.ToDto(dto);

            return dto;
        }

        // editable child list - SI_Server
        public static readonly PropertyInfo<SI_Server_EditList> ServerList_Property =
            RegisterProperty<SI_Server_EditList>(p => p.ServerList, RelationshipTypes.LazyLoad);
        public SI_Server_EditList ServerList
        {
            get
            {
                return LazyGetProperty(ServerList_Property,
                    () => DataPortal.Fetch<SI_Server_EditList>(new SI_Server_ListCriteria { DomainID = (EDomain) ReadProperty(ObjectID_Property) }));
            }
            private set { LoadProperty(ServerList_Property, value); }
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
        protected void DataPortal_Create(SI_Domain_ItemCriteria aKey)
        {
            base.DataPortal_Create();

            if (aKey != null)
            {
                DomainNm = aKey.DomainNm;
            }
        }

        [CreateChild]
        protected override void Child_Create()
        {
            base.Child_Create();
        }

        [Fetch]
        private void DataPortal_Fetch(SI_Domain_ItemCriteria aKey)
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_SI_DOMAIN>();
                var data = dal.SelectItem(aKey.ToDto());

                using (BypassPropertyChecks) { FromDto (data); }

                BusinessRules.CheckRules();
            }
        }

        [FetchChild]
        private void Child_Fetch(D_SI_DOMAIN dto) { FromDto(dto); }

        [Insert]
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                var dal  = dalManager.GetProvider<I_SI_DOMAIN>();
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
                var dal  = dalManager.GetProvider<I_SI_DOMAIN>();
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

                var dal  = dalManager.GetProvider<I_SI_DOMAIN>();
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

                var dal = dalManager.GetProvider<I_SI_DOMAIN>();
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
                var dal = dalManager.GetProvider<I_SI_DOMAIN>();

                dal.DeleteItem(new K_SI_DOMAIN { objectID = this.ObjectID });
            }
        }

        [DeleteSelfChild]
        private void Child_DeleteSelf()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                FieldManager.UpdateChildren(this);

                var dal = dalManager.GetProvider<I_SI_DOMAIN>();
                using (BypassPropertyChecks)
                {
                    dal.DeleteItem(new K_SI_DOMAIN { objectID = this.ObjectID });
                }
            }
        }

        #endregion
    }

    /// <summary>
    /// Unit of Work Getter
    /// </summary>
    [Serializable]
    public class SI_Domain_EditItem_Getter : EditItem_Getter_Base<SI_Domain_EditItem, SI_Domain_ItemCriteria>
    {
        #region DataPortal

        [Fetch]
        protected override void DataPortal_Fetch(SI_Domain_ItemCriteria aCriteria)
        {
            if (aCriteria.HasKey)
                EditItem = SI_Domain_EditItem.GetItem(aCriteria);
            else
                EditItem = SI_Domain_EditItem.NewItem(aCriteria);
        }

        #endregion
    }

    /// <summary>
    /// Editable List
    /// </summary>
    [Serializable]
    public class SI_Domain_EditList : EditList_Base<SI_Domain_EditList, SI_Domain_ListCriteria, SI_Domain_EditItem, SI_Domain_ItemCriteria>
    {
        #region DataPortal

        [Fetch]
        private void DataPortal_Fetch(SI_Domain_ListCriteria aCriteria)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;

            using (var ctx = DalFactory.GetManager(DalFactory.SI_SCHEMA_NM))
            {
                var dal = ctx.GetProvider<I_SI_DOMAIN>();
                var list = dal.SelectList(aCriteria.ToDto());

                foreach (var item in list)
                    Add(DataPortal.FetchChild<SI_Domain_EditItem>(item));
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
