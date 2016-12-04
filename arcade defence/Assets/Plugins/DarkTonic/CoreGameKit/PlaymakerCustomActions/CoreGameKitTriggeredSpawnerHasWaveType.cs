using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Check if a wave of a certain event type is spawning in a Triggered Spawner")]
public class CoreGameKitTriggeredSpawnerHasWaveType : FsmStateAction {
	private TriggeredSpawner spawner = null;
	
	[RequiredField]
    [Tooltip("The event type of the wave you wish to check for.")]
    public TriggeredSpawner.EventType eventType;

	[Tooltip("This field should only be used if you are stopping a Custom Event")]
	public FsmString customEventName = new FsmString();
	
	[RequiredField]
	[CheckForComponent(typeof(TriggeredSpawner))]
	[Tooltip("Triggered Spawner Object")]
	public FsmOwnerDefault triggeredSpawner = new FsmOwnerDefault();
	
	[TooltipAttribute("The variable to store the result in.")]
	public FsmBool boolVariable = new FsmBool();
	
	[Tooltip("Repeat every frame while the state is active.")]
	public bool everyFrame;
	
	public override void OnEnter() {
		CheckForWave();
		
		if (!everyFrame) {
			Finish();
		}
	}
	
	public override void OnUpdate() {
		CheckForWave();
	}

	private void CheckForWave() {
		if (this.spawner == null) {
			var go = Fsm.GetOwnerDefaultTarget(triggeredSpawner);
			this.spawner = go.GetComponent<TriggeredSpawner>();
		}

		boolVariable.Value = this.spawner.HasActiveWaveOfType(eventType, customEventName.Value);
	}
	
	public override void Reset() {
		triggeredSpawner = new FsmOwnerDefault();
		boolVariable = new FsmBool();
		customEventName = new FsmString();
	}
}
