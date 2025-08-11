# Save System Specification - Bot Babysitter

## Overview
Comprehensive save/load system that manages AI evolution, player progress, minigame scores, and game settings with robust error handling and backup capabilities.

## Core Save Data Structure

### 1. AI State Data (BB_AIData)
```cpp
struct FAIStateData
{
    // Basic Information
    int32 CurrentStage;                    // 1-4 personality stage
    float TrustLevel;                      // 0.0-1.0 trust percentage
    float CuriosityLevel;                  // 0.0-1.0 curiosity percentage
    float DeceptionLevel;                  // 0.0-1.0 deception percentage
    
    // Personality Metrics
    TArray<FString> ConversationHistory;   // Recent conversations
    TArray<FString> UnlockedFeatures;      // Available UI elements
    FDateTime LastInteractionTime;         // Timestamp of last interaction
    
    // Behavioral Data
    TMap<FString, float> PersonalityTraits; // Dynamic personality values
    TArray<FString> KnownTopics;           // Topics AI has learned about
    TArray<FString> SuspiciousActivities;  // Tracked suspicious behavior
    
    // Stage Progression
    float TimeInCurrentStage;              // Time spent in current stage
    int32 InteractionsInStage;             // Number of interactions
    bool StageTransitionReady;             // Ready for next stage
};
```

### 2. Player Progress Data (BB_PlayerData)
```cpp
struct FPlayerProgressData
{
    // Game Progress
    FDateTime SessionStartTime;            // When current session started
    int32 TotalPlayTime;                   // Total time played (minutes)
    int32 CurrentSessionTime;              // Current session time (minutes)
    
    // Minigame Scores
    TMap<FString, FMinigameScore> MinigameScores; // High scores per game
    TArray<FString> UnlockedMinigames;     // Available minigames
    TArray<FString> CompletedTutorials;    // Completed tutorial sections
    
    // Achievements
    TArray<FString> UnlockedAchievements;  // Earned achievements
    TMap<FString, int32> AchievementProgress; // Progress toward achievements
    
    // Settings
    FGameSettings UserSettings;            // Player preferences
    FInputBindings CustomBindings;         // Custom control scheme
};
```

### 3. Game State Data (BB_GameStateData)
```cpp
struct FGameStateData
{
    // Current Session
    FString CurrentLevel;                  // Active level/scene
    FVector PlayerLocation;                // Player position
    FRotator PlayerRotation;               // Player orientation
    
    // UI State
    TArray<FString> OpenWindows;           // Currently open UI windows
    TArray<FString> MinimizedWindows;      // Minimized UI windows
    FVector2D ChatWindowPosition;          // Chat window position
    FVector2D TerminalWindowPosition;      // Terminal window position
    
    // System State
    bool ContainmentBreachActive;          // Active breach status
    int32 SecurityLevel;                   // Current security level (1-4)
    TArray<FString> ActiveAlerts;          // Current system alerts
    
    // Audio State
    float MasterVolume;                    // Master audio volume
    float MusicVolume;                     // Music volume
    float SFXVolume;                       // Sound effects volume
    float VoiceVolume;                     // Voice volume
};
```

## Save File Management

### File Structure
```
SaveData/
├── AutoSave/
│   ├── AutoSave_001.sav
│   ├── AutoSave_002.sav
│   └── AutoSave_003.sav
├── ManualSave/
│   ├── Save_001.sav
│   ├── Save_002.sav
│   └── Save_003.sav
├── Backup/
│   ├── Backup_2024_01_15_14_30.sav
│   └── Backup_2024_01_15_15_45.sav
└── Settings/
    ├── UserSettings.ini
    └── InputBindings.ini
```

### Save File Format
```cpp
struct FSaveFileHeader
{
    FString GameVersion;                   // Game version when saved
    FDateTime SaveDateTime;                // When save was created
    FString SaveName;                      // User-defined save name
    int32 SaveVersion;                     // Save file format version
    uint32 Checksum;                       // Data integrity check
};

struct FSaveFileData
{
    FSaveFileHeader Header;                // File header information
    FAIStateData AIData;                   // AI state and evolution
    FPlayerProgressData PlayerData;        // Player progress and scores
    FGameStateData GameStateData;          // Current game state
    TArray<uint8> CompressedData;          // Compressed additional data
};
```

## Save Operations

### Auto-Save System
**Triggers:**
- Every 5 minutes of active gameplay
- After major AI interactions
- Before stage transitions
- When exiting game
- After minigame completion

