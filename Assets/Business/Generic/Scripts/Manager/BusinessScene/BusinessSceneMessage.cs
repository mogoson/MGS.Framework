/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  BusinessSceneMessage.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  06/28/2026
 *  Description  :  Initial development version.
 *************************************************************************/

namespace Business.Generic
{
    public struct EnterSceneStartMessage
    {
        public BusinessScene scene;
    }

    public struct EnterSceneProgressMessage
    {
        public BusinessScene scene;
        public float progress;
    }

    public struct EnterSceneFinishedMessage
    {
        public BusinessScene scene;
    }
}