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

namespace Business.Generic
{
    public static class GameManager
    {
        public static IApplicationManager Application { get { return ApplicationManager.Instance; } }

        public static IBusinessSceneManager SceneManager { get { return BusinessSceneManager.Instance; } }

        public static IGenericUIManager UIManager { get { return GenericUIManager.Instance; } }

        static GameManager() { }
    }
}