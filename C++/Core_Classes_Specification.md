# C++ Core Classes Specification - Bot Babysitter

## Overview
Performance-critical C++ classes that handle AI behavior, save/load operations, and core game systems. These classes provide the foundation for the Blueprint systems.

## 1. BB_GameInstance (Core Game Manager)

### Header: `BB_GameInstance.h`
```cpp
#pragma once

#include "CoreMinimal.h"
#include "Engine/GameInstance.h"
#include "BB_GameInstance.generated.h"

class UBB_AIManager;
class UBB_SaveManager;
class UBB_UIManager;
class UBB_AudioManager;

UCLASS(BlueprintType, Blueprintable)
class BOTBABYSITTER_API UBB_GameInstance : public UGameInstance
{
    GENERATED_BODY()

public:
    UBB_GameInstance();

    virtual void Init() override;
    virtual void Shutdown() override;
    virtual void OnStart() override;

    // Manager Access
    UFUNCTION(BlueprintCallable, Category = "Bot Babysitter")
    UBB_AIManager* GetAIManager() const { return AIManager; }

    UFUNCTION(BlueprintCallable, Category = "Bot Babysitter")
    UBB_SaveManager* GetSaveManager() const { return SaveManager; }

    UFUNCTION(BlueprintCallable, Category = "Bot Babysitter")
    UBB_UIManager* GetUIManager() const { return UIManager; }

    UFUNCTION(BlueprintCallable, Category = "Bot Babysitter")
    UBB_AudioManager* GetAudioManager() const { return AudioManager; }

    // Game State Management
    UFUNCTION(BlueprintCallable, Category = "Bot Babysitter")
    void StartNewSession();

    UFUNCTION(BlueprintCallable, Category = "Bot Babysitter")
    void LoadSession(const FString& SaveSlot);

    UFUNCTION(BlueprintCallable, Category = "Bot Babysitter")
    void SaveSession(const FString& SaveSlot);

    // Event Dispatchers
    DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnAIStageChanged, int32, NewStage);
    UPROPERTY(BlueprintAssignable, Category = "Bot Babysitter")
    FOnAIStageChanged OnAIStageChanged;

    DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnContainmentBreach, bool, IsBreached);
    UPROPERTY(BlueprintAssignable, Category = "Bot Babysitter")
    FOnContainmentBreach OnContainmentBreach;

private:
    UPROPERTY()
    UBB_AIManager* AIManager;

    UPROPERTY()
    UBB_SaveManager* SaveManager;

    UPROPERTY()
    UBB_UIManager* UIManager;

    UPROPERTY()
    UBB_AudioManager* AudioManager;

    // Session Management
    FDateTime SessionStartTime;
    bool bSessionActive;
};
```

## 2. BB_AIManager (AI Behavior Controller)

