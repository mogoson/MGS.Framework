/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ApplicationMessager.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/17/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using Framework;
using UnityEngine;

namespace Business.Generic
{
    class ApplicationMessager : MonoBehaviour
    {
        private void OnApplicationFocus(bool focus)
        {
            FrameworkEntry.MessageBus.Spread(new AppFocusMessage { focus = focus });
        }

        private void OnApplicationPause(bool pause)
        {
            FrameworkEntry.MessageBus.Spread(new AppPauseMessage { pause = pause });
        }

        private void OnApplicationQuit()
        {
            FrameworkEntry.MessageBus.Spread(new AppQuitMessage());
        }
    }
}