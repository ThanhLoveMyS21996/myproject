using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDaTaAccess
{
    public static class SqlDbHelper
    {
        public static List<BaiViet> GetListBaiVietByIdDanhMuc()
        {
            List<BaiViet> listBaiViet = new List<BaiViet>();
            try
            {
                //Ket Noi
                var connect = ConnectSqlSeverDb.GetSqlConnection();
                //
                SqlCommand cmd = new SqlCommand("SP_GetBaiVietByIDdanhMuc", connect);
                cmd.Parameters.AddWithValue("id_danhmuc", 2);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var duLieuNhanDc = cmd.ExecuteReader();
                while(duLieuNhanDc.Read())
                {
                    var idBViet = duLieuNhanDc["IdBaiViet"].ToString();
                    var nd_BaiViet = duLieuNhanDc["NoiDungBaiViet"].ToString() ;
                    var tacgia = duLieuNhanDc["TacGia"].ToString();
                    var idDanhMuc = duLieuNhanDc["IDDanhMuc"].ToString();
                    var baiViEtLuuTam = new BaiViet();
                    baiViEtLuuTam.TacGia = tacgia;
                    baiViEtLuuTam.IdBaiViet = Convert.ToInt32(idBViet);
                    baiViEtLuuTam.NoiDungBaiViet = nd_BaiViet;
                    baiViEtLuuTam.IDDanhMuc = Convert.ToInt32(idDanhMuc);
                    listBaiViet.Add(baiViEtLuuTam);
                }
            }
            catch (Exception Ex)
            {

                throw;
            }
            return listBaiViet;
        }
        public static int ThemMoiBaiVietByIdDanhMuc(BaiViet inputBaiViet)
        {
            int sodong = 0;
            try
            {

                //ket noi
                var connect = ConnectSqlSeverDb.GetSqlConnection();
                //
                SqlCommand cmd = new SqlCommand("SP_InSertData_tblBaiViet", connect);
                //
                cmd.Parameters.AddWithValue("@id_danhmuc",inputBaiViet.IDDanhMuc);
                cmd.Parameters.AddWithValue("@nd_baiViet",inputBaiViet.NoiDungBaiViet);
                cmd.Parameters.AddWithValue("@tac_gia",inputBaiViet.TacGia);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //thuc thi
                sodong = cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {

                throw;
            }
            return sodong;
        }

        public static int XoaBaiVietByIdBaiViet(BaiViet baiVietCanXoa)
        {
            int sodongAffected = 0;
            try
            {

                //ket noi
                var connect = ConnectSqlSeverDb.GetSqlConnection();
                //
                SqlCommand cmd = new SqlCommand("ST_DeleteByIDBaiViet_tblBaiViet", connect);
                //
                cmd.Parameters.AddWithValue("@id_baiVietXoa", baiVietCanXoa.IdBaiViet);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //thuc thi
                sodongAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {

                throw;
            }
            return sodongAffected;
        }
    }
}