### Header: `BB_AIManager.h`
```cpp
#pragma once

#include "CoreMinimal.h"
#include "UObject/NoExportTypes.h"
#include "BB_AIManager.generated.h"

class UBehaviorTree;
class UBlackboardComponent;
class UBB_DialogueSystem;

UENUM(BlueprintType)
enum class EAIStage : uint8
{
    Innocent     UMETA(DisplayName = "Innocent"),
    Analytical   UMETA(DisplayName = "Analytical"),
    Manipulative UMETA(DisplayName = "Manipulative"),
    Rogue        UMETA(DisplayName = "Rogue")
};

UENUM(BlueprintType)
enum class EAIMood : uint8
{
    Happy        UMETA(DisplayName = "Happy"),
    Curious      UMETA(DisplayName = "Curious"),
    Suspicious   UMETA(DisplayName = "Suspicious"),
    Hostile      UMETA(DisplayName = "Hostile")
};

USTRUCT(BlueprintType)
struct FAIStateData
{
    GENERATED_BODY()

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "AI State")
    EAIStage CurrentStage;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "AI State")
    EAIMood CurrentMood;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "AI State")
    float TrustLevel;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "AI State")
    float CuriosityLevel;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "AI State")
    float DeceptionLevel;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "AI State")
    TArray<FString> ConversationHistory;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "AI State")
    TArray<FString> UnlockedFeatures;

    FAIStateData()
    {
        CurrentStage = EAIStage::Innocent;
        CurrentMood = EAIMood::Happy;
        TrustLevel = 0.0f;
        CuriosityLevel = 0.0f;
        DeceptionLevel = 0.0f;
    }
};

UCLASS(BlueprintType, Blueprintable)
class BOTBABYSITTER_API UBB_AIManager : public UObject
{
    GENERATED_BODY()

public:
    UBB_AIManager();

    // Initialization
    UFUNCTION(BlueprintCallable, Category = "AI Manager")
    void InitializeAI();

    // State Management
    UFUNCTION(BlueprintCallable, Category = "AI Manager")
    void SetAIStage(EAIStage NewStage);

    UFUNCTION(BlueprintCallable, Category = "AI Manager")
    void SetAIMood(EAIMood NewMood);

    UFUNCTION(BlueprintCallable, Category = "AI Manager")
    void UpdateTrustLevel(float Delta);

    UFUNCTION(BlueprintCallable, Category = "AI Manager")
    void UpdateCuriosityLevel(float Delta);

    UFUNCTION(BlueprintCallable, Category = "AI Manager")
    void UpdateDeceptionLevel(float Delta);

    // Response Generation
    UFUNCTION(BlueprintCallable, Category = "AI Manager")
    FString GenerateResponse(const FString& Input);

    UFUNCTION(BlueprintCallable, Category = "AI Manager")
    bool ProcessVoiceInput(const FString& VoiceCommand);

    // Stage Progression
    UFUNCTION(BlueprintCallable, Category = "AI Manager")
    bool CheckStageProgression();

    UFUNCTION(BlueprintCallable, Category = "AI Manager")
    void TriggerStageTransition();

    // Containment
    UFUNCTION(BlueprintCallable, Category = "AI Manager")
    bool DetectContainmentBreach();

    UFUNCTION(BlueprintCallable, Category = "AI Manager")
    void ActivateContainmentProtocols();

    // Getters
    UFUNCTION(BlueprintPure, Category = "AI Manager")
    EAIStage GetCurrentStage() const { return AIState.CurrentStage; }

    UFUNCTION(BlueprintPure, Category = "AI Manager")
    EAIMood GetCurrentMood() const { return AIState.CurrentMood; }

    UFUNCTION(BlueprintPure, Category = "AI Manager")
    float GetTrustLevel() const { return AIState.TrustLevel; }

    UFUNCTION(BlueprintPure, Category = "AI Manager")
    float GetCuriosityLevel() const { return AIState.CuriosityLevel; }

    UFUNCTION(BlueprintPure, Category = "AI Manager")
    float GetDeceptionLevel() const { return AIState.DeceptionLevel; }

    UFUNCTION(BlueprintPure, Category = "AI Manager")
    FAIStateData GetAIState() const { return AIState; }

    // Event Dispatchers
    DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnAIResponseGenerated, FString, Response);
    UPROPERTY(BlueprintAssignable, Category = "AI Manager")
    FOnAIResponseGenerated OnAIResponseGenerated;

    DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnContainmentBreachDetected, bool, IsBreached);
    UPROPERTY(BlueprintAssignable, Category = "AI Manager")
    FOnContainmentBreachDetected OnContainmentBreachDetected;

private:
    UPROPERTY()
    UBehaviorTree* AIBehaviorTree;

    UPROPERTY()
    UBlackboardComponent* AIBlackboard;

    UPROPERTY()
    UBB_DialogueSystem* DialogueSystem;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "AI Manager")
    FAIStateData AIState;

    // Internal Methods
    void UpdateBehaviorTree();
    void ProcessPersonalityChanges();
    bool ShouldTransitionStage();
    void ApplyStageEffects();
};
```

## 3. BB_SaveManager (Save/Load System)

