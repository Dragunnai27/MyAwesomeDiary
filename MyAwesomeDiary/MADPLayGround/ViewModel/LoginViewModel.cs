using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADPLayGround.ViewModel
{
    class LoginViewModel
    {
        public User CurrentUser { get; set; }
        public LoginViewModel()
        {

        }
        public bool Login(string id, string password)
        {
            return false;
        }
        private bool CheckID(string id) => false;
        private bool ValidateID(string id) => false;
        private bool ValidatePassword(string id) => false;
        public void Register(string id, string password)
        {

        }
        private void Hashing()
        {

        }
        private byte[] GetSalt()
        {
            return new byte[16];
        }
        private void RegisterSuccess()
        {

        }
    }    
}
