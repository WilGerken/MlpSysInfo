using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysInfo.Library.Common
{
    public class CS_Exception : Exception
    {
        protected static string BuildMessage (string aPrefix, Exception ex)
        {
            string lMsg = string.Format ("{0}: {1}", aPrefix, ex.Message);

            Exception lInnerEx = ex.InnerException;

            while (lInnerEx != null)
            {
                lMsg = string.Format ("{0} <{1}>", lMsg, lInnerEx.Message);

                lInnerEx = lInnerEx.InnerException;
            }

            return lMsg;
        }

        public string MethodNm { get; set; }
        public CS_Exception (string aMethodNm, string aMessage) : 
            base (aMessage)
        {
            MethodNm = aMethodNm;
        }

        public CS_Exception (string aMethodNm, string aMessage, Exception ex) : 
            base (BuildMessage (aMessage, ex), ex)
        {
            MethodNm = aMethodNm;
        }
    }

    public class CS_ConnectException : CS_Exception
    {
        public string ConnectTxt { get; set; }

        public CS_ConnectException (string aMethodNm, string aMessage, string aConnectTxt) : 
            base (aMethodNm, aMessage)
        {
            ConnectTxt = aConnectTxt;
        }

        public CS_ConnectException (string aMethodNm, string aMessage, string aConnectTxt, Exception ex) : 
            base (aMethodNm, BuildMessage (aMessage, ex), ex)
        {
            ConnectTxt = aConnectTxt;
        }
    }

    public class CS_CommandException : CS_Exception
    {
        public string CommandTxt { get; set; }
        public CS_CommandException (string aMethodNm, string aMessage, string aCommandTxt) : 
            base (aMethodNm, aMessage)
        {
            CommandTxt = aCommandTxt;
        }

        public CS_CommandException (string aMethodNm, string aMessage, string aCommandTxt, Exception ex) : 
            base (aMethodNm, BuildMessage (aMessage, ex), ex)
        {
            CommandTxt = aCommandTxt;
        }
    }
}
