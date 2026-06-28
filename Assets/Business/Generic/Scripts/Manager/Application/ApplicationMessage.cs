/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ApplicationMessage.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  06/28/2026
 *  Description  :  Initial development version.
 *************************************************************************/

namespace Business.Generic
{
    public struct AppFocusMessage
    {
        public bool focus;
    }

    public struct AppPauseMessage
    {
        public bool pause;
    }

    public struct AppQuitAskMessage { }

    public struct AppQuitMessage { }
}