using System;
using System.Collections;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace InfinityIdle.Core
{
    public class SaveManager : MonoBehaviour
    {
        private const string SAVE_FILE_NAME = "infinityidle_save.json";
        private const int SAVE_VERSION = 1;
        
        [Header("Save Settings")]
        [SerializeField] private bool useCompression = true;
        [SerializeField] private int maxBackups = 5;
        
        private SaveData currentSaveData;
        private string savePath;

        public IEnumerator Initialize()
        {
            savePath = Path.Combine(Application.persistentDataPath, SAVE_FILE_NAME);
            yield return LoadGame();
        }

        public void Save()
        {
            try
            {
                GameManager.Instance.ChangeState(GameManager.GameState.Saving);
                
                currentSaveData = CollectSaveData();
                string json = JsonConvert.SerializeObject(currentSaveData, Formatting.Indented);
                
                CreateBackup();
                File.WriteAllText(savePath, json);
                
                Debug.Log($"Game saved successfully at {DateTime.Now}");
                GameManager.Instance.ChangeState(GameManager.GameState.Playing);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to save game: {e.Message}");
                GameManager.Instance.ChangeState(GameManager.GameState.Playing);
            }
        }

        private IEnumerator LoadGame()
        {
            if (File.Exists(savePath))
            {
                try
                {
                    string json = File.ReadAllText(savePath);
                    currentSaveData = JsonConvert.DeserializeObject<SaveData>(json);
                    
                    if (currentSaveData != null && currentSaveData.version == SAVE_VERSION)
                    {
                        ApplySaveData(currentSaveData);
                        Debug.Log("Game loaded successfully");
                    }
                    else
                    {
                        Debug.LogWarning("Save file version mismatch, starting new game");
                        currentSaveData = CreateNewSave();
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError($"Failed to load save: {e.Message}");
                    currentSaveData = CreateNewSave();
                }
            }
            else
            {
                Debug.Log("No save file found, starting new game");
                currentSaveData = CreateNewSave();
            }
            
            yield return null;
        }

        private SaveData CreateNewSave()
        {
            return new SaveData
            {
                version = SAVE_VERSION,
                lastSave = DateTime.Now,
                currencies = new CurrencyData(),
                buildings = new BuildingData[0],
                settings = new GameSettings()
            };
        }

        private SaveData CollectSaveData()
        {
            SaveData data = new SaveData
            {
                version = SAVE_VERSION,
                lastSave = DateTime.Now,
                currencies = new CurrencyData(),
                buildings = new BuildingData[0],
                settings = new GameSettings()
            };

            // TODO: Collect data from various managers
            
            return data;
        }

        private void ApplySaveData(SaveData data)
        {
            // TODO: Apply save data to various managers
            
            // Calculate offline progress
            TimeSpan offlineTime = DateTime.Now - data.lastSave;
            if (offlineTime.TotalSeconds > 0)
            {
                CalculateOfflineProgress(offlineTime);
            }
        }

        private void CalculateOfflineProgress(TimeSpan offlineTime)
        {
            float offlineSeconds = (float)Math.Min(offlineTime.TotalSeconds, 7200); // 2 hour cap
            Debug.Log($"Calculating offline progress for {offlineSeconds} seconds");
            
            // TODO: Implement offline progress calculation
        }

        private void CreateBackup()
        {
            // Simple backup rotation
            for (int i = maxBackups - 1; i > 0; i--)
            {
                string oldBackup = savePath + $".backup{i}";
                string newBackup = savePath + $".backup{i + 1}";
                
                if (File.Exists(oldBackup))
                {
                    if (File.Exists(newBackup))
                        File.Delete(newBackup);
                    File.Move(oldBackup, newBackup);
                }
            }
            
            if (File.Exists(savePath))
            {
                File.Copy(savePath, savePath + ".backup1", true);
            }
        }

        public void DeleteSave()
        {
            if (File.Exists(savePath))
            {
                File.Delete(savePath);
            }
            
            for (int i = 1; i <= maxBackups; i++)
            {
                string backupPath = savePath + $".backup{i}";
                if (File.Exists(backupPath))
                {
                    File.Delete(backupPath);
                }
            }
            
            currentSaveData = CreateNewSave();
            ApplySaveData(currentSaveData);
        }
    }

    [Serializable]
    public class SaveData
    {
        public int version;
        public DateTime lastSave;
        public CurrencyData currencies;
        public BuildingData[] buildings;
        public GameSettings settings;
    }

    [Serializable]
    public class CurrencyData
    {
        public string credits = "0";
        public string influence = "0";
        public string entangledMatter = "0";
        public string darkMatter = "0";
    }

    [Serializable]
    public class BuildingData
    {
        public string id;
        public int level;
        public string totalProduced = "0";
    }

    [Serializable]
    public class GameSettings
    {
        public float musicVolume = 0.5f;
        public float sfxVolume = 0.5f;
        public bool notificationsEnabled = true;
        public int graphicsQuality = 2;
    }
}