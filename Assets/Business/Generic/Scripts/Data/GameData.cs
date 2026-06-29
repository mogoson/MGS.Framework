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

using System;
using MGS.JsonAvatar;
using MGS.StreamingIO;
using MGS.StreamingPorter;
using UnityEngine;

namespace Business.Generic
{
    public static class GameData
    {
        public static PlayerData PlayerData { get; }

        public static GameConfig GameConfig { get; }

        public static IJsonAvatar<PlayerConfig> PlayerConfig { get; }

        static GameData()
        {
            PlayerData = new PlayerData();
            GameConfig = ReadConfig<GameConfig>("GameConfig.json");
            PlayerConfig = new JsonAvatar<PlayerConfig>(GetConfigFile("PlayerConfig.json"));
        }

        #region Config
        public static string GetConfigFile(string fileName)
        {
            return StreamingPorter.GetDestPath($"Config/{fileName}");
        }

        public static string GetConfigName(string fileName)
        {
            return StreamingPorter.GetFileName($"Config/{fileName}");
        }

        public static T ReadConfig<T>(string fileName)
        {
            fileName = GetConfigName(fileName);
            var json = PersistentIO.ReadAllText(fileName, out Exception error);
            if (error != null)
            {
                Debug.LogException(error);
                return default;
            }
            var config = JsonConvert.FromJson<T>(json, out error);
            if (error != null)
            {
                Debug.LogException(error);
            }
            return config;
        }
        #endregion
    }
}