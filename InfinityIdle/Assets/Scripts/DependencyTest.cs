using UnityEngine;
using BreakInfinity;
using Newtonsoft.Json;
#if UNITY_6_0_OR_NEWER
using UnityEngine.UIElements;
using Unity.Properties;
#endif
using TMPro;

public class DependencyTest : MonoBehaviour
{
    void Start()
    {
        Debug.Log("=== Testing Dependencies ===");
        
        // Test BreakInfinity
        try
        {
            BigDouble test = new BigDouble(1000);
            Debug.Log($"✓ BigDouble works: {test}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"✗ BigDouble failed: {e.Message}");
        }
        
        // Test JSON
        try
        {
            string json = JsonConvert.SerializeObject(new {test = "json works"});
            Debug.Log($"✓ JSON works: {json}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"✗ JSON failed: {e.Message}");
        }
        
        // Test TextMeshPro
        try
        {
            bool tmpAvailable = typeof(TextMeshProUGUI) != null;
            Debug.Log($"✓ TextMeshPro available: {tmpAvailable}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"✗ TextMeshPro check failed: {e.Message}");
        }
        
        Debug.Log("=== All tests complete! ===");
    }
}