using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Destroy a Killable object in Core GameKit")]
public class CoreGameKitKillableDestroy : FsmStateAction {
	private Killable myKillable;
	
	[RequiredField]
	[CheckForComponent(typeof(Killable))]
	[Tooltip("A GameObject with a Killable Component.")]
	public FsmOwnerDefault gameObject;

	[RequiredField]
	[Tooltip("The name of the scenario (World Variable Mod Group)")]
    public FsmString scenarioName = new FsmString(Killable.DestroyedText);

    [Tooltip("If checked, this will skip the Death Delay, if any.")]
    public FsmBool killImmediately = new FsmBool();
	
	public override void OnEnter() {
		if (myKillable == null) {
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			myKillable = go.GetComponent<Killable>();
		}
		
		myKillable.DestroyKillable(scenarioName.Value, killImmediately.Value);
		
		Finish();
	}
	
	public override void Reset() {
		gameObject = new FsmOwnerDefault();
		scenarioName = new FsmString(Killable.DestroyedText);
        killImmediately = new FsmBool();
	}
}
