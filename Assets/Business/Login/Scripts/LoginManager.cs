using System;
using System.Collections;
using Business.Generic;
using UnityEngine;

namespace Business.Login
{
    public class LoginManager : MonoBehaviour
    {
        #region Config
        public AccountConfig GetAccountConfig()
        {
            return GameData.PlayerConfig.Data.account;
        }

        public void SetAccountConfig(string userName, string password)
        {
            GameData.PlayerConfig.Data.account.username = userName;
            GameData.PlayerConfig.Data.account.password = password;
            GameData.PlayerConfig.Push();
        }
        #endregion

        #region Login
        public void Login(string userName, string password, Action<Exception> finished)
        {
            IEnumerator LoginAsync(Action<Exception> onFinished)
            {
                yield return new WaitForSeconds(3.0f);
                onFinished?.Invoke(null);
            }
            StartCoroutine(LoginAsync(OnLogin));
            void OnLogin(Exception error)
            {
                if (error == null)
                {
                    OnLoginSucceed(userName);
                }
                finished?.Invoke(error);
            }
        }

        void OnLoginSucceed(string userName)
        {
            GameData.PlayerData.UserName = userName;

            //Set more info...
        }

        public void FinishLogin()
        {
            GameManager.SceneManager.EnterScene(BusinessScene.Main);
        }
        #endregion
    }
}