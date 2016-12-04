using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.CoreGameKit;

[AddComponentMenu("Dark Tonic/Core GameKit/Listeners/World Variable Playmaker Listener")]
[RequireComponent(typeof(PlayMakerFSM))]
public class WorldVariablePlaymakerListener : WorldVariableListener {
	public CGKPlaymakerUtility.PlaymakerEventSetting updateIntValueSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting updateFloatValueSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	
	private Dictionary<string, CGKPlaymakerUtility.PlaymakerFsmWithEvents> fsmEventsMap = null;
	
	// Lazy lookup and persistent
	private Dictionary<string, CGKPlaymakerUtility.PlaymakerFsmWithEvents> EventsByFsmName {
		get {
			if (fsmEventsMap == null) {
				fsmEventsMap = CGKPlaymakerUtility.GetEventListByFSM(this);
			}
			
			return fsmEventsMap;
		}
	}
	 
	public override void UpdateValue(int newValue, int oldValue) {
		CGKPlaymakerUtility.SendEventIfValid(updateIntValueSetting, EventsByFsmName);

		base.UpdateValue(newValue, oldValue);
	}

	public override void UpdateFloatValue(float newValue, float oldValue) {
		CGKPlaymakerUtility.SendEventIfValid(updateFloatValueSetting, EventsByFsmName);
		
		base.UpdateFloatValue(newValue, oldValue);
	}
}
