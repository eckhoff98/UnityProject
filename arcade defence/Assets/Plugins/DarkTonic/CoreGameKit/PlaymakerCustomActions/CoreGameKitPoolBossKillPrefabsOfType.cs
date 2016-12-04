using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Kill all prefabs of one type in Core GameKit. Only prefabs with a Killable component will be affected.")]
public class CoreGameKitPoolBossKillPrefabsOfType : FsmStateAction {
	private Transform trans = null;
	
    [RequiredField]
    [Tooltip("Object holding object to kill")]
	public FsmOwnerDefault gameObject = new FsmOwnerDefault();
	
	public override void OnEnter() {
		if (this.trans == null) {
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			this.trans = go.transform;
		}
		
		// kill!
		SpawnUtility.KillAllOfPrefab(this.trans);
		
		Finish();
	}
	
	public override void Reset() {
		gameObject = new FsmOwnerDefault();
	}
}
