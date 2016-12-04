using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Get the current Hit Points of a Killable in Core GameKit")]
public class CoreGameKitKillableGetCurrentHitPoints : FsmStateAction {
	private Killable myKillable;

	[RequiredField]
	[CheckForComponent(typeof(Killable))]
	[Tooltip("A GameObject with a Killable Component.")]
	public FsmOwnerDefault gameObject;
	
	[Tooltip("Repeat every frame while the state is active.")]
    public bool everyFrame;
	
	[RequiredField]
	[Tooltip("The variable to store the current Hit Points in.")]
	public FsmInt intVariable = new FsmInt(0);
	
	public override void OnEnter() {
		StoreHitPoints();
		
		if (!everyFrame)
		{
		    Finish();
		}		
	}

	public override void OnUpdate()
	{
		StoreHitPoints();
	}

	private void StoreHitPoints() {
		if (myKillable == null) {
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			myKillable = go.GetComponent<Killable>();
		}

		if (!intVariable.UsesVariable) {
			Debug.LogError("You must assign a variable to store the current Hit Points in.");
			return;
		}
		
		intVariable.Value = myKillable.currentHitPoints;
	}
	
	public override void Reset() {
		everyFrame = false;
		intVariable = new FsmInt(0);
		gameObject = new FsmOwnerDefault();
	}
}
