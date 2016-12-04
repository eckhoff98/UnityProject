using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.CoreGameKit;
using HutongGames;

[AddComponentMenu("Dark Tonic/Core GameKit/Listeners/Timed Despawner Playmaker Listener")]
[RequireComponent(typeof(PlayMakerFSM))]
public class TimedDespawnerPlaymakerListener : TimedDespawnerListener {
	public CGKPlaymakerUtility.PlaymakerEventSetting despawningSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	
	private Dictionary<string, CGKPlaymakerUtility.PlaymakerFsmWithEvents> fsmEventsMap = null;

	public override void Despawning(Transform transDespawning) {
		CGKPlaymakerUtility.SendEventIfValid(despawningSetting, EventsByFsmName);
	}
	
	// Lazy lookup and persistent
	private Dictionary<string, CGKPlaymakerUtility.PlaymakerFsmWithEvents> EventsByFsmName {
		get {
			if (fsmEventsMap == null) {
				fsmEventsMap = CGKPlaymakerUtility.GetEventListByFSM(this);
			}
			
			return fsmEventsMap;
		}
	}
}
