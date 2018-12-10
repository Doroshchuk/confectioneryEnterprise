using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConfectioneryEnterprise.WcfService.Contract
{
    public abstract class IBaseService
    {
        protected XDocument LoadDocument(string fileName)
        {
            var file = ConfigurationManager.AppSettings[fileName];
            return XDocument.Load(file);
        }
    }
}
