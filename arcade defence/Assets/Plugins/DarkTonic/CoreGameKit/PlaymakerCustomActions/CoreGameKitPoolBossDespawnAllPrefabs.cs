using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Despawn all prefabs in Core GameKit")]
public class CoreGameKitPoolBossDespawnAllPrefabs : FsmStateAction {
	public override void OnEnter() {
		// despawn!
		SpawnUtility.DespawnAllPrefabs();
		
		Finish();
	}
	 
	public override void Reset() {
	} 
}
