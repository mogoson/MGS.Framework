/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PlayerConfig.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  06/26/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace Business.Generic
{
    /// <summary>
    /// Player config.
    /// </summary>
    [Serializable]
    public class PlayerConfig
    {
        public AccountConfig account;
    }

    /// <summary>
    /// Player account config.
    /// </summary>
    [Serializable]
    public struct AccountConfig
    {
        public string username;
        public string password;
    }
}