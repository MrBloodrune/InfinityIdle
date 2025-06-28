# Galactic Conquest Idle Game - Architecture Document

## Game Overview

**Title**: Infinite Idle: Galactic Rule  
**Genre**: Idle/Clicker with Strategy Elements  
**Platform**: PC (Primary), Mobile (Secondary)  
**Engine**: Unity 2D  
**Target Audience**: Idle game enthusiasts who enjoy deeper strategic elements  
**Monetization**: Freemium with all content earnable through gameplay

### Core Concept
Players begin as the chosen emperor of a dying world and must expand their empire from planetary to universal scale through conquest, diplomacy, and trade. The game combines traditional idle mechanics with faction systems, random events, and strategic decision-making. Each faction provides a unique playthrough experience, encouraging multiple prestige cycles.

## Implementation Priority

### Phase 1: Core Loop (Weeks 1-4)
1. **Basic currency system** (Credits with condensation to Influence)
2. **5 basic generators** with exponential costs
3. **Currency condensation** (Credits → Influence only)
4. **Save/load system** with offline progress
5. **Basic UI** with tab system and condensation interface
6. **First prestige mechanic** (Energy generation)

### Phase 2: Faction Foundation (Weeks 5-8)
1. **2 initial factions** (Militaristic, Merchant)
2. **Faction-specific buildings**
3. **Dark Matter currency** (Influence → Dark Matter condensation)
4. **Basic travel system** (Influence costs for expansion)
5. **Basic event system** (binary only)
6. **Linear skill trees** (5 nodes each)

### Phase 3: Engagement Systems (Weeks 9-12)
1. **Daily mission system** (Entangled Matter rewards)
2. **Entangled Matter** implementation
3. **Basic monetization** (EM purchases + shop)
4. **All 6 factions** implemented
5. **Complex events** added
6. **Trade route system**
7. **Achievement system**

### Phase 4: Polish & Depth (Weeks 13-16)
1. **Advanced travel mechanics** (wormholes, energy jumps)
2. **Full skill trees** (30 nodes each)
3. **Prestige node system** (50 nodes)
4. **Reality warping** (Tier 1-2)
5. **Currency condensation automation**
6. **Mobile optimization**

### Phase 5: Beta & Launch (Weeks 17-20)
1. **Balance testing** with player feedback
2. **Tutorial system** (emphasize condensation and travel)
3. **Cloud saves**
4. **Platform-specific features**
5. **Launch preparation**

---

## Success Metrics

### Player Retention Targets
- **Day 1**: 40% (Tutorial completion)
- **Day 7**: 20% (First prestige)
- **Day 30**: 10% (Multiple factions tried)
- **Day 90**: 5% (Deep engagement)

### Monetization Targets
- **Conversion Rate**: 2-5% of players make purchase
- **ARPPU**: $10-20 monthly
- **Ad Revenue**: $0.50-1.00 per daily active user (if ads enabled)

### Engagement Metrics
- **Daily Play Time**: 15-30 minutes active, 2-4 hours passive
- **Prestiges per Week**: 2-5 (scaling down over time)
- **Events Completed**: 70%+ completion rate
- **Faction Switching**: 50% of players try 2+ factions

---

## Energy System & Reality Warping

### Energy Generation Mechanics

**Sacrifice Options**:
1. **Planet Sacrifice**
   - Requires full control of planet
   - Permanently removes from game
   - Energy = sqrt(total_resources_generated / 10^12)
   - Bonus multiplier for special planets

2. **System Sacrifice**
   - Requires all planets in system
   - Multiplier based on system completion
   - Energy = base * (1 + 0.1 * planet_count)^2

3. **Galaxy Sacrifice** (Late Game)
   - Requires 75%+ galaxy control
   - Massive Energy boost
   - Unlocks reality warp options

### Reality Warp Options

**Tier 1 Warps** (1-10 Energy):
- Instant building construction
- Skip event cooldowns
- Temporary production boost (x10, 1 hour)
- Reset faction relations

**Tier 2 Warps** (10-100 Energy):
- Faction alignment shift (keep 25% progress)
- Permanent building discount (5%)
- Unlock cross-faction technology
- Create wormhole (instant travel)

**Tier 3 Warps** (100-1000 Energy):
- Major faction switch (keep 50% progress)
- Universe law change (+production, +costs)
- Unlock unique faction hybrid
- Time acceleration (permanent +10% speed)

**Tier 4 Warps** (1000+ Energy):
- Complete faction memory (start with all unlocks)
- Fundamental constant change (alter game math)
- Multiverse bridge (access parallel games)
- Omnipotence mode (all factions simultaneously at 10%)

### Energy Scaling Formula
```
Energy_cost = base_cost * (times_used^1.5) * (prestige_level^0.5)
```

This ensures early warps are accessible but later ones require strategic planning.

---

## Skill Tree Systems