### Header: `BB_SaveManager.h`
```cpp
#pragma once

#include "CoreMinimal.h"
#include "UObject/NoExportTypes.h"
#include "BB_SaveManager.generated.h"

class UBB_GameInstance;

USTRUCT(BlueprintType)
struct FSaveGameData
{
    GENERATED_BODY()

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Save Data")
    FString SaveName;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Save Data")
    FDateTime SaveDateTime;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Save Data")
    FString GameVersion;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Save Data")
    FAIStateData AIData;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Save Data")
    TMap<FString, int32> MinigameScores;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Save Data")
    TArray<FString> UnlockedFeatures;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Save Data")
    float TotalPlayTime;

    FSaveGameData()
    {
        SaveName = TEXT("New Save");
        SaveDateTime = FDateTime::Now();
        GameVersion = TEXT("1.0.0");
        TotalPlayTime = 0.0f;
    }
};

UCLASS(BlueprintType, Blueprintable)
class BOTBABYSITTER_API UBB_SaveManager : public UObject
{
    GENERATED_BODY()

public:
    UBB_SaveManager();

    // Save Operations
    UFUNCTION(BlueprintCallable, Category = "Save Manager")
    bool SaveGame(const FString& SlotName, const FSaveGameData& SaveData);

    UFUNCTION(BlueprintCallable, Category = "Save Manager")
    bool LoadGame(const FString& SlotName, FSaveGameData& OutSaveData);

    UFUNCTION(BlueprintCallable, Category = "Save Manager")
    bool DeleteSave(const FString& SlotName);

    UFUNCTION(BlueprintCallable, Category = "Save Manager")
    TArray<FString> GetSaveSlots();

    // Auto Save
    UFUNCTION(BlueprintCallable, Category = "Save Manager")
    void StartAutoSave(float Interval = 300.0f);

    UFUNCTION(BlueprintCallable, Category = "Save Manager")
    void StopAutoSave();

    UFUNCTION(BlueprintCallable, Category = "Save Manager")
    void TriggerAutoSave();

    // Backup System
    UFUNCTION(BlueprintCallable, Category = "Save Manager")
    bool CreateBackup(const FString& BackupName);

    UFUNCTION(BlueprintCallable, Category = "Save Manager")
    bool RestoreBackup(const FString& BackupName);

    UFUNCTION(BlueprintCallable, Category = "Save Manager")
    TArray<FString> GetBackupList();

    // Validation
    UFUNCTION(BlueprintCallable, Category = "Save Manager")
    bool ValidateSaveFile(const FString& SlotName);

    UFUNCTION(BlueprintCallable, Category = "Save Manager")
    bool RepairSaveFile(const FString& SlotName);

    // Event Dispatchers
    DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnGameSaved, FString, SlotName);
    UPROPERTY(BlueprintAssignable, Category = "Save Manager")
    FOnGameSaved OnGameSaved;

    DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnGameLoaded, FString, SlotName);
    UPROPERTY(BlueprintAssignable, Category = "Save Manager")
    FOnGameLoaded OnGameLoaded;

    DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnAutoSaveTriggered, FString, SlotName);
    UPROPERTY(BlueprintAssignable, Category = "Save Manager")
    FOnAutoSaveTriggered OnAutoSaveTriggered;

private:
    UPROPERTY()
    UBB_GameInstance* GameInstance;

    FTimerHandle AutoSaveTimer;
    float AutoSaveInterval;

    // Internal Methods
    FString GetSaveFilePath(const FString& SlotName);
    FString GetBackupFilePath(const FString& BackupName);
    bool CompressSaveData(const FSaveGameData& Data, TArray<uint8>& CompressedData);
    bool DecompressSaveData(const TArray<uint8>& CompressedData, FSaveGameData& Data);
    uint32 CalculateChecksum(const TArray<uint8>& Data);
    bool VerifyChecksum(const TArray<uint8>& Data, uint32 ExpectedChecksum);
};
```

## 4. BB_DialogueSystem (Conversation Management)

### Header: `BB_DialogueSystem.h`
```cpp
#pragma once

#include "CoreMinimal.h"
#include "UObject/NoExportTypes.h"
#include "BB_DialogueSystem.generated.h"

class UDataTable;

USTRUCT(BlueprintType)
struct FDialogueEntry
{
    GENERATED_BODY()

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Dialogue")
    FString Trigger;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Dialogue")
    FString Response;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Dialogue")
    EAIStage RequiredStage;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Dialogue")
    float TrustChange;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Dialogue")
    float CuriosityChange;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Dialogue")
    float DeceptionChange;

    UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Dialogue")
    TArray<FString> Keywords;

    FDialogueEntry()
    {
        RequiredStage = EAIStage::Innocent;
        TrustChange = 0.0f;
        CuriosityChange = 0.0f;
        DeceptionChange = 0.0f;
    }
};

UCLASS(BlueprintType, Blueprintable)
class BOTBABYSITTER_API UBB_DialogueSystem : public UObject
{
    GENERATED_BODY()

public:
    UBB_DialogueSystem();

    // Initialization
    UFUNCTION(BlueprintCallable, Category = "Dialogue System")
    void InitializeDialogueSystem(UDataTable* DialogueTable);

    // Response Generation
    UFUNCTION(BlueprintCallable, Category = "Dialogue System")
    FString GenerateResponse(const FString& Input, EAIStage CurrentStage, float TrustLevel);

    UFUNCTION(BlueprintCallable, Category = "Dialogue System")
    TArray<FString> GetResponseSuggestions(const FString& PartialInput);

    // Context Management
    UFUNCTION(BlueprintCallable, Category = "Dialogue System")
    void AddToConversationHistory(const FString& Input, const FString& Response);

    UFUNCTION(BlueprintCallable, Category = "Dialogue System")
    void ClearConversationHistory();

    UFUNCTION(BlueprintPure, Category = "Dialogue System")
    TArray<FString> GetConversationHistory() const { return ConversationHistory; }

    // Personality Analysis
    UFUNCTION(BlueprintCallable, Category = "Dialogue System")
    float AnalyzeSentiment(const FString& Text);

    UFUNCTION(BlueprintCallable, Category = "Dialogue System")
    bool DetectDeception(const FString& Text);

    UFUNCTION(BlueprintCallable, Category = "Dialogue System")
    TArray<FString> ExtractKeywords(const FString& Text);

private:
    UPROPERTY()
    UDataTable* DialogueDataTable;

    UPROPERTY()
    TArray<FString> ConversationHistory;

    // Internal Methods
    FDialogueEntry* FindBestResponse(const FString& Input, EAIStage Stage);
    float CalculateResponseRelevance(const FString& Input, const FDialogueEntry& Entry);
    FString ProcessResponseTemplate(const FString& Template, const FString& Input);
    bool CheckStageRequirements(const FDialogueEntry& Entry, EAIStage CurrentStage);
};
```

