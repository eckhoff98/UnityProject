using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.CoreGameKit;

[AddComponentMenu("Dark Tonic/Core GameKit/Listeners/Prefab Pool Playmaker Listener")]
[RequireComponent(typeof(PlayMakerFSM))]
public class WavePrefabPoolPlaymakerListener : WavePrefabPoolListener {
	public CGKPlaymakerUtility.PlaymakerEventSetting prefabGrabbedFromPoolSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting poolRefillingSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	
	private Dictionary<string, CGKPlaymakerUtility.PlaymakerFsmWithEvents> fsmEventsMap = null;
	
	public override void PrefabGrabbedFromPool(Transform transGrabbed) {
		CGKPlaymakerUtility.SendEventIfValid(prefabGrabbedFromPoolSetting, EventsByFsmName);
	}
	
	public override void PoolRefilling() {
		CGKPlaymakerUtility.SendEventIfValid(poolRefillingSetting, EventsByFsmName);
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
