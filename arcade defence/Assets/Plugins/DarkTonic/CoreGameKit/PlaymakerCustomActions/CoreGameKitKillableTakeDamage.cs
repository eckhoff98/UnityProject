using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Inflict points of damage on a Killable in Core GameKit")]
public class CoreGameKitKillableTakeDamage : FsmStateAction {
	private Killable myKillable;
	
	[RequiredField]
	[CheckForComponent(typeof(Killable))]
	[Tooltip("A GameObject with a Killable Component.")]
	public FsmOwnerDefault gameObject;
	
    [RequiredField]
    [Tooltip("Damage Points to hit the Killable with")]
	public FsmInt damagePoints;

    [Tooltip("Repeat every frame while the state is active.")]
    public bool everyFrame;
	
	public override void OnEnter() {
		TakeDamage();
		
		if (!everyFrame) {
			Finish();
		}
	}
	
	public override void OnUpdate() {
		TakeDamage();
	}
	
	private void TakeDamage() {
		if (myKillable == null) {
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			myKillable = go.GetComponent<Killable>();
		}
		
		myKillable.TakeDamage(damagePoints.Value);
	}
	
	public override void Reset() {
		damagePoints = new FsmInt();
		gameObject = new FsmOwnerDefault();
	}
}
