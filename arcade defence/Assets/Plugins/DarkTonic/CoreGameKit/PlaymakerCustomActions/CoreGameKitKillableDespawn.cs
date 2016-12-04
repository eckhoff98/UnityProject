using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Despawn a Killable object in Core GameKit")]
public class CoreGameKitKillableDespawn : FsmStateAction {
	private Killable myKillable;
	
	[RequiredField]
	[CheckForComponent(typeof(Killable))]
	[Tooltip("A GameObject with a Killable Component.")]
	public FsmOwnerDefault gameObject;
	
	public override void OnEnter() {
		if (myKillable == null) {
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			myKillable = go.GetComponent<Killable>();
		}
		
		myKillable.Despawn(TriggeredSpawner.EventType.CodeTriggered1);
		
		Finish();
	}
	
	public override void Reset() {
		gameObject = new FsmOwnerDefault();
	}
}
