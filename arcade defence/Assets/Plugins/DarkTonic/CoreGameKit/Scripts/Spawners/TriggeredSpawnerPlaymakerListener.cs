using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.CoreGameKit;

[AddComponentMenu("Dark Tonic/Core GameKit/Listeners/Triggered Spawner Playmaker Listener")]
[RequireComponent(typeof(PlayMakerFSM))]
public class TriggeredSpawnerPlaymakerListener : TriggeredSpawnerListener {
	public CGKPlaymakerUtility.PlaymakerEventSetting eventPropagatingSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting propagatedEventReceivedSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting waveEndedEarlySetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting propagatedWaveEndedEarlySetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting itemFailedToSpawnSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting itemSpawnedSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting waveFinishedSpawningSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting waveStartSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting waveRepeatSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting spawnerDespawningSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting customEventReceivedSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	
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
	
	public override void EventPropagating(TriggeredSpawner.EventType eType, Transform transmitterTrans, int receiverSpawnerCount) {
		CGKPlaymakerUtility.SendEventIfValid(eventPropagatingSetting, EventsByFsmName);
	}
	
	public override void PropagatedEventReceived(TriggeredSpawner.EventType eType, Transform transmitterTrans) {
		CGKPlaymakerUtility.SendEventIfValid(propagatedEventReceivedSetting, EventsByFsmName);
	}

    public override void WaveEndedEarly(TriggeredSpawner.EventType eType) {
        CGKPlaymakerUtility.SendEventIfValid(waveEndedEarlySetting, EventsByFsmName);
    }
	
    public override void PropagatedWaveEndedEarly(TriggeredSpawner.EventType eType, string customEventName, Transform transmitterTrans, int receiverSpawnerCount) {
        CGKPlaymakerUtility.SendEventIfValid(propagatedWaveEndedEarlySetting, EventsByFsmName);
    }
	
	public override void ItemFailedToSpawn(TriggeredSpawner.EventType eType, Transform failedPrefabTrans) {
		CGKPlaymakerUtility.SendEventIfValid(itemFailedToSpawnSetting, EventsByFsmName);
	}

	public override void ItemSpawned(TriggeredSpawner.EventType eType, Transform spawnedTrans) {
		CGKPlaymakerUtility.SendEventIfValid(itemSpawnedSetting, EventsByFsmName);
	}
	
	public override void WaveFinishedSpawning(TriggeredSpawner.EventType eType, TriggeredWaveSpecifics spec) {
		CGKPlaymakerUtility.SendEventIfValid(waveFinishedSpawningSetting, EventsByFsmName);
	}
	
	public override void WaveStart(TriggeredSpawner.EventType eType, TriggeredWaveSpecifics spec) {
		CGKPlaymakerUtility.SendEventIfValid(waveStartSetting, EventsByFsmName);
	}
	
	public override void WaveRepeat(TriggeredSpawner.EventType eType, TriggeredWaveSpecifics spec) {
		CGKPlaymakerUtility.SendEventIfValid(waveRepeatSetting, EventsByFsmName);
	}
	
	public override void SpawnerDespawning(Transform transDespawning) {
		CGKPlaymakerUtility.SendEventIfValid(spawnerDespawningSetting, EventsByFsmName);
	}
	
	public override void CustomEventReceived(string customEventName, Vector3 eventOrigin) {
		CGKPlaymakerUtility.SendEventIfValid(customEventReceivedSetting, EventsByFsmName);
	}
}
