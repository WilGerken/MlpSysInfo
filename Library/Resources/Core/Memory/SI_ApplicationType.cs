﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SysInfo.Library.Common;

namespace SysInfo.Library.Resources.Core.Memory
{
    /// <summary>
    /// data access class
    /// </summary>
    public class SI_APPLICATION_TYPE : DATA_ACCESS_BASE<D_SI_APPLICATION_TYPE, F_SI_APPLICATION_TYPE, K_SI_APPLICATION_TYPE>, I_SI_APPLICATION_TYPE
    {
        // resource list
        public static List<D_SI_APPLICATION_TYPE> ResourceList = new List<D_SI_APPLICATION_TYPE>();

        static SI_APPLICATION_TYPE()
        {
            ResourceList.Add (new D_SI_APPLICATION_TYPE { objectID = (int) EApplicationType.Web,     typeCd = "WEB",     typeTxt = "Web Application",
                createByUid = Ref.AdminUid, updateByUid = Ref.AdminUid });
            ResourceList.Add (new D_SI_APPLICATION_TYPE { objectID = (int) EApplicationType.Console, typeCd = "CONSOLE", typeTxt = "Console Application",
                createByUid = Ref.AdminUid, updateByUid = Ref.AdminUid });
            ResourceList.Add (new D_SI_APPLICATION_TYPE { objectID = (int) EApplicationType.Desktop, typeCd = "DESKTOP", typeTxt = "Desktop Application",
                createByUid = Ref.AdminUid, updateByUid = Ref.AdminUid });
        }

        /// <summary>
        /// select a list of items from persistent store for given filter
        /// </summary>
        /// <param name="aFilter"></param>
        /// <returns></returns>
        public List<D_SI_APPLICATION_TYPE> SelectList (F_SI_APPLICATION_TYPE aFilter)
        {
            IEnumerable<D_SI_APPLICATION_TYPE> lResult = ResourceList;

            // apply filter attributes
            if (aFilter.objectID.HasValue)
            {
                lResult = lResult.Where (x => x.objectID == aFilter.objectID.Value);
            }

            if (! string.IsNullOrEmpty (aFilter.typeCd))
            {
                lResult = lResult.Where (x => x.typeCd.Contains (aFilter.typeCd));
            }

            // check base criteria
            lResult = CheckBaseCriteria(lResult, aFilter);

            // return result
            return lResult.ToList<D_SI_APPLICATION_TYPE>();
        }

        /// <summary>
        /// remove all matching items from persistent store
        /// </summary>
        /// <param name="aFilter"></param>
        public void DeleteList(F_SI_APPLICATION_TYPE aFilter)
        {
            throw new NotImplementedException("SI_APPLICATION_TYPE.DeleteList not implemented");
        }

        /// <summary>
        /// select an item from persistent store for given key
        /// </summary>
        /// <param name="aKey"></param>
        /// <returns></returns>
        public D_SI_APPLICATION_TYPE SelectItem(K_SI_APPLICATION_TYPE aKey)
        {
            D_SI_APPLICATION_TYPE lResult = null;

            // apply key attributes
            if (aKey.objectID.HasValue)
            {
                F_SI_APPLICATION_TYPE lFilter = new F_SI_APPLICATION_TYPE() { objectID = aKey.objectID.Value };

                lResult = SelectList(lFilter).FirstOrDefault();
            }

            // throw exception if not found
            if (lResult == null)
                throw new DllNotFoundException(string.Format("SI_APPLICATION_TYPE Item not found for key {0}", aKey.objectID));

            // return result
            return lResult;
        }

        /// <summary>
        /// insert an item into persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_SI_APPLICATION_TYPE InsertItem(D_SI_APPLICATION_TYPE aDto)
        {
            int lID = 0;

            if (ResourceList.Count > 0)
                lID = ResourceList.Select(x => x.objectID).Max() + 1;

            // create new item
            D_SI_APPLICATION_TYPE lItem = new D_SI_APPLICATION_TYPE
            {
                typeCd   = aDto.typeCd,
                typeTxt  = aDto.typeTxt,
                descTxt  = aDto.descTxt,

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
                ResourceList.Add(lItem);
            }

            return aDto;
        }

        /// <summary>
        /// update an item in persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_SI_APPLICATION_TYPE UpdateItem(D_SI_APPLICATION_TYPE aDto)
        {
            // fetch indicated item
            D_SI_APPLICATION_TYPE lItem = ResourceList.Where(x => x.objectID == aDto.objectID).FirstOrDefault();

            // update item
            lock (lItem)
            {
                lItem.typeCd  = aDto.typeCd;
                lItem.typeTxt = aDto.typeTxt;
                lItem.descTxt = aDto.descTxt;

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
        public void DeleteItem(K_SI_APPLICATION_TYPE aKey)
        {
            // fetch indicated item
            D_SI_APPLICATION_TYPE lItem = ResourceList.Where(x => x.objectID == aKey.objectID).FirstOrDefault();

            // delete item from list
            lock (ResourceList)
            {
                ResourceList.Remove(lItem);
            }
        }
    }
}