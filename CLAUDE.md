# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is the "Infinity Idle" (formerly "Galactic Conquest Idle") game project. Currently in the pre-development documentation phase with comprehensive design documents but no implementation yet.

## Technology Stack (Planned)

- **Game Engine**: Unity 2021.3 LTS (2D)
- **Backend**: PlayFab or custom Node.js solution
- **Large Number Handling**: BreakInfinity.cs
- **Version Control**: Git with GitHub
- **Target Platforms**: PC (Steam) primary, Mobile (iOS/Android) secondary

## Project Structure

```
idle/
└── docs/           # Game design and technical documentation
```

## Key Documentation Files

- **Game Design.md**: Core gameplay mechanics, progression systems, and game loops
- **Technical Architecture.md**: Unity architecture patterns and system designs
- **Content Database.md**: Detailed specifications for all factions, buildings, and upgrades
- **Mathematical Systems.md**: Economy formulas, scaling calculations, and balance equations
- **Development Plan.md**: 20-week development timeline and team structure

## Unity Development Guidelines (When Implementation Begins)

### Architecture Patterns
- Use Service Locator pattern for system access
- Implement Observer pattern for game events
- Use Object Pooling for frequently spawned objects (particles, UI elements)
- Scriptable Objects for game data configuration

### Core Systems to Implement
1. **Currency System**: Handle values up to 10^308 using BreakInfinity.cs
2. **Save System**: JSON-based with compression, cloud save support
3. **Prestige System**: Multiple layers (Ascension, Transcendence, Reality Warp)
4. **Faction System**: 6 unique factions with specialized mechanics
5. **Resource System**: 4-tier currency condensation mechanics

### Performance Considerations
- Update loops optimized for idle games (reduced frequency when idle)
- Efficient number formatting for large values
- Careful memory management for mobile platforms

## Game-Specific Commands (Future)

Once Unity project is created:
```bash
# Unity project will be in a subdirectory
cd InfinityIdle/

# Open in Unity Hub
unity-hub --open .

# Build commands will depend on Unity setup
# Typically through Unity Editor or Unity Cloud Build
```

## Important Game Mechanics

1. **Currency Tiers**: Credits → Energy → Matter → Essence (each condenses at 1e6)
2. **Faction Bonuses**: Each faction provides unique gameplay modifiers
3. **Time Mechanics**: Variable time acceleration (1x to 1000x+)
4. **Prestige Calculations**: Based on total resources earned, not current amounts

## Development Priorities

1. Core idle mechanics and number system
2. Single faction implementation (Human Federation first)
3. Basic UI and save system
4. Prestige layer 1 (Ascension)
5. Additional factions and content
6. Advanced features and polish

When implementing features, always refer to the design documents for specific formulas and balance values.