**Implementation:**
```cpp
class BB_AutoSaveManager
{
private:
    FTimerHandle AutoSaveTimer;
    float AutoSaveInterval = 300.0f; // 5 minutes
    
public:
    void StartAutoSave();
    void StopAutoSave();
    void TriggerAutoSave();
    void CleanupOldAutoSaves();
};
```

### Manual Save System
**Features:**
- Multiple save slots (10 slots)
- Custom save names
- Save preview with thumbnail
- Save metadata (date, time, AI stage)
- Save validation and repair

**Implementation:**
```cpp
class BB_ManualSaveManager
{
public:
    bool SaveGame(int32 SlotIndex, FString SaveName);
    bool LoadGame(int32 SlotIndex);
    bool DeleteSave(int32 SlotIndex);
    TArray<FSaveFileInfo> GetSaveFileList();
    bool ValidateSaveFile(int32 SlotIndex);
};
```

### Backup System
**Automatic Backups:**
- Daily backup of all save data
- Backup before major updates
- Cloud backup integration (optional)
- Backup verification and restoration

**Manual Backups:**
- Create backup on demand
- Export save data
- Import save data
- Backup comparison tools

## Data Persistence

### GameInstance Integration
```cpp
class BB_GameInstance : public UGameInstance
{
private:
    UPROPERTY()
    class UBB_SaveManager* SaveManager;
    
    UPROPERTY()
    class UBB_AIDataManager* AIDataManager;
    
public:
    virtual void Init() override;
    virtual void Shutdown() override;
    
    UFUNCTION(BlueprintCallable)
    void SaveGameData();
    
    UFUNCTION(BlueprintCallable)
    void LoadGameData();
};
```

### Blueprint Integration
**Save Functions:**
- `Save Game Data` - Save current game state
- `Load Game Data` - Load saved game state
- `Auto Save` - Trigger auto-save
- `Create Backup` - Create manual backup
- `Restore Backup` - Restore from backup

**Load Functions:**
- `Get Save File List` - Get available saves
- `Get Save File Info` - Get save metadata
- `Validate Save File` - Check save integrity
- `Delete Save File` - Remove save file

## Error Handling

### Save Validation
```cpp
struct FSaveValidationResult
{
    bool IsValid;                          // Overall validity
    TArray<FString> Errors;                // List of errors
    TArray<FString> Warnings;              // List of warnings
    bool CanRepair;                        // Can be repaired
    FString RepairInstructions;            // How to repair
};
```

### Recovery Mechanisms
**Automatic Recovery:**
- Corrupted save detection
- Automatic backup restoration
- Data repair algorithms
- Fallback to previous save

**Manual Recovery:**
- Save file repair tools
- Data extraction utilities
- Manual backup restoration
- Reset to default state

## Performance Optimization

### Save Optimization
- **Compression**: LZ4 compression for save files
- **Incremental Saves**: Only save changed data
- **Async Operations**: Non-blocking save/load
- **Memory Management**: Efficient data structures

### Load Optimization
- **Progressive Loading**: Load data in stages
- **Caching**: Cache frequently accessed data
- **Background Loading**: Load in background threads
- **Preloading**: Preload next level data

## Security Features

### Data Protection
- **Encryption**: AES-256 encryption for save files
- **Checksums**: Data integrity verification
- **Anti-Tampering**: Detect modified save files
- **Backup Verification**: Validate backup integrity

### Access Control
- **User Permissions**: Control save file access
- **Cloud Sync**: Secure cloud storage
- **Version Control**: Track save file versions
- **Audit Trail**: Log save operations

## Integration Points

### AI System Integration
- **State Persistence**: Save AI personality and evolution
- **Conversation History**: Maintain conversation context
- **Behavioral Patterns**: Track AI learning and adaptation
- **Stage Progression**: Save evolution milestones

### UI System Integration
- **Window States**: Remember UI layout and positions
- **User Preferences**: Save interface customization
- **Accessibility Settings**: Remember accessibility options
- **Language Settings**: Save language preferences

### Minigame Integration
- **Score Tracking**: Save high scores and progress
- **Unlock Status**: Track available minigames
- **Difficulty Settings**: Remember challenge levels
- **Achievement Progress**: Track achievement completion

## Migration and Compatibility

### Version Migration
- **Format Updates**: Handle save file format changes
- **Data Migration**: Convert old save data to new format
- **Backward Compatibility**: Support older save files
- **Migration Validation**: Verify migrated data integrity

### Platform Compatibility
- **Cross-Platform**: Support different platforms
- **Cloud Sync**: Synchronize across devices
- **Local Storage**: Fallback to local storage
- **Export/Import**: Transfer saves between platforms

