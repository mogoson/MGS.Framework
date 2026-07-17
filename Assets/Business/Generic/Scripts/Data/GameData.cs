/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GameData.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  05/31/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.JsonAvatar;
using MGS.StreamingPorter;

namespace Business.Generic
{
    public static class GameData
    {
        public static PlayerData PlayerData { get; }

        public static IJsonAvatar<GameConfig> GameConfig { get; }

        public static IJsonAvatar<PlayerConfig> PlayerConfig { get; }

        static GameData()
        {
            PlayerData = new PlayerData();

            var filePath = StreamingPorter.GetDestPath("Config/GameConfig.json");
            GameConfig = new JsonAvatar<GameConfig>(filePath);

            filePath = StreamingPorter.GetDestPath("Config/PlayerConfig.json");
            PlayerConfig = new JsonAvatar<PlayerConfig>(filePath);
        }
    }
}