# Technical Architecture

## System Overview

### Architecture Philosophy
The Galactic Conquest Idle game uses a modular, event-driven architecture built on Unity 2D with these core principles:
- **Separation of Concerns**: Each system operates independently with clear interfaces
- **Data-Driven Design**: ScriptableObjects for content, allowing designer iteration without code changes
- **Performance First**: Optimized for long play sessions and mobile battery life
- **Scalability**: Architecture supports content expansion without refactoring
- **Platform Agnostic**: Shared codebase with platform-specific implementations

### Design Patterns Used
- **Singleton Pattern**: Manager classes (CurrencyManager, FactionManager)
- **Observer Pattern**: Event system for loose coupling between systems
- **Object Pooling**: UI elements, particle effects, number popups
- **Strategy Pattern**: Faction-specific behaviors and calculations
- **State Machine**: Game progression stages and complex UI flows
- **Command Pattern**: Player actions for undo/replay functionality

### Dependency Management
```
GameManager (Core)
├── SaveManager
├── CurrencyManager
│   └── CondensationSystem
├── ProgressionManager
│   ├── PrestigeSystem
│   └── StageController
├── FactionManager
│   └── SkillTreeManager
├── EventManager
├── TravelManager
│   └── GalaxyMapController
└── UIManager
    ├── TabController
    └── NotificationSystem
```

### Module Communication
- Central EventBus for decoupled communication
- ScriptableObject events for designer-friendly triggers
- Direct references only for performance-critical paths
- Message queuing for non-critical updates

---

## Project Structure

### Folder Organization
```
Assets/
├── Scripts/
│   ├── Core/
│   │   ├── GameManager.cs
│   │   ├── SaveManager.cs
│   │   ├── AnalyticsManager.cs
│   │   ├── EventBus.cs
│   │   └── PlatformAbstraction.cs
│   ├── Currency/
│   │   ├── CurrencyManager.cs
│   │   ├── BigNumberHandler.cs
│   │   ├── CondensationSystem.cs
│   │   ├── CurrencyDisplay.cs
│   │   └── EntangledMatterManager.cs
│   ├── Progression/
│   │   ├── PrestigeManager.cs
│   │   ├── StageManager.cs
│   │   ├── RealityWarpController.cs
│   │   └── OfflineProgressCalculator.cs
│   ├── Buildings/
│   │   ├── Generator.cs
│   │   ├── BuildingManager.cs
│   │   ├── ProductionCalculator.cs
│   │   └── MilestoneTracker.cs
│   ├── Factions/
│   │   ├── FactionManager.cs
│   │   ├── FactionModifiers.cs
│   │   ├── CrossFactionUnlocks.cs
│   │   └── PhilosophyAxis.cs
│   ├── Skills/
│   │   ├── LinearSkillTree.cs
│   │   ├── NodeSkillTree.cs
│   │   ├── SkillEffectProcessor.cs
│   │   └── EndlessSinkHandler.cs
│   ├── Travel/
│   │   ├── GalaxyMap.cs
│   │   ├── TravelCostCalculator.cs
│   │   ├── TradeRouteManager.cs
│   │   ├── WormholeNetwork.cs
│   │   └── PathfindingSystem.cs
│   ├── Events/
│   │   ├── EventManager.cs
│   │   ├── EventQueue.cs
│   │   ├── BinaryEventHandler.cs
│   │   ├── ComplexEventHandler.cs
│   │   └── MinigameController.cs
│   ├── UI/
│   │   ├── UIManager.cs
│   │   ├── TabSystem.cs
│   │   ├── CurrencyDisplayPanel.cs
│   │   ├── EventNotificationUI.cs
│   │   ├── GalaxyMapUI.cs
│   │   └── MobileUIAdapter.cs
│   ├── Platform/
│   │   ├── SteamIntegration.cs
│   │   ├── MobileServices.cs
│   │   ├── CloudSaveService.cs
│   │   └── IAPHandler.cs
│   └── Utilities/
│       ├── ObjectPool.cs
│       ├── UpdateBatcher.cs
│       ├── NumberFormatter.cs
│       └── PerformanceMonitor.cs
├── Data/
│   ├── Factions/
│   ├── Buildings/
│   ├── Events/
│   ├── Skills/
│   └── Balance/
├── Prefabs/
│   ├── UI/
│   ├── Buildings/
│   ├── Effects/
│   └── Systems/
├── Resources/
│   ├── Sprites/
│   ├── Audio/
│   ├── Fonts/
│   └── Localization/
└── StreamingAssets/
    ├── BalanceData/
    └── EventTemplates/
```

