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
    public class SI_APPLICATION : DATA_ACCESS_BASE<D_SI_APPLICATION, F_SI_APPLICATION, K_SI_APPLICATION>, I_SI_APPLICATION
    {
        #region Test Data

        // resource list
        public static List<D_SI_APPLICATION> ResourceList = new List<D_SI_APPLICATION>();

        static SI_APPLICATION()
        {
            int lID = 1;

            ResourceList.Add(new D_SI_APPLICATION
            {
                objectID = lID++,
                applicationNm = "Enlighten Devl",
                serverID = (SI_SERVER.ResourceList.Where(x => x.serverNm == "ENLIGHTEN_APP_DEVL").Select(x => x.objectID).First()),
                serverNm = "ENLIGHTEN_APP_DEVL",
                applicationTypeID = (EApplicationType) (SI_APPLICATION_TYPE.ResourceList.Where(x => x.typeCd == "WEB").Select(x => x.objectID).First()),
                applicationTypeTxt = "Oracle",
                createByUid = Ref.AdminUid,
                updateByUid = Ref.AdminUid
            });
            ResourceList.Add(new D_SI_APPLICATION
            {
                objectID = lID++,
                applicationNm = "Enlighten Test",
                serverID = (SI_SERVER.ResourceList.Where(x => x.serverNm == "ENLIGHTEN_APP_TEST").Select(x => x.objectID).First()),
                serverNm = "ENLIGHTEN_APP_TEST",
                applicationTypeID = (EApplicationType) (SI_APPLICATION_TYPE.ResourceList.Where(x => x.typeCd == "WEB").Select(x => x.objectID).First()),
                applicationTypeTxt = "Oracle",
                createByUid = Ref.AdminUid,
                updateByUid = Ref.AdminUid
            });
            ResourceList.Add(new D_SI_APPLICATION
            {
                objectID = lID++,
                applicationNm = "Enlighten Prod",
                serverID = (SI_SERVER.ResourceList.Where(x => x.serverNm == "ENLIGHTEN_APP_PROD").Select(x => x.objectID).First()),
                serverNm = "ENLIGHTEN_APP_PROD",
                applicationTypeID = (EApplicationType) (SI_APPLICATION_TYPE.ResourceList.Where(x => x.typeCd == "WEB").Select(x => x.objectID).First()),
                applicationTypeTxt = "Oracle",
                createByUid = Ref.AdminUid,
                updateByUid = Ref.AdminUid
            });
            ResourceList.Add(new D_SI_APPLICATION
            {
                objectID = lID++,
                applicationNm = "Enlighten Laptop",
                serverID = (SI_SERVER.ResourceList.Where(x => x.serverNm == "ENLIGHTEN_REMOTE").Select(x => x.objectID).First()),
                serverNm = "ENLIGHTEN_LAPTOP",
                applicationTypeID = (EApplicationType)(SI_APPLICATION_TYPE.ResourceList.Where(x => x.typeCd == "WEB").Select(x => x.objectID).First()),
                applicationTypeTxt = "Oracle",
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
        public List<D_SI_APPLICATION> SelectList (F_SI_APPLICATION aFilter)
        {
            IEnumerable<D_SI_APPLICATION> lResult = from item       in ResourceList
                                                    join serverItem in SI_SERVER.ResourceList           on       item.serverID          equals serverItem.objectID
                                                    join domainItem in SI_DOMAIN.ResourceList           on (int) serverItem.domainID    equals domainItem.objectID
                                                    join typeItem   in SI_APPLICATION_TYPE.ResourceList on (int) item.applicationTypeID equals typeItem.objectID
                                                    select new D_SI_APPLICATION
                                                    {
                                                        domainID           = serverItem.domainID,
                                                        domainNm           = domainItem.domainNm,
                                                        serverID           = item.serverID,
                                                        serverNm           = serverItem.serverNm,
                                                        applicationNm      = item.applicationNm,
                                                        applicationTypeID  = item.applicationTypeID,
                                                        applicationTypeTxt = typeItem.typeTxt,
                                                        descTxt            = item.descTxt,

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

            if (aFilter.serverID.HasValue)
            {
                lResult = lResult.Where (x => x.serverID == aFilter.serverID.Value);
            }

            if (! string.IsNullOrEmpty (aFilter.applicationNm))
            {
                lResult = lResult.Where (x => x.applicationNm.Contains (aFilter.applicationNm));
            }

            // check base criteria
            lResult = CheckBaseCriteria (lResult, aFilter);

            // return result
            return lResult.ToList<D_SI_APPLICATION>();
        }

        /// <summary>
        /// remove all matching items from persistent store
        /// </summary>
        /// <param name="aFilter"></param>
        public void DeleteList (F_SI_APPLICATION aFilter)
        {
            throw new NotImplementedException ("SI_APPLICATION.DeleteList not implemented");
        }

        /// <summary>
        /// select an item from persistent store for given key
        /// </summary>
        /// <param name="aKey"></param>
        /// <returns></returns>
        public D_SI_APPLICATION SelectItem (K_SI_APPLICATION aKey)
        {
            D_SI_APPLICATION lResult = null;

            // apply key attributes
            if (aKey.objectID.HasValue)
            {
                F_SI_APPLICATION lFilter = new F_SI_APPLICATION() { objectID = aKey.objectID.Value };

                lResult = SelectList(lFilter).FirstOrDefault();
            }

            // throw exception if not found
            if (lResult == null)
                throw new DllNotFoundException (string.Format ("SI_APPLICATION Item not found for key {0}", aKey.objectID));

            // return result
            return lResult;
        }

        /// <summary>
        /// insert an item into persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_SI_APPLICATION InsertItem(D_SI_APPLICATION aDto)
        {
            int lID = 0;

            if (ResourceList.Count > 0)
                lID = ResourceList.Select(x => x.objectID).Max() + 1;

            // create new item
            D_SI_APPLICATION lItem = new D_SI_APPLICATION
            {
                serverID           = aDto.serverID,
                applicationTypeID  = aDto.applicationTypeID,
                applicationNm      = aDto.applicationNm,
                descTxt            = aDto.descTxt,

                // related fields
                domainID           = aDto.domainID,
                domainNm           = aDto.domainNm,
                serverNm           = aDto.serverNm,
                applicationTypeTxt = aDto.applicationTypeTxt,

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
        public D_SI_APPLICATION UpdateItem (D_SI_APPLICATION aDto)
        {
            // fetch indicated item
            D_SI_APPLICATION lItem = ResourceList.Where (x => x.objectID == aDto.objectID).FirstOrDefault();

            // update item
            lock (lItem)
            {
                lItem.serverID           = aDto.serverID;
                lItem.applicationTypeID  = aDto.applicationTypeID;
                lItem.applicationNm      = aDto.applicationNm;
                lItem.descTxt            = aDto.descTxt;

                // related fields
                lItem.domainID           = aDto.domainID;
                lItem.domainNm           = aDto.domainNm;
                lItem.serverNm           = aDto.serverNm;
                lItem.applicationTypeTxt = aDto.applicationTypeTxt;

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
        public void DeleteItem (K_SI_APPLICATION aKey)
        {
            // fetch indicated item
            D_SI_APPLICATION lItem = ResourceList.Where (x => x.objectID == aKey.objectID).FirstOrDefault();

            // delete item from list
            lock (ResourceList)
            {
                ResourceList.Remove(lItem);
            }
        }
    }
}