### Faction-Specific Linear Trees
Each faction has a unique linear skill tree with 3 branches:

**Branch Types**:
1. **Economic Branch**: Production multipliers, cost reductions
2. **Military Branch**: Combat bonuses, conquest speed
3. **Special Branch**: Faction-unique abilities

**Tree Structure**:
- 10 levels per branch (30 total)
- Each level costs increasing Energy
- Final levels have "endless sink" options (1% bonus per level, no cap)
- Completing all branches unlocks faction mastery bonus

### Prestige Node System (Path of Exile-inspired)
- **Starting Nodes**: Determined by which faction tree you completed
- **Node Types**:
  - Small nodes: +5% to specific currency
  - Medium nodes: +25% to specific mechanic
  - Keystone nodes: Game-changing effects
  - Gateway nodes: Connect distant parts of tree

**Example Keystone Nodes**:
- "Entropic Cascade": Buildings have 50% chance to generate x10 resources but 1% chance to explode
- "Temporal Flux": Offline progress runs at 200% but online at 50%
- "Quantum Superposition": All faction bonuses at 25% effectiveness

---

## Monetization & Engagement Systems

### Freemium Model Structure

**Core Philosophy**: Everything purchasable is earnable through active play

### Mission System (Engagement Driver)
**Daily Missions** (Reset 24h):
- Click 1000 times: 10 Entangled Matter
- Complete 5 events: 10 Entangled Matter
- Reach X production: 15 Entangled Matter

**Weekly Missions** (Reset 7d):
- Prestige once: 100 Entangled Matter
- Try new faction: 150 Entangled Matter
- Reach stage X: 200 Entangled Matter

**Monthly Challenges** (Reset 30d):
- Complete faction tree: 500 Entangled Matter
- Achieve X Energy: 1000 Entangled Matter
- Special challenge: 2000 Entangled Matter

### Entangled Matter System
**Quantum Currency Mechanics**:
- When spending, player chooses what currency it "becomes"
- Conversion rates scale with progression stage
- Can entangle with: Credits, Influence, Dark Matter, or Energy (limited)
- Special entanglements during events (2x efficiency, specific currency only)

**Conversion Examples**:
- Early game: 1 Entangled Matter = 1 hour of current production
- Mid game: 1 Entangled Matter = 6 hours of production
- Late game: 1 Entangled Matter = 24 hours of production
- Energy entanglement: 100 Entangled Matter = 1 Energy (limited uses)

### IAP Options (Placeholder Prices)
1. **Entangled Matter Packs**: $1-$100 (100-15,000 Entangled Matter)
2. **Starter Packs**: $5-$20 (Entangled Matter + temporary boosts)
3. **QoL Features**:
   - Auto-clicker: 500 Entangled Matter or $5
   - Offline progress +4h: 300 Entangled Matter or $3
   - Event queue: 1000 Entangled Matter or $10
4. **Faction Unlocks**: 
   - Early unlock: 2000 Entangled Matter or $20
   - Instant unlock all: $50

### Entangled Matter Spending Options
- **Time Warps**: 2x speed (30 min) - 50 Entangled Matter
- **Instant Event**: Skip cooldown - 25 Entangled Matter  
- **Resource Boost**: x10 all for 1h - 100 Entangled Matter
- **Faction Switch**: Reduce Energy cost by 50% - 200 Entangled Matter
- **Prestige Boost**: +100% Energy gain (one prestige) - 500 Entangled Matter
- **Currency Entanglement**: Convert to any base currency at current rates

### Ad Integration (Optional)
- Watch ad for 2x production (30 min)
- Watch ad to refresh one daily mission
- Watch ad for 10 free Entangled Matter (3x daily)

---

## Design Questions & Decisions

### 1. Core Gameplay Loop

**Currency System** (4-tier system):
1. **Credits**: Basic currency for buildings, units, and infrastructure
2. **Influence**: Diplomatic/political currency for faction relations and events
3. **Dark Matter**: Advanced currency for late-game upgrades and special units
4. **Energy** (Prestige): Universal energy gained by consuming planets/systems
   - Allows reality warping abilities
   - Faction alignment changes
   - Permanent universal upgrades
   - Scales with prestige level for larger/more frequent reality changes

**Energy Mechanics**:
- Sacrifice entire planets/systems for Energy (permanent loss)
- Energy cost for faction switch scales with current progression
- Reality warps can alter fundamental game rules
- Energy accumulation accelerates in later prestige cycles

**Primary Click Action**: 
- **Imperial Decree** - Generates small amounts of all three base currencies
- Effectiveness modified by faction choice and upgrades
- Can trigger instant events or bonuses

### Progression System

**Stage Structure with Scaling Difficulty**:
1. **Planetary Unification** (Tutorial - Hour 1)
   - Unify dying homeworld
   - Introduce basic mechanics
   - First faction choice

