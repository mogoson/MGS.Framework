/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MessageUI.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/11/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Business.Generic
{
    public class MessageUI : BaseUI
    {
        public Text texTittle;
        public Text texMessage;

        [Space]
        public Button btnConfirm;
        public Text texConfirm;

        protected Action onConfirm;

        protected override void Awake()
        {
            base.Awake();
            btnConfirm.onClick.AddListener(OnBtnConfirmClick);
        }

        void OnBtnConfirmClick()
        {
            Close();
            onConfirm?.Invoke();
            onConfirm = null;
        }

        public void Refresh(string tittle, string message, string confirm, Action onConfirm)
        {
            texTittle.text = tittle;
            texMessage.text = message;
            texConfirm.text = confirm;
            this.onConfirm = onConfirm;
        }
    }
}