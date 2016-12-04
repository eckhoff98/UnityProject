using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Add to the value of a float World Variable in Core GameKit")]
public class CoreGameKitVariableFloatAdd : FsmStateAction {
    [RequiredField]
    [Tooltip("World Variable Name")]
	public FsmString worldVariableName = new FsmString(string.Empty);
	
	[RequiredField]
	[Tooltip("The value to add to the World Variable.")]
	public FsmFloat newValue = new FsmFloat(0f);

    [Tooltip("Repeat every frame while the state is active.")]
    public bool everyFrame;
	
	public override void OnEnter() {
		AddFloat();
		
		if (!everyFrame) {		
			Finish();
		}
	}
	
	public override void OnUpdate() {
		AddFloat();
	}
	
	private void AddFloat() {
		var trans = this.Owner.transform;
		var modifier = new WorldVariableModifier(worldVariableName.Value, WorldVariableTracker.VariableType._float);
		modifier._modValueFloatAmt.curModMode = KillerVariable.ModMode.Add;
		modifier._modValueFloatAmt.Value = newValue.Value;
		
		WorldVariableTracker.ModifyPlayerStat(modifier, trans);
	}
	
	public override void Reset() {
		worldVariableName = new FsmString(string.Empty);
		newValue = new FsmFloat(0f);
	}
}
