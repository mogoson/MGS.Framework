/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DialogUI.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  05/31/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Business.Generic
{
    public class DialogUI : MonoBehaviour
    {
        [SerializeField] Text texTittle;
        [SerializeField] Text texMsg;

        [Space]
        [SerializeField] Button btnYes;
        [SerializeField] Text texYes;

        [Space]
        [SerializeField] Button btnNo;
        [SerializeField] Text texNo;

        Action<bool> onSelect;

        private void Awake()
        {
            btnYes.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
                onSelect?.Invoke(true);
            });
            btnNo.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
                onSelect?.Invoke(false);
            });
        }

        public void Refresh(string tittle, string message, string yes, string no, Action<bool> onSelect)
        {
            this.onSelect = onSelect;
            texTittle.text = tittle;
            texMsg.text = message;
            texYes.text = yes;
            texNo.text = no;
            btnYes.gameObject.SetActive(!string.IsNullOrEmpty(yes));
            btnNo.gameObject.SetActive(!string.IsNullOrEmpty(no));
        }
    }
}