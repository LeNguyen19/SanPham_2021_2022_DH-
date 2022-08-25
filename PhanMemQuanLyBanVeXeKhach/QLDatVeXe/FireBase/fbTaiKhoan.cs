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
    public class fbTaiKhoan
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

        public static async Task<Model_TaiKhoan> FirebaseGetThongTinKhoa(IFirebaseClient client, string rootName)
        {
            if (client != null)
            {
                FirebaseResponse response = await client.GetAsync(rootName);
                return response.ResultAs<Model_TaiKhoan>();
            }
            return null;
        }
        public static async Task<List<Model_TaiKhoan>> GetThongTinTaiKhoan()
        {
            IFirebaseClient client = CreateFirebaseClient();

            List<Model_TaiKhoan> ds = new List<Model_TaiKhoan>();

            int i = 1;
            bool co = true;
            while (co)
            {
                try
                {
                    Model_TaiKhoan tk = await FirebaseGetThongTinKhoa(client, "TaiKhoan/" + i.ToString() + "/");
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


        public static async Task<bool> ThemTaiKhoan(Model_TaiKhoan pTaiKhoan, int stt)
        {
            IFirebaseClient client = CreateFirebaseClient();
            try
            {
                if (pTaiKhoan != null)
                {

                    string rootName = string.Format("TaiKhoan/{0}", stt);

                    FirebaseInsertData(client, pTaiKhoan, rootName);

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> XoaTaiKhoan(Model_TaiKhoan pTaiKhoan, int stt)
        {
            IFirebaseClient client = CreateFirebaseClient();
            try
            {
                string rootName = string.Format("TaiKhoan/{0}", stt);

                FirebaseUpdateData(client, pTaiKhoan, rootName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> SuaTaiKhoan(Model_TaiKhoan pTaiKhoan, int stt)
        {
            IFirebaseClient client = CreateFirebaseClient();
            try
            {
                if (pTaiKhoan != null)
                {

                    string rootName = string.Format("TaiKhoan/{0}", stt);

                    FirebaseUpdateData(client, pTaiKhoan, rootName);

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
