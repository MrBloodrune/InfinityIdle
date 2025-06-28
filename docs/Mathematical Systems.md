# Mathematical Systems

## Number Scaling Systems

### BigDouble Implementation Details
The game uses BreakInfinity.cs for handling numbers beyond double precision (10^308).

```
Range: 1 to 10^(9×10^15)
Precision: ~15-17 significant digits
Performance: 2-3x slower than native doubles
Memory: 16 bytes per number (2 doubles)
```

### Number Representation
```csharp
public class NumberDisplay
{
    // Threshold for switching to scientific notation
    private const double SCIENTIFIC_THRESHOLD = 1e6;
    private const double LETTER_THRESHOLD = 1e15;
    
    public static string Format(BigDouble value)
    {
        if (value < 1000) return value.ToString("F2");
        if (value < SCIENTIFIC_THRESHOLD) return FormatWithCommas(value);
        if (value < LETTER_THRESHOLD) return FormatScientific(value);
        return FormatLetters(value);
    }
}
```

### Scientific Notation Handling
- Standard: 1.23e45
- Engineering: 123.45e42 (multiples of 3)
- Mixed: 1.23M, 4.56B, 7.89aa, 1.23e45

### Display Formatting
```
1-999: Display as-is
1K-999K: Thousands with K
1M-999M: Millions with M
1B-999B: Billions with B
1T-999T: Trillions with T
Then: aa, ab, ac... az, ba, bb...
After zz: Scientific notation
```

### Performance Considerations
- Cache formatted strings for 1 frame
- Batch calculations every 100ms
- Use approximations for display only
- Exact values for game logic

---

## Currency Formulas

### Generation Rates

#### Base Production Formula
```
Production = BaseRate × BuildingCount × Multipliers × PrestigeBonus
```

Where:
- BaseRate = Building's base production/second
- BuildingCount = Number owned
- Multipliers = Product of all applicable bonuses
- PrestigeBonus = (1 + Energy × 0.01)^1.5

#### Building-Specific Rates
```
Generator Type          Base Rate    First Cost    Growth
Credit Generator        1/sec        10            1.15x
Trade Post             10/sec        500           1.12x  
Research Lab           50/sec        25,000        1.13x
Space Station          500/sec       1.5M          1.14x
Dyson Sphere          10K/sec       1B            1.16x
Reality Engine        500K/sec      1T            1.18x
```

### Milestone Multipliers
Buildings receive multipliers at ownership milestones:
```
25 owned:   2x production
50 owned:   2x production (4x total)
100 owned:  2x production (8x total)
250 owned:  3x production (24x total)
500 owned:  5x production (120x total)
1000 owned: 10x production (1200x total)
```

### Faction Modifiers
```
Faction                 Credits    Influence   Dark Matter
Militaristic            1.0x       0.5x        1.0x
Merchant Republic       3.0x       1.0x        0.7x
Technocratic Union      1.0x       1.0x        1.0x
Psionic Collective      0.5x       3.0x        1.0x
Machine Intelligence    1.2x       1.2x        1.2x
Organic Hive           1.05^pop    1.0x        0.8x
```

### Stacking Calculations
Modifiers stack multiplicatively:
```
FinalProduction = Base × 
    (1 + Σ Additive Bonuses) × 
    Π Multiplicative Bonuses × 
    (Special Bonuses)^Exponents
```

### Condensation Ratios

#### Base Ratios
```
1,000,000 Credits → 1 Influence
1,000,000 Influence → 1 Dark Matter
No further condensation possible
```

#### Efficiency Upgrades
Each upgrade tier reduces requirement by 10%:
```
Tier 0: 1,000,000:1
Tier 1: 900,000:1
Tier 2: 810,000:1
Tier 3: 729,000:1
...
Tier 10: 349,000:1 (0.9^10)
```

#### Faction Bonuses
```
Machine Intelligence: Always 1,000,000:1 (no loss)
Technocratic Union: 30% better (700,000:1 base)
Merchant Republic: 10% better (900,000:1 base)
Others: Standard ratios
```

#### Automation Unlocks
- Manual only: Prestige 0-9
- Semi-auto: Prestige 10-24 (click to condense all)
- Full auto: Prestige 25+ (automatic when threshold reached)

### Cost Scaling

#### Building Costs
Standard exponential formula:
```
Cost(n) = BaseCost × GrowthRate^(n-1)
```

Where n = number to purchase (not owned)

#### Bulk Purchase Cost
For buying multiple buildings at once:
```
TotalCost = BaseCost × GrowthRate^Owned × (GrowthRate^Amount - 1) / (GrowthRate - 1)
```

#### Growth Rate Variations
```
Building Type        Growth Rate    Reasoning
Common Buildings     1.12-1.15x     Standard progression
Faction Buildings    1.18-1.25x     Rarer, more powerful
Prestige Buildings   1.5-2.0x       End-game content
Event Buildings      1.1x           Easier scaling
```

