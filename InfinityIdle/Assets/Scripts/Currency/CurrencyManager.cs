using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;

namespace InfinityIdle.Core
{
    public class CurrencyManager : MonoBehaviour
    {
        [Header("Currency Values")]
        private Dictionary<CurrencyType, BigDouble> currencies = new Dictionary<CurrencyType, BigDouble>();
        
        [Header("Currency Events")]
        public event Action<CurrencyType, BigDouble, BigDouble> OnCurrencyChanged;
        
        public enum CurrencyType
        {
            Credits,
            Influence,
            EntangledMatter,
            DarkMatter,
            Essence
        }

        public IEnumerator Initialize()
        {
            // Initialize all currencies to zero
            foreach (CurrencyType type in Enum.GetValues(typeof(CurrencyType)))
            {
                currencies[type] = new BigDouble(0);
            }
            
            yield return null;
        }

        public BigDouble GetCurrency(CurrencyType type)
        {
            return currencies.ContainsKey(type) ? currencies[type] : new BigDouble(0);
        }

        public void AddCurrency(CurrencyType type, BigDouble amount)
        {
            if (amount <= 0) return;
            
            BigDouble oldAmount = currencies[type];
            currencies[type] += amount;
            
            OnCurrencyChanged?.Invoke(type, oldAmount, currencies[type]);
            
            // Check for condensation
            CheckCondensation(type);
        }

        public bool SpendCurrency(CurrencyType type, BigDouble amount)
        {
            if (amount <= 0) return false;
            
            if (currencies[type] >= amount)
            {
                BigDouble oldAmount = currencies[type];
                currencies[type] -= amount;
                
                OnCurrencyChanged?.Invoke(type, oldAmount, currencies[type]);
                return true;
            }
            
            return false;
        }

        public bool CanAfford(CurrencyType type, BigDouble amount)
        {
            return currencies[type] >= amount;
        }

        private void CheckCondensation(CurrencyType type)
        {
            BigDouble condensationThreshold = new BigDouble(1e6);
            
            // Credits -> Influence
            if (type == CurrencyType.Credits && currencies[type] >= condensationThreshold)
            {
                BigDouble condensedAmount = currencies[type] / condensationThreshold;
                currencies[type] = currencies[type] % condensationThreshold;
                AddCurrency(CurrencyType.Influence, condensedAmount);
            }
            // Influence -> Entangled Matter
            else if (type == CurrencyType.Influence && currencies[type] >= condensationThreshold)
            {
                BigDouble condensedAmount = currencies[type] / condensationThreshold;
                currencies[type] = currencies[type] % condensationThreshold;
                AddCurrency(CurrencyType.EntangledMatter, condensedAmount);
            }
            // Entangled Matter -> Dark Matter
            else if (type == CurrencyType.EntangledMatter && currencies[type] >= condensationThreshold)
            {
                BigDouble condensedAmount = currencies[type] / condensationThreshold;
                currencies[type] = currencies[type] % condensationThreshold;
                AddCurrency(CurrencyType.DarkMatter, condensedAmount);
            }
            // Dark Matter -> Essence
            else if (type == CurrencyType.DarkMatter && currencies[type] >= condensationThreshold)
            {
                BigDouble condensedAmount = currencies[type] / condensationThreshold;
                currencies[type] = currencies[type] % condensationThreshold;
                AddCurrency(CurrencyType.Essence, condensedAmount);
            }
        }

        public void LoadCurrencyData(CurrencyData data)
        {
            currencies[CurrencyType.Credits] = BigDouble.Parse(data.credits);
            currencies[CurrencyType.Influence] = BigDouble.Parse(data.influence);
            currencies[CurrencyType.EntangledMatter] = BigDouble.Parse(data.entangledMatter);
            currencies[CurrencyType.DarkMatter] = BigDouble.Parse(data.darkMatter);
            
            // Trigger UI updates
            foreach (var kvp in currencies)
            {
                OnCurrencyChanged?.Invoke(kvp.Key, kvp.Value, kvp.Value);
            }
        }

        public CurrencyData GetSaveData()
        {
            return new CurrencyData
            {
                credits = currencies[CurrencyType.Credits].ToString(),
                influence = currencies[CurrencyType.Influence].ToString(),
                entangledMatter = currencies[CurrencyType.EntangledMatter].ToString(),
                darkMatter = currencies[CurrencyType.DarkMatter].ToString()
            };
        }
    }
}