using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Pause the current wave in Core GameKit")]
public class CoreGameKitWavePause : FsmStateAction {
	public override void OnEnter() {
		LevelSettings.PauseWave();
		
		Finish();
	}
	
	public override void Reset() {
	}
}
