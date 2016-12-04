using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Add attack points and/or hit points to a Killable in Core GameKit")]
public class CoreGameKitKillableAttackOrHitPointsAdd : FsmStateAction {
	private Killable myKillable;
	
	[RequiredField]
	[CheckForComponent(typeof(Killable))]
	[Tooltip("A GameObject with a Killable Component.")]
	public FsmOwnerDefault gameObject;
	
	[Tooltip("Repeat every frame while the state is active.")]
	public bool everyFrame;
	
	[RequiredField]
	[Tooltip("Attack Points to add")]
	public FsmInt additionalAttackPoints;
	
	[RequiredField]
	[Tooltip("Hit Points to add")]
	public FsmInt additionalHitPoints;
	
	public override void OnEnter() {
		ChangeHitPoints();
		
		if (!everyFrame) {
			Finish();
		}
	}
	 
	public override void OnUpdate() {
		ChangeHitPoints();
	}
	
	private void ChangeHitPoints() {
		if (myKillable == null) {
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			myKillable = go.GetComponent<Killable>();
		}
		
		myKillable.atckPoints.Value += additionalAttackPoints.Value;
		
		var addHP = additionalHitPoints.Value;
		
		myKillable.AddHitPoints(addHP);
		if (addHP < 0) {
			myKillable.TakeDamage(-addHP);
		}
	}
	
	public override void Reset() {
		additionalAttackPoints = new FsmInt();
		additionalHitPoints = new FsmInt();
		gameObject = new FsmOwnerDefault();
	}
}
