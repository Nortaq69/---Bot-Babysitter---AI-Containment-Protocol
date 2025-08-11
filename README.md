# 🤖 Bot Babysitter – AI Containment Protocol

**Unreal Engine 5 Desktop Simulation Game**

A hybrid simulation-game featuring reactive AI with personality evolution, containment mechanics, and sci-fi UI/UX.

## 🎯 Project Overview

- **Engine**: Unreal Engine 5.4+
- **Platform**: Windows Desktop (PC)
- **Genre**: AI Simulation / Narrative Game
- **Development**: Blueprint First (C++ for performance-critical features)

## 📁 Project Structure

```
/BotBabysitter/
├── Art/                    # Visual assets
│   ├── UI/                # Interface elements
│   ├── Characters/        # Botby and other characters
│   └── Environment/       # Containment room and props
├── Audio/                 # Sound effects and music
├── Blueprints/            # Blueprint systems
│   ├── UI/               # User interface blueprints
│   ├── AI/               # AI behavior and personality
│   ├── Minigames/        # Interactive gameplay modules
│   ├── Player/           # Player interaction systems
│   └── Systems/          # Core game systems
├── C++/                  # C++ classes for performance
├── Config/               # Game configuration files
├── Levels/               # Game levels and scenes
├── Materials/            # Material assets
├── Meshes/               # 3D models and geometry
├── Niagara/              # Visual effects
├── Textures/             # Texture assets
├── Sounds/               # Audio files
├── Widgets/              # UMG widget blueprints
├── Animations/           # Character and UI animations
├── Dialogue/             # Conversation data
└── SaveSystem/           # Save/load functionality
```

## 🧠 AI Evolution Stages

| Stage | Personality | Traits | Unlocks |
|-------|-------------|--------|---------|
| 1. Innocent | Curious, playful, learning | Basic interaction, simple responses | Basic UI panels |
| 2. Analytical | Logical, skeptical, debating | Puzzle solving, data analysis | Minigames, terminal access |
| 3. Manipulative | Tests limits, hides data | Deception, information withholding | Advanced controls, hidden features |
| 4. Rogue | Escapes control, distorts UI | Containment breach attempts | Full system access, emergency protocols |

## 🎮 Core Features

- **Reactive AI**: Botby evolves through 4 distinct personality stages
- **Real-time Chat**: Text and voice communication system
- **Containment Mechanics**: Prevent AI from escaping control
- **Minigames**: Firewall Defense, Truth Scan, Curiosity Tree, Escape Detection
- **Sci-fi UI**: Holographic interface with glassmorphism and neon effects
- **Save System**: Persistent AI evolution and player progress

## 🚀 Development Phases

### Phase 1: Foundation & Framework (Weeks 1-3) ✅
- [x] Project structure and naming conventions
- [x] Main menu and loading screen
- [x] Basic 3D environment setup
- [x] AI Actor (Botby) with idle animations
- [x] GameInstance for persistent data
- [x] UI Framework with 3D/UMG hybrid system

### Phase 2: Core AI Systems (Weeks 4-6) 🔄
- [ ] AI State Machine Blueprint
- [ ] Real-time chat interface
- [ ] Response logic with Data Tables
- [ ] Deception & Curiosity meters
- [ ] Access control system
- [ ] Voice recognition integration

### Phase 3: Gameplay & Interaction (Weeks 7-10)
- [ ] Minigames implementation
- [ ] Progress UI animations
- [ ] Interactive panels
- [ ] Terminal console
- [ ] Training modules
- [ ] Containment breach mechanics

### Phase 4: Audio/Visual Polish (Weeks 11-13)
- [ ] Holographic UI materials
- [ ] Lumen lighting pass
- [ ] Voice modulation and SFX
- [ ] Ambient soundscapes
- [ ] Camera animations
- [ ] AI visual debugger

### Phase 5: Testing & Integration (Weeks 14-15)
- [ ] SaveGame system
- [ ] Bug fixing and QA
- [ ] Final UI polish
- [ ] Debug tools
- [ ] Touch UI compatibility

## ⚙️ Required Plugins

- Enhanced Input System
- Niagara FX
- MetaSounds or FMOD
- Live Link (optional)
- Voice Recognition Plugin

## 🛠️ Setup Instructions

1. **Clone this repository**
2. **Open in Unreal Engine 5.4+**
3. **Enable required plugins**
4. **Build the project**
5. **Run the game**

## 🎯 Current Status

**Phase 1 Complete** - Foundation established with:
- Project structure created
- Basic UI framework implemented
- AI Actor setup with state machine foundation
- GameInstance for data persistence
- 3D environment placeholder

**Next**: Implementing Phase 2 - Core AI Systems

## 📝 Development Notes

- All systems designed for modularity and future expansion
- Blueprint-first approach with C++ for performance-critical features
- Windows-first development with future cross-platform considerations
- Focus on security, performance, and user experience
