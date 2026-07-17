/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LobbyUI.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/18/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using Business.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Business.Lobby
{
    class LobbyUI : BaseUI
    {
        [SerializeField] Button btnMovie;
        [SerializeField] Button btnMusic;
        [SerializeField] Button btnPainting;

        public event Action<RoomName> OnSelectRoomEvent;

        protected override void Awake()
        {
            base.Awake();

            btnMovie.onClick.AddListener(OnBtnMovieClick);
            btnMusic.onClick.AddListener(OnBtnMusicClick);
            btnPainting.onClick.AddListener(OnBtnPaintionClick);
        }

        void OnBtnMovieClick()
        {
            Close();
            OnSelectRoomEvent?.Invoke(RoomName.MovieRoom);
        }

        void OnBtnMusicClick()
        {
            Close();
            OnSelectRoomEvent?.Invoke(RoomName.MusicRoom);
        }

        void OnBtnPaintionClick()
        {
            Close();
            OnSelectRoomEvent?.Invoke(RoomName.PaintingRoom);
        }
    }
}