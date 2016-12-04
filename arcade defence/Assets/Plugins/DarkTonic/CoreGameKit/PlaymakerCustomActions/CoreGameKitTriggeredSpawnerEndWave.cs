using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("End a wave of a certain event type in a Triggered Spawner")]
public class CoreGameKitTriggeredSpawnerEndWave : FsmStateAction {
	private TriggeredSpawner spawner = null;
	
	[RequiredField]
    [Tooltip("The event type of the wave you wish to end.")]
    public TriggeredSpawner.EventType eventType;

	[RequiredField]
	[CheckForComponent(typeof(TriggeredSpawner))]
	[Tooltip("Triggered Spawner Object")]
	public FsmOwnerDefault triggeredSpawner = new FsmOwnerDefault();

	[Tooltip("This field should only be used if you are stopping a Custom Event")]
	public FsmString customEventName = new FsmString();

	public override void OnEnter() {
		EndWave();
		
		Finish();
	}
     
	private void EndWave() {
		if (this.spawner == null) {
			var go = Fsm.GetOwnerDefaultTarget(triggeredSpawner);
			this.spawner = go.GetComponent<TriggeredSpawner>();
		}

		this.spawner.EndWave(eventType, customEventName.Value);
	}
	
	public override void Reset() {
		triggeredSpawner = new FsmOwnerDefault();
		customEventName = new FsmString();
	}
}
