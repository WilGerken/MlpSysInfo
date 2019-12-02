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
    public class SI_DB_LINK : DATA_ACCESS_BASE<D_SI_DB_LINK, F_SI_DB_LINK, K_SI_DB_LINK>, I_SI_DB_LINK
    {
        #region Test Data

        // resource list
        public static List<D_SI_DB_LINK> ResourceList = new List<D_SI_DB_LINK>();

        static SI_DB_LINK()
        {
        }

        #endregion

        /// <summary>
        /// select a list of items from persistent store for given filter
        /// </summary>
        /// <param name="aFilter"></param>
        /// <returns></returns>
        public List<D_SI_DB_LINK> SelectList (F_SI_DB_LINK aFilter)
        {
            IEnumerable<D_SI_DB_LINK> lResult = from item        in ResourceList
                                                join srcItem     in SI_DATABASE.ResourceList          on       item.sourceDatabaseID  equals srcItem.objectID
                                                join srcTypeItem in SI_DATABASE_TYPE.ResourceList     on (int) srcItem.databaseTypeID equals srcTypeItem.objectID
                                                join srcSvrItem  in SI_SERVER.ResourceList            on       srcItem.serverID       equals srcSvrItem.objectID
                                                join srcLvlItem  in SI_SERVER_LEVEL_TYPE.ResourceList on (int) srcSvrItem.levelTypeID equals srcLvlItem.objectID
                                                join srcDomItem  in SI_DOMAIN.ResourceList            on (int) srcSvrItem.domainID    equals srcDomItem.objectID
                                                join tarItem     in SI_DATABASE.ResourceList          on       item.targetDatabaseID  equals tarItem.objectID
                                                join tarTypeItem in SI_DATABASE_TYPE.ResourceList     on (int) tarItem.databaseTypeID equals tarTypeItem.objectID
                                                join tarSvrItem  in SI_SERVER.ResourceList            on       tarItem.serverID       equals tarSvrItem.objectID
                                                join tarLvlItem  in SI_SERVER_LEVEL_TYPE.ResourceList on (int) tarSvrItem.levelTypeID equals tarLvlItem.objectID
                                                join tarDomItem  in SI_DOMAIN.ResourceList            on (int) tarSvrItem.domainID    equals tarDomItem.objectID
                                                select new D_SI_DB_LINK
                                                {
                                                    sourceDomainID           = srcSvrItem.domainID,
                                                    sourceDomainNm           = srcDomItem.domainNm,
                                                    sourceServerID           = srcItem.serverID,
                                                    sourceServerNm           = srcSvrItem.serverNm,
                                                    sourceServerLevelTypeID  = srcSvrItem.levelTypeID,
                                                    sourceServerLevelTypeTxt = srcLvlItem.typeTxt,
                                                    sourceDatabaseID         = item.sourceDatabaseID,
                                                    sourceDatabaseNm         = srcItem.databaseNm,
                                                    sourceDatabaseTypeID     = srcItem.databaseTypeID,
                                                    sourceDatabaseTypeTxt    = srcTypeItem.typeTxt,
                                                    targetDomainID           = tarSvrItem.domainID,
                                                    targetDomainNm           = tarDomItem.domainNm,
                                                    targetServerID           = tarItem.serverID,
                                                    targetServerNm           = tarSvrItem.serverNm,
                                                    targetServerLevelTypeID  = tarSvrItem.levelTypeID,
                                                    targetServerLevelTypeTxt = tarLvlItem.typeTxt,
                                                    targetDatabaseID         = item.targetDatabaseID,
                                                    targetDatabaseNm         = tarItem.databaseNm,
                                                    targetDatabaseTypeID     = tarItem.databaseTypeID,
                                                    targetDatabaseTypeTxt    = tarTypeItem.typeTxt,
                                                    descTxt                  = item.descTxt,
                                                   
                                                    objectID    = item.objectID,
                                                    activeYn    = item.activeYn,
                                                    createByNm  = item.createByNm,
                                                    createOnDts = item.createOnDts,
                                                    updateByNm  = item.updateByNm,
                                                    updateOnDts = item.updateOnDts
                                                };

            // apply filter attributes
            if (aFilter.objectID.HasValue)
            {
                lResult = lResult.Where (x => x.objectID == aFilter.objectID.Value);
            }

            if (aFilter.sourceDatabaseID.HasValue)
            {
                lResult = lResult.Where (x => x.sourceDatabaseID == aFilter.sourceDatabaseID);
            }

            if (aFilter.targetDatabaseID.HasValue)
            {
                lResult = lResult.Where(x => x.targetDatabaseID == aFilter.targetDatabaseID);
            }

            // check base criteria
            lResult = CheckBaseCriteria (lResult, aFilter);

            // return result
            return lResult.ToList<D_SI_DB_LINK>();
        }

        /// <summary>
        /// remove all matching items from persistent store
        /// </summary>
        /// <param name="aFilter"></param>
        public void DeleteList (F_SI_DB_LINK aFilter)
        {
            throw new NotImplementedException ("SI_DB_LINK.DeleteList not implemented");
        }

        /// <summary>
        /// select an item from persistent store for given key
        /// </summary>
        /// <param name="aKey"></param>
        /// <returns></returns>
        public D_SI_DB_LINK SelectItem (K_SI_DB_LINK aKey)
        {
            D_SI_DB_LINK lResult = null;

            // apply key attributes
            if (aKey.objectID.HasValue)
            {
                F_SI_DB_LINK lFilter = new F_SI_DB_LINK() { objectID = aKey.objectID.Value };

                lResult = SelectList(lFilter).FirstOrDefault();
            }

            // throw exception if not found
            if (lResult == null)
                throw new DllNotFoundException (string.Format ("SI_DB_LINK Item not found for key {0}", aKey.objectID));

            // return result
            return lResult;
        }

        /// <summary>
        /// insert an item into persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_SI_DB_LINK InsertItem (D_SI_DB_LINK aDto)
        {
            int lID = 0;

            if (ResourceList.Count > 0)
                lID = ResourceList.Select(x => x.objectID).Max() + 1;

            // create new item
            D_SI_DB_LINK lItem = new D_SI_DB_LINK
            {
                sourceDatabaseID = aDto.sourceDatabaseID,
                targetDatabaseID = aDto.targetDatabaseID,
                descTxt          = aDto.descTxt,

                // related fields
                sourceDomainID           = aDto.sourceDomainID,
                sourceDomainNm           = aDto.sourceDomainNm,
                sourceServerID           = aDto.sourceServerID,
                sourceServerNm           = aDto.sourceServerNm,
                sourceServerLevelTypeID  = aDto.sourceServerLevelTypeID,
                sourceServerLevelTypeTxt = aDto.sourceServerLevelTypeTxt,
                sourceDatabaseNm         = aDto.sourceDatabaseNm,
                sourceDatabaseTypeID     = aDto.sourceDatabaseTypeID,
                sourceDatabaseTypeTxt    = aDto.sourceDatabaseTypeTxt,
                targetDomainID           = aDto.targetDomainID,
                targetDomainNm           = aDto.targetDomainNm,
                targetServerID           = aDto.targetServerID,
                targetServerNm           = aDto.targetServerNm,
                targetServerLevelTypeID  = aDto.targetServerLevelTypeID,
                targetServerLevelTypeTxt = aDto.targetServerLevelTypeTxt,
                targetDatabaseNm         = aDto.targetDatabaseNm,
                targetDatabaseTypeID     = aDto.targetDatabaseTypeID,
                targetDatabaseTypeTxt    = aDto.targetDatabaseTypeTxt,

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
        public D_SI_DB_LINK UpdateItem (D_SI_DB_LINK aDto)
        {
            // fetch indicated item
            D_SI_DB_LINK lItem = ResourceList.Where (x => x.objectID == aDto.objectID).FirstOrDefault();

            // update item
            lock (lItem)
            {
                lItem.sourceDatabaseID = aDto.sourceDatabaseID;
                lItem.targetDatabaseID = aDto.targetDatabaseID;
                lItem.descTxt          = aDto.descTxt;

                // related fields
                lItem.sourceDomainID           = aDto.sourceDomainID;
                lItem.sourceDomainNm           = aDto.sourceDomainNm;
                lItem.sourceServerID           = aDto.sourceServerID;
                lItem.sourceServerNm           = aDto.sourceServerNm;
                lItem.sourceServerLevelTypeID  = aDto.sourceServerLevelTypeID;
                lItem.sourceServerLevelTypeTxt = aDto.sourceServerLevelTypeTxt;
                lItem.sourceDatabaseNm         = aDto.sourceDatabaseNm;
                lItem.sourceDatabaseTypeID     = aDto.sourceDatabaseTypeID;
                lItem.sourceDatabaseTypeTxt    = aDto.sourceDatabaseTypeTxt;
                lItem.targetDomainID           = aDto.targetDomainID;
                lItem.targetDomainNm           = aDto.targetDomainNm;
                lItem.targetServerID           = aDto.targetServerID;
                lItem.targetServerNm           = aDto.targetServerNm;
                lItem.targetServerLevelTypeID  = aDto.targetServerLevelTypeID;
                lItem.targetServerLevelTypeTxt = aDto.targetServerLevelTypeTxt;
                lItem.targetDatabaseNm         = aDto.targetDatabaseNm;
                lItem.targetDatabaseTypeID     = aDto.targetDatabaseTypeID;
                lItem.targetDatabaseTypeTxt    = aDto.targetDatabaseTypeTxt;

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
        public void DeleteItem (K_SI_DB_LINK aKey)
        {
            // fetch indicated item
            D_SI_DB_LINK lItem = ResourceList.Where (x => x.objectID == aKey.objectID).FirstOrDefault();

            // delete item from list
            lock (ResourceList)
            {
                ResourceList.Remove(lItem);
            }
        }
    }
}