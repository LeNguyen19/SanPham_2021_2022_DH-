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
    public class fbLichChay
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

        public static async Task<PT_LichChay> FirebaseGetThongTinLichChay(IFirebaseClient client, string rootName)
        {
            if (client != null)
            {
                FirebaseResponse response = await client.GetAsync(rootName);
                return response.ResultAs<PT_LichChay>();
            }
            return null;
        }
        public static async Task<List<PT_LichChay>> GetThongTinLichChay()
        {
            IFirebaseClient client = CreateFirebaseClient();

            List<PT_LichChay> ds = new List<PT_LichChay>();

            int i = 1;
            bool co = true;
            while (co)
            {
                try
                {
                    PT_LichChay tk = await FirebaseGetThongTinLichChay(client, "LichChay/" + i.ToString() + "/");
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


        public static async Task<bool> ThemLichChay(PT_LichChay pLichChay, int stt)
        {
            IFirebaseClient client = CreateFirebaseClient();
            try
            {
                if (pLichChay != null)
                {

                    string rootName = string.Format("LichChay/{0}", stt);

                    FirebaseInsertData(client, pLichChay, rootName);

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> XoaLichChay(PT_LichChay pLichChay, int stt)
        {
            IFirebaseClient client = CreateFirebaseClient();
            try
            {
                string rootName = string.Format("LichChay/{0}", stt);

                FirebaseUpdateData(client, pLichChay, rootName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> SuaLichChay(PT_LichChay pLichChay, int stt)
        {
            IFirebaseClient client = CreateFirebaseClient();
            try
            {
                if (pLichChay != null)
                {

                    string rootName = string.Format("LichChay/{0}", stt);

                    FirebaseUpdateData(client, pLichChay, rootName);

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
