using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SysInfo.Library.Common;

namespace SysInfo.Library.Resources.Core.Memory
{
    /// <summary>
    /// data access class
    /// </summary>
    public class SI_DATABASE : DATA_ACCESS_BASE<D_SI_DATABASE, F_SI_DATABASE, K_SI_DATABASE>, I_SI_DATABASE
    {
        #region Test Data

        // resource list
        public static List<D_SI_DATABASE> ResourceList = new List<D_SI_DATABASE>();

        static SI_DATABASE()
        {
            int lID = 1;

            ResourceList.Add (new D_SI_DATABASE
            {
                objectID = lID++,
                databaseNm = "Enlighten Devl",
                serverID = (SI_SERVER.ResourceList.Where(x => x.serverNm == "ENLIGHTEN_DB_DEVL").Select(x => x.objectID).First()),
                serverNm = "ENLIGHTEN_DB_DEVL",
                databaseTypeID = (EDatabaseType) (SI_DATABASE_TYPE.ResourceList.Where(x => x.typeCd == "ORACLE").Select(x => x.objectID).First()),
                databaseTypeTxt = "Oracle",
                createByUid = Ref.AdminUid,
                updateByUid = Ref.AdminUid
            });
            ResourceList.Add(new D_SI_DATABASE
            {
                objectID = lID++,
                databaseNm = "Enlighten Test",
                serverID = (SI_SERVER.ResourceList.Where(x => x.serverNm == "ENLIGHTEN_DB_TEST").Select(x => x.objectID).First()),
                serverNm = "ENLIGHTEN_DB_TEST",
                databaseTypeID = (EDatabaseType)(SI_DATABASE_TYPE.ResourceList.Where(x => x.typeCd == "ORACLE").Select(x => x.objectID).First()),
                databaseTypeTxt = "Oracle",
                createByUid = Ref.AdminUid,
                updateByUid = Ref.AdminUid
            });
            ResourceList.Add(new D_SI_DATABASE
            {
                objectID = lID++,
                databaseNm = "Enlighten Prod",
                serverID = (SI_SERVER.ResourceList.Where(x => x.serverNm == "ENLIGHTEN_DB_PROD").Select(x => x.objectID).First()),
                serverNm = "ENLIGHTEN_DB_PROD",
                databaseTypeID = (EDatabaseType)(SI_DATABASE_TYPE.ResourceList.Where(x => x.typeCd == "ORACLE").Select(x => x.objectID).First()),
                databaseTypeTxt = "Oracle",
                createByUid = Ref.AdminUid,
                updateByUid = Ref.AdminUid
            });
        }

        #endregion

        /// <summary>
        /// select a list of items from persistent store for given filter
        /// </summary>
        /// <param name="aFilter"></param>
        /// <returns></returns>
        public List<D_SI_DATABASE> SelectList (F_SI_DATABASE aFilter)
        {
            IEnumerable<D_SI_DATABASE> lResult = from item       in ResourceList
                                                 join serverItem in SI_SERVER.ResourceList            on       item.serverID          equals serverItem.objectID
                                                 join domainItem in SI_DOMAIN.ResourceList            on (int) serverItem.domainID    equals domainItem.objectID
                                                 join typeItem   in SI_DATABASE_TYPE.ResourceList     on (int) item.databaseTypeID    equals typeItem.objectID
                                                 select new D_SI_DATABASE
                                                 {
                                                     domainID        = serverItem.domainID,
                                                     domainNm        = domainItem.domainNm,
                                                     serverID        = item.serverID,
                                                     serverNm        = serverItem.serverNm,
                                                     databaseNm      = item.databaseNm,
                                                     databaseTypeID  = item.databaseTypeID,
                                                     databaseTypeTxt = typeItem.typeTxt,
                                                     descTxt         = item.descTxt,

                                                     objectID = item.objectID,
                                                     activeYn = item.activeYn,
                                                     createByNm = item.createByNm,
                                                     createOnDts = item.createOnDts,
                                                     updateByNm = item.updateByNm,
                                                     updateOnDts = item.updateOnDts
                                                 };

            // apply filter attributes
            if (aFilter.serverID.HasValue)
            {
                lResult = lResult.Where (x => x.serverID == aFilter.serverID.Value);
            }

            if (! string.IsNullOrEmpty (aFilter.databaseNm))
            {
                lResult = lResult.Where (x => x.databaseNm.Contains (aFilter.databaseNm));
            }

            // check base criteria
            lResult = CheckBaseCriteria (lResult, aFilter);

            // return result
            return lResult.ToList<D_SI_DATABASE>();
        }

