/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LoginUI.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  06/12/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using Business.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Business.Login
{
    public class LoginUI : MonoBehaviour
    {
        [SerializeField] LoginManager manager;

        [Space]
        [SerializeField] InputField iptUser;
        [SerializeField] InputField iptPwd;

        [Space]
        [SerializeField] Button btnClear;
        [SerializeField] Toggle togRemember;
        [SerializeField] Button btnForget;

        [Space]
        [SerializeField] Button btnLogin;
        [SerializeField] Text texMsg;

        private void Awake()
        {
            btnClear?.onClick.AddListener(OnBtnClearClick);
            btnForget?.onClick.AddListener(OnBtnForgetClick);
            btnLogin.onClick.AddListener(OnBtnLoginClick);
        }

        private void Start()
        {
            var account = manager.GetAccountConfig();
            SetAccountInput(account.username, account.password);
        }

        void OnBtnClearClick()
        {
            SetAccountInput(string.Empty, string.Empty);
        }

        void OnBtnForgetClick()
        {
            togRemember.isOn = false;
            SetAccountInput(string.Empty, string.Empty);
            manager.SetAccountConfig(null, null);
        }

        void OnBtnLoginClick()
        {
            if (string.IsNullOrEmpty(iptUser.text))
            {
                texMsg.text = "User name can not be null.";
                return;
            }

            if (string.IsNullOrEmpty(iptPwd.text))
            {
                texMsg.text = "Password can not be null.";
                return;
            }

            StartLogin();
        }

        void SetAccountInput(string username, string password)
        {
            iptUser.text = username;
            iptPwd.text = password;
        }

        void StartLogin()
        {
            btnLogin.interactable = false;
            texMsg.text = string.Empty;

            GameUI.Instance.ShowLoadingUI("Login...");
            manager.Login(iptUser.text, iptPwd.text, OnLoginFinished);
        }

        void OnLoginFinished(Exception error)
        {
            btnLogin.interactable = true;
            GameUI.Instance.QuitLoadingUI();

            if (error == null)
            {
                OnLoginSucceed();
            }
            else
            {
                OnLoginFailed(error);
            }
        }

        void OnLoginSucceed()
        {
            if (togRemember != null && togRemember.isOn)
            {
                manager.SetAccountConfig(iptUser.text, iptPwd.text);
            }
            manager.FinishLogin();
        }

        void OnLoginFailed(Exception error)
        {
            texMsg.text = error.Message;
        }
    }
}