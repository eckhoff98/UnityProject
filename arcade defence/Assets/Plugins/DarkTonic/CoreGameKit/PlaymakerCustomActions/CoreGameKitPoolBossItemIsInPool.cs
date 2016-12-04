using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Return a boolean indicating if a Transform is pooled in Pool Boss in Core GameKit")]
public class CoreGameKitPoolBossItemIsInPool : FsmStateAction {

	[RequiredField]
    [Tooltip("Prefab To Ask About")]
	public FsmGameObject prefab = new FsmGameObject();
	
	[RequiredField]
	[Tooltip("The variable to store the result in.")]
	public FsmBool boolVariable = new FsmBool();
	
	public override void OnEnter() {
		if (prefab.Value == null) {
			Debug.LogError("You have not set the prefab object in the FSM in Game Object '" + this.Owner.transform.name + "'.");
			return;
		}
		
		boolVariable.Value = PoolBoss.PrefabIsInPool(prefab.Value.transform);
		
		Finish();
	}

	public override void Reset() {
		prefab = new FsmGameObject();
		boolVariable = new FsmBool();
	}
}
