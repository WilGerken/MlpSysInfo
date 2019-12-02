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
    public class SI_SERVER : DATA_ACCESS_BASE<D_SI_SERVER, F_SI_SERVER, K_SI_SERVER>, I_SI_SERVER
    {
        #region Test Data

        // resource list
        public static List<D_SI_SERVER> ResourceList = new List<D_SI_SERVER>();

        static SI_SERVER()
        {
            int lID = 1;

            ResourceList.Add (new D_SI_SERVER { objectID = lID++, serverNm = "ENLIGHTEN_APP_DEVL", domainID = EDomain.RedLand,  domainNm = "Red Land",  
                levelTypeID = EServerLevelType.Devl, levelTypeTxt = "Development", versionTxt = "Server 2012", 
                createByUid = Ref.AdminUid, updateByUid = Ref.AdminUid });
            ResourceList.Add (new D_SI_SERVER { objectID = lID++, serverNm = "ENLIGHTEN_APP_TEST", domainID = EDomain.BlueLand, domainNm = "Blue Land",
                levelTypeID = EServerLevelType.Test, levelTypeTxt = "Test / Stage", versionTxt = "Server 2012", 
                createByUid = Ref.AdminUid, updateByUid = Ref.AdminUid });
            ResourceList.Add (new D_SI_SERVER { objectID = lID++, serverNm = "ENLIGHTEN_APP_PROD", domainID = EDomain.BlueLand, domainNm = "Blue Land",
                levelTypeID = EServerLevelType.Prod, levelTypeTxt = "Production", versionTxt = "Server 2012", 
                createByUid = Ref.AdminUid, updateByUid = Ref.AdminUid });
            ResourceList.Add (new D_SI_SERVER { objectID = lID++, serverNm = "ENLIGHTEN_DB_DEVL",  domainID = EDomain.BlueLand, domainNm = "Blue Land",
                levelTypeID = EServerLevelType.Devl, levelTypeTxt = "Development", versionTxt = "Server 2012", 
                createByUid = Ref.AdminUid, updateByUid = Ref.AdminUid });
            ResourceList.Add (new D_SI_SERVER { objectID = lID++, serverNm = "ENLIGHTEN_DB_TEST",  domainID = EDomain.BlueLand, domainNm = "Blue Land",
                levelTypeID = EServerLevelType.Test, levelTypeTxt = "Test / Stage", versionTxt = "Server 2012", 
                createByUid = Ref.AdminUid, updateByUid = Ref.AdminUid });
            ResourceList.Add (new D_SI_SERVER { objectID = lID++, serverNm = "ENLIGHTEN_DB_PROD",  domainID = EDomain.BlueLand, domainNm = "Blue Land",
                levelTypeID = EServerLevelType.Prod, levelTypeTxt = "Production", versionTxt = "Server 2012", 
                createByUid = Ref.AdminUid, updateByUid = Ref.AdminUid });
            ResourceList.Add (new D_SI_SERVER { objectID = lID++, serverNm = "ENLIGHTEN_REMOTE",   domainID = EDomain.BlueLand, domainNm = "Blue Land",
                levelTypeID = EServerLevelType.Prod, levelTypeTxt = "Production", versionTxt = "Windows 10", 
                createByUid = Ref.AdminUid, updateByUid = Ref.AdminUid });
        }

        #endregion

        /// <summary>
        /// select a list of items from persistent store for given filter
        /// </summary>
        /// <param name="aFilter"></param>
        /// <returns></returns>
        public List<D_SI_SERVER> SelectList (F_SI_SERVER aFilter)
        {
            IEnumerable<D_SI_SERVER> lResult = from item       in ResourceList
                                               join domainItem in SI_DOMAIN.ResourceList            on (int) item.domainID    equals domainItem.objectID
                                               join levelItem  in SI_SERVER_LEVEL_TYPE.ResourceList on (int) item.levelTypeID equals levelItem.objectID
                                               select new D_SI_SERVER
                                               {
                                                   domainID     = item.domainID,
                                                   domainNm     = domainItem.domainNm,
                                                   serverNm     = item.serverNm,
                                                   levelTypeID  = item.levelTypeID,
                                                   levelTypeTxt = levelItem.typeTxt,
                                                   versionTxt   = item.versionTxt,
                                                   descTxt      = item.descTxt,

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

            if (aFilter.domainID.HasValue)
            {
                lResult = lResult.Where(x => x.domainID == aFilter.domainID.Value);
            }

            if (! string.IsNullOrEmpty (aFilter.serverNm))
            {
                lResult = lResult.Where (x => x.serverNm.Contains (aFilter.serverNm));
            }

            // check base criteria
            lResult = CheckBaseCriteria (lResult, aFilter);

            // return result
            return lResult.ToList<D_SI_SERVER>();
        }

        /// <summary>
        /// remove all matching items from persistent store
        /// </summary>
        /// <param name="aFilter"></param>
        public void DeleteList (F_SI_SERVER aFilter)
        {
            throw new NotImplementedException ("SI_SERVER.DeleteList not implemented");
        }

        /// <summary>
        /// select an item from persistent store for given key
        /// </summary>
        /// <param name="aKey"></param>
        /// <returns></returns>
        public D_SI_SERVER SelectItem (K_SI_SERVER aKey)
        {
            D_SI_SERVER lResult = null;

            // apply key attributes
            if (aKey.objectID.HasValue)
            {
                F_SI_SERVER lFilter = new F_SI_SERVER() { objectID = aKey.objectID.Value };

                lResult = SelectList(lFilter).FirstOrDefault();
            }

            // throw exception if not found
            if (lResult == null)
                throw new DllNotFoundException (string.Format ("SI_SERVER Item not found for key {0}", aKey.objectID));

            // return result
            return lResult;
        }

        /// <summary>
        /// insert an item into persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_SI_SERVER InsertItem(D_SI_SERVER aDto)
        {
            int lID = 0;

            if (ResourceList.Count > 0)
                lID = ResourceList.Select(x => x.objectID).Max() + 1;

            // create new item
            D_SI_SERVER lItem = new D_SI_SERVER
            {
                domainID    = aDto.domainID,
                serverNm    = aDto.serverNm,
                levelTypeID = aDto.levelTypeID,
                versionTxt  = aDto.versionTxt,
                descTxt     = aDto.descTxt,

                // related fields
                domainNm     = aDto.domainNm,
                levelTypeTxt = aDto.levelTypeTxt,

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
        public D_SI_SERVER UpdateItem (D_SI_SERVER aDto)
        {
            // fetch indicated item
            D_SI_SERVER lItem = ResourceList.Where (x => x.objectID == aDto.objectID).FirstOrDefault();

            // update item
            lock (lItem)
            {
                lItem.domainID    = aDto.domainID;
                lItem.serverNm    = aDto.serverNm;
                lItem.levelTypeID = aDto.levelTypeID;
                lItem.versionTxt  = aDto.versionTxt;
                lItem.descTxt     = aDto.descTxt;

                // related fields
                lItem.domainNm     = aDto.domainNm;
                lItem.levelTypeTxt = aDto.levelTypeTxt;
                
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
        public void DeleteItem (K_SI_SERVER aKey)
        {
            // fetch indicated item
            D_SI_SERVER lItem = ResourceList.Where (x => x.objectID == aKey.objectID).FirstOrDefault();

            // delete item from list
            lock (ResourceList)
            {
                ResourceList.Remove(lItem);
            }
        }
    }
}