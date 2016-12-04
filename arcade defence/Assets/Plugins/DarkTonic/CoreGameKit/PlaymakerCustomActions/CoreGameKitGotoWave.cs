using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("End the current wave in Core GameKit and go to a new Level / Wave of your choice!")]
public class CoreGameKitGotoWave : FsmStateAction {
	[Tooltip("The level number to go to.")]
	public FsmInt levelNumber = new FsmInt();
	
	[Tooltip("The wave number to go to.")]
	public FsmInt waveNumber = new FsmInt();
	
	public override void OnEnter() {
		LevelSettings.GotoWave(levelNumber.Value, waveNumber.Value);
		
		Finish();
	}
	
	public override void Reset() {
		levelNumber = new FsmInt();
		waveNumber = new FsmInt();
	}
}
