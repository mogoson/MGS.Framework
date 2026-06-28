/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LaunchUI.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  06/28/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using Business.Generic;
using UnityEngine;

namespace Business.Launch
{
    internal class LaunchUI : MonoBehaviour
    {
        [SerializeField] LaunchManager manager;

        private void Awake()
        {
            manager.OnStartEvent += Manager_OnStartEvent;
            manager.OnFinishEvent += Manager_OnFinishEvent;
        }

        private void Manager_OnStartEvent()
        {
            GameUI.Instance.ShowLoadingUI("Launching...");
        }

        private void Manager_OnFinishEvent(Exception error)
        {
            GameUI.Instance.QuitLoadingUI();
            Destroy(gameObject);
            if (error == null) return;

            var message = $"Launch failed: {error.Message}\r\nPlease restart to retry.";
            GameUI.Instance.ShowDialogUI("Launch Error", message, "OK", null, OnDialog);
            void OnDialog(bool _)
            {
                GameManager.Application.Quit();
            }
        }
    }
}