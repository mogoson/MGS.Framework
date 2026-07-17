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
using MGS.MonoUI;
using UnityEngine;
using UnityEngine.UI;

namespace Business.Login
{
    class LoginUI : MonoUI
    {
        [SerializeField] InputField iptUser;
        [SerializeField] InputField iptPwd;
        [SerializeField] Button btnLogin;
        [SerializeField] Text texMsg;

        public event Action<string, string> OnLoginEvent;

        protected override void Awake()
        {
            base.Awake();
            btnLogin.onClick.AddListener(OnBtnLoginClick);
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

        void StartLogin()
        {
            btnLogin.interactable = false;
            texMsg.text = string.Empty;
            OnLoginEvent?.Invoke(iptUser.text, iptPwd.text);
        }

        public void SetInput(string username, string password)
        {
            iptUser.text = username;
            iptPwd.text = password;
        }

        public void OnLoginResult(Exception error)
        {
            if (error == null)
            {
                return;
            }

            btnLogin.interactable = true;
            texMsg.text = error.Message;
        }
    }
}