        /// <summary>
        /// remove all matching items from persistent store
        /// </summary>
        /// <param name="aFilter"></param>
        public void DeleteList (F_SI_DATABASE aFilter)
        {
            throw new NotImplementedException ("SI_DATABASE.DeleteList not implemented");
        }

        /// <summary>
        /// select an item from persistent store for given key
        /// </summary>
        /// <param name="aKey"></param>
        /// <returns></returns>
        public D_SI_DATABASE SelectItem (K_SI_DATABASE aKey)
        {
            D_SI_DATABASE lResult = null;

            // apply key attributes
            if (aKey.objectID.HasValue)
            {
                F_SI_DATABASE lFilter = new F_SI_DATABASE() { objectID = aKey.objectID.Value };

                lResult = SelectList(lFilter).FirstOrDefault();
            }

            // throw exception if not found
            if (lResult == null)
                throw new DllNotFoundException (string.Format ("SI_DATABASE Item not found for key {0}", aKey.objectID));

            // return result
            return lResult;
        }

        /// <summary>
        /// insert an item into persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_SI_DATABASE InsertItem(D_SI_DATABASE aDto)
        {
            int lID = 0;

            if (ResourceList.Count > 0)
                lID = ResourceList.Select(x => x.objectID).Max() + 1;

            // create new item
            D_SI_DATABASE lItem = new D_SI_DATABASE
            {
                serverID        = aDto.serverID,
                databaseNm      = aDto.databaseNm,
                databaseTypeID  = aDto.databaseTypeID,
                descTxt         = aDto.descTxt,

                // related fields
                domainID        = aDto.domainID,
                domainNm        = aDto.domainNm,
                serverNm        = aDto.serverNm,
                databaseTypeTxt = aDto.databaseTypeTxt,

                // meta fields
                objectID    = lID,
                activeYn    = aDto.activeYn,
                createByUid = aDto.createByUid,
                createOnDts = aDto.createOnDts,
                updateByUid = aDto.updateByUid,
                updateOnDts = aDto.updateOnDts,
            };

            // insert new item into list
            lock (ResourceList)
            {
                ResourceList.Add (lItem);
            }

            return aDto;
        }

        /// <summary>
        /// update an item in persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_SI_DATABASE UpdateItem (D_SI_DATABASE aDto)
        {
            // fetch indicated item
            D_SI_DATABASE lItem = ResourceList.Where (x => x.objectID == aDto.objectID).FirstOrDefault();

            // update item
            lock (lItem)
            {
                lItem.serverID        = aDto.serverID;
                lItem.databaseNm      = aDto.databaseNm;
                lItem.databaseTypeID  = aDto.databaseTypeID;
                lItem.descTxt         = aDto.descTxt;

                // related fields
                lItem.domainID        = aDto.domainID;
                lItem.domainNm        = aDto.domainNm;
                lItem.serverNm        = aDto.serverNm;
                lItem.databaseTypeTxt = aDto.databaseTypeTxt;

                // meta fields
                lItem.activeYn    = aDto.activeYn;
                lItem.createByUid = aDto.createByUid;
                lItem.createOnDts = aDto.createOnDts;
                lItem.updateByUid = aDto.updateByUid;
                lItem.updateOnDts = aDto.updateOnDts;
            }

            return aDto;
        }

        /// <summary>
        /// remove an item from persistent store
        /// </summary>
        /// <param name="aKey"></param>
        public void DeleteItem (K_SI_DATABASE aKey)
        {
            // fetch indicated item
            D_SI_DATABASE lItem = ResourceList.Where (x => x.objectID == aKey.objectID).FirstOrDefault();

            // delete item from list
            lock (ResourceList)
            {
                ResourceList.Remove(lItem);
            }
        }
    }
}