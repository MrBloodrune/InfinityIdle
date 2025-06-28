using System;
using UnityEngine;
using BreakInfinity;
using InfinityIdle.Core;

namespace InfinityIdle.Buildings
{
    [Serializable]
    public class Generator : IEconomyUpdate
    {
        [Header("Generator Info")]
        public string id;
        public string displayName;
        public string description;
        public Sprite icon;
        
        [Header("Economy")]
        public BigDouble baseCost;
        public BigDouble baseProduction;
        public float costGrowthRate = 1.15f;
        public int owned = 0;
        
        [Header("Milestones")]
        public int[] milestones = { 10, 25, 50, 100, 150, 200, 250 };
        public float milestoneMultiplier = 2f;
        
        private BigDouble currentProduction;
        private BigDouble totalProduced;
        private CurrencyManager currencyManager;
        
        public void Initialize(CurrencyManager manager)
        {
            currencyManager = manager;
            RecalculateProduction();
        }

        public BigDouble GetCost(int amount = 1)
        {
            if (amount == 1)
            {
                return baseCost * BigDouble.Pow(costGrowthRate, owned);
            }
            
            // Bulk buy formula
            BigDouble ratio = BigDouble.Pow(costGrowthRate, amount) - 1;
            ratio /= costGrowthRate - 1;
            return baseCost * BigDouble.Pow(costGrowthRate, owned) * ratio;
        }

        public int GetMaxAffordable()
        {
            BigDouble currency = currencyManager.GetCurrency(CurrencyManager.CurrencyType.Credits);
            
            if (currency < GetCost(1))
                return 0;
            
            // Binary search for max affordable
            int low = 1;
            int high = 1000; // Reasonable upper limit
            
            while (low < high)
            {
                int mid = (low + high + 1) / 2;
                if (GetCost(mid) <= currency)
                    low = mid;
                else
                    high = mid - 1;
            }
            
            return low;
        }

        public bool Purchase(int amount = 1)
        {
            BigDouble cost = GetCost(amount);
            
            if (currencyManager.SpendCurrency(CurrencyManager.CurrencyType.Credits, cost))
            {
                owned += amount;
                RecalculateProduction();
                
                GameManager.Instance.GetComponent<EventBus>().Publish(
                    new GeneratorPurchasedEvent(this, amount, cost)
                );
                
                return true;
            }
            
            return false;
        }

        public void OnEconomyUpdate(float deltaTime)
        {
            if (owned > 0 && currentProduction > 0)
            {
                BigDouble produced = currentProduction * deltaTime;
                totalProduced += produced;
                currencyManager.AddCurrency(CurrencyManager.CurrencyType.Credits, produced);
            }
        }

        private void RecalculateProduction()
        {
            currentProduction = baseProduction * owned;
            
            // Apply milestone bonuses
            float milestoneBonus = 1f;
            foreach (int milestone in milestones)
            {
                if (owned >= milestone)
                {
                    milestoneBonus *= milestoneMultiplier;
                }
            }
            
            currentProduction *= milestoneBonus;
            
            // TODO: Apply faction bonuses, upgrades, etc.
        }

        public BigDouble GetProduction()
        {
            return currentProduction;
        }

        public BigDouble GetTotalProduced()
        {
            return totalProduced;
        }

        public float GetNextMilestoneProgress()
        {
            foreach (int milestone in milestones)
            {
                if (owned < milestone)
                {
                    return (float)owned / milestone;
                }
            }
            return 1f; // All milestones achieved
        }

        public int GetNextMilestone()
        {
            foreach (int milestone in milestones)
            {
                if (owned < milestone)
                {
                    return milestone;
                }
            }
            return -1; // All milestones achieved
        }
    }

    public class GeneratorPurchasedEvent
    {
        public Generator Generator { get; }
        public int Amount { get; }
        public BigDouble Cost { get; }

        public GeneratorPurchasedEvent(Generator generator, int amount, BigDouble cost)
        {
            Generator = generator;
            Amount = amount;
            Cost = cost;
        }
    }
}