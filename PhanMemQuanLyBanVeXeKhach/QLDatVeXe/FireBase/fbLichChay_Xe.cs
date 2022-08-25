using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;

namespace FireBase
{
    public class fbLichChay_Xe
    {
        public static IFirebaseClient CreateFirebaseClient()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "SRAPt25tpzURIvwVHJGRFqc963Lr30un1pqXqD9L",
                BasePath = "https://dbquanlynhaxe-default-rtdb.asia-southeast1.firebasedatabase.app"
            };

            IFirebaseClient client;

            client = new FireSharp.FirebaseClient(config);
            return client;
        }

        public static async Task<PT_LichChay_Xe> FirebaseGetThongTinLichChay_Xe(IFirebaseClient client, string rootName)
        {
            if (client != null)
            {
                FirebaseResponse response = await client.GetAsync(rootName);
                return response.ResultAs<PT_LichChay_Xe>();
            }
            return null;
        }
        public static async Task<List<PT_LichChay_Xe>> GetThongTinLichChay_Xe()
        {
            IFirebaseClient client = CreateFirebaseClient();

            List<PT_LichChay_Xe> ds = new List<PT_LichChay_Xe>();

            int i = 1;
            bool co = true;
            while (co)
            {
                try
                {
                    PT_LichChay_Xe tk = await FirebaseGetThongTinLichChay_Xe(client, "LichChay_Xe/" + i.ToString() + "/");
                    if (tk == null)
                    {
                        co = false;
                        break;
                    }
                    i++;
                    ds.Add(tk);
                }
                catch (Exception ex)
                {
                    co = false;
                }
            }
            return ds;

        }


        public static async Task<bool> ThemLichChay_Xe(PT_LichChay_Xe pLichChay_Xe, int stt)
        {
            IFirebaseClient client = CreateFirebaseClient();
            try
            {
                if (pLichChay_Xe != null)
                {

                    string rootName = string.Format("LichChay_Xe/{0}", stt);

                    FirebaseInsertData(client, pLichChay_Xe, rootName);

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> XoaLichChay_Xe(PT_LichChay_Xe pLichChay_Xe, int stt)
        {
            IFirebaseClient client = CreateFirebaseClient();
            try
            {
                string rootName = string.Format("LichChay_Xe/{0}", stt);

                FirebaseUpdateData(client, pLichChay_Xe, rootName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> SuaLichChay_Xe(PT_LichChay_Xe pLichChay_Xe, int stt)
        {
            IFirebaseClient client = CreateFirebaseClient();
            try
            {
                if (pLichChay_Xe != null)
                {

                    string rootName = string.Format("LichChay_Xe/{0}", stt);

                    FirebaseUpdateData(client, pLichChay_Xe, rootName);

                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static async void FirebaseInsertData(IFirebaseClient client, object data, string rootName)
        {
            if (client != null)
            {
                await client.SetAsync(rootName, data);
            }
        }

        public static async void FirebaseDeleteData(IFirebaseClient client, string rootName)
        {
            if (client != null)
            {
                await client.DeleteAsync(rootName);
            }
        }

        public static async void FirebaseUpdateData(IFirebaseClient client, object data, string rootName)
        {
            if (client != null)
            {
                await client.UpdateAsync(rootName, data);
            }
        }
    }
}