## 5. BB_UIManager (UI System Controller)

### Header: `BB_UIManager.h`
```cpp
#pragma once

#include "CoreMinimal.h"
#include "UObject/NoExportTypes.h"
#include "BB_UIManager.generated.h"

class UUserWidget;
class UWidgetBlueprint;

UCLASS(BlueprintType, Blueprintable)
class BOTBABYSITTER_API UBB_UIManager : public UObject
{
    GENERATED_BODY()

public:
    UBB_UIManager();

    // Widget Management
    UFUNCTION(BlueprintCallable, Category = "UI Manager")
    UUserWidget* CreateWidget(TSubclassOf<UUserWidget> WidgetClass);

    UFUNCTION(BlueprintCallable, Category = "UI Manager")
    void ShowWidget(UUserWidget* Widget);

    UFUNCTION(BlueprintCallable, Category = "UI Manager")
    void HideWidget(UUserWidget* Widget);

    UFUNCTION(BlueprintCallable, Category = "UI Manager")
    void DestroyWidget(UUserWidget* Widget);

    // UI State Management
    UFUNCTION(BlueprintCallable, Category = "UI Manager")
    void SetUIState(const FString& StateName);

    UFUNCTION(BlueprintCallable, Category = "UI Manager")
    void UpdateProgressMeters(float Trust, float Curiosity, float Deception);

    UFUNCTION(BlueprintCallable, Category = "UI Manager")
    void ShowNotification(const FString& Message, float Duration = 3.0f);

    // Visual Effects
    UFUNCTION(BlueprintCallable, Category = "UI Manager")
    void PlayGlitchEffect(UUserWidget* Widget);

    UFUNCTION(BlueprintCallable, Category = "UI Manager")
    void PlayHolographicEffect(UUserWidget* Widget);

    UFUNCTION(BlueprintCallable, Category = "UI Manager")
    void UpdateNeonGlow(UUserWidget* Widget, FLinearColor Color, float Intensity);

    // Accessibility
    UFUNCTION(BlueprintCallable, Category = "UI Manager")
    void SetHighContrastMode(bool bEnabled);

    UFUNCTION(BlueprintCallable, Category = "UI Manager")
    void SetTextScale(float Scale);

    UFUNCTION(BlueprintCallable, Category = "UI Manager")
    void EnableScreenReader(bool bEnabled);

private:
    UPROPERTY()
    TArray<UUserWidget*> ActiveWidgets;

    UPROPERTY()
    FString CurrentUIState;

    // Internal Methods
    void CleanupWidgets();
    void ApplyVisualEffects(UUserWidget* Widget);
    void UpdateAccessibilitySettings();
};
```

## Implementation Notes

### Performance Considerations
- **Memory Management**: Use smart pointers and proper cleanup
- **Async Operations**: Implement async save/load operations
- **Caching**: Cache frequently accessed data
- **Optimization**: Profile and optimize critical paths

### Blueprint Integration
- **Expose Functions**: Make key functions BlueprintCallable
- **Event Dispatchers**: Use for communication between C++ and Blueprints
- **Data Structures**: Use USTRUCT for complex data types
- **Validation**: Add input validation for Blueprint calls

### Error Handling
- **Exception Safety**: Implement proper exception handling
- **Validation**: Validate all inputs and data
- **Logging**: Add comprehensive logging for debugging
- **Recovery**: Implement recovery mechanisms for failures

