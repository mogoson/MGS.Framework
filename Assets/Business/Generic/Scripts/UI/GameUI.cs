/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GameUI.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  05/31/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using MGS.Singleton;
using UnityEngine;

namespace Business.Generic
{
    public class GameUI : MonoSingleton<GameUI>
    {
        [SerializeField] LoadingUI loadingUI;
        [SerializeField] DialogUI dialogUI;

        #region Life Cycle
        void Awake()
        {
            SubscribeAppMessage();
            SubscribeSceneMessage();
        }

        void OnDestroy()
        {
            UnsubscribeAppMessage();
            UnsubscribeSceneMessage();
        }
        #endregion

        #region App Message
        void SubscribeAppMessage()
        {
            GameManager.MessageBus.Subscribe<AppQuitAskMessage>(OnAppQuitAsk);
        }

        void UnsubscribeAppMessage()
        {
            GameManager.MessageBus.Unsubscribe<AppQuitAskMessage>(OnAppQuitAsk);
        }

        void OnAppQuitAsk(AppQuitAskMessage message)
        {
            ShowQuitDialogUI(OnCallback);
            void OnCallback(bool yes)
            {
                if (yes)
                {
                    GameManager.Application.Quit();
                }
            }
        }
        #endregion

        #region Scene Message
        void SubscribeSceneMessage()
        {
            GameManager.MessageBus.Subscribe<EnterSceneStartMessage>(OnEnterSceneStart);
            GameManager.MessageBus.Subscribe<EnterSceneProgressMessage>(OnEnterSceneProgress);
            GameManager.MessageBus.Subscribe<EnterSceneFinishedMessage>(OnEnterSceneFinished);
        }

        void UnsubscribeSceneMessage()
        {
            GameManager.MessageBus.Unsubscribe<EnterSceneStartMessage>(OnEnterSceneStart);
            GameManager.MessageBus.Unsubscribe<EnterSceneProgressMessage>(OnEnterSceneProgress);
            GameManager.MessageBus.Unsubscribe<EnterSceneFinishedMessage>(OnEnterSceneFinished);
        }

        void OnEnterSceneStart(EnterSceneStartMessage message)
        {
            ShowLoadingUI($"Loading {message.scene} Scene...");
        }

        void OnEnterSceneProgress(EnterSceneProgressMessage message)
        {
            ShowLoadingUI(message.progress);
        }

        void OnEnterSceneFinished(EnterSceneFinishedMessage message)
        {
            QuitLoadingUI();
        }
        #endregion

        #region LoadingUI
        public void ShowLoadingUI()
        {
            ShowLoadingUI("Loading...");
        }

        public void ShowLoadingUI(string message)
        {
            loadingUI.Refresh(message);
            loadingUI.gameObject.SetActive(true);
        }

        public void ShowLoadingUI(float progress)
        {
            loadingUI.Refresh(progress);
            loadingUI.gameObject.SetActive(true);
        }

        public void QuitLoadingUI()
        {
            loadingUI.gameObject.SetActive(false);
        }
        #endregion

        #region DialogUI
        public void ShowDialogUI(string tittle, string message, string yes, string no, Action<bool> callback)
        {
            dialogUI.Refresh(tittle, message, yes, no, callback);
            dialogUI.gameObject.SetActive(true);
        }

        public void ShowQuitDialogUI(Action<bool> callback)
        {
            ShowDialogUI("Quit", "Are you sure quit the system?", "Yes", "No", callback);
        }

        public void QuitDialogUI()
        {
            dialogUI.gameObject.SetActive(false);
        }
        #endregion
    }
}