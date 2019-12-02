using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SysInfo.Library.Domain;

namespace SysInfo_Wpf.ViewModels
{
    public interface IMainWindow_ViewModel
    {
        SI_Domain_EditList      DomainList      { get; }
        SI_Server_EditList      ServerList      { get; }
        SI_Application_EditList ApplicationList { get; }
        SI_Database_EditList    DatabaseList    { get; }

        void Refresh();
    }

    public class MainWindow_ViewModel : IMainWindow_ViewModel
    {
        public SI_Domain_EditList _DomainList;
        public SI_Domain_EditList  DomainList
        { 
            get
            {
                if (_DomainList == null)
                    _DomainList = SI_Domain_EditList.GetList();

                return _DomainList;
            }
            
        }

        public SI_Server_EditList _ServerList;
        public SI_Server_EditList  ServerList
        {
            get
            {
                if (_ServerList == null)
                    _ServerList = SI_Server_EditList.GetList();

                return _ServerList;
            }

        }

        public SI_Application_EditList _ApplicationList;
        public SI_Application_EditList  ApplicationList
        {
            get
            {
                if (_ApplicationList == null)
                    _ApplicationList = SI_Application_EditList.GetList();

                return _ApplicationList;
            }

        }

        public SI_Database_EditList _DatabaseList;
        public SI_Database_EditList  DatabaseList
        {
            get
            {
                if (_DatabaseList == null)
                    _DatabaseList = SI_Database_EditList.GetList();

                return _DatabaseList;
            }

        }

        public MainWindow_ViewModel ()
        {
            Console.WriteLine ("Index_ViewModel Constructor Executing");
        }

        public void Refresh ()
        {
            _DomainList = SI_Domain_EditList.GetList();
        }
    }
}
