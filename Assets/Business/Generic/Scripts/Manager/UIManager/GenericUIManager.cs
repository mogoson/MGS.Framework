/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GenericUIManager.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/11/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.MonoUI;

namespace Business.Generic
{
    class GenericUIManager : MonoUIManager, IGenericUIManager
    {
        public static GenericUIManager Instance { private set; get; }

        private void Awake()
        {
            Instance = this;
        }
    }
}