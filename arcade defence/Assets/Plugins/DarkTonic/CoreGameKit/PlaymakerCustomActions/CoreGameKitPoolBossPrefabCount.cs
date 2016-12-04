using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Get total number of different prefabs set up in Pool Boss in Core GameKit")]
public class CoreGameKitPoolBossPrefabCount : FsmStateAction {
	[RequiredField]
	[Tooltip("The variable to store the value of the World Variable in.")]
	public FsmInt intVariable = new FsmInt();
	
	public override void OnEnter() {
		intVariable.Value = PoolBoss.PrefabCount;
		
		Finish();
	}

	public override void Reset() {
		intVariable = new FsmInt();
	}
}
