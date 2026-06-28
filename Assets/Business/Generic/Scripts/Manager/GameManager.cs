/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GameManager.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  05/31/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.MessageBus;

namespace Business.Generic
{
    public static class GameManager
    {
        public static IApplicationManager Application { get; }

        public static IMessageBus MessageBus { get; }

        public static IBusinessSceneManager SceneManager { get; }

        static GameManager()
        {
            Application = new ApplicationManager();
            MessageBus = new MessageBus();
            SceneManager = new BusinessSceneManager();
        }
    }
}