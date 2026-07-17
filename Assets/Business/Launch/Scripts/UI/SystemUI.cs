/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SystemUI.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/05/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using Business.Generic;
using Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Business.Launch
{
    class SystemUI : BaseUI
    {
        [SerializeField] Button btnLobby;
        [SerializeField] Button btnLogout;
        [SerializeField] Button btnQuit;

        protected override void Awake()
        {
            base.Awake();

            FrameworkEntry.MessageBus.Subscribe<EnterSceneStartMessage>(OnEnterSceneStart);

            btnLobby.onClick.AddListener(OnBtnBackClick);
            btnLogout.onClick.AddListener(OnBtnLogoutClick);
            btnQuit.onClick.AddListener(OnBtnQuitClick);
        }

        private void Start()
        {
            btnLobby.gameObject.SetActive(false);
            btnLogout.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            FrameworkEntry.MessageBus.Unsubscribe<EnterSceneStartMessage>(OnEnterSceneStart);
        }

        void OnEnterSceneStart(EnterSceneStartMessage message)
        {
            var isCanBackLobby = message.scene > BusinessScene.Lobby;
            btnLobby.gameObject.SetActive(isCanBackLobby);

            var isCanLogout = message.scene > BusinessScene.Login;
            btnLogout.gameObject.SetActive(isCanLogout);
        }

        void OnBtnBackClick()
        {
            GameManager.SceneManager.EnterSceneAsync(BusinessScene.Lobby);
        }

        void OnBtnLogoutClick()
        {
            var dialogUI = GameManager.UIManager.CreateIfNotFind<DialogUI>();
            dialogUI.Refresh("Logout", "Are you sure logout?", "Yes", "Cancel", isYes =>
            {
                if (isYes)
                {
                    GameManager.SceneManager.EnterSceneAsync(BusinessScene.Login);
                }
            });
            dialogUI.Show();
        }

        void OnBtnQuitClick()
        {
            GameManager.Application.AskQuit();
        }
    }
}