using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Xml;

namespace MyIdentity
{
    public static class LocalDataManager
    {
        private static readonly string location;
        static LocalDataManager()
        {
            location = AppDomain.CurrentDomain.BaseDirectory + "LocalData.xml";
            bool IsHasLocalFile = File.Exists(location);

            if (!IsHasLocalFile)
            {
                XDocument xml = new XDocument();
                XElement AuthorizedUser = new XElement("AuthorizeUser");
                XElement AuthUserName = new XElement("AuthUserName", "null");
                AuthorizedUser.Add(AuthUserName);
                xml.Add(AuthorizedUser);
                xml.Save("LocalData.xml");
            }
        }
        public static string CurrentUserName
        {
            get
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(location);
                XmlNode UserNameNode = xml.DocumentElement.SelectSingleNode("AuthUserName");
                if (!UserNameNode.Equals("null"))
                    return UserNameNode.InnerText;
                else
                    return null;
            }
        }

        public static void WriteAuthorizedUser(string userName)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(location);
            XmlNode UserNameNode = xml.DocumentElement.SelectSingleNode("AuthUserName");
            UserNameNode.InnerText = userName;
            xml.Save("LocalData.xml");
        }
    }
}
