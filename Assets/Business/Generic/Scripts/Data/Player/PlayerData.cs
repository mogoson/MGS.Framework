/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PlayerData.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  05/31/2026
 *  Description  :  Initial development version.
 *************************************************************************/

namespace Business.Generic
{
    /// <summary>
    /// Player runtime data.
    /// </summary>
    public class PlayerData
    {
        public string UserName { set; get; }

        public void Clear()
        {
            UserName = null;
        }
    }
}