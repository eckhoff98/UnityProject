using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Despawn any one item in Core GameKit")]
public class CoreGameKitPoolBossDespawn : FsmStateAction {
	private Transform trans = null;
	
    [RequiredField]
    [Tooltip("Object holding object to despawn")]
	public FsmOwnerDefault gameObject = new FsmOwnerDefault();
	
	public override void OnEnter() {
		if (this.trans == null) {
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			this.trans = go.transform;
		}
		
		// despawn!
		PoolBoss.Despawn(this.trans);
		
		Finish();
	}
	
	public override void Reset() {
		gameObject = new FsmOwnerDefault();
	}
}