2. **Solar Expansion** (Hours 1-10, first run)
   - Colonize nearby planets
   - First alien contact
   - Trade routes unlock
   - First Energy gain opportunity

3. **Galactic Conquest** (Days 1-7, scales with prestige)
   - Warp drive technology
   - Major faction warfare
   - Diplomatic alliances
   - Multiple systems available for Energy conversion

4. **Universal Dominion** (Weeks 1-4+)
   - Wormhole navigation
   - Reality manipulation unlocked
   - First faction switch available
   - Energy costs become primary progression gate

5. **Multiversal Ascension** (Months 1+)
   - Cross-dimensional warfare
   - Eldritch opponents
   - Massive Energy generation
   - Reality warps affect multiple universes

**Prestige Scaling**:
- Early prestiges: 2-4 hours (quick progression)
- Mid-game prestiges: 1-3 days (balanced runs)
- Late-game prestiges: 1-2 weeks (deep strategic play)
- Currency gains scale exponentially with Energy invested

### Faction System

**Multi-Axis Philosophy System** (Stellaris-inspired):
- **Expansion Axis**: Isolationist ↔ Expansionist
- **Governance Axis**: Authoritarian ↔ Democratic  
- **Technology Axis**: Traditionalist ↔ Progressive
- **Economic Axis**: Collectivist ↔ Individualist

**Initial Six Factions** (with unique mechanics):

1. **Militaristic Confederation** (Expansionist/Authoritarian)
   - Unique Building: War Academies (+50% fleet production)
   - Special Event: Military coups (can be beneficial)
   - Playstyle: Aggressive expansion, conquest bonuses
   - Energy Focus: Converting conquered worlds

2. **Merchant Republic** (Expansionist/Individualist)
   - Unique Building: Trade Hubs (multiply credit generation)
   - Special Event: Market fluctuations (risk/reward)
   - Playstyle: Economic snowballing, trade route optimization
   - Energy Focus: Bankrupting then consuming economic rivals

3. **Technocratic Union** (Progressive/Collectivist)
   - Unique Building: Research Complexes (unlock automation faster)
   - Special Event: Scientific breakthroughs (tech jumps)
   - Playstyle: Efficiency focus, reduced click requirements
   - Energy Focus: Consuming obsolete tech worlds

4. **Psionic Collective** (Isolationist/Authoritarian)
   - Unique Building: Mind Spires (influence generation x3)
   - Special Event: Psychic storms (temporary boosts)
   - Playstyle: Influence-heavy, event manipulation
   - Energy Focus: Harvesting psychic populations

5. **Machine Intelligence** (Progressive/Authoritarian)
   - Unique Building: Server Farms (perfect efficiency)
   - Special Event: Logic cascades (no negative events)
   - Playstyle: Predictable growth, no RNG
   - Energy Focus: Digitizing organic worlds

6. **Organic Hive** (Expansionist/Collectivist)
   - Unique Building: Spawning Pools (exponential unit growth)
   - Special Event: Evolution leaps (permanent multipliers)
   - Playstyle: Population-based power, consume mechanics
   - Energy Focus: Devouring entire biospheres

**Faction Switching**:
- Requires Energy investment (scales with current power)
- Retains 10-50% of buildings (based on compatibility)
- Unlocks cross-faction technologies after switching
- Each faction has exclusive achievements/unlocks

### Event System

**Progressive Event Complexity**:
- **Early Game**: 80% binary choices, 20% resource-based
- **Mid Game**: 50% binary, 50% multi-option
- **Late Game**: 20% binary, 80% complex strategic decisions

**Event Categories**:
- **Political** (assassination attempts, coups, elections)
  - Binary: "Support coup?" Yes (+military, -influence) / No (+influence, -military)
  - Complex: Multiple faction support options with varying costs/benefits
  
- **Economic** (market crashes, resource discoveries)
  - Binary: "Exploit workers?" Yes (+credits now) / No (+credits/second)
  - Complex: Investment options with risk/reward ratios
  
- **Military** (rebellions, invasions, defections)
  - Binary: "Crush rebellion?" Yes (lose population) / No (lose control)
  - Complex: Multiple response strategies affecting multiple systems
  
- **Cosmic** (supernovas, wormhole anomalies, ancient artifacts)
  - Binary: "Investigate anomaly?" Yes (random effect) / No (safe)
  - Complex: Research paths with long-term consequences

**Mini-game Events** (Late-game addition):
- **Siege Events**: Rapid clicking increases success chance
- **Diplomacy Events**: Pattern matching for better outcomes  
- **Research Events**: Simple puzzle solving for permanent bonuses
- Success grants small permanent multipliers (0.1% - 1%)

**Event Frequency**: 
- Early game: 1 event per 5-10 minutes
- Mid game: 1 event per 2-5 minutes
- Late game: Multiple simultaneous events requiring prioritization
- Faction choice affects event types and frequency

---

## Technical Architecture

### Core Systems

