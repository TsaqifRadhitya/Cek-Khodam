using System;
using System.Resources;

namespace Cek_Khodam
{
    public class DATA_KHODAM
    {
        public static string[] DATA = { "Harimau Waria"
                ,"Elang Perak"
                ,"Kucing Garong"
                ,"Beruang Korup"
                ,"Kelinci VPN"
                ,"Nyi Blorong"
                ,"Macan Kumbang"
                ,"Kris Emas"
                ,"Putri Ratu"
                ,"Mahkota Raja"
                ,"Gajah Tunggal"
                ,"Tuyul Mulet"
                ,"Kucing Wakanda"};
        public static string Nama_Khodam()
        {
            Random rand = new Random();
            int index = rand.Next(DATA_KHODAM.DATA.Length);
            return DATA_KHODAM.DATA[index];
        }
    }
}
