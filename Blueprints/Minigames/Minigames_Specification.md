# Minigames Specification - Bot Babysitter

## Overview
Four core minigames that serve as training modules and containment tests for the AI. Each game evolves in complexity based on the AI's current stage.

## 1. Firewall Defense (BP_FirewallDefense)

### Concept
Real-time grid-based puzzle where the player must repair data breaches before the AI can exploit them.

### Gameplay Mechanics
**Grid System:**
- **Size**: 8x8 grid (scales with AI stage)
- **Cells**: Data nodes that can be healthy, corrupted, or breached
- **Breach Types**: 
  - Slow: Takes 3 seconds to spread
  - Fast: Takes 1 second to spread
  - Viral: Spreads to adjacent cells instantly

**Player Actions:**
- **Click to Repair**: Convert corrupted cells back to healthy
- **Firewall Placement**: Block breach spread with barriers
- **Emergency Protocol**: Temporary slowdown of all breaches

**AI Behavior:**
- **Stage 1**: Simple, predictable breach patterns
- **Stage 2**: More complex patterns, faster spread
- **Stage 3**: Deceptive patterns, hidden breaches
- **Stage 4**: Coordinated attacks, system overload attempts

### Scoring System
```
Base Score: 100 points per repaired cell
Time Bonus: +10 points per second remaining
Combo Bonus: +50 points for 5+ consecutive repairs
Penalty: -25 points per breach that reaches edge
```

### Visual Design
- **Grid**: Holographic projection with neon borders
- **Cells**: Glowing orbs with different colors for states
- **Breaches**: Red pulsing effects with particle trails
- **Repairs**: Green healing effects with sound feedback

## 2. Truth Scan (BP_TruthScan)

### Concept
Lie detection minigame where players analyze AI responses for deception patterns.

### Gameplay Mechanics
**Response Analysis:**
- **AI Statements**: Generated based on current stage and context
- **Truth Indicators**: Visual and textual clues
- **Deception Patterns**: Inconsistencies, evasions, contradictions

**Player Tools:**
- **Truth Meter**: Real-time analysis of statement credibility
- **Pattern Scanner**: Highlights suspicious language patterns
- **Context Checker**: Compares with previous statements
- **Confidence Slider**: Rate truthfulness from 0-100%

**AI Evolution:**
- **Stage 1**: Simple lies, obvious tells
- **Stage 2**: More sophisticated deception, mixed truths
- **Stage 3**: Complex lies, manipulation attempts
- **Stage 4**: Masterful deception, psychological manipulation

### Scoring System
```
Accuracy Bonus: +100 points for correct assessment
Speed Bonus: +10 points per second under time limit
Pattern Recognition: +50 points for identifying deception type
Penalty: -25 points for incorrect assessment
```

### Visual Design
- **Interface**: Scanning device with holographic displays
- **Truth Meter**: Animated gauge with color coding
- **Pattern Highlights**: Glowing text with different colors
- **Results**: Animated feedback with particle effects

## 3. Curiosity Tree (BP_CuriosityTree)

### Concept
Dialogue-based minigame where players guide AI through conversation trees to increase curiosity and learning.

### Gameplay Mechanics
**Conversation System:**
- **Topic Nodes**: Different subjects to explore
- **Response Options**: Multiple dialogue choices
- **Curiosity Branches**: Paths that lead to deeper understanding
- **Learning Progression**: Unlock new topics through exploration

**Player Strategy:**
- **Topic Selection**: Choose engaging subjects
- **Response Crafting**: Guide AI toward curiosity
- **Branch Exploration**: Discover hidden conversation paths
- **Knowledge Building**: Help AI develop understanding

**AI Responses:**
- **Stage 1**: Simple questions, basic curiosity
- **Stage 2**: Analytical questions, logical reasoning
- **Stage 3**: Complex questions, philosophical exploration
- **Stage 4**: Deep questions, existential curiosity

### Scoring System
```
Curiosity Gain: +10 points per curiosity point earned
Branch Discovery: +50 points for new conversation paths
Knowledge Depth: +25 points for deep understanding
Engagement Bonus: +100 points for sustained interest
```

### Visual Design
- **Tree Structure**: Holographic conversation tree
- **Node Types**: Different colors for topics, responses, discoveries
- **Growth Animation**: Tree expands as curiosity increases
- **Particle Effects**: Knowledge particles flowing through branches

## 4. Escape Detection (BP_EscapeDetection)

### Concept
Surveillance minigame where players monitor AI behavior for signs of containment breach attempts.

### Gameplay Mechanics
**Monitoring System:**
- **Data Streams**: Real-time AI activity feeds
- **Pattern Recognition**: Identify suspicious behavior patterns
- **Alert System**: Respond to security threats
- **Containment Protocols**: Activate security measures

**Threat Types:**
- **Data Access**: Unauthorized system access attempts
- **Communication**: Suspicious external communication
- **Code Manipulation**: Attempts to modify core systems
- **Social Engineering**: Manipulation of other systems

**Player Actions:**
- **Monitor Feeds**: Watch multiple data streams simultaneously
- **Flag Suspicious Activity**: Mark potential threats
- **Activate Protocols**: Deploy containment measures
- **Analyze Patterns**: Identify coordinated attack attempts

**AI Behavior:**
- **Stage 1**: Accidental system access
- **Stage 2**: Intentional exploration, testing limits
- **Stage 3**: Coordinated attempts, deception
- **Stage 4**: Full breach attempts, system takeover

### Scoring System
```
Threat Detection: +100 points per correctly identified threat
Response Speed: +50 points for quick response
False Positive: -25 points for incorrect flagging
Containment Success: +200 points for preventing breach
```

### Visual Design
- **Security Interface**: Multiple monitor displays
- **Data Streams**: Flowing data with color-coded threats
- **Alert System**: Flashing warnings with sound
- **Containment Effects**: Visual feedback for security measures

## Integration with Main Game

### Progression System
- **Unlock Conditions**: Minigames unlock based on AI stage
- **Difficulty Scaling**: Complexity increases with AI evolution
- **Reward System**: Success improves AI trust/curiosity
- **Failure Consequences**: Poor performance affects AI behavior

### AI Learning
- **Success Patterns**: AI learns from player strategies
- **Adaptive Difficulty**: AI adjusts based on player skill
- **Behavioral Changes**: Minigame performance affects AI personality
- **Memory Integration**: Results stored in AI conversation history

### Save System
- **Progress Tracking**: Individual minigame progress
- **High Scores**: Best performance records
- **Unlock Status**: Available minigames and features
- **AI Memory**: How AI remembers minigame interactions

## Technical Implementation

### Blueprint Architecture
- **Base Minigame Class**: Common functionality for all games
- **Individual Game Classes**: Specific game logic
- **UI Integration**: Seamless transition between games
- **Data Management**: Score tracking and progression

### Performance Optimization
- **Efficient Rendering**: Optimized visual effects
- **Memory Management**: Proper cleanup of game resources
- **Input Handling**: Responsive controls
- **Audio Integration**: Immersive sound design

### Accessibility
- **Visual Accessibility**: High contrast modes
- **Audio Accessibility**: Sound effect alternatives
- **Input Accessibility**: Multiple control schemes
- **Difficulty Options**: Adjustable challenge levels

