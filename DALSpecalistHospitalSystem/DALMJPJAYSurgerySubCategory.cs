using DOSpecalistHospitalSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DALSpecalistHospitalSystem
{
  

    public class DALMJPJAYSurgerySubCategory
    {
        private SqlConnection conn;
        private SqlCommand Cmd;
        public bool IsValidConnection;



        private string SP_Procedure = "SP_MJPJAY_SubCategory";
        private string Table_Name = "MJPJAY_SubCategory";
        private string Primary_Key = "ID";

        public DALMJPJAYSurgerySubCategory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet Load(DOMJPJAY_SubCategory Obj1)
        {
            DataSet DS = new DataSet();
            return DS = DBCommon.ExecuteDataset(DBCommon.OpenConnection(), SP_Procedure, true, Obj1.SQLParameters);
        }

        public DOMJPJAY_SubCategory Loaddr(DOMJPJAY_SubCategory Obj1)
        {
            SqlDataReader dr;

            dr = DBCommon.ExecuteDataReader(DBCommon.OpenConnection(), CommandType.StoredProcedure, SP_Procedure, Obj1.SQLParameters);
            DOMJPJAY_SubCategory objDOMJPJAY_SubCategory = new DOMJPJAY_SubCategory(dr);
            return objDOMJPJAY_SubCategory;
            dr.Close();
            dr.Dispose();
            objDOMJPJAY_SubCategory = null;
        }

        public void Save(DOMJPJAY_SubCategory Obj1, bool IsNew)
        {
            if (IsNew)
            {
                CallInsert(Obj1);

            }
            else
            {
                CallUpdate(Obj1);
            }
            Obj1 = null;
        }

        private void CallInsert(DOMJPJAY_SubCategory Obj1)
        {
            DBCommon.ExecuteNonQuery(DBCommon.OpenConnection(), SP_Procedure, true, Obj1.SQLParameters);
        }

        private void CallUpdate(DOMJPJAY_SubCategory Obj1)
        {
            DBCommon.ExecuteNonQuery(DBCommon.OpenConnection(), SP_Procedure, true, Obj1.SQLParameters);
        }

        public void Delete(DOMJPJAY_SubCategory Obj1)
        {
            DBCommon.ExecuteNonQuery(DBCommon.OpenConnection(), SP_Procedure, true, Obj1.SQLParameters);
        }
        public int GetMaxCount()
        {
            int i = DBCommon.GetMaxId(Table_Name, Primary_Key);
            return i + 1;
        }
    }
}
