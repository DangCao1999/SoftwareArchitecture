using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClient
{
    class UserBUS
    {
        private const String FIREBASE_APP = "https://sademo-fa5ba-default-rtdb.firebaseio.com/";
        private FirebaseClient firebase = new FirebaseClient(FIREBASE_APP);

        public async Task<bool> register(User userRe)
        {
            try
            {
                //await firebase.Child("books").PostAsync(newBook); // auto-generated key
                await firebase.Child("Users").Child("code: " + userRe.code).PutAsync(userRe); // custom key
                return true;
            }
            catch { return false; }
        }


        public async Task<bool> login(User userLogin)
        {
            var userGet = await firebase.Child("Users").OnceAsync<User>();
            foreach (var user in userGet)
                if (user.Object.username.ToLower() == userLogin.username && user.Object.password == userLogin.password)
                    return true;
               return false;
        }

    }

  
}
