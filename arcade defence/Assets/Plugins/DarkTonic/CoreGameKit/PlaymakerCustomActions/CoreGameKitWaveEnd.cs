using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("End the current wave in Core GameKit")]
public class CoreGameKitWaveEnd : FsmStateAction {
	public override void OnEnter() {
		LevelSettings.EndWave();
		
		Finish();
	}
	
	public override void Reset() {
	}
}
