using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Restart the current wave in Core GameKit")]
public class CoreGameKitWaveRestart : FsmStateAction {
	public override void OnEnter() {
		LevelSettings.RestartCurrentWave();
		
		Finish();
	}
	
	public override void Reset() {
	}
}
