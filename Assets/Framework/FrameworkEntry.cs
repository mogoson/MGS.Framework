/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FrameworkEntry.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/02/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using MGS.MessageBus;
using MGS.MonoAgent;
using UnityEngine;

namespace Framework
{
    /// <summary>
    /// Entry of framewor interface.
    /// </summary>
    public static class FrameworkEntry
    {
        static FrameworkEntry()
        {
            MessageBus = new MessageBus();
        }

        #region IO
        /*
        MGS.IOUtility
            DirectoryUtility, Create/Delete directory.
            FileUtility, Read/Write file.
        
        MGS.StreamingIO
            StreamingIO, Read asset from Unity streamingAssetsPath.
            PersistentIO, Read/Write asset from/to Unity persistentDataPath.

        MGS.StreamingPorter
            StreamingPorter, Transport manifest assets from streaming to persistent path.

        MGS.JsonAvatar
            JsonConvert, Convert json.
            FieldOnlyContractResolver, Contract resolver for field only.
            JsonAvatar, Avatar to pull data from file and push data to file.
        */
        #endregion

        #region Mono
        /*
        MGS.Singleton
            Singleton<T>, Provide single instance for type.
            MonoSingleton<T>, Provide single instance for Unity Component.
            MonoSingleton, Provide single instance for MonoSingleton.

        MGS.MonoAgent
            MonoAgent<T>, Provide an instance of MonoBehaviour in normal C# Class.
            ApplicationAgent, Listener Application Focus/Pause/Quit.
            MainThreadAgent, Enqueue action and invoke by main thread.
            CoroutineAgent, Provide generic routine and start coroutine.
            RoutineAgent, Provide generic routine.

        MGS.MonoCollection
            MonoCollection<T>, Manage items for data list.
            PageCollection<T>, Manage items for page data.
            MonoItem<T>, Item template.

        MGS.Adaptive
            IAdaptive, Adaptive, AdaptivePro, AdaptiveSmooth
            ChildToTarget, FaceToTarget, HookToTarget, LookToTarget, SizeToTarget, LineSizeToTarget
            VisualUtility
        */

        public static IMainThreadAgent MainThread { get { return MainThreadAgent.Instance; } }

        public static ICoroutineAgent Coroutine { get { return CoroutineAgent.Instance; } }
        #endregion

        #region Capture
        /*
        MGS.Capture
            CameraCapture, Capture camera texture.
            WebCameraCapture, Capture the web camera texture.
            CameraDisplay, Display the texture that capture from camera.
            CaptureUtility, Screenshot and Camerashot and SaveAsPNG.
         */
        #endregion

        #region UI
        /*
        MGS.MonoUI
            IMonoUI, IMonoUI<T>, MonoUI, MonoUI<T>
            IMonoUIManager, MonoUIManager
            IMonoUILoader, MonoUILoader
            IFocusable, ScreenSpaceDepthFocusable

        Framework
            ScreenSpaceFocusable
            WorldSpaceFocusable
        */
        #endregion

        #region Message
        /*
        MGS.MessageBus
            MessageBus, Subscribe/Unsubscribe/Spread/Clear message.
         */

        public static IMessageBus MessageBus { get; }
        #endregion

        #region Unload
        /*
        UnityEngine
            Resources

        System
            GC
        */

        public static void UnloadUnusedAssets()
        {
            Resources.UnloadUnusedAssets();
        }

        public static void CollectGC()
        {
            GC.Collect();
        }
        #endregion
    }
}