### Naming Conventions
- **Scripts**: PascalCase (CurrencyManager.cs)
- **Methods**: PascalCase (CalculateProduction())
- **Variables**: camelCase (currentCredits)
- **Constants**: UPPER_SNAKE_CASE (MAX_BUILDINGS)
- **Interfaces**: IPrefixed (IPoolable)
- **Events**: On+Action (OnCurrencyChanged)
- **Coroutines**: Suffixed with Coroutine (LoadDataCoroutine)

### Asset Organization
- Sprites organized by feature (Buildings/, UI/, Icons/)
- Prefabs mirror script organization
- ScriptableObjects in Data/ with subdirectories
- Audio split into Music/ and SFX/
- Platform-specific assets in Platform/ subdirectories

Links to [[Code Examples#Core Systems]]

---

## Core Technologies

### Unity 2D Specifics
- **Unity Version**: 2021.3 LTS (Long Term Support)
- **Render Pipeline**: Built-in (for mobile compatibility)
- **UI System**: Unity UI (uGUI) with optimizations
- **Input System**: Both legacy and new Input System support
- **Physics**: Disabled (not needed for idle game)

### BreakInfinity.cs Integration
```csharp
// Wrapper for consistent usage
public static class BigNumber
{
    public static BigDouble Parse(string value) => BigDouble.Parse(value);
    public static string Format(BigDouble value) => NumberFormatter.Format(value);
    public static BigDouble Min(BigDouble a, BigDouble b) => BigDouble.Min(a, b);
    public static BigDouble Max(BigDouble a, BigDouble b) => BigDouble.Max(a, b);
}
```

### ScriptableObject Architecture
- **FactionData**: Stores faction properties, modifiers, philosophy
- **BuildingData**: Base costs, production rates, upgrade paths
- **EventData**: Event templates, choices, outcomes
- **SkillNodeData**: Effects, costs, connections
- **BalanceData**: Global constants, progression curves

### Job System Usage
- Batch calculations for thousands of buildings
- Offline progress computation
- Pathfinding for galaxy map
- Particle system updates

### Third-Party Libraries
- **BreakInfinity.cs**: Big number handling
- **DOTween**: UI animations (optional)
- **TextMeshPro**: Text rendering
- **Newtonsoft.Json**: Save file serialization
- **Unity Analytics**: Player behavior tracking

---

## Platform Considerations

### PC/Steam

#### Resolution Handling
- Support 16:9, 16:10, 21:9 aspects
- Minimum: 1280x720
- UI scales with screen size
- Safe areas for different aspects

#### Input Systems
- Full keyboard shortcuts
- Tooltip support on hover
- Right-click context menus
- Scroll wheel for zooming galaxy map
- Drag to pan galaxy view

#### Steam Integration
- Achievements API
- Cloud saves
- Rich presence
- Trading cards support
- Workshop for custom events/mods

#### Performance Targets
- 60 FPS standard, 144 FPS capable
- < 2GB RAM usage
- < 500MB install size
- 10 second cold start

### Mobile

#### Touch Optimization
- Minimum touch target: 44x44 pixels
- Gesture support (pinch, pan, tap, hold)
- No hover states
- Contextual button sizes
- Edge swipe protection

#### Battery Management
- FPS limiting options (30/60)
- Reduced particle effects mode
- Background calculation throttling
- Screen dimming in idle mode
- Automatic pause on minimize

#### Screen Adaptation
- Portrait and landscape support
- Dynamic UI layout
- Notch/cutout handling
- Scaled UI for tablets
- Font size accessibility options

#### Platform-Specific Features
- Push notifications for events
- Haptic feedback
- Share functionality
- Rate app prompts
- Ad integration hooks

### Cross-Platform

#### Shared Codebase Strategy
```csharp
public interface IPlatformService
{
    void Initialize();
    void SaveToCloud(SaveData data);
    void ShowAchievement(string id);
    void TrackEvent(string name, Dictionary<string, object> parameters);
}

public class PlatformManager
{
    private IPlatformService platformService;
    
    void Awake()
    {
        #if UNITY_STANDALONE
            platformService = new SteamPlatformService();
        #elif UNITY_IOS || UNITY_ANDROID
            platformService = new MobilePlatformService();
        #else
            platformService = new DefaultPlatformService();
        #endif
    }
}
```

#### Platform Abstractions
- File I/O abstraction
- Input handling layer
- Achievement system wrapper
- Analytics abstraction
- IAP abstraction

#### Cloud Save System
- Conflict resolution (newest wins)
- Compression before upload
- Incremental saves
- Offline queue
- Cross-platform compatibility

#### Account Management
- Optional account system
- Guest play support
- Social login options
- Progress transfer codes
- GDPR compliance

---

## Performance Architecture

### Update Loop Design
```csharp
public class UpdateManager : MonoBehaviour
{
    // Different update frequencies
    private float economyUpdateInterval = 0.1f;  // 10 Hz
    private float uiUpdateInterval = 0.0333f;    // 30 Hz
    private float saveInterval = 30f;            // Every 30 seconds
    
    // Staggered updates to avoid frame spikes
    void Start()
    {
        StartCoroutine(EconomyUpdate());
        StartCoroutine(UIUpdate());
        StartCoroutine(AutoSave());
    }
}
```

### Calculation Batching
- Group similar calculations
- Use dirty flags for changes
- Batch UI updates
- Cache frequently accessed values
- Precalculate when possible

### Render Optimization
- Multiple canvases (static/dynamic)
- Disable off-screen elements
- LOD for galaxy map
- Particle pooling
- Sprite atlasing

### Memory Pooling Strategies
- UI element pools (popups, effects)
- Event notification pools
- Number formatter cache
- Texture pools for dynamic content
- Audio source pooling

---

## Data Architecture

### ScriptableObject Usage
```csharp
[CreateAssetMenu(fileName = "BuildingData", menuName = "GameData/Building")]
public class BuildingData : ScriptableObject
{
    public string buildingName;
    public string description;
    public Sprite icon;
    public BigDouble baseCost;
    public BigDouble baseProduction;
    public float growthRate = 1.15f;
    public List<MilestoneData> milestones;
}
```

### Runtime Data Management
- Singleton managers for global state
- ScriptableObject instances for configuration
- Separate runtime instances from asset data
- Clear ownership of mutable data

### Persistent Data Design
```csharp
[System.Serializable]
public class SaveData
{
    public int version;
    public DateTime lastSave;
    public CurrencyData currencies;
    public BuildingData[] buildings;
    public FactionProgress factionProgress;
    public PrestigeData prestige;
    public Dictionary<string, object> flags;
}
```

### Configuration Systems
- Balance constants in ScriptableObjects
- Hot-reloadable in editor
- A/B testing support
- Remote configuration ready
- Version migration support

---

## Networking Architecture

### Cloud Save Implementation
- Automatic sync on pause/resume
- Manual sync button
- Conflict resolution UI
- Compression before upload
- Encryption for sensitive data

### Leaderboard System
- Global/Friends/Weekly boards
- Multiple metrics tracked
- Cheating prevention
- Cached for offline viewing
- Privacy controls

### Event Broadcasting
- Server-sent events support
- Special weekend events
- Community challenges
- News/update delivery
- Offline event queue

### Future Multiplayer Considerations
- Architecture allows for guilds/alliances
- Asynchronous interactions
- Shared galaxy instances possible
- Trading system groundwork
- PvP raid foundation

---

## Build Pipeline

### Automated Builds
- Jenkins/GitHub Actions integration
- Nightly builds
- Platform-specific builds
- Build numbering system
- Automated testing

### Version Management
```csharp
public static class Version
{
    public const int Major = 1;
    public const int Minor = 0;
    public const int Patch = 0;
    public const int Build = AUTO_INCREMENT;
    
    public static string Full => $"{Major}.{Minor}.{Patch}.{Build}";
}
```

### Asset Optimization
- Texture compression per platform
- Audio compression settings
- Sprite atlas generation
- Unused asset stripping
- Shader variant stripping

### Distribution Strategy
- Steam Direct
- Google Play
- Apple App Store
- itch.io
- Direct download option

---

## Third-Party Integrations

### Analytics Services
- Unity Analytics for basics
- Custom events for gameplay
- Funnel tracking
- Revenue tracking
- Privacy compliance

### Ad Networks (Optional)
- AdMob integration ready
- Unity Ads backup
- Reward video placements
- Banner ad positions
- Mediation support

### Payment Processing
- Unity IAP
- Receipt validation
- Restore purchases
- Regional pricing
- Fraud prevention

### Social Platforms
- Discord Rich Presence
- Twitter sharing
- Facebook login (optional)
- Reddit integration
- Twitch drops support

---

## Links to Other Documents
- [[Game Design#Core Systems]] - Game mechanics implementation
- [[Code Examples#Core Systems]] - Detailed code implementations
- [[Mathematical Systems#Performance]] - Performance calculations
- [[Development Plan#Technical Requirements]] - Technical milestones