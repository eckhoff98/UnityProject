using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class CGKPlaymakerUtility {
	public const string NO_FSM_NAME = "[NONE]";
	
	[Serializable]
	public class PlaymakerEventSetting {
		public bool useSetting = false;
		public string _fsmName = NO_FSM_NAME;
		public string _fsmEventName = NO_FSM_NAME;
	}
	
	public struct PlaymakerFsmWithEvents {
		public PlayMakerFSM _fsm;
		public List<string> _fsmEvents;
		
		public PlaymakerFsmWithEvents(PlayMakerFSM fsm, List<string> fsmEvents) {
			_fsm = fsm;
			_fsmEvents = fsmEvents;
		}
	}
	
	public static Dictionary<string, PlaymakerFsmWithEvents> GetEventListByFSM(MonoBehaviour behavior) {
		var fsms = behavior.GetComponents<PlayMakerFSM>();
		
		var eventList = new Dictionary<string, PlaymakerFsmWithEvents>(); 
		eventList.Add(NO_FSM_NAME, new PlaymakerFsmWithEvents(null, null));
		
		for (var i = 0; i < fsms.Length; i++) {
			var anFsm = fsms[i];

			var events = new List<string>();
			events.Add(NO_FSM_NAME);
			
			for (var e = 0; e < anFsm.FsmEvents.Length; e++) {
				events.Add(anFsm.FsmEvents[e].Name);
			}
			 
			eventList.Add(anFsm.FsmName, new PlaymakerFsmWithEvents(anFsm, events));
		}
		
		return eventList;
	}
	
	public static void SendEventIfValid(CGKPlaymakerUtility.PlaymakerEventSetting eventSetting, Dictionary<string, CGKPlaymakerUtility.PlaymakerFsmWithEvents> eventsByFsmName) {
		if (!eventSetting.useSetting) {
			return;
		}
		
		var fsmName = eventSetting._fsmName;
		var fsmEventName = eventSetting._fsmEventName;
		
		if (fsmName == NO_FSM_NAME) {
			return;
		}

		if (fsmEventName == NO_FSM_NAME) {
			return;
		}
		
		if (!eventsByFsmName.ContainsKey(fsmName)) {
			return;
		}
		
		var fsmWithEvents = eventsByFsmName[fsmName];
		
		if (fsmWithEvents._fsmEvents.IndexOf(fsmEventName) < 0) {
			return;
		}
		
		fsmWithEvents._fsm.SendEvent(fsmEventName);
	}

}
