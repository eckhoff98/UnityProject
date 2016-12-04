using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Change attack points and/or hit points of a Killable in Core GameKit")]
public class CoreGameKitKillableAttackOrHitPointsMod : FsmStateAction {
	private Killable myKillable;
	
	[RequiredField]
	[CheckForComponent(typeof(Killable))]
	[Tooltip("A GameObject with a Killable Component.")]
	public FsmOwnerDefault gameObject;
	
	[Tooltip("Repeat every frame while the state is active.")]
	public bool everyFrame;
	
	[Tooltip("Check this box if you want to change the Attack Points with the value below.")]
	public FsmBool changeAttackPoints = new FsmBool();
	
	[RequiredField]
	[Tooltip("new Attack Points value")]
	public FsmInt newAttackPoints;
	
	[Tooltip("Check this box if you want to change the Hit Points with the value below.")]
	public FsmBool changeHitPoints = new FsmBool();
	
	[RequiredField]
	[Tooltip("new Hit Points value")]
	public FsmInt newHitPoints;
	
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
		
		if (changeAttackPoints.Value) {
			myKillable.atckPoints.Value = newAttackPoints.Value;
		}
		
		if (changeHitPoints.Value) {
			myKillable.currentHitPoints = newHitPoints.Value;
		}
	}
	
	public override void Reset() {
		newAttackPoints = new FsmInt();
		newHitPoints = new FsmInt();
		changeAttackPoints = new FsmBool();
		changeHitPoints = new FsmBool();
		gameObject = new FsmOwnerDefault();
	}
}