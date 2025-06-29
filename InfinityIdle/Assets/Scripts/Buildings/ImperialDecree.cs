using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using BreakInfinity;
using InfinityIdle.Core;
using InfinityIdle.UI;

// If EventSystems is missing, you may need to install the Input System package
// Window > Package Manager > Unity Registry > Input System

namespace InfinityIdle.Buildings
{
    public class ImperialDecree : MonoBehaviour, IPointerClickHandler
    {
        [Header("Click Settings")]
        [SerializeField] private BigDouble baseClickPower = new BigDouble(1);
        [SerializeField] private float clickMultiplier = 1f;
        
        [Header("Visual Feedback")]
        [SerializeField] private GameObject clickEffect;
        [SerializeField] private Transform effectSpawnPoint;
        [SerializeField] private AudioClip clickSound;
        
        private CurrencyManager currencyManager;
        private AudioSource audioSource;
        private ObjectPool<GameObject> effectPool;
        
        private void Start()
        {
            currencyManager = FindObjectOfType<CurrencyManager>();
            audioSource = GetComponent<AudioSource>();
            
            if (clickEffect != null)
            {
                effectPool = new ObjectPool<GameObject>(
                    () => Instantiate(clickEffect),
                    effect => effect.SetActive(true),
                    effect => effect.SetActive(false),
                    effect => Destroy(effect),
                    10
                );
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            PerformClick();
        }

        private void PerformClick()
        {
            BigDouble clickValue = CalculateClickValue();
            currencyManager.AddCurrency(CurrencyManager.CurrencyType.Credits, clickValue);
            
            ShowClickFeedback(clickValue);
            PlayClickSound();
            
            GameManager.Instance.EventBus.Publish(new ImperialDecreeClickedEvent(clickValue));
        }

        private BigDouble CalculateClickValue()
        {
            BigDouble value = baseClickPower * clickMultiplier;
            
            // TODO: Apply upgrades, skills, and faction bonuses
            
            return value;
        }

        private void ShowClickFeedback(BigDouble value)
        {
            if (effectPool != null && effectSpawnPoint != null)
            {
                GameObject effect = effectPool.Get();
                effect.transform.position = effectSpawnPoint.position;
                
                // Assume effect has a component to display the value
                var display = effect.GetComponent<FloatingNumber>();
                if (display != null)
                {
                    display.SetValue(value);
                }
                
                // Return to pool after animation
                StartCoroutine(ReturnToPoolAfterDelay(effect, 1f));
            }
        }

        private System.Collections.IEnumerator ReturnToPoolAfterDelay(GameObject effect, float delay)
        {
            yield return new WaitForSeconds(delay);
            effectPool.Return(effect);
        }

        private void PlayClickSound()
        {
            if (audioSource != null && clickSound != null)
            {
                audioSource.PlayOneShot(clickSound);
            }
        }

        public void SetBaseClickPower(BigDouble power)
        {
            baseClickPower = power;
        }

        public void SetClickMultiplier(float multiplier)
        {
            clickMultiplier = multiplier;
        }

        public BigDouble GetCurrentClickPower()
        {
            return CalculateClickValue();
        }
    }

    public class ImperialDecreeClickedEvent
    {
        public BigDouble Value { get; }

        public ImperialDecreeClickedEvent(BigDouble value)
        {
            Value = value;
        }
    }
}