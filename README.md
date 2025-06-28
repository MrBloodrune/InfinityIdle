# Infinity Idle (Galactic Conquest)

A strategic idle game where players expand from a dying planet to universal dominance. Think "Cookie Clicker meets Stellaris" with deep faction mechanics and reality-warping progression.

## Game Features

- 🌌 6 unique factions with distinct playstyles
- 💰 4-tier currency system with condensation mechanics
- 🚀 Strategic travel and expansion across galaxies
- ⚡ Multiple prestige layers (Ascension, Transcendence, Reality Warp)
- 📊 Handle numbers up to 10^308 and beyond
- 🎮 Cross-platform play (PC/Mobile)

## Technology Stack

- **Engine**: Unity 2021.3 LTS (2D)
- **Platform**: PC (Steam) primary, Mobile (iOS/Android) secondary
- **Backend**: PlayFab or custom Node.js
- **Large Numbers**: BreakInfinity.cs
- **Save Format**: JSON with compression

## Project Structure

```
idle/
├── docs/                    # Game design documentation
├── InfinityIdle/           # Unity project
├── CLAUDE.md               # AI assistant guidelines
└── README.md               # This file
```

## Development Timeline

- **Phase 1 (Weeks 1-4)**: Core idle loop and mechanics
- **Phase 2 (Weeks 5-8)**: Faction system foundation
- **Phase 3 (Weeks 9-12)**: Engagement and monetization
- **Phase 4 (Weeks 13-16)**: Polish and depth
- **Phase 5 (Weeks 17-20)**: Beta and launch preparation

## Getting Started

### Prerequisites

- Unity Hub
- Unity 2021.3 LTS
- Git with Git LFS
- Visual Studio or VS Code

### Setup

1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd idle
   ```

2. Install Git LFS:
   ```bash
   git lfs install
   ```

3. Open Unity Hub and add the `InfinityIdle` project

4. Install required packages:
   - TextMeshPro
   - BreakInfinity.cs
   - Newtonsoft.Json

## Documentation

See the `/docs` folder for comprehensive game design documentation:
- Game Design.md - Core mechanics and systems
- Technical Architecture.md - Implementation details
- Development Plan.md - Timeline and milestones
- Content Database.md - Faction and building specifications

## Contributing

This is currently a solo/small team project. Contribution guidelines will be added as the team grows.

## License

All rights reserved. This project is not open source.