/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LobbyController.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/18/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.MonoUI;
using UnityEngine;

namespace Business.Lobby
{
    class LobbyController : MonoBehaviour
    {
        [SerializeField] MonoUIManager UI;
        [SerializeField] LobbyBusinees business;

        private void Start()
        {
            var lobbyUI = UI.Create<LobbyUI>();
            lobbyUI.OnSelectRoomEvent += OnSelectRoom;
        }

        private void OnSelectRoom(RoomName roomName)
        {
            business.EnterRoom(roomName);
        }
    }
}