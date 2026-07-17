/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GenericController.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/11/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using Framework;
using UnityEngine;

namespace Business.Generic
{
    class GenericController : MonoBehaviour
    {
        LoadingUI loadingUI;

        #region Life Cycle
        private void Awake()
        {
            SubscribeAppMessage();
            SubscribeSceneMessage();
        }

        private void OnDestroy()
        {
            UnsubscribeAppMessage();
            UnsubscribeSceneMessage();
        }
        #endregion

        #region App Message
        void SubscribeAppMessage()
        {
            FrameworkEntry.MessageBus.Subscribe<AppQuitAskMessage>(OnAppQuitAsk);
        }

        void UnsubscribeAppMessage()
        {
            FrameworkEntry.MessageBus.Unsubscribe<AppQuitAskMessage>(OnAppQuitAsk);
        }

        void OnAppQuitAsk(AppQuitAskMessage message)
        {
            var dialogUI = GameManager.UIManager.CreateIfNotFind<DialogUI>();
            dialogUI.Refresh("Quit", "Are you sure quit the system?", "Yes", "Cancel", isYes =>
            {
                if (isYes)
                {
                    GameManager.Application.Quit();
                }
            });
            dialogUI.Show();
        }
        #endregion

        #region Scene Message
        void SubscribeSceneMessage()
        {
            FrameworkEntry.MessageBus.Subscribe<EnterSceneStartMessage>(OnEnterSceneStart);
            FrameworkEntry.MessageBus.Subscribe<EnterSceneProgressMessage>(OnEnterSceneProgress);
            FrameworkEntry.MessageBus.Subscribe<EnterSceneFinishedMessage>(OnEnterSceneFinished);
        }

        void UnsubscribeSceneMessage()
        {
            FrameworkEntry.MessageBus.Unsubscribe<EnterSceneStartMessage>(OnEnterSceneStart);
            FrameworkEntry.MessageBus.Unsubscribe<EnterSceneProgressMessage>(OnEnterSceneProgress);
            FrameworkEntry.MessageBus.Unsubscribe<EnterSceneFinishedMessage>(OnEnterSceneFinished);
        }

        void OnEnterSceneStart(EnterSceneStartMessage message)
        {
            loadingUI = GameManager.UIManager.CreateIfNotFind<LoadingUI>();
            loadingUI.Refresh($"Loading {message.scene} Scene...");
            loadingUI.Show();
        }

        void OnEnterSceneProgress(EnterSceneProgressMessage message)
        {
            loadingUI.Refresh(message.progress);
        }

        void OnEnterSceneFinished(EnterSceneFinishedMessage message)
        {
            loadingUI.Close();
        }
        #endregion
    }
}