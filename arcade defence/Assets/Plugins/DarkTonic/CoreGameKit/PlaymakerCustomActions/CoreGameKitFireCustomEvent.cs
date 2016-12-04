using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Fire a Custom Event in Core GameKit")]
public class CoreGameKitFireCustomEvent : FsmStateAction {
	[RequiredField]
	[Tooltip("The name of the custom event.")]
	public FsmString customEventName = new FsmString();
	
	[RequiredField]
	[Tooltip("The origin point of the custom event, used for distance measurements if any distance criteria are used.")]		
	public FsmVector3 eventOrigin = new FsmVector3();

	public override void OnEnter() {
		LevelSettings.FireCustomEvent (customEventName.Value, eventOrigin.Value);
		
		Finish();
	}

	public override void Reset() {
		customEventName = new FsmString();
		eventOrigin = new FsmVector3();
	}
}
