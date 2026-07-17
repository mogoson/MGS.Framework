/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LobbyBusinees.cs
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

namespace Business.Lobby
{
    enum RoomName
    {
        MovieRoom,
        MusicRoom,
        PaintingRoom
    }

    class LobbyBusinees : MonoBehaviour
    {
        public void EnterRoom(RoomName roomName)
        {
            var scene = Enum.Parse<BusinessScene>(roomName.ToString());
            GameManager.SceneManager.EnterSceneAsync(scene);
        }
    }
}