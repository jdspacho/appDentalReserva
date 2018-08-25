using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App4.Data;
using App4.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace App4.Services
{
    public class UsersService
    {
        private UsersRepository _usersRepository;
        public UsersService()
        {
            _usersRepository = new UsersRepository();

        }
        public List<Users>GetUsers()
        {
            return _usersRepository.GetUsers();
        }
        public Users GetUsersAutentication(string Correo, string Password)
        {
            return _usersRepository.GetUsersAutentication(Correo,Password);
        }
        public bool GetUsersAutenticationBool(string Correo, string Password)
        {
            if (_usersRepository.GetUsersAutentication(Correo, Password) == null)
            {
                return false;
            }
            return true;
        }
        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Please turn on your internet settings.",
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable(
                "google.com");
            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Check you internet connection.",
                };
            }

            return new Response
            {
                IsSuccess = true,
                Message = "Ok",
            };
        }

    }
}