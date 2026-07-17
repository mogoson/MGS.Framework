/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LoginController.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/09/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using Business.Generic;
using MGS.MonoUI;
using UnityEngine;

namespace Business.Login
{
    class LoginController : MonoBehaviour
    {
        [SerializeField] MonoUIManager UI;
        [SerializeField] LoginBusiness business;

        LoginUI loginUI;
        LoadingUI loadingUI;
        string userName;

        private void Start()
        {
            loginUI = UI.Create<LoginUI>();
            loginUI.OnLoginEvent += OnLogin;

            var playerCfg = GameData.PlayerConfig.Data;
            loginUI.SetInput(playerCfg.userName, string.Empty);
        }

        void OnLogin(string userName, string password)
        {
            this.userName = userName;

            loadingUI = GameManager.UIManager.CreateIfNotFind<LoadingUI>();
            loadingUI.Refresh("Login...");
            loadingUI.Show();
            business.LoginAsync(userName, password, OnLoginFinished);
        }

        void OnLoginFinished(Exception error)
        {
            loadingUI.Close();
            loginUI.OnLoginResult(error);
            if (error == null)
            {
                loginUI.Close();

                //If remember.
                if (GameData.PlayerConfig.Data.userName != userName)
                {
                    GameData.PlayerConfig.Data.userName = userName;
                    GameData.PlayerConfig.Push();
                }
                GameManager.SceneManager.EnterScene(BusinessScene.Lobby);
            }
        }
    }
}