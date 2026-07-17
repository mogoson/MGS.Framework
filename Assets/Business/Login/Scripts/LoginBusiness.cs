/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LoginBusiness.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/09/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections;
using Business.Generic;
using UnityEngine;

namespace Business.Login
{
    class LoginBusiness : MonoBehaviour
    {
        public void LoginAsync(string userName, string password, Action<Exception> finished)
        {
            IEnumerator LoginSample(Action<Exception> finished)
            {
                yield return new WaitForSeconds(3.0f);
                finished?.Invoke(null);
            }
            StartCoroutine(LoginSample(OnLoginFinish));

            void OnLoginFinish(Exception error)
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
    }
}