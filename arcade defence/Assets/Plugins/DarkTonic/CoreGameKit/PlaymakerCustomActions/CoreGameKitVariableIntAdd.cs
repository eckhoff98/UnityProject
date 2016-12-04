using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Add to the value of an int World Variable in Core GameKit")]
public class CoreGameKitVariableIntAdd : FsmStateAction {
    [RequiredField]
    [Tooltip("World Variable Name")]
	public FsmString worldVariableName = new FsmString(string.Empty);
	
	[RequiredField]
	[Tooltip("The value to add to the World Variable.")]
	public FsmInt newValue = new FsmInt(0);

    [Tooltip("Repeat every frame while the state is active.")]
    public bool everyFrame;
	
	public override void OnEnter() {
		IntAdd();
		
		if (!everyFrame) {		
			Finish();
		}
	}
	
	public override void OnUpdate() {
		IntAdd();
	}
	
	private void IntAdd() {
		var trans = this.Owner.transform;
		var modifier = new WorldVariableModifier(worldVariableName.Value, WorldVariableTracker.VariableType._integer);
		modifier._modValueIntAmt.curModMode = KillerVariable.ModMode.Add;
		modifier._modValueIntAmt.Value = newValue.Value;
		
		WorldVariableTracker.ModifyPlayerStat(modifier, trans);
	}
	
	public override void Reset() {
		worldVariableName = new FsmString(string.Empty);
		newValue = new FsmInt(0);
	}
}
