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
    public class fbXe
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

        public static async Task<Xe> FirebaseGetThongTinXe(IFirebaseClient client, string rootName)
        {
            if (client != null)
            {
                FirebaseResponse response = await client.GetAsync(rootName);
                return response.ResultAs<Xe>();
            }
            return null;
        }
        public static async Task<List<Xe>> GetThongTinXe()
        {
            IFirebaseClient client = CreateFirebaseClient();

            List<Xe> ds = new List<Xe>();

            int i = 1;
            bool co = true;
            while (co)
            {
                try
                {
                    Xe tk = await FirebaseGetThongTinXe(client, "Xe/" + i.ToString() + "/");
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


        public static async Task<bool> ThemXe(Xe pXe, int stt)
        {
            IFirebaseClient client = CreateFirebaseClient();
            try
            {
                if (pXe != null)
                {

                    string rootName = string.Format("Xe/{0}", stt);

                    FirebaseInsertData(client, pXe, rootName);

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> XoaXe(Xe pXe, int stt)
        {
            IFirebaseClient client = CreateFirebaseClient();
            try
            {
                string rootName = string.Format("Xe/{0}", stt);

                FirebaseUpdateData(client, pXe, rootName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> SuaXe(Xe pXe, int stt)
        {
            IFirebaseClient client = CreateFirebaseClient();
            try
            {
                if (pXe != null)
                {

                    string rootName = string.Format("Xe/{0}", stt);

                    FirebaseUpdateData(client, pXe, rootName);

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
