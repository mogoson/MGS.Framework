/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LaunchBusiness.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  06/26/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using Business.Generic;
using MGS.StreamingPorter;
using UnityEngine;

namespace Business.Launch
{
    class LaunchBusiness : MonoBehaviour
    {
        public void LaunchAsync(Action<Exception> finished)
        {
            TransportAsync(finished);

            //Do more things...
        }

        public void LaunchFinish()
        {
            GameManager.SceneManager.EnterSceneAsync(BusinessScene.Login);
        }

        #region Transport
        void TransportAsync(Action<Exception> finished)
        {
            StreamingPorter.TransportAsync(OnTransport);
            void OnTransport(string version, Exception error)
            {
                if (error == null)
                {
                    if (!string.IsNullOrEmpty(version))
                    {
                        Debug.Log($"The porter transport streaming assets to persistent path for version {version}");
                    }
                    finished?.Invoke(null);
                }
                else
                {
                    Debug.LogError($"The porter transport error: {error.Message}");
                    finished?.Invoke(error);
                }
            }
        }
        #endregion
    }
}