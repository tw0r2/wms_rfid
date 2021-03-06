﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using THOK.Util;
using THOK.Wms.DownloadWms.Dao;

namespace THOK.Wms.DownloadWms.Bll
{
   public class AddXmlValueBll
    {
       public void insert(string id,string xml)
       {
           using (PersistentManager dbpm = new PersistentManager())
           {
               string sql = @"DELETE WMS_XML_VALUE WHERE [DATETIME]<DATEADD(DAY, -3, CONVERT(VARCHAR(14), GETDATE(), 112)) 
                              INSERT INTO WMS_XML_VALUE(ID,DateTime,XmlValue)VALUES('" + Guid.NewGuid() + "_" + id + "','" + DateTime.Now + "','" + xml + "')";
               AddXmlValueDao dao = new AddXmlValueDao();
               dao.Insert(sql);
           }
       }
    }
}
