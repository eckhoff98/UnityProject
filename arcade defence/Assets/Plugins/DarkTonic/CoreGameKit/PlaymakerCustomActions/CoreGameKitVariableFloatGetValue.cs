using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Get the value of a float World Variable in Core GameKit")]
public class CoreGameKitVariableFloatGetValue : FsmStateAction {
    [RequiredField]
    [Tooltip("World Variable Name")]
	public FsmString worldVariableName = new FsmString(string.Empty);

    [Tooltip("Repeat every frame while the state is active.")]
    public bool everyFrame;
	
	[RequiredField]
	[Tooltip("The variable to store the value of the World Variable in.")]
	public FsmFloat floatVariable = new FsmFloat(0f);
	
	public override void OnEnter() {
		UpdateVariable();
		
		if (!everyFrame)
		{
		    Finish();
		}		
	}

	public override void OnUpdate()
	{
		UpdateVariable();
	}

	private void UpdateVariable() {
		var variable = WorldVariableTracker.GetWorldVariable(worldVariableName.Value);
		floatVariable.Value = variable.CurrentFloatValue;
	}
	
	public override void Reset() {
		worldVariableName = new FsmString(string.Empty);
		everyFrame = false;
		floatVariable = new FsmFloat(0f);
	}
}
