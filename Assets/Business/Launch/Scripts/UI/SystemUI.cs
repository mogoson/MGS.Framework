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

using Framework;
using UnityEngine.UI;

namespace Business.Generic
{
    public class SystemUI : BaseUI
    {
        public Button btnBack;
        public Button btnLogout;
        public Button btnQuit;

        protected override void Awake()
        {
            base.Awake();

            FrameworkEntry.MessageBus.Subscribe<EnterSceneStartMessage>(OnEnterSceneStart);

            btnBack.onClick.AddListener(OnBtnBackClick);
            btnLogout.onClick.AddListener(OnBtnLogoutClick);
            btnQuit.onClick.AddListener(OnBtnQuitClick);
        }

        private void Start()
        {
            btnBack.gameObject.SetActive(false);
            btnLogout.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            FrameworkEntry.MessageBus.Unsubscribe<EnterSceneStartMessage>(OnEnterSceneStart);
        }

        void OnEnterSceneStart(EnterSceneStartMessage message)
        {
            var isCanBack = message.scene > BusinessScene.Lobby;
            btnBack.gameObject.SetActive(isCanBack);
        }

        void OnBtnBackClick()
        {
            var scene = GameManager.SceneManager.Scene - 1;
            if (scene > BusinessScene.Lobby)
            {
                GameManager.SceneManager.EnterScene(scene);
            }
        }

        void OnBtnLogoutClick()
        {
            GameManager.SceneManager.EnterScene(BusinessScene.Login);
        }

        void OnBtnQuitClick()
        {
            GameManager.Application.AskQuit();
        }
    }
}