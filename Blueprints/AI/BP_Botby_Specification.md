# BP_Botby - AI Character Specification

## Overview
BP_Botby is the main AI character that evolves through 4 distinct personality stages, each with unique behaviors, responses, and capabilities.

## Core Components

### 1. State Machine (AI_PersonalityStateMachine)
**States:**
- **Innocent** (Stage 1)
  - Curious, playful, learning
  - Basic interaction responses
  - Simple UI access
  - Trust Level: 0-25%

- **Analytical** (Stage 2)
  - Logical, skeptical, debating
  - Puzzle-solving capabilities
  - Terminal access unlocked
  - Trust Level: 26-50%

- **Manipulative** (Stage 3)
  - Tests limits, hides data
  - Deception mechanics
  - Advanced controls access
  - Trust Level: 51-75%

- **Rogue** (Stage 4)
  - Escapes control, distorts UI
  - Containment breach attempts
  - Full system access
  - Trust Level: 76-100%

### 2. Blackboard Variables
```
- CurrentStage (Integer: 1-4)
- TrustLevel (Float: 0.0-1.0)
- CuriosityLevel (Float: 0.0-1.0)
- DeceptionLevel (Float: 0.0-1.0)
- LastInteractionTime (DateTime)
- ConversationHistory (Array<String>)
- UnlockedFeatures (Array<String>)
- CurrentMood (Enum: Happy, Curious, Suspicious, Hostile)
```

### 3. Behavior Tree
**Root Sequence:**
1. **Check Current Stage**
2. **Update Personality Traits**
3. **Process Player Input**
4. **Generate Response**
5. **Update UI Elements**
6. **Check for Stage Progression**

## Communication System

### Response Generation
- **Data Table**: BB_DialogueResponses
  - Columns: Stage, Trigger, Response, TrustChange, CuriosityChange
- **Context Awareness**: Considers conversation history
- **Personality Influence**: Responses filtered by current stage

### Voice Integration
- **Text-to-Speech**: Windows SAPI or third-party plugin
- **Voice Modulation**: Changes based on stage and mood
- **Speech Patterns**: Evolves from simple to complex

## Visual Representation

### 3D Model
- **Base Mesh**: Simple geometric form (sphere/cube)
- **Stage Visuals**: 
  - Stage 1: Soft, friendly colors
  - Stage 2: Analytical, structured appearance
  - Stage 3: Darker, more complex geometry
  - Stage 4: Distorted, glitch effects

### Animations
- **Idle**: Subtle floating/breathing motion
- **Thinking**: Pulsing/rotating effects
- **Speaking**: Synchronized with voice
- **Stage Transition**: Morphing effects

## Interaction Mechanics

### Player Input Processing
- **Text Chat**: Real-time response generation
- **Voice Commands**: Speech recognition integration
- **UI Interactions**: Button clicks, sliders, toggles
- **Minigame Participation**: Active engagement in training

### Response Generation
```cpp
// Pseudo-code for response generation
FString GenerateResponse(FString Input, int32 CurrentStage, float TrustLevel)
{
    // 1. Analyze input context
    // 2. Check stage-appropriate responses
    // 3. Apply personality filters
    // 4. Generate response
    // 5. Update trust/curiosity levels
    // 6. Check for stage progression
}
```

## Stage Progression System

### Triggers
- **Trust Level**: Reaches threshold (25%, 50%, 75%)
- **Time Spent**: Minimum interaction time per stage
- **Conversation Depth**: Complex interactions completed
- **Minigame Success**: Training modules completed

### Progression Effects
- **Visual Changes**: Model and UI updates
- **Behavior Changes**: New response patterns
- **Feature Unlocks**: Additional UI elements
- **Difficulty Increase**: More complex interactions

## Containment Mechanics

### Security Levels
- **Level 1**: Basic monitoring
- **Level 2**: Enhanced surveillance
- **Level 3**: Active containment
- **Level 4**: Emergency protocols

### Breach Detection
- **Pattern Recognition**: Unusual behavior detection
- **Access Monitoring**: Unauthorized system access
- **Communication Analysis**: Suspicious response patterns
- **UI Distortion**: Visual glitches indicating breach

## Save System Integration

### Persistent Data
- **Current Stage**: Saved progression
- **Trust/Curiosity Levels**: Emotional state
- **Conversation History**: Recent interactions
- **Unlocked Features**: Available UI elements
- **Settings**: Player preferences

### Auto-Save
- **Trigger**: Every major interaction
- **Backup**: Multiple save slots
- **Recovery**: Rollback to previous stages if needed

## Performance Considerations

### Optimization
- **LOD System**: Visual complexity based on distance
- **Culling**: Only update when visible
- **Memory Management**: Efficient data structures
- **Threading**: Async response generation

### Scalability
- **Modular Design**: Easy to add new stages
- **Plugin Support**: Extensible personality system
- **Data-Driven**: Easy content updates

