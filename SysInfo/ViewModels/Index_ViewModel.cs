using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SysInfo.Library.Domain;

namespace SysInfo.ViewModels
{
    public interface IIndex_ViewModel
    {
        SI_Domain_EditList Domain_EditList { get; }
        void Refresh();
    }

    public class Index_ViewModel : IIndex_ViewModel
    {
        public SI_Domain_EditList _Domain_EditList;
        public SI_Domain_EditList  Domain_EditList         { 
            get
            {
                if (_Domain_EditList == null)
                    _Domain_EditList = SI_Domain_EditList.GetList();

                return _Domain_EditList;
            }
            
        }

        public Index_ViewModel ()
        {
            Console.WriteLine ("Index_ViewModel Constructor Executing");

        }

        public void Refresh ()
        {
            _Domain_EditList = SI_Domain_EditList.GetList();
        }
    }
}
