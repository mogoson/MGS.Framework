/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  WorldSpaceFocusable.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/08/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Adaptive;
using MGS.MonoUI;
using UnityEngine;

namespace Framework
{
    public class WorldSpaceFocusable : MonoBehaviour, IMonoUIFocusable
    {
        protected IAdaptive adaptive;

        protected virtual void Awake()
        {
            adaptive = GetComponent<IAdaptive>();
        }

        public void Focus()
        {
            adaptive?.Adapt();
        }
    }
}