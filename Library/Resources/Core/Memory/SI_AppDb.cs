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
    public class SI_APP_DB : DATA_ACCESS_BASE<D_SI_APP_DB, F_SI_APP_DB, K_SI_APP_DB>, I_SI_APP_DB
    {
        #region Test Data

        // resource list
        public static List<D_SI_APP_DB> ResourceList = new List<D_SI_APP_DB>();

        static SI_APP_DB()
        {
            int lID = 1;

            ResourceList.Add(new D_SI_APP_DB
            {
                objectID = lID++,
                databaseID = (SI_DATABASE.ResourceList.Where(x => x.databaseNm == "Enlighten Devl").Select(x => x.objectID).First()),
                databaseNm = "ENLIGHTEN_DB_DEVL",
                applicationID = (SI_APPLICATION.ResourceList.Where(x => x.applicationNm == "Enlighten Devl").Select(x => x.objectID).First()),
                applicationNm = "ENLIGHTEN_APP_DEVL",
                createByUid = Ref.AdminUid,
                createOnDts = DateTime.Now,
                updateByUid = Ref.AdminUid,
                updateOnDts = DateTime.Now
            });
            ResourceList.Add(new D_SI_APP_DB
            {
                objectID = lID++,
                databaseID = (SI_DATABASE.ResourceList.Where(x => x.databaseNm == "Enlighten Test").Select(x => x.objectID).First()),
                databaseNm = "ENLIGHTEN_DB_TEST",
                applicationID = (SI_APPLICATION.ResourceList.Where(x => x.applicationNm == "Enlighten Test").Select(x => x.objectID).First()),
                applicationNm = "ENLIGHTEN_APP_TEST",
                createByUid = Ref.AdminUid,
                createOnDts = DateTime.Now,
                updateByUid = Ref.AdminUid,
                updateOnDts = DateTime.Now
            });
            ResourceList.Add(new D_SI_APP_DB
            {
                objectID = lID++,
                databaseID = (SI_DATABASE.ResourceList.Where(x => x.databaseNm == "Enlighten Prod").Select(x => x.objectID).First()),
                databaseNm = "ENLIGHTEN_DB_PROD",
                applicationID = (SI_APPLICATION.ResourceList.Where(x => x.applicationNm == "Enlighten Prod").Select(x => x.objectID).First()),
                applicationNm = "ENLIGHTEN_APP_PROD",
                createByUid = Ref.AdminUid,
                createOnDts = DateTime.Now,
                updateByUid = Ref.AdminUid,
                updateOnDts = DateTime.Now
            });
        }

        #endregion

        /// <summary>
        /// select a list of items from persistent store for given filter
        /// </summary>
        /// <param name="aFilter"></param>
        /// <returns></returns>
        public List<D_SI_APP_DB> SelectList (F_SI_APP_DB aFilter)
        {
            IEnumerable<D_SI_APP_DB> lResult = from item        in ResourceList
                                               join appItem     in SI_APPLICATION.ResourceList       on       item.applicationID        equals appItem.objectID
                                               join appTypeItem in SI_APPLICATION_TYPE.ResourceList  on (int) appItem.applicationTypeID equals appTypeItem.objectID
                                               join appSvrItem  in SI_SERVER.ResourceList            on       appItem.serverID          equals appSvrItem.objectID
                                               join appLvlItem  in SI_SERVER_LEVEL_TYPE.ResourceList on (int) appSvrItem.levelTypeID    equals appLvlItem.objectID
                                               join appDomItem  in SI_DOMAIN.ResourceList            on (int) appSvrItem.domainID       equals appDomItem.objectID
                                               join dbItem      in SI_DATABASE.ResourceList          on       item.databaseID           equals dbItem.objectID
                                               join dbTypeItem  in SI_DATABASE_TYPE.ResourceList     on (int) dbItem.databaseTypeID     equals dbTypeItem.objectID
                                               join dbSvrItem   in SI_SERVER.ResourceList            on       dbItem.serverID           equals dbSvrItem.objectID
                                               join dbLvlItem   in SI_SERVER_LEVEL_TYPE.ResourceList on (int) dbSvrItem.levelTypeID     equals dbLvlItem.objectID
                                               join dbDomItem   in SI_DOMAIN.ResourceList            on (int) dbSvrItem.domainID        equals dbDomItem.objectID
                                               select new D_SI_APP_DB
                                               {
                                                   appDomainID           = appSvrItem.domainID,
                                                   appDomainNm           = appDomItem.domainNm,
                                                   appServerID           = appItem.serverID,
                                                   appServerNm           = appSvrItem.serverNm,
                                                   appServerLevelTypeID  = appSvrItem.levelTypeID,
                                                   appServerLevelTypeTxt = appLvlItem.typeTxt,
                                                   applicationID         = item.applicationID,
                                                   applicationNm         = appItem.applicationNm,
                                                   applicationTypeID     = appItem.applicationTypeID,
                                                   applicationTypeTxt    = appTypeItem.typeTxt,
                                                   dbDomainID            = dbSvrItem.domainID,
                                                   dbDomainNm            = dbDomItem.domainNm,
                                                   dbServerID            = dbItem.serverID,
                                                   dbServerNm            = dbSvrItem.serverNm,
                                                   dbServerLevelTypeID   = dbSvrItem.levelTypeID,
                                                   dbServerLevelTypeTxt  = dbLvlItem.typeTxt,
                                                   databaseID            = item.databaseID,
                                                   databaseNm            = dbItem.databaseNm,
                                                   databaseTypeID        = dbItem.databaseTypeID,
                                                   databaseTypeTxt       = dbTypeItem.typeTxt,
                                                   descTxt               = item.descTxt,
                                                   
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

            if (aFilter.applicationID.HasValue)
            {
                lResult = lResult.Where (x => x.applicationID == aFilter.applicationID);
            }

            if (aFilter.databaseID.HasValue)
            {
                lResult = lResult.Where(x => x.databaseID == aFilter.databaseID);
            }

            // check base criteria
            lResult = CheckBaseCriteria (lResult, aFilter);

            // return result
            return lResult.ToList<D_SI_APP_DB>();
        }

        /// <summary>
        /// remove all matching items from persistent store
        /// </summary>
        /// <param name="aFilter"></param>
        public void DeleteList (F_SI_APP_DB aFilter)
        {
            throw new NotImplementedException ("SI_APP_DB.DeleteList not implemented");
        }

        /// <summary>
        /// select an item from persistent store for given key
        /// </summary>
        /// <param name="aKey"></param>
        /// <returns></returns>
        public D_SI_APP_DB SelectItem (K_SI_APP_DB aKey)
        {
            D_SI_APP_DB lResult = null;

            // apply key attributes
            if (aKey.objectID.HasValue)
            {
                F_SI_APP_DB lFilter = new F_SI_APP_DB () { objectID = aKey.objectID.Value };

                lResult = SelectList(lFilter).FirstOrDefault();
            }

            // throw exception if not found
            if (lResult == null)
                throw new DllNotFoundException (string.Format ("SI_APP_DB Item not found for key {0}", aKey.objectID));

            // return result
            return lResult;
        }

        /// <summary>
        /// insert an item into persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_SI_APP_DB InsertItem(D_SI_APP_DB aDto)
        {
            int lID = 0;

            if (ResourceList.Count > 0)
                lID = ResourceList.Select(x => x.objectID).Max() + 1;

            // create new item
            D_SI_APP_DB lItem = new D_SI_APP_DB
            {
                applicationID   = aDto.applicationID,
                databaseID      = aDto.databaseID,
                dbLinkID        = aDto.dbLinkID,
                descTxt         = aDto.descTxt,

                // related fields
                appDomainID           = aDto.appDomainID,
                appDomainNm           = aDto.appDomainNm,
                appServerID           = aDto.appServerID,
                appServerNm           = aDto.appServerNm,
                appServerLevelTypeID  = aDto.appServerLevelTypeID,
                appServerLevelTypeTxt = aDto.appServerLevelTypeTxt,
                applicationNm         = aDto.applicationNm,
                applicationTypeID     = aDto.applicationTypeID,
                applicationTypeTxt    = aDto.applicationTypeTxt,
                dbDomainID            = aDto.dbDomainID,
                dbDomainNm            = aDto.dbDomainNm,
                dbServerID            = aDto.dbServerID,
                dbServerNm            = aDto.dbServerNm,
                dbServerLevelTypeID   = aDto.dbServerLevelTypeID,
                dbServerLevelTypeTxt  = aDto.dbServerLevelTypeTxt,
                databaseNm            = aDto.databaseNm,
                databaseTypeID        = aDto.databaseTypeID,
                databaseTypeTxt       = aDto.databaseTypeTxt,

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
        public D_SI_APP_DB UpdateItem (D_SI_APP_DB aDto)
        {
            // fetch indicated item
            D_SI_APP_DB lItem = ResourceList.Where (x => x.objectID == aDto.objectID).FirstOrDefault();

            // update item
            lock (lItem)
            {
                lItem.applicationID = aDto.applicationID;
                lItem.databaseID    = aDto.databaseID;
                lItem.dbLinkID      = aDto.dbLinkID;
                lItem.descTxt       = aDto.descTxt;

                // related fields
                lItem.appDomainID           = aDto.appDomainID;
                lItem.appDomainNm           = aDto.appDomainNm;
                lItem.appServerID           = aDto.appServerID;
                lItem.appServerNm           = aDto.appServerNm;
                lItem.appServerLevelTypeID  = aDto.appServerLevelTypeID;
                lItem.appServerLevelTypeTxt = aDto.appServerLevelTypeTxt;
                lItem.applicationNm         = aDto.applicationNm;
                lItem.applicationTypeID     = aDto.applicationTypeID;
                lItem.applicationTypeTxt    = aDto.applicationTypeTxt;
                lItem.dbDomainID            = aDto.dbDomainID;
                lItem.dbDomainNm            = aDto.dbDomainNm;
                lItem.dbServerID            = aDto.dbServerID;
                lItem.dbServerNm            = aDto.dbServerNm;
                lItem.dbServerLevelTypeID   = aDto.dbServerLevelTypeID;
                lItem.dbServerLevelTypeTxt  = aDto.dbServerLevelTypeTxt;
                lItem.databaseNm            = aDto.databaseNm;
                lItem.databaseTypeID        = aDto.databaseTypeID;
                lItem.databaseTypeTxt       = aDto.databaseTypeTxt;

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
        public void DeleteItem (K_SI_APP_DB aKey)
        {
            // fetch indicated item
            D_SI_APP_DB lItem = ResourceList.Where (x => x.objectID == aKey.objectID).FirstOrDefault();

            // delete item from list
            lock (ResourceList)
            {
                ResourceList.Remove(lItem);
            }
        }
    }
}