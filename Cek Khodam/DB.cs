using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Schema;
using Npgsql;

namespace Cek_Khodam
{
    public class DB_Connetion
    {
        public DataTable data { get; set; }
        public bool Status {get;set;}
        public string connection = "Host=localhost;Username=postgres;Password=;Database=Cek Khodam";
        public void Data_Bridge(string nama, string khodam)
        {
            NpgsqlConnection con = new NpgsqlConnection(this.connection);
            con.Open();
            NpgsqlCommand cur = new NpgsqlCommand();
            cur.Connection = con;
            cur.CommandText = $"INSERT INTO Khodam(nama,khodam) VALUES('{nama}','{khodam}')";
            cur.Prepare();
            cur.ExecuteNonQuery();
            con.Close();
        }
        public void Data_Get()
        {
            try
            {
                NpgsqlConnection con = new NpgsqlConnection(this.connection);
                con.Open();
                NpgsqlCommand cur = new NpgsqlCommand();
                cur.Connection = con;
                cur.CommandText = "Select nama,khodam,To_Char(tanggal,'dd-mm-yyyy'),To_Char(jam,'HH24:MI:SS') from khodam";
                cur.Prepare();
                NpgsqlDataReader reader = cur.ExecuteReader();
                DataTable table = new DataTable();
                table.Columns.Add("TANGGAL", typeof(string));
                table.Columns.Add("JAM",typeof(string));
                table.Columns.Add("NAME", typeof(string));
                table.Columns.Add("Khodam", typeof(string));
                while (reader.Read())
                {
                    string[] tanggal = reader.GetString(2).Split('-');
                    int max = tanggal.Length;
                    string akhir = "";
                    for(int i = 0; i < max ; i++)
                    {
                        if(i == max-1)
                            {
                                akhir += tanggal[i];
                            }
                        else
                            {
                                akhir += tanggal[i] + "-";
                            }
                    }

                    table.Rows.Add(akhir, reader.GetString(3), reader.GetString(0),reader.GetString(1));
                }
                if(table.Rows.Count > 0)
                {
                    this.data = table;
                    this.Status = true;
                }
                else
                {
                    this.Status = false;
                }
            }
            catch
            {
                this.Status = false;
            }
        }
    }
    public class DB_Store : Form
    {
        public string nama;
        public string khodam;
        public DB_Store(string nama, string khodam)
        {
            this.nama = nama;
            this.khodam = khodam;
        }
        public void send()
        {
            DB_Connetion DB = new DB_Connetion();
            DB.Data_Bridge(this.nama, this.khodam);
        }
    }
}
