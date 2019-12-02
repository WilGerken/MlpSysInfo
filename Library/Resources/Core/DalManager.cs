using System;

namespace SysInfo.Library.Resources.Core
{
    public class DalManager : IDalManager
    {
        public T GetProvider<T>() where T : class
        {
            var lName = typeof(T).FullName.Replace ("I_SI", "Memory.SI");
            //var lName = typeof(T).FullName.Replace ("I_S", "SqlServer.S");
            var lType = Type.GetType (lName);

            if (lType != null)
                return Activator.CreateInstance (lType) as T;
            else
                throw new NotImplementedException (lName);
        }

        public void Dispose() { }
    }
}
