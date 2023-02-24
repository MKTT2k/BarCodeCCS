using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_CCSTape.DAL
{
    class DataConnection
    {
        #region Binding Data
        public SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=CCSTAPE;Integrated Security=True");
        }

        public DataTable GetTable(string sql)
        {
            SqlConnection conn = GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public void ExecuteNonQuery(String sql)
        {
            try
            {
                SqlConnection conn = GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        public DataTable get_Equipment()
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("get_Equipment", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader reader = sqlCommand.ExecuteReader();
                DataTable table = new DataTable();
                if (reader.HasRows)
                {
                    table.Load(reader);
                }
                return table;
            }
        }

        public DataTable get_LotFPCB(string tray_num)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("get_LotFPCB", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@tray_num", tray_num);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                DataTable table = new DataTable();
                if (reader.HasRows)
                {
                    table.Load(reader);
                    return table;
                }
                return null;
            }
        }

        public DataTable get_FPCB(string tray_num)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("get_FPCB", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@tray_num", tray_num);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                DataTable table = new DataTable();
                if (reader.HasRows)
                {
                    table.Load(reader);
                    return table;
                }
                return new DataTable();
            }
        }

        public DataTable get_FPCBAfterCCS(string tray_num)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("get_FPCBAfterCSS", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@tray_num", tray_num);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                DataTable table = new DataTable();
                if (reader.HasRows)
                {
                    table.Load(reader);
                    return table;
                }
                return null;
            };
        }

        public DataTable search_FPCB_Scan(string tray_num, string prod_serial)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("search_FPCB_Scan", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@tray_num", tray_num);
                sqlCommand.Parameters.AddWithValue("@prod_serial", prod_serial);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                DataTable table = new DataTable();
                if (reader.HasRows)
                {
                    table.Load(reader);
                    return table;
                }
                return null;
            };
        }
        #endregion

        #region CRUD
        public void add_FPCBCCS(string tray_num, string equip, string serial, string code, string orderno, 
                                string pcb_lot, string fpcb_lot, string tape1, string tape2, string tape3, 
                                string tape4, string tape5)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand("add_FPCBCCS", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@tray_num", tray_num);
                    sqlCommand.Parameters.AddWithValue("@line", equip);
                    sqlCommand.Parameters.AddWithValue("@serial", serial);
                    sqlCommand.Parameters.AddWithValue("@code", code);
                    sqlCommand.Parameters.AddWithValue("@orderno", orderno);
                    sqlCommand.Parameters.AddWithValue("@pcb_lot", pcb_lot);
                    sqlCommand.Parameters.AddWithValue("@fpcb_lot", fpcb_lot);
                    sqlCommand.Parameters.AddWithValue("@tape1", tape1);
                    sqlCommand.Parameters.AddWithValue("@tape2", tape2);
                    sqlCommand.Parameters.AddWithValue("@tape3", tape3);
                    sqlCommand.Parameters.AddWithValue("@tape4", tape4);
                    sqlCommand.Parameters.AddWithValue("@tape5", tape5);

                    sqlCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
