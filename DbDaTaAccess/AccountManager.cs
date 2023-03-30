using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDaTaAccess
{
    public class AccountManager : IAccount
    {
        public Account GetAccountById(int IdAccount)
        {
            throw new NotImplementedException();
        }



        public Account Check_GetAccountByName(Account AccountInputTruyen)
        {
            var tkhoanStoreLayRa = new Account();
            try
            {
                // kn
                var connect = ConnectSqlSeverDb.GetSqlConnection();
                //cmd
                SqlCommand cmd = new SqlCommand("St_CheckAccount", connect);
                cmd.Parameters.AddWithValue("@name_tk", AccountInputTruyen.Account_Name);
                cmd.Parameters.AddWithValue("@passWords", AccountInputTruyen.PassWord_Acc);
                //
                cmd.Parameters.AddWithValue("@ResponseCode", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();

                var responseCode = cmd.Parameters["@ResponseCode"].Value != null ? Convert.ToInt32(cmd.Parameters["@ResponseCode"].Value) : 0;
                
                tkhoanStoreLayRa.IDAccount = responseCode;

                return tkhoanStoreLayRa;
            }
            catch (Exception Ex)
            {
                return tkhoanStoreLayRa;
            }
         
        }
    }
}