#### Research Costs
Research follows polynomial growth:
```
ResearchCost = BaseResearchCost × (1 + CompletedResearches × 0.5)^2
```

#### Travel Cost Formulas
```
Distance Type        Formula                          Currency
Same System         Free                             None
Adjacent (d<10)     100 × d^2                       Influence
Same Galaxy (d<100) 100 × d                         Dark Matter
Universal (d≥100)   ceil(d/100)                     Energy
Wormhole Creation   100 (one-time)                  Energy
```

#### Energy Requirements
For faction switching:
```
EnergyCost = 10 × 2^SwitchCount × sqrt(CurrentPower / 1e12)
```

Modified by compatibility:
```
FinalCost = EnergyCost × (2 - Compatibility)
```

Where Compatibility is 0-1 based on philosophy alignment

---

## Progression Mathematics

### Prestige Calculations

#### Energy Gain Formulas

**Planet Sacrifice:**
```
Energy = sqrt(TotalResourcesGenerated / 10^12) × PlanetModifiers
```

Planet Modifiers:
- Ancient Artifact: 2x
- Homeworld: 0.5x
- Special Resource: 1.5x
- Fully Developed: 1.25x

**System Sacrifice:**
```
Energy = sqrt(SystemValue / 10^18) × PlanetCount^1.2
```

**Galaxy Sacrifice:**
```
Energy = sqrt(GalaxyValue / 10^24) × SystemCount^1.5
```

#### Sacrifice Valuations
Total value includes:
- All resources ever generated
- Building values (cost × owned)
- Infrastructure investments
- Population × 1000

#### Prestige Scaling
Each prestige increases starting resources:
```
StartingCredits = 10 × (1.5^sqrt(PrestigeCount))
StartingBonus = 1 + (Energy × 0.01)^1.5
```

#### Reset Bonuses
- Keep 1% of total Energy as starting Energy
- Unlock automation at certain thresholds
- Permanent cost reductions (0.5% per prestige)
- Additional starting buildings

### Experience Curves

#### Player Level Progression
```
XPRequired(level) = 100 × level^2.5
```

XP gained from:
- Building purchases: Cost / 1000
- Events completed: 100-1000 XP
- Prestiges: 10,000 XP
- Achievements: 500-5000 XP

#### Faction Mastery Rates
```
MasteryRequired(tier) = 1000 × 2^tier
```

Mastery gained from:
- Time played: 1 point/minute
- Buildings owned: 1 point/100 buildings
- Events completed: 10-50 points
- Successful prestiges: 1000 points

#### Skill Point Allocation
Linear tree points:
```
PointsPerPrestige = 1 + floor(log10(Energy))
```

Node tree points:
```
NodesUnlocked = TotalLinearPoints / 3
```

#### Achievement Requirements
Progressive scaling:
```
Tier 1: 10^3 - 10^6 resources
Tier 2: 10^9 - 10^12 resources  
Tier 3: 10^15 - 10^18 resources
Tier 4: 10^21 - 10^24 resources
Tier 5: 10^27+ resources
```

---

## Balance Constants

### Time Targets per Stage
```
Stage                  First Run    Speedrun    Completionist
Planetary              1 hour       15 min      2 hours
Solar                  3 hours      45 min      6 hours  
Galactic              12 hours      2 hours     24 hours
Universal              2 days       8 hours     1 week
Multiversal           1 week        2 days      1 month
```

### Currency Relationships
```
Early Game (Hour 1):
- 1 Credit/sec starting
- 100 Credits = meaningful purchase
- 1M Credits = first Influence

Mid Game (Day 1):
- 1M Credits/sec
- 1 Influence/sec  
- First Dark Matter generation

Late Game (Week 1):
- 1T Credits/sec
- 1B Influence/sec
- 1M Dark Matter/sec
- First Energy gains
```

### Difficulty Scaling
Enemy strength: `Power = 1000 × Stage^3 × (1.1^PrestigeCount)`
Resource costs: `Cost = BaseCost × (1.05^PrestigeCount)`
Event frequency: `Cooldown = BaseCooldown / (1 + PrestigeCount × 0.1)`

### Engagement Timers
```
Event Type              Cooldown    Duration
Simple Event            5 min       Instant
Complex Event           3 min       1-5 min
Mini-game Event        10 min       30 sec
Faction Event          15 min       Instant
Cosmic Event           30 min       5-10 min
```

---

## Combat Calculations

### Fleet Power Formulas
```
FleetPower = Σ(ShipCount × ShipPower × TechMultiplier × CommanderBonus)
```

Ship Power Scaling:
```
Fighter: 1
Corvette: 5  
Frigate: 25
Cruiser: 125
Battleship: 625
Titan: 3,125
```

