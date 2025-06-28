using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfinityIdle.Core
{
    public class UpdateManager : MonoBehaviour
    {
        [Header("Update Intervals")]
        [SerializeField] private float economyUpdateInterval = 0.1f;  // 10 Hz
        [SerializeField] private float uiUpdateInterval = 0.0333f;    // 30 Hz
        [SerializeField] private float saveInterval = 30f;            // Every 30 seconds
        
        private List<IEconomyUpdate> economyUpdates = new List<IEconomyUpdate>();
        private List<IUIUpdate> uiUpdates = new List<IUIUpdate>();
        
        private Coroutine economyCoroutine;
        private Coroutine uiCoroutine;
        private Coroutine saveCoroutine;

        public IEnumerator Initialize()
        {
            StartUpdateLoops();
            yield return null;
        }

        private void StartUpdateLoops()
        {
            economyCoroutine = StartCoroutine(EconomyUpdateLoop());
            uiCoroutine = StartCoroutine(UIUpdateLoop());
            saveCoroutine = StartCoroutine(AutoSaveLoop());
        }

        public void RegisterEconomyUpdate(IEconomyUpdate update)
        {
            if (!economyUpdates.Contains(update))
            {
                economyUpdates.Add(update);
            }
        }

        public void UnregisterEconomyUpdate(IEconomyUpdate update)
        {
            economyUpdates.Remove(update);
        }

        public void RegisterUIUpdate(IUIUpdate update)
        {
            if (!uiUpdates.Contains(update))
            {
                uiUpdates.Add(update);
            }
        }

        public void UnregisterUIUpdate(IUIUpdate update)
        {
            uiUpdates.Remove(update);
        }

        private IEnumerator EconomyUpdateLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(economyUpdateInterval);
                
                if (GameManager.Instance.CurrentState == GameManager.GameState.Playing)
                {
                    float deltaTime = economyUpdateInterval;
                    
                    for (int i = economyUpdates.Count - 1; i >= 0; i--)
                    {
                        if (i < economyUpdates.Count)
                        {
                            economyUpdates[i].OnEconomyUpdate(deltaTime);
                        }
                    }
                }
            }
        }

        private IEnumerator UIUpdateLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(uiUpdateInterval);
                
                if (GameManager.Instance.CurrentState == GameManager.GameState.Playing)
                {
                    for (int i = uiUpdates.Count - 1; i >= 0; i--)
                    {
                        if (i < uiUpdates.Count)
                        {
                            uiUpdates[i].OnUIUpdate();
                        }
                    }
                }
            }
        }

        private IEnumerator AutoSaveLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(saveInterval);
                
                if (GameManager.Instance.CurrentState == GameManager.GameState.Playing)
                {
                    SaveManager saveManager = GetComponent<SaveManager>();
                    if (saveManager != null)
                    {
                        saveManager.Save();
                    }
                }
            }
        }

        private void OnDestroy()
        {
            if (economyCoroutine != null) StopCoroutine(economyCoroutine);
            if (uiCoroutine != null) StopCoroutine(uiCoroutine);
            if (saveCoroutine != null) StopCoroutine(saveCoroutine);
        }
    }

    public interface IEconomyUpdate
    {
        void OnEconomyUpdate(float deltaTime);
    }

    public interface IUIUpdate
    {
        void OnUIUpdate();
    }
}