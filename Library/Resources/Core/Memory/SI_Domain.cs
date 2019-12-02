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
    public class SI_DOMAIN : DATA_ACCESS_BASE<D_SI_DOMAIN, F_SI_DOMAIN, K_SI_DOMAIN>, I_SI_DOMAIN
    {
        // resource list
        public static List<D_SI_DOMAIN> ResourceList = new List<D_SI_DOMAIN>();

        static SI_DOMAIN()
        {
            ResourceList.Add (new D_SI_DOMAIN { objectID = (int) EDomain.BlueLand, domainNm = "Blue Land",
                createByUid = Ref.AdminUid, updateByUid = Ref.AdminUid });
            ResourceList.Add (new D_SI_DOMAIN { objectID = (int) EDomain.RedLand,  domainNm = "Red Land",
                createByUid = Ref.AdminUid, updateByUid = Ref.AdminUid });
        }

        /// <summary>
        /// select a list of items from persistent store for given filter
        /// </summary>
        /// <param name="aFilter"></param>
        /// <returns></returns>
        public List<D_SI_DOMAIN> SelectList (F_SI_DOMAIN aFilter)
        {
            IEnumerable<D_SI_DOMAIN> lResult = ResourceList;

            // apply filter attributes
            if (aFilter.objectID.HasValue)
            {
                lResult = lResult.Where (x => x.objectID == aFilter.objectID.Value);
            }

            if (!string.IsNullOrEmpty (aFilter.domainNm))
            {
                lResult = lResult.Where (x => x.domainNm.Contains (aFilter.domainNm));
            }

            // check base criteria
            lResult = CheckBaseCriteria (lResult, aFilter);

            // return result
            return lResult.ToList<D_SI_DOMAIN>();
        }

        /// <summary>
        /// remove all matching items from persistent store
        /// </summary>
        /// <param name="aFilter"></param>
        public void DeleteList (F_SI_DOMAIN aFilter)
        {
            throw new NotImplementedException ("SI_DOMAIN.DeleteList not implemented");
        }

        /// <summary>
        /// select an item from persistent store for given key
        /// </summary>
        /// <param name="aKey"></param>
        /// <returns></returns>
        public D_SI_DOMAIN SelectItem (K_SI_DOMAIN aKey)
        {
            D_SI_DOMAIN lResult = null;

            // apply key attributes
            if (aKey.objectID.HasValue)
            {
                F_SI_DOMAIN lFilter = new F_SI_DOMAIN() { objectID = aKey.objectID.Value };

                lResult = SelectList(lFilter).FirstOrDefault();
            }

            // throw exception if not found
            if (lResult == null)
                throw new DllNotFoundException (string.Format ("SI_DOMAIN Item not found for key {0}", aKey.objectID));

            // return result
            return lResult;
        }

        /// <summary>
        /// insert an item into persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_SI_DOMAIN InsertItem(D_SI_DOMAIN aDto)
        {
            int lID = 0;

            if (ResourceList.Count > 0)
                lID = ResourceList.Select(x => x.objectID).Max() + 1;

            // create new item
            D_SI_DOMAIN lItem = new D_SI_DOMAIN
            {
                domainNm = aDto.domainNm,
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
                ResourceList.Add (lItem);
            }

            return aDto;
        }

        /// <summary>
        /// update an item in persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_SI_DOMAIN UpdateItem(D_SI_DOMAIN aDto)
        {
            // fetch indicated item
            D_SI_DOMAIN lItem = ResourceList.Where(x => x.objectID == aDto.objectID).FirstOrDefault();

            // update item
            lock (lItem)
            {
                lItem.domainNm = aDto.domainNm;
                lItem.descTxt  = aDto.descTxt;

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
        public void DeleteItem (K_SI_DOMAIN aKey)
        {
            // fetch indicated item
            D_SI_DOMAIN lItem = ResourceList.Where(x => x.objectID == aKey.objectID).FirstOrDefault();

            // delete item from list
            lock (ResourceList)
            {
                ResourceList.Remove (lItem);
            }
        }
    }
}