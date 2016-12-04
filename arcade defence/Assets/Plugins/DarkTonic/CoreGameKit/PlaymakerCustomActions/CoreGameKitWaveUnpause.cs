using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Unpause the current wave in Core GameKit")]
public class CoreGameKitWaveUnpause : FsmStateAction {
	public override void OnEnter() {
		LevelSettings.UnpauseWave();
		
		Finish();
	}
	
	public override void Reset() {
	}
}
