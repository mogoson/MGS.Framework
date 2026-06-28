/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LoadingUI.cs
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
    public class LoadingUI : MonoBehaviour
    {
        [SerializeField] Text texMsg;
        [SerializeField] Image imgIcon;

        public void Refresh(string message)
        {
            texMsg.text = message;
        }

        public void Refresh(float progress)
        {
            imgIcon.fillAmount = progress;
        }
    }
}