using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;
//using SmartPhonesClient;
using SensorClient;

namespace SmartPhoneClient
{
    class SmartPhonesBUS2
    {
        private const String FIREBASE_APP = "https://sademo-fa5ba-default-rtdb.firebaseio.com/";
        private FirebaseClient firebase = new FirebaseClient(FIREBASE_APP);

        public void ListenFirebase(DataGridView dgvSmartPhones)
        {
            firebase.Child("Smartphones").AsObservable<SmartPhone>().Subscribe((item) => { UpdateDataGridView(dgvSmartPhones); });
        }

        private async void UpdateDataGridView(DataGridView dgvSmartPhones)
        {
            List<SmartPhone> SmartPhoness = await GetAll();
            dgvSmartPhones.BeginInvoke(new MethodInvoker(delegate { dgvSmartPhones.DataSource = SmartPhoness; })); // set asynchronous datasource
        }

        private async Task<List<SmartPhone>> GetAll()
        {
            List<SmartPhone> SmartPhoness = new List<SmartPhone>();
            var fbSmartPhoness = await firebase.Child("Smartphones").OnceAsync<SmartPhone>();
            foreach (var item in fbSmartPhoness)
                SmartPhoness.Add(item.Object);
            return SmartPhoness;
        }

        public async Task<SmartPhone> GetDetails(int code)
        {
            var fbSmartPhoness = await firebase.Child("Smartphones").OnceAsync<SmartPhone>();
            foreach (var item in fbSmartPhoness)
                if (item.Object.Code == code)
                    return item.Object;
            return null;
        }

        private async Task<String> GetKeyByCode(int code)
        {
            var fbSmartPhoness = await firebase.Child("Smartphones").OnceAsync<SmartPhone>();
            foreach (var item in fbSmartPhoness)
                if (item.Object.Code == code)
                    return item.Key;
            return null;
        }

        public async Task<List<SmartPhone>> Search(String keyword)
        {
            List<SmartPhone> SmartPhoness = new List<SmartPhone>();
            var fbSmartPhoness = await firebase.Child("Smartphones").OnceAsync<SmartPhone>();
            foreach (var item in fbSmartPhoness)
                if (item.Object.Name.ToLower().Contains(keyword.ToLower()))
                    SmartPhoness.Add(item.Object);
            return SmartPhoness;
        }

        public async Task<bool> Add(SmartPhone newSmartPhones)
        {
            try
            {
                //await firebase.Child("books").PostAsync(newBook); // auto-generated key
                await firebase.Child("Smartphones").Child("Smartphone Code: " + newSmartPhones.Code).PutAsync(newSmartPhones); // custom key
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> Update(SmartPhone newSmartPhones)
        {
            try
            {
                String key = await GetKeyByCode(newSmartPhones.Code);
                if (String.IsNullOrEmpty(key)) return false;
                await firebase.Child("Smartphones").Child(key).PutAsync(newSmartPhones);
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> Delete(int code)
        {
            try
            {
                String key = await GetKeyByCode(code);
                if (String.IsNullOrEmpty(key)) return false;
                await firebase.Child("Smartphones").Child(key).DeleteAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