```
GameCore/
├── Currencies/
│   ├── CurrencyManager.cs
│   ├── BigNumberSystem.cs (BreakInfinity)
│   ├── CurrencyDisplay.cs
│   ├── CurrencyCondenser.cs (hierarchical conversion)
│   └── EnergySystem.cs (prestige currency)
├── Generators/
│   ├── Generator.cs (base class)
│   ├── PlanetaryBuildings.cs
│   ├── FleetProduction.cs
│   ├── PassiveIncome.cs
│   └── FactionBuildings.cs (unique per faction)
├── TravelSystem/
│   ├── GalaxyMap.cs
│   ├── TravelCostCalculator.cs
│   ├── TradeRouteManager.cs
│   ├── WormholeNetwork.cs
│   └── ExpansionStrategy.cs
├── Progression/
│   ├── StageManager.cs
│   ├── PrestigeSystem.cs
│   ├── EnergyConversion.cs (planet/system sacrifice)
│   └── AchievementSystem.cs
├── Factions/
│   ├── FactionManager.cs
│   ├── FactionDefinitions.cs (ScriptableObjects)
│   ├── DiplomacySystem.cs
│   ├── FactionModifiers.cs
│   └── FactionSwitching.cs
├── SkillTrees/
│   ├── LinearTreeManager.cs
│   ├── NodeTreeManager.cs
│   ├── SkillDefinitions.cs (ScriptableObjects)
│   └── TreeSerializer.cs
├── Events/
│   ├── EventSystem.cs
│   ├── EventDatabase.cs (ScriptableObjects)
│   ├── BinaryEventHandler.cs
│   ├── ComplexEventHandler.cs
│   ├── MinigameController.cs
│   └── EventUI.cs
├── Missions/
│   ├── MissionManager.cs
│   ├── DailyMissions.cs
│   ├── WeeklyMissions.cs
│   ├── MonthlyMissions.cs
│   └── MissionRewards.cs
├── Monetization/
│   ├── EntangledMatterManager.cs
│   ├── IAPHandler.cs
│   ├── AdManager.cs (optional)
│   ├── EntanglementSystem.cs (currency conversion)
│   └── ShopUI.cs
└── SaveSystem/
    ├── SaveManager.cs
    ├── CloudSaveIntegration.cs
    ├── OfflineProgressCalculator.cs
    └── SaveVersioning.cs
```

### Data Architecture

**ScriptableObject Database**:
```
DataAssets/
├── Factions/
│   ├── MilitaristicConfederation.asset
│   ├── MerchantRepublic.asset
│   └── [Other factions...]
├── Buildings/
│   ├── Common/
│   └── FactionSpecific/
├── Events/
│   ├── EarlyGame/
│   ├── MidGame/
│   └── LateGame/
├── Skills/
│   ├── LinearTrees/
│   └── NodeDefinitions/
├── Missions/
│   ├── DailyTemplates/
│   ├── WeeklyTemplates/
│   └── MonthlyTemplates/
└── Upgrades/
    └── [Various upgrade definitions]
```

### Performance Targets

- **Mobile**: 30 FPS minimum, 2-hour battery life
- **PC**: 60 FPS target, 144 FPS capable
- **Save frequency**: Every 30 seconds + on major actions
- **Maximum save size**: 1MB compressed
- **Event processing**: <16ms per frame
- **Number calculations**: Batched every 100ms

---

## Monetization Strategy (Optional)

**Question**: What's your monetization approach?
- [ ] Premium one-time purchase
- [ ] Free with ads + ad removal IAP
- [ ] Freemium with convenience IAPs
- [ ] Purely free/open source

**Suggested IAPs** (if applicable):
- Time warps (2x, 4x, 8x speed for 30 minutes)
- Starter packs for new prestiges
- Cosmetic empire customization
- Additional save slots

---

## Key Mathematical Constants

### Generator Scaling
- **Building cost growth**: 
  - Common buildings: 1.12x - 1.15x
  - Faction buildings: 1.18x - 1.25x
  - Energy converters: 1.5x - 2.0x
- **Production growth**: Linear with milestone multipliers at 25, 50, 100, 250, 500, 1000
- **Energy formula**: 
  - Planet sacrifice: sqrt(planet_value / 10^12)
  - System sacrifice: sqrt(system_value / 10^18) * system_count
  - Galaxy sacrifice: sqrt(galaxy_value / 10^24) * galaxy_count^1.5

### Currency Relationships
- **Base Generation Rates**:
  - Credits: Base currency, all costs reference this
  - Influence: Generated at Credits/100 rate initially
  - Dark Matter: Generated at Credits/10,000 rate initially
  - Energy: Prestige only, not generated passively
- **Condensation Ratios**:
  - Base: 1,000,000:1 (Credits→Influence, Influence→Dark Matter)
  - With upgrades: Can improve to 900,000:1, 800,000:1, etc.
  - Faction bonuses: Up to 20% better ratios
  - Automation unlocked at prestige level 10

