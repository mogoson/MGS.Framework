/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LaunchController.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/08/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using Business.Generic;
using UnityEngine;

namespace Business.Launch
{
    class LaunchController : MonoBehaviour
    {
        [SerializeField] LaunchBusiness business;
        LoadingUI loadingUI;

        private void Start()
        {
            loadingUI = GameManager.UIManager.CreateIfNotFind<LoadingUI>();
            loadingUI.Refresh("Launching...");
            loadingUI.Show();
            business.LaunchAsync(OnLaunchFinished);
        }

        void OnLaunchFinished(Exception error)
        {
            loadingUI.Close();
            if (error == null)
            {
                Destroy(business.gameObject);
                Destroy(gameObject);

                GameManager.UIManager.CreateIfNotFind<SystemUI>();
                business.LaunchFinish();
            }
            else
            {
                var message = $"Launch failed: {error.Message}\r\nPlease restart to try.";
                var messageUI = GameManager.UIManager.CreateIfNotFind<MessageUI>();
                messageUI.Refresh("Launch Error", message, "OK", GameManager.Application.Quit);
                messageUI.Show();
            }
        }
    }
}