/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LaunchManager.cs
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
    internal class LaunchManager : MonoBehaviour
    {
        public event Action OnStartEvent;
        public event Action<Exception> OnFinishEvent;

        private void Start()
        {
            OnStartEvent?.Invoke();
            Initialize(Finished);
            void Finished(Exception error)
            {
                OnFinishEvent?.Invoke(error);
                Destroy(gameObject);
                if (error == null)
                {
                    GameManager.SceneManager.EnterScene(BusinessScene.Login);
                }
            }
        }

        void Initialize(Action<Exception> finished)
        {
            TransportAsset(finished);

            //Do more things...
        }

        #region Transport
        void TransportAsset(Action<Exception> finished)
        {
            StreamingPorter.TransportAsync(OnTransport);
            void OnTransport(string version, Exception error)
            {
                GameUI.Instance.QuitLoadingUI();
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