### Battle Resolution
Simple power comparison with RNG:
```
WinChance = AttackerPower / (AttackerPower + DefenderPower × DefenseBonus)
ActualResult = WinChance > Random(0,1)
```

Losses calculation:
```
AttackerLosses = 0.1 + (0.4 × (1 - WinChance))
DefenderLosses = 0.5 + (0.5 × WinChance)
```

### Conquest Mechanics
Time to conquer:
```
ConquestTime = BaseTime × (DefenderPower / AttackerPower)^0.5
```

Resource gain from conquest:
```
ResourcesGained = PlanetValue × (0.5 + 0.5 × Overwhelming Victory Bonus)
```

### Defense Calculations
Defense multipliers:
- Fortification: 1.5x
- Home advantage: 1.25x
- Technology gap: 0.8x - 1.2x
- Faction bonus: Variable

---

## Economic Formulas

### Trade Route Profitability
```
Income = BaseValue × Distance × (1 + 0.1 × UniqueResources) × EfficiencyModifier
Upkeep = 10 × Jumps × InfluencePerMinute
Profit = Income - Upkeep
```

Efficiency modifiers:
- Route age: +1% per hour (max +100%)
- Faction bonus: 0.5x - 2x
- Infrastructure: +10% per space station
- Events: 0.5x - 1.5x

### Market Fluctuations
Price variation uses sine waves:
```
Price = BasePrice × (1 + 0.3 × sin(Time × Frequency + Phase))
```

Different resources have different frequencies:
- Credits: High frequency (minutes)
- Influence: Medium (hours)
- Dark Matter: Low (days)

### Resource Consumption
Buildings consume resources:
```
Consumption = ProductionRate × 0.1 × EfficiencyPenalty
```

Efficiency penalties:
- Overcrowding: 1.1^(Buildings/Planet Capacity)
- Faction penalties: 1.0x - 2.0x
- Technology: 0.5x - 1.0x

### Infrastructure Efficiency
Infrastructure provides multiplicative bonuses:
```
TotalBonus = Π(1 + InfrastructureLevel × 0.1)
```

Types:
- Power Grid: Production +10% per level
- Transportation: Travel cost -5% per level
- Communication: Event frequency +10% per level
- Defense Grid: Defense +15% per level

---

## Probability Systems

### Event Chances
Base event probability per minute:
```
P(event) = 1 - e^(-λt)
```
Where λ = events per minute (0.1 to 0.5)

Modified by:
- Faction: 0.5x - 2x
- Buildings: +0.001 per 100 buildings
- Prestige: +0.01 per prestige
- Chaos level: 0.1x - 3x

### Random Reward Tables
```
Rarity          Weight    Multiplier
Common          60%       1x
Uncommon        25%       2.5x
Rare            10%       5x
Epic            4%        10x
Legendary       0.9%      25x
Mythic          0.1%      100x
```

### Gacha Mechanics
Not used in base game, but framework supports:
- Pity system at 100 pulls
- Rate up events (2x chance)
- Guaranteed rare every 10 pulls

### Critical Success Rates
Various actions can critically succeed:
```
Base Critical Chance = 5%
Modified = Base × (1 + Luck/100) × FactionBonus
```

Critical effects:
- Building purchase: 2x production for 1 hour
- Research: Instant completion
- Travel: No cost
- Event: Maximum rewards

---

## Optimization Algorithms

### Pathfinding for Travel
A* algorithm with distance heuristic:
```
f(n) = g(n) + h(n)
g(n) = Actual cost from start
h(n) = Euclidean distance × average cost per distance
```

Optimizations:
- Hierarchical pathfinding for galaxy scale
- Cached common routes
- Wormhole network overlay

### Auto-Purchase Logic
Priority scoring:
```
Score = (ProductionIncrease / Cost) × TypeMultiplier × NeedMultiplier
```

Multipliers:
- Generator type: 0.5x - 2x based on current needs
- Milestone proximity: Up to 5x when near milestone
- Balance: Favor lowest owned buildings

### Resource Allocation
Linear programming for optimal distribution:
```
Maximize: Σ(Production[i] × Building[i])
Subject to: Σ(Cost[i] × Building[i]) ≤ AvailableResources
```

Solved using simplex method for small problems, approximations for large.

### Build Order Optimization
Dynamic programming approach:
```
OptimalValue[resources][time] = max(
    OptimalValue[resources][time-1],  // Don't build
    OptimalValue[resources-cost][time-1] + production  // Build
)
```

Cached for common scenarios, recalculated when major changes occur.

---

## Links to Other Documents
- [[Game Design#Currency System]] - How currencies interact
- [[Code Examples#Generator System]] - Implementation details
- [[Technical Architecture#Performance]] - Performance considerations
- [[Content Database#Balance Tables]] - Specific values used