using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Kill all prefabs in Core GameKit. Only prefabs with a Killable component will be affected.")]
public class CoreGameKitPoolBossKillAllPrefabs : FsmStateAction {
	public override void OnEnter() {
		// kill!
		SpawnUtility.KillAllPrefabs();
		
		Finish();
	}
	
	public override void Reset() {
	}
}
