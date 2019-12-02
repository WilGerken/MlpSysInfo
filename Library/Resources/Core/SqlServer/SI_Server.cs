using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SysInfo.Library.Common;
//using Csla.Data.EntityFrameworkCore;

namespace SysInfo.Library.Resources.Core.SqlServer
{
    /// <summary>
    /// data access class
    /// </summary>
    public class SI_SERVER : DATA_ACCESS_BASE<D_SI_SERVER, F_SI_SERVER, K_SI_SERVER>, I_SI_SERVER
    {
        public static List<D_SI_SERVER> ResourceList = new List<D_SI_SERVER>();

        /// <summary>
        /// select a list of items from persistent store for given filter
        /// </summary>
        /// <param name="aFilter"></param>
        /// <returns></returns>
        public List<D_SI_SERVER> SelectList (F_SI_SERVER aFilter)
        {
            List<D_SI_SERVER> lResult = new List<D_SI_SERVER>();
#if (TODO)
            using (var ctx = DbContextManager<SysInfoEntities>.GetManager ("SysInfoEntities"))
            {
                var lQuery = (from item in ctx.DbContext.SI_SERVER_TAB
                              select new D_SI_SERVER
                              {
                                  domainID = item.DOMAIN_ID,
                                  serverNm = item.CHAIN_NM,
                                  descTxt = item.DESC_TXT,

                                  objectID    = item.OBJECT_ID,
                                  activeYn    = item.ACTIVE_YN,
                                  createOnDts = item.CREATE_ON_DTS,
                                  createByUid = item.CREATE_BY_UID,
                                  updateOnDts = item.UPDATE_ON_DTS,
                                  updateByUid = item.UPDATE_BY_UID,
                                  versionKey  = item.ORA_ROWSCN
                              });

                // apply filter attributes
                if (aFilter.objectID.HasValue)
                {
                    lResult = lResult.Where (x => x.objectID == aFilter.objectID.Value);
                }

                if (! string.IsNullOrEmpty (aFilter.serverNm))
                {
                    lQuery = lQuery.Where (x => x.serverNm.Contains (aFilter.serverNm));
                }

                // check base criteria
                lQuery = CheckBaseCriteria (lQuery, aFilter);

                lResult = lQuery.ToList<D_SI_SERVER>();
            }
#endif
            // return result
            return lResult;
        }

        /// <summary>
        /// remove all matching items from persistent store
        /// </summary>
        /// <param name="aFilter"></param>
        public void DeleteList(F_SI_SERVER aFilter)
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
#if (TODO)
            using (var ctx = DbContextManager<CheckSomeEntities>.GetManager ("CheckSomeEntities"))
            {
                var lQuery = (from item in ctx.DbContext.SI_SERVER_TAB
                              select new D_SI_SERVER
                              {
                                  chainNm = item.CHAIN_NM,
                                  descTxt = item.DESC_TXT,

                                  objectID     = item.OBJECT_ID,
                                  activeYn     = item.ACTIVE_YN,
                                  createByUid  = item.CREATE_BY_UID,
                                  createOnDts  = item.CREATE_ON_DTS,
                                  updateByUid  = item.UPDATE_BY_UID,
                                  updateOnDts  = item.UPDATE_ON_DTS,
                                  versionKey   = item.ORA_ROWSCN
                              });

                if (aKey.objectID.HasValue)
                {
                    lQuery = lQuery.Where(x => x.objectID == aKey.objectID.Value);
                }
                else if (! string.IsNullOrEmpty (aKey.chainNm))
                {
                    lQuery = lQuery.Where (x => string.Compare (x.chainNm, aKey.chainNm, true) == 0);
                }
                else
                {
                    throw new Exception ("SI_SERVER: Key missing for item select");
                }
                
                lResult = lQuery.FirstOrDefault();
            }

            // throw exception if not found
            if (lResult == null)
                throw new DllNotFoundException (string.Format ("SI_SERVER Item not found for key {0}", aKey.objectID));
#endif
            // return result
            return lResult;
        }

        /// <summary>
        /// insert an item into persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_SI_SERVER InsertItem (D_SI_SERVER aDto)
        {
#if (TODO)
            using (var ctx = DbContextManager<CheckSomeEntities>.GetManager("CheckSomeEntities"))
            {
                // create new persistent object
                var data = new CheckSomeEntities.O_SI_SERVER ();

                data.CHAIN_NM = aDto.chainNm;
                data.DESC_TXT = aDto.descTxt;

                data.OBJECT_ID     = aDto.objectID;
                data.ACTIVE_YN     = aDto.IsActive ? "Y" : "N";
                data.CREATE_BY_UID = aDto.createByUid;
                data.CREATE_ON_DTS = aDto.createOnDts;
                data.UPDATE_BY_UID = aDto.updateByUid;
                data.UPDATE_ON_DTS = aDto.updateOnDts;

                // persist object and save changes
                ctx.DbContext.SI_SERVER_TAB.Add (data);
                ctx.DbContext.SaveChanges();

                aDto.objectID       = data.OBJECT_ID;
                aDto.createByUid    = aDto.updateByUid = data.CREATE_BY_UID;
                aDto.createOnDts    = aDto.updateOnDts = data.CREATE_ON_DTS;
                aDto.versionKey     = data.ORA_ROWSCN;
            }
#endif
            return aDto;
        }

        /// <summary>
        /// update an item in persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_SI_SERVER UpdateItem (D_SI_SERVER aDto)
        {
#if (TODO)
            using (var ctx = DbContextManager<CheckSomeEntities>.GetManager("CheckSomeEntities"))
            {
                var data = ctx.DbContext.SI_SERVER_TAB.Find (aDto.objectID);

                // compare versions
                if (! aDto.IsVersionKey (data.ORA_ROWSCN))
                    throw new Exception ("version key mismatch");

                // update persisted object
                data.CHAIN_NM = aDto.chainNm;
                data.DESC_TXT = aDto.descTxt;

                data.ACTIVE_YN     = aDto.IsActive ? "Y" : "N";
                data.CREATE_BY_UID = aDto.createByUid;
                data.CREATE_ON_DTS = aDto.createOnDts;
                data.UPDATE_BY_UID = aDto.updateByUid;
                data.UPDATE_ON_DTS = aDto.updateOnDts;

                // save changes
                ctx.DbContext.SaveChanges();

                aDto.updateByUid    = data.UPDATE_BY_UID;
                aDto.updateOnDts    = data.UPDATE_ON_DTS;
                aDto.versionKey     = data.ORA_ROWSCN;
            }
#endif
            return aDto;
        }

        /// <summary>
        /// remove an item from persistent store
        /// </summary>
        /// <param name="aKey"></param>
        public void DeleteItem (K_SI_SERVER aKey)
        {
#if (TODO)
            using (var ctx = DbContextManager<CheckSomeEntities>.GetManager("CheckSomeEntities"))
            {
                var data = ctx.DbContext.SI_SERVER_TAB.Find (aKey.objectID);

                ctx.DbContext.SI_SERVER_TAB.Remove(data);
                ctx.DbContext.SaveChanges();
            }
#endif
        }
    }
}