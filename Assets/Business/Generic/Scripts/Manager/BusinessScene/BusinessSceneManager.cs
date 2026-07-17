/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  BusinessSceneManager.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  06/28/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections;
using Framework;
using MGS.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Business.Generic
{
    class BusinessSceneManager : Singleton<BusinessSceneManager>, IBusinessSceneManager
    {
        public BusinessScene Scene { private set; get; }
        Coroutine coroutine;

        BusinessSceneManager() { }

        public void EnterScene(BusinessScene scene, Action<Exception> finished = null)
        {
            if (scene == Scene)
            {
                finished?.Invoke(null);
                return;
            }

            if (coroutine != null)
            {
                finished?.Invoke(new Exception("Another scene is loading."));
                return;
            }

            coroutine = FrameworkEntry.Coroutine.StartCoroutine(EnterSceneAsync(scene, finished));
        }

        IEnumerator EnterSceneAsync(BusinessScene scene, Action<Exception> finished = null)
        {
            FrameworkEntry.MessageBus.Spread(new EnterSceneStartMessage { scene = scene });
            if (Scene != BusinessScene.Launch)
            {
                var sceneName = Scene.ToString();
                var aperation = SceneManager.UnloadSceneAsync(sceneName, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
                var message = new EnterSceneProgressMessage { scene = scene };
                while (!aperation.isDone)
                {
                    message.progress = aperation.progress * 0.5f;
                    FrameworkEntry.MessageBus.Spread(message);
                    yield return null;
                }
                FrameworkEntry.UnloadUnusedAssets();
            }

            Scene = scene;
            if (Scene != BusinessScene.Launch)
            {
                var sceneName = Scene.ToString();
                var aperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                var message = new EnterSceneProgressMessage { scene = scene };
                while (!aperation.isDone)
                {
                    message.progress = 0.5f + aperation.progress * 0.5f;
                    FrameworkEntry.MessageBus.Spread(message);
                    yield return null;
                }
                var current = SceneManager.GetSceneByName(sceneName);
                SceneManager.SetActiveScene(current);
            }

            coroutine = null;
            FrameworkEntry.MessageBus.Spread(new EnterSceneFinishedMessage { scene = scene });
            finished?.Invoke(null);
        }
    }
}