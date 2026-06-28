/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IBusinessSceneManager.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  06/28/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace Business.Generic
{
    public interface IBusinessSceneManager
    {
        BusinessScene Scene { get; }

        void EnterScene(BusinessScene scene, Action<Exception> finished = null);
    }
}