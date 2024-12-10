﻿using Android.Gms.Auth.Api.SignIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using sombrero.GoogleServices;
using Android.Gms.Common;

namespace sombrero.GoogleServices
{
    public partial class GoogleAuthService
    {

        public static Activity _activity;
        public static GoogleSignInOptions _gso;
        public static GoogleSignInClient _googleSignInClient;

        private TaskCompletionSource<GoogleUserDTO> _taskCompletionSource = new TaskCompletionSource<GoogleUserDTO>();
        private Task<GoogleUserDTO> GoogleAuthentication
        {
            get => _taskCompletionSource.Task;
        }

        public GoogleAuthService()
        {
            _activity = Platform.CurrentActivity;
            //Google Auth Option
            _gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
                            .RequestIdToken(WebApiKey)
                            .RequestEmail()
                            .RequestId()
                            .RequestProfile()
                            .Build();
            

            _googleSignInClient = GoogleSignIn.GetClient(_activity, _gso);


            MainActivity.ResultGoogleAuth += MainActivity_ResultGoogleAuth;
        }


        public Task<GoogleUserDTO> AuthenticateAsync()
        {
            _taskCompletionSource = new TaskCompletionSource<GoogleUserDTO>();

            _activity.StartActivityForResult(_googleSignInClient.SignInIntent, 9001);

            return GoogleAuthentication;

        }

        private void MainActivity_ResultGoogleAuth(object sender, (bool Success, GoogleSignInAccount Account) e)
        {
            if (e.Success)
            {
                try
                {
                    var currentAccount = e.Account;

                    _taskCompletionSource.SetResult(
                        new GoogleUserDTO
                        {
                            otros=currentAccount.GrantedScopes,//
                            Email = currentAccount.Email,
                            FullName = currentAccount.DisplayName,
                            TokenId = currentAccount.IdToken,
                            UserName = currentAccount.GivenName,
                            
                        });
                }
                catch (Exception ex)
                {
                    _taskCompletionSource.SetException(ex);
                }
            }

        }

        public async Task<GoogleUserDTO> GetCurrentUserAsync()
        {
            try
            {
                var user = await _googleSignInClient.SilentSignInAsync();
                return new GoogleUserDTO
                {
                    otros=user.GrantedScopes,
                    Email = user.Email,
                    FullName = $"{user.DisplayName}",
                    TokenId = user.IdToken,
                    UserName = user.GivenName
                };

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task LogoutAsync() => _googleSignInClient.SignOutAsync();

    }
}
