using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Get the value of an int World Variable in Core GameKit")]
public class CoreGameKitVariableIntGetValue : FsmStateAction {
    [RequiredField]
    [Tooltip("World Variable Name")]
	public FsmString worldVariableName = new FsmString(string.Empty);

    [Tooltip("Repeat every frame while the state is active.")]
    public bool everyFrame;
	
	[RequiredField]
	[Tooltip("The variable to store the value of the World Variable in.")]
	public FsmInt intVariable = new FsmInt(0);
	
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
		intVariable.Value = variable.CurrentIntValue;
	}
	
	public override void Reset() {
		worldVariableName = new FsmString(string.Empty);
		everyFrame = false;
		intVariable = new FsmInt(0);
	}
}
