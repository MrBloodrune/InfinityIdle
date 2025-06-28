using UnityEngine;
using BreakInfinity;
using Newtonsoft.Json;

public class SimpleDependencyTest : MonoBehaviour
{
    void Start()
    {
        Debug.Log("=== Testing Core Dependencies ===");
        
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
            var testObj = new { message = "Hello from JSON", value = 42 };
            string json = JsonConvert.SerializeObject(testObj);
            Debug.Log($"✓ JSON serialization works: {json}");
            
            var deserialized = JsonConvert.DeserializeObject(json);
            Debug.Log($"✓ JSON deserialization works");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"✗ JSON failed: {e.Message}");
        }
        
        Debug.Log("=== Core dependency tests complete! ===");
        Debug.Log("Note: TextMeshPro is built into Unity 6 and doesn't need separate installation");
    }
}