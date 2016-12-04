using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Make a Killable object in Core GameKit invincible for X seconds")]
public class CoreGameKitKillableTemporaryInvincibility : FsmStateAction {
	private Killable myKillable;
	
	[RequiredField]
	[CheckForComponent(typeof(Killable))]
	[Tooltip("A GameObject with a Killable Component.")]
	public FsmOwnerDefault gameObject;
	
	[RequiredField]
	[Tooltip("The amount of time to make the Killable invincible.")]
	public FsmFloat invincibleTime = new FsmFloat(2f);
	
	public override void OnEnter() {
		if (myKillable == null) {
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			myKillable = go.GetComponent<Killable>();
		}
		
		myKillable.TemporaryInvincibility(invincibleTime.Value);
		
		Finish();
	}
	
	public override void Reset() {
		gameObject = new FsmOwnerDefault();
		invincibleTime = new FsmFloat(2f);
	}
}
