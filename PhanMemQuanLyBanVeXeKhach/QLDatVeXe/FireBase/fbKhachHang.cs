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
    public class fbKhachHang
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

        public static async Task<Model_KhachHang> FirebaseGetThongTinKhachHang(IFirebaseClient client, string rootName)
        {
            if (client != null)
            {
                FirebaseResponse response = await client.GetAsync(rootName);
                return response.ResultAs<Model_KhachHang>();
            }
            return null;
        }
        public static async Task<List<Model_KhachHang>> GetThongTinKhachHang()
        {
            IFirebaseClient client = CreateFirebaseClient();

            List<Model_KhachHang> ds = new List<Model_KhachHang>();

            int i = 1;
            bool co = true;
            while (co)
            {
                try
                {
                    Model_KhachHang tk = await FirebaseGetThongTinKhachHang(client, "KhachHang/" + i.ToString() + "/");
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


        public static async Task<bool> ThemKhachHang(Model_KhachHang pKhachHang, int stt)
        {
            IFirebaseClient client = CreateFirebaseClient();
            try
            {
                if (pKhachHang != null)
                {

                    string rootName = string.Format("KhachHang/{0}", stt);

                    FirebaseInsertData(client, pKhachHang, rootName);

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> XoaKhachHang(Model_KhachHang pKhachHang, int stt)
        {
            IFirebaseClient client = CreateFirebaseClient();
            try
            {
                string rootName = string.Format("KhachHang/{0}", stt);

                FirebaseUpdateData(client, pKhachHang, rootName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> SuaKhachHang(Model_KhachHang pKhachHang, int stt)
        {
            IFirebaseClient client = CreateFirebaseClient();
            try
            {
                if (pKhachHang != null)
                {

                    string rootName = string.Format("KhachHang/{0}", stt);

                    FirebaseUpdateData(client, pKhachHang, rootName);

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
