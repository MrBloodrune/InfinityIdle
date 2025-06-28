using UnityEngine;
using BreakInfinity;

namespace InfinityIdle.Buildings
{
    [CreateAssetMenu(fileName = "GeneratorData", menuName = "InfinityIdle/Generator")]
    public class GeneratorData : ScriptableObject
    {
        [Header("Basic Info")]
        public string id;
        public string displayName;
        [TextArea(3, 5)]
        public string description;
        public Sprite icon;
        
        [Header("Economy")]
        [SerializeField] private string baseCostString = "10";
        [SerializeField] private string baseProductionString = "1";
        public float costGrowthRate = 1.15f;
        
        [Header("Milestones")]
        public int[] milestones = { 10, 25, 50, 100, 150, 200, 250 };
        public float milestoneMultiplier = 2f;
        
        [Header("Visual")]
        public Color themeColor = Color.white;
        public GameObject purchaseEffect;
        
        // Properties to convert string values to BigDouble
        public BigDouble baseCost => BigNumber.Parse(baseCostString);
        public BigDouble baseProduction => BigNumber.Parse(baseProductionString);
        
        // Helper method for editor
        public void SetBaseCost(BigDouble value)
        {
            baseCostString = value.ToString();
        }
        
        public void SetBaseProduction(BigDouble value)
        {
            baseProductionString = value.ToString();
        }
    }
}