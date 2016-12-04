using System.Collections.Generic;
using DarkTonic.CoreGameKit;
using UnityEditor;
using UnityEngine;

public static class DTPlaymakerUtility {
	public static void RenderPlaymakerTransmitEvent(CGKPlaymakerUtility.PlaymakerEventSetting eventSetting, string eventName, 
		Dictionary<string, CGKPlaymakerUtility.PlaymakerFsmWithEvents> fsmEventsByFsm, MonoBehaviour listener) {

		var isDirty = false;

		var newUseSetting = EditorGUILayout.BeginToggleGroup("Hookup: " + eventName, eventSetting.useSetting);
		if (newUseSetting != eventSetting.useSetting) {
			UndoHelper.RecordObjectPropertyForUndo(ref isDirty, listener, "toggle Hookup: " + eventName);
			eventSetting.useSetting = newUseSetting;
		}
		
		if (eventSetting.useSetting) {
			var fsmNames = new List<string>();
			fsmNames.AddRange(fsmEventsByFsm.Keys);
			
			var chosenFsmName = eventSetting._fsmName;
			
			var fsmIndex = fsmNames.IndexOf(eventSetting._fsmName);
			var newFsmIndex = EditorGUILayout.Popup("FSM Name", fsmIndex, fsmNames.ToArray());
			if (newFsmIndex < 0) {
				DTInspectorUtility.ShowRedErrorBox("Could not find FSM Name '" + eventSetting._fsmName + "'.");
			} else {
				chosenFsmName = fsmNames[newFsmIndex];
				
				if (newFsmIndex != fsmIndex) {
					UndoHelper.RecordObjectPropertyForUndo(ref isDirty, listener, "change FSM Name");
					eventSetting._fsmName = chosenFsmName;
					eventSetting._fsmEventName = CGKPlaymakerUtility.NO_FSM_NAME;
				}
				if (eventSetting._fsmName == CGKPlaymakerUtility.NO_FSM_NAME) {
					DTInspectorUtility.ShowRedErrorBox("You have not selected an FSM Name. This event will not communicate with Playmaker.");
				}
				 
				var fsmEvents = fsmEventsByFsm[chosenFsmName]._fsmEvents;
			
				if (newFsmIndex != 0) {
					var eventIndex = fsmEvents.IndexOf(eventSetting._fsmEventName);
			
					var newEventIndex = EditorGUILayout.Popup("FSM Event Name", eventIndex, fsmEvents.ToArray());
					if (newEventIndex < 0) {
						DTInspectorUtility.ShowRedErrorBox("Could not find FSM Event '" + eventSetting._fsmEventName + "'.");
					} else {
						var chosenFsmEvent = fsmEvents[newEventIndex];
						if (newEventIndex != eventIndex) {
							UndoHelper.RecordObjectPropertyForUndo(ref isDirty,listener, "change FSM Event Name");
							eventSetting._fsmEventName = chosenFsmEvent;
						}
						if (eventSetting._fsmEventName == CGKPlaymakerUtility.NO_FSM_NAME) {
							DTInspectorUtility.ShowRedErrorBox("You have not selected an FSM Event Name. This event will not communicate with Playmaker.");
						}
					}
				}
			}
		}
		
		EditorGUILayout.EndToggleGroup();
	}

}
