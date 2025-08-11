using UnrealBuildTool;
using System.Collections.Generic;

public class BotBabysitterTarget : TargetRules
{
	public BotBabysitterTarget(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Game;
		DefaultBuildSettings = BuildSettingsVersion.V4;
		IncludeOrderVersion = EngineIncludeOrderVersion.Unreal5_3;
		ExtraModuleNames.Add("BotBabysitter");
	}
}
