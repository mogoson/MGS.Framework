/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ApplicationManager.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  06/28/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.MonoAgent;
using UnityEngine;

namespace Business.Generic
{
    internal class ApplicationManager : MonoAgent<ApplicationMono>, IApplicationManager
    {
        public void AskQuit()
        {
            GameManager.MessageBus.Spread(new AppQuitAskMessage());
        }

        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else
            UnityEngine.Application.Quit();
#endif
        }
    }

    internal class ApplicationMono : MonoBehaviour
    {
        private void OnApplicationFocus(bool focus)
        {
            GameManager.MessageBus.Spread(new AppFocusMessage { focus = focus });
        }

        private void OnApplicationPause(bool pause)
        {
            GameManager.MessageBus.Spread(new AppPauseMessage { pause = pause });
        }

        private void OnApplicationQuit()
        {
            GameManager.MessageBus.Spread(new AppQuitMessage());
        }
    }
}