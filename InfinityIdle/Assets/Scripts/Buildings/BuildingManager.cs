using System.Collections.Generic;
using UnityEngine;
using InfinityIdle.Core;

namespace InfinityIdle.Buildings
{
    public class BuildingManager : MonoBehaviour
    {
        [Header("Building Configuration")]
        [SerializeField] private GeneratorData[] generatorConfigs;
        
        private Dictionary<string, Generator> generators = new Dictionary<string, Generator>();
        private CurrencyManager currencyManager;
        private UpdateManager updateManager;
        
        private void Start()
        {
            currencyManager = GetComponent<CurrencyManager>();
            updateManager = GetComponent<UpdateManager>();
            
            InitializeGenerators();
        }

        private void InitializeGenerators()
        {
            foreach (var config in generatorConfigs)
            {
                Generator generator = new Generator
                {
                    id = config.id,
                    displayName = config.displayName,
                    description = config.description,
                    icon = config.icon,
                    baseCost = config.baseCost,
                    baseProduction = config.baseProduction,
                    costGrowthRate = config.costGrowthRate,
                    milestones = config.milestones,
                    milestoneMultiplier = config.milestoneMultiplier
                };
                
                generator.Initialize(currencyManager);
                generators[config.id] = generator;
                
                // Register for economy updates
                updateManager.RegisterEconomyUpdate(generator);
            }
        }

        public Generator GetGenerator(string id)
        {
            return generators.ContainsKey(id) ? generators[id] : null;
        }

        public List<Generator> GetAllGenerators()
        {
            return new List<Generator>(generators.Values);
        }

        public bool PurchaseGenerator(string id, int amount = 1)
        {
            Generator generator = GetGenerator(id);
            if (generator != null)
            {
                return generator.Purchase(amount);
            }
            return false;
        }

        public void LoadBuildingData(BuildingData[] data)
        {
            foreach (var buildingData in data)
            {
                if (generators.ContainsKey(buildingData.id))
                {
                    generators[buildingData.id].owned = buildingData.level;
                    // Note: totalProduced would need to be added to BuildingData for full restoration
                }
            }
            
            // Recalculate all productions
            foreach (var generator in generators.Values)
            {
                generator.Initialize(currencyManager);
            }
        }

        public BuildingData[] GetSaveData()
        {
            List<BuildingData> saveData = new List<BuildingData>();
            
            foreach (var kvp in generators)
            {
                saveData.Add(new BuildingData
                {
                    id = kvp.Key,
                    level = kvp.Value.owned,
                    totalProduced = kvp.Value.GetTotalProduced().ToString()
                });
            }
            
            return saveData.ToArray();
        }

        private void OnDestroy()
        {
            // Unregister all generators from update manager
            foreach (var generator in generators.Values)
            {
                updateManager?.UnregisterEconomyUpdate(generator);
            }
        }
    }
}