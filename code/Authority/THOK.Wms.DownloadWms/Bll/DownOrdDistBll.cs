using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using THOK.Util;
using THOK.WMS.DownloadWms.Dao;

namespace THOK.WMS.DownloadWms.Bll
{
    public class DownOrdDistBll
    {
        #region 从营销系统下载配车单信息
        /// <summary>
        /// 下载配车单信息
        /// </summary>
        /// <returns></returns>
        public bool DownOrgDistBillInfo()
        {
            bool tag = true;
            DataTable orgTable = this.QueryOrgDistCode();
            string distCodeList = UtinString.MakeString(orgTable, "DIST_BILL_ID");
            distCodeList = "DIST_BILL_ID NOT IN (" + distCodeList + ")";
            DataTable bistBillMasterTable = this.GetDistBillMaster(distCodeList);
            if (bistBillMasterTable.Rows.Count > 0)
                this.Insert(bistBillMasterTable);
            else
                tag = false;
            return tag;
        }

        /// <summary>
        /// 下载配车单主表信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDistBillMaster(string bistMaster)
        {
            using (PersistentManager dbpm = new PersistentManager("YXConnection"))
            {
                DownOrdDistDao dao = new DownOrdDistDao();
                dao.SetPersistentManager(dbpm);
                return dao.GetDistBillMaster(bistMaster);
            }
        }

        /// <summary>
        /// 下载配车单细单信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDistBillDetail(string bistDetail)
        {
            using (PersistentManager dbpm = new PersistentManager("YXConnection"))
            {
                DownOrdDistDao dao = new DownOrdDistDao();
                dao.SetPersistentManager(dbpm);
                return dao.GetDistBillDetail(bistDetail);
            }
        }

        /// <summary>
        /// 查询已下载过的配车单编码
        /// </summary>
        /// <returns></returns>
        public DataTable QueryOrgDistCode()
        {
            using (PersistentManager dbpm = new PersistentManager())
            {
                DownOrdDistDao dao = new DownOrdDistDao();
                return dao.QueryOrgDistCode();
            }
        }

        /// <summary>
        /// 把下载的数据插入数据库
        /// </summary>
        /// <param name="orgDistBillTable"></param>
        public void Insert(DataTable bistBillMasterTable)
        {
            using (PersistentManager dbpm = new PersistentManager())
            {
                DownOrdDistDao dao = new DownOrdDistDao();
                dao.Insert(bistBillMasterTable);
            }
        }
        #endregion
    }
}