### Travel System Constants
- **Intra-system**: Free
- **Adjacent systems**: 100 * distance^2 Influence
- **Trade route upkeep**: 10 Influence/minute/jump
- **Warp jump**: 100 * distance Dark Matter
- **Galaxy hop**: 10,000 Dark Matter + 1 Energy
- **Wormhole creation**: 100 Energy (permanent)
- **Travel cost reductions**:
  - Technology: -10% per level (max 50%)
  - Faction bonuses: -20% to -50%
  - Infrastructure: -5% per space highway

### Time Scales
- **Offline progress cap**: 
  - Base: 2 hours
  - Upgraded: 8 hours
  - Premium: 24 hours
- **Tick rate**: 10 Hz display, 1 Hz calculations
- **Save interval**: 30 seconds
- **Event cooldowns**: 
  - Early: 300-600 seconds
  - Late: 120-300 seconds

### Balance Targets
- **First prestige**: 2-4 hours of active play
- **First faction switch**: 10-20 total Energy
- **First condensation**: 30-60 minutes (1M credits)
- **New content unlock**: Every 2-3 prestiges
- **"Wall" feeling**: Every 10x total Energy
- **Complete faction tree**: 50-100 prestiges
- **Unlock all factions**: 200-500 hours total playtime

### Faction-Specific Multipliers
- **Militaristic**: x2 fleet production, x0.5 influence generation, -20% travel costs
- **Merchant**: x3 credit generation, x0.7 dark matter generation, -50% trade route costs
- **Technocratic**: x1.5 all automation, x0.8 click power, -30% condensation ratios
- **Psionic**: x3 influence generation, x0.5 credit generation, free intra-galaxy travel
- **Machine**: x1.2 all resources, no random event bonuses, perfect condensation (1M:1)
- **Organic**: x1.05^population all resources, x2 consumption costs, +50% travel costs

### Mission Rewards (Entangled Matter Economy)
- **Daily completion**: 30-50 Entangled Matter
- **Weekly completion**: 200-500 Entangled Matter
- **Monthly completion**: 1500-3500 Entangled Matter
- **Natural earn rate**: ~100 Entangled Matter/day active play
- **Target**: Significant purchase every 5-7 days
- **Entanglement rates**: Scale with progression stage

---

## UI/UX Architecture

### Screen Layout

```
┌─────────────────────────────────────┐
│  Resources Bar (Credits/Inf/DM/EM)  │
│  [Condense] buttons between tiers   │
├─────────────┬───────────────────────┤
│             │                       │
│  Galaxy Map │   Building/Fleet     │
│  (Shows     │   Management Panel   │
│   travel    │                       │
│   costs)    │                       │
│             ├───────────────────────┤
│             │   Travel & Trade     │
│             │   Route Overview     │
├─────────────┴───────────────────────┤
│  Event Notifications / Choices      │
└─────────────────────────────────────┘
```

**Tab Structure**:
1. Empire (main view with travel costs)
2. Military
3. Diplomacy  
4. Research
5. Trade Routes (manage established routes)
6. Artifacts (late game)
7. Statistics
8. Achievements
9. Settings

**Currency Display Enhancement**:
- Show condensation progress bars (e.g., 750K/1M Credits → Influence)
- Quick condense buttons with confirmation
- Entangled Matter special display with "entangle" options
- Travel cost preview on hover over distant systems

**Travel System UI**:
- Galaxy map with distance indicators
- Cost preview before confirming travel
- Trade route visualization with upkeep costs
- Wormhole network overlay (late game)
- Color coding for travel methods (green=free, yellow=influence, purple=dark matter, red=energy)

**Question**: Should the UI be diegetic (part of the game world) or traditional menu-based?

---

## Technical Implementation Details

