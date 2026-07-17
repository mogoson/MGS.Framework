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

using UnityEngine.UI;

namespace Business.Generic
{
    public class LoadingUI : BaseUI<string>
    {
        public Text texMessage;
        public Image imgProgress;

        public override void Refresh(string message)
        {
            texMessage.text = message;
        }

        public void Refresh(float progress)
        {
            imgProgress.fillAmount = progress;
        }
    }
}