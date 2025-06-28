using UnityEngine;
using TMPro;
using BreakInfinity;
using InfinityIdle.Core;

namespace InfinityIdle.UI
{
    public class FloatingNumber : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI numberText;
        [SerializeField] private float floatSpeed = 2f;
        [SerializeField] private float fadeSpeed = 1f;
        [SerializeField] private float lifetime = 1f;
        
        private float timer;
        private Color originalColor;
        
        private void Awake()
        {
            if (numberText == null)
                numberText = GetComponent<TextMeshProUGUI>();
                
            if (numberText != null)
                originalColor = numberText.color;
        }
        
        public void SetValue(BigDouble value)
        {
            if (numberText != null)
            {
                numberText.text = "+" + NumberFormatter.Format(value);
                numberText.color = originalColor;
            }
            
            timer = lifetime;
        }
        
        private void Update()
        {
            if (timer > 0)
            {
                // Float upward
                transform.position += Vector3.up * floatSpeed * Time.deltaTime;
                
                // Fade out
                timer -= Time.deltaTime;
                float alpha = timer / lifetime;
                
                if (numberText != null)
                {
                    Color newColor = numberText.color;
                    newColor.a = alpha;
                    numberText.color = newColor;
                }
                
                if (timer <= 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}