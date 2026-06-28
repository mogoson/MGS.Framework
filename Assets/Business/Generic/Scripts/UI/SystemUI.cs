/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SystemUI.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  05/31/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace Business.Generic
{
    public class SystemUI : MonoBehaviour
    {
        [SerializeField] Button btnBack;
        [SerializeField] Button btnQuit;

        private void Awake()
        {
            btnBack.onClick.AddListener(() =>
            {
                var scene = GameManager.SceneManager.Scene - 1;
                if (scene > BusinessScene.Launch)
                {
                    GameManager.SceneManager.EnterScene(scene);
                }
            });

            btnQuit.onClick.AddListener(() => GameManager.Application.AskQuit());
        }
    }
}