### Multiplayer & Social Features
- **Primary**: Single-player focused
- **Social Features**: 
  - Leaderboards (Energy accumulated, fastest prestiges)
  - Weekly faction competitions
  - Shared universe events (affect all players' event pools)

### Platform Features
- **Cloud saves**: Required for cross-device progression
- **Steam Integration**: Achievements, trading cards, workshop for custom events
- **Mobile Features**: 
  - Push notifications for completed missions
  - Offline progress notifications
  - Battery saver mode (reduced FPS/effects)

### MVP Content Scope
**MVP Features**:
- 4 progression stages (Planet → Solar → Galaxy → Universal)
- 6 factions with unique mechanics
- 30 building types (5 common per stage + 5 unique per faction)
- 100 achievements
- Linear skill trees for each faction
- Basic prestige node tree (50 nodes)
- 30 event types (10 binary, 20 complex)
- Daily/Weekly mission system
- Basic monetization (gems + time warps)

**Post-Launch Roadmap**:
- **Month 1**: Multiversal stage + 2 new factions
- **Month 2**: Expanded node tree (150+ nodes)
- **Month 3**: Mini-game events + artifact system
- **Month 6**: Second prestige layer (Transcendence)
- **Year 1**: Total of 12 factions, 500+ nodes

### Art Direction
- **Recommended**: Vector/geometric with particle effects
- Clean, readable UI optimized for mobile
- Faction-specific color schemes and iconography
- Scalable graphics for planet → universe visualization
- Minimal but impactful animations (performance focus)

---

## Risk Mitigation

### Technical Risks
1. **Save system corruption**: Implement rolling backups (last 5 saves)
2. **Number overflow**: Use BreakInfinity from day 1
3. **Performance degradation**: Profile every build, strict draw call budget

### Design Risks
1. **Complexity creep**: Start simple, add features based on metrics
2. **Balance issues**: Implement analytics from day 1
3. **Player retention**: Daily rewards, events, constant progression visibility

---

## Next Steps

### Immediate Development Tasks

1. **Set up project structure**
   - Create Unity project with folder hierarchy
   - Import BreakInfinity.cs for number handling
   - Set up ScriptableObject templates

2. **Implement core mathematics**
   - BigDouble currency system
   - Generator cost/production formulas
   - Offline progress calculator
   - Energy conversion formulas

3. **Build basic UI framework**
   - Tab system with 7 main tabs
   - Currency display with number formatting
   - Building purchase buttons
   - Simple event notification system

4. **Create first faction prototype**
   - Militaristic Confederation as template
   - 5 unique buildings
   - 3 faction-specific events
   - Basic skill tree (5 nodes)

5. **Implement save system**
   - Local save/load
   - Version compatibility
   - Offline progress on load
   - Auto-save every 30 seconds

### Week 1 Prototype Goals
- Playable first 30 minutes
- Credits generation working
- 10 buildings available
- First prestige possible
- One faction fully implemented

### Technical Validation Needed
- Performance test with 1000+ buildings
- Save system stress test (1MB+ saves)
- Mobile battery usage baseline
- Event system performance with 10+ simultaneous events

### Design Validation Questions
1. Is 15% cost growth too aggressive for buildings with travel costs added?
2. Does faction switching feel rewarding vs punishing?
3. Is Energy gain rate satisfying?
4. Do events interrupt flow or enhance it?
5. Is the mission system compelling enough for daily return?
6. Does travel cost create interesting decisions or just friction?
7. Is 1M:1 condensation ratio intuitive and achievable?
8. Should Entangled Matter → Energy conversion be limited or unlimited?

---

## Code Examples

### Currency Condensation System

```csharp
public class CurrencyCondenser : MonoBehaviour
{
    [System.Serializable]
    public class CondensationTier
    {
        public string fromCurrency;
        public string toCurrency;
        public BigDouble baseRatio = 1000000; // 1M:1 default
        public float currentEfficiency = 1.0f; // Multiplier from upgrades
    }
    
    public List<CondensationTier> condensationTiers;
    private Dictionary<string, CondensationTier> tierLookup;
    
    void Start()
    {
        // Set up condensation hierarchy
        condensationTiers = new List<CondensationTier>
        {
            new CondensationTier { fromCurrency = "Credits", toCurrency = "Influence" },
            new CondensationTier { fromCurrency = "Influence", toCurrency = "DarkMatter" }
        };
        
        BuildLookupTable();
    }
    
    public bool CanCondense(string fromCurrency, BigDouble amount)
    {
        if (!tierLookup.ContainsKey(fromCurrency)) return false;
        
        var tier = tierLookup[fromCurrency];
        BigDouble requiredAmount = tier.baseRatio * tier.currentEfficiency;
        
        return CurrencyManager.Instance.GetCurrency(fromCurrency) >= requiredAmount * amount;
    }
    
    public void CondenseCurrency(string fromCurrency, BigDouble amount)
    {
        if (!CanCondense(fromCurrency, amount)) return;
        
        var tier = tierLookup[fromCurrency];
        BigDouble cost = tier.baseRatio * tier.currentEfficiency * amount;
        
        // Apply faction bonuses
        if (FactionManager.Instance.currentFaction.factionName == "Machine Intelligence")
        {
            cost *= 0.9f; // 10% efficiency bonus
        }
        
        CurrencyManager.Instance.SpendCurrency(fromCurrency, cost);
        CurrencyManager.Instance.AddCurrency(tier.toCurrency, amount);
        
        // Trigger achievement/analytics
        AchievementManager.Instance.CheckCondensationAchievements(fromCurrency, amount);
    }
    
    public void UpgradeEfficiency(string fromCurrency, float improvement)
    {
        if (tierLookup.ContainsKey(fromCurrency))
        {
            tierLookup[fromCurrency].currentEfficiency *= (1f - improvement);
        }
    }
}
```

### Travel Cost Calculator

```csharp
public class TravelCostCalculator : MonoBehaviour
{
    [System.Serializable]
    public class TravelCost
    {
        public string currencyType;
        public BigDouble amount;
        public float time; // Travel time in seconds
    }
    
    public AnimationCurve distanceCostCurve;
    public float baseInfluenceCost = 100f;
    public float baseDarkMatterCost = 100f;
    
    public TravelCost CalculateTravelCost(CelestialBody from, CelestialBody to)
    {
        float distance = Vector3.Distance(from.galacticPosition, to.galacticPosition);
        TravelCost cost = new TravelCost();
        
        // Determine travel tier based on distance
        if (distance < 1f) // Same system
        {
            cost.currencyType = "Credits";
            cost.amount = 0; // Free intra-system travel
            cost.time = 0;
        }
        else if (distance < 10f) // Nearby systems
        {
            cost.currencyType = "Influence";
            cost.amount = new BigDouble(baseInfluenceCost * Mathf.Pow(distance, 2));
            cost.time = distance * 60f; // 1 minute per unit distance
        }
        else if (distance < 100f) // Same galaxy
        {
            cost.currencyType = "DarkMatter";
            cost.amount = new BigDouble(baseDarkMatterCost * distance);
            cost.time = distance * 10f; // Faster with dark matter
        }
        else // Intergalactic
        {
            cost.currencyType = "Energy";
            cost.amount = new BigDouble(Mathf.Ceil(distance / 100f));
            cost.time = 0; // Instant with energy
        }
        
        // Apply modifiers
        ApplyFactionModifiers(ref cost);
        ApplyTechnologyModifiers(ref cost);
        ApplyInfrastructureModifiers(from, to, ref cost);
        
        return cost;
    }
    
    void ApplyFactionModifiers(ref TravelCost cost)
    {
        var faction = FactionManager.Instance.currentFaction;
        
        switch (faction.factionName)
        {
            case "Merchant Republic":
                if (cost.currencyType == "Influence")
                    cost.amount *= 0.5f; // 50% trade route discount
                break;
            case "Psionic Collective":
                if (cost.currencyType == "DarkMatter")
                    cost.amount = 0; // Free intra-galaxy travel
                break;
            case "Machine Intelligence":
                cost.time *= 0.7f; // 30% faster travel
                break;
        }
    }
    
    public void EstablishTradeRoute(CelestialBody from, CelestialBody to)
    {
        float distance = Vector3.Distance(from.galacticPosition, to.galacticPosition);
        int jumps = Mathf.CeilToInt(distance);
        
        BigDouble upkeepCost = new BigDouble(10 * jumps); // 10 influence per jump per minute
        
        TradeRoute route = new TradeRoute
        {
            start = from,
            end = to,
            upkeepPerMinute = upkeepCost,
            bonusMultiplier = 1f + (0.1f * jumps) // More distant = more profitable
        };
        
        TradeRouteManager.Instance.AddRoute(route);
    }
}
```

### Entangled Matter System

```csharp
public class EntangledMatterManager : MonoBehaviour
{
    public BigDouble entangledMatter;
    
    [System.Serializable]
    public class EntanglementOption
    {
        public string targetCurrency;
        public BigDouble conversionRate; // How much of target currency per EM
        public float progressionMultiplier; // Scales with game stage
    }
    
    public List<EntanglementOption> entanglementOptions;
    
    public void SpendEntangledMatter(BigDouble amount, string targetCurrency)
    {
        if (entangledMatter < amount) return;
        
        var option = entanglementOptions.Find(x => x.targetCurrency == targetCurrency);
        if (option == null) return;
        
        // Calculate actual conversion based on progression
        BigDouble actualRate = option.conversionRate * GetProgressionMultiplier();
        
        // Special case for Energy
        if (targetCurrency == "Energy")
        {
            if (GetEnergyEntanglementCount() >= GetMaxEnergyEntanglements())
            {
                UIManager.Instance.ShowError("Maximum Energy entanglements reached this prestige!");
                return;
            }
        }
        
        entangledMatter -= amount;
        CurrencyManager.Instance.AddCurrency(targetCurrency, amount * actualRate);
        
        // Track for achievements
        TrackEntanglement(targetCurrency, amount);
    }
    
    float GetProgressionMultiplier()
    {
        // Early game: 1 EM = 1 hour production
        // Late game: 1 EM = 24 hours production
        int prestigeLevel = PrestigeManager.Instance.GetPrestigeLevel();
        return Mathf.Pow(2f, Mathf.Min(prestigeLevel * 0.5f, 4.58f)); // Caps at 24x
    }
    
    public void AddEntangledMatter(BigDouble amount, string source)
    {
        entangledMatter += amount;
        
        // Special event: Quantum entanglement burst
        if (Random.value < 0.01f) // 1% chance
        {
            EventManager.Instance.TriggerEvent("QuantumBurst", new Dictionary<string, object>
            {
                { "multiplier", Random.Range(2f, 5f) },
                { "duration", 300f } // 5 minutes
            });
        }
    }
}
```

### Faction System Implementation

```csharp
[CreateAssetMenu(fileName = "FactionData", menuName = "GameData/Faction")]
public class FactionData : ScriptableObject
{
    public string factionName;
    public Sprite factionIcon;
    public Color factionColor;
    
    [Header("Philosophy Axes")]
    [Range(-10, 10)] public int expansionism; // -10 isolationist, +10 expansionist
    [Range(-10, 10)] public int governance;   // -10 authoritarian, +10 democratic
    [Range(-10, 10)] public int technology;   // -10 traditional, +10 progressive
    [Range(-10, 10)] public int economics;    // -10 collectivist, +10 individualist
    
    [Header("Unique Mechanics")]
    public List<BuildingData> uniqueBuildings;
    public List<EventData> uniqueEvents;
    public MultiplierSet baseMultipliers;
    
    [Header("Skill Tree")]
    public LinearSkillTree economicBranch;
    public LinearSkillTree militaryBranch;
    public LinearSkillTree specialBranch;
    
    [Header("Energy Focus")]
    public string energyGenerationMethod;
    public float energyMultiplier = 1.0f;
}

[System.Serializable]
public class MultiplierSet
{
    public float creditMultiplier = 1.0f;
    public float influenceMultiplier = 1.0f;
    public float darkMatterMultiplier = 1.0f;
    public float buildingCostMultiplier = 1.0f;
    public float eventFrequencyMultiplier = 1.0f;
}

public class FactionManager : MonoBehaviour
{
    public FactionData currentFaction;
    public int factionSwitchCount = 0;
    
    public void SwitchFaction(FactionData newFaction, bool useEnergy = true)
    {
        if (useEnergy)
        {
            BigDouble energyCost = CalculateSwitchCost(newFaction);
            if (!GameManager.Instance.CanAffordEnergy(energyCost))
                return;
            
            GameManager.Instance.SpendEnergy(energyCost);
        }
        
        // Calculate retention based on philosophy compatibility
        float compatibility = CalculateCompatibility(currentFaction, newFaction);
        float retentionRate = Mathf.Lerp(0.1f, 0.5f, compatibility);
        
        // Apply retention to buildings
        BuildingManager.Instance.ApplyFactionSwitch(retentionRate);
        
        // Switch faction
        currentFaction = newFaction;
        factionSwitchCount++;
        
        // Apply new faction bonuses
        ApplyFactionModifiers();
        
        // Unlock cross-faction tech if applicable
        if (factionSwitchCount > 1)
            UnlockCrossFactionTech();
    }
    
    float CalculateCompatibility(FactionData from, FactionData to)
    {
        if (from == null || to == null) return 0.5f;
        
        float diff = 0;
        diff += Mathf.Abs(from.expansionism - to.expansionism);
        diff += Mathf.Abs(from.governance - to.governance);
        diff += Mathf.Abs(from.technology - to.technology);
        diff += Mathf.Abs(from.economics - to.economics);
        
        // Convert to 0-1 range (max diff is 80)
        return 1f - (diff / 80f);
    }
}
```

### Energy Sacrifice System

```csharp
public class EnergyConverter : MonoBehaviour
{
    public BigDouble CalculatePlanetEnergy(Planet planet)
    {
        BigDouble totalValue = planet.totalResourcesGenerated;
        BigDouble baseEnergy = BigDouble.Sqrt(totalValue / 1e12);
        
        // Apply faction multiplier
        float factionBonus = FactionManager.Instance.currentFaction.energyMultiplier;
        
        // Apply special planet bonuses
        float specialBonus = 1f;
        if (planet.hasAncientArtifact) specialBonus *= 2f;
        if (planet.isHomeworld) specialBonus *= 0.5f; // Penalty for destroying homeworld
        
        return baseEnergy * factionBonus * specialBonus;
    }
    
    public void SacrificePlanet(Planet planet)
    {
        BigDouble energy = CalculatePlanetEnergy(planet);
        
        // Create dramatic effect
        StartCoroutine(PlanetDestructionAnimation(planet));
        
        // Grant energy
        GameManager.Instance.AddEnergy(energy);
        
        // Remove planet from game
        PlanetManager.Instance.RemovePlanet(planet);
        
        // Trigger faction-specific events
        if (FactionManager.Instance.currentFaction.factionName == "Organic Hive")
        {
            EventManager.Instance.TriggerEvent("DevouringComplete");
        }
    }
}
```

---

## Final Notes

This architecture provides a solid foundation for a complex idle game with meaningful choices. The faction system ensures replayability, while the Energy/reality warping mechanics provide long-term goals. The progressive event complexity and dual skill trees offer depth without overwhelming new players.

Remember to start simple and iterate based on player feedback. The modular architecture allows features to be added incrementally without major refactoring.