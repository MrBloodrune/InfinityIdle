# Unity Scripts

This folder contains the C# scripts for the InfinityIdle Unity project. 

## Usage

Copy these scripts into your Unity project at:
`InfinityIdle/Assets/Scripts/`

## Required Dependencies

Before using these scripts, install the following in Unity:

1. **BreakInfinity.cs** - For handling large numbers
   - Available on Unity Asset Store or GitHub
   
2. **Newtonsoft.Json** - For save system
   - Install via Package Manager: `com.unity.nuget.newtonsoft-json`
   
3. **TextMeshPro** - For text rendering
   - Install via Package Manager (usually included by default)

## Script Organization

- **Core/** - Game management, save system, event bus
- **Currency/** - Currency management and big number handling
- **Utilities/** - Helper classes like number formatting

## Next Steps

1. Create a new Unity 2D project
2. Copy these scripts to Assets/Scripts/
3. Install required dependencies
4. Create a GameObject with GameManager attached
5. Run the game to initialize core systems