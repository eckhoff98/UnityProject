using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.CoreGameKit;

[AddComponentMenu("Dark Tonic/Core GameKit/Listeners/Syncro Spawner Playmaker Listener")]
[RequireComponent(typeof(PlayMakerFSM))]
public class WaveSyncroSpawnerPlaymakerListener : WaveSyncroSpawnerListener {
	public CGKPlaymakerUtility.PlaymakerEventSetting itemFailedToSpawnSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting itemSpawnedSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting waveFinishedSpawningSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting waveStartSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting waveRepeatSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting elimWaveCompleteSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	
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
	
	public override void ItemFailedToSpawn(Transform failedPrefabTrans) {
		CGKPlaymakerUtility.SendEventIfValid(itemFailedToSpawnSetting, EventsByFsmName);
	}

	public override void ItemSpawned(Transform spawnedTrans) {
		CGKPlaymakerUtility.SendEventIfValid(itemSpawnedSetting, EventsByFsmName);
	}
	
	public override void WaveFinishedSpawning(WaveSpecifics spec) {
		CGKPlaymakerUtility.SendEventIfValid(waveFinishedSpawningSetting, EventsByFsmName);
	}
	
	public override void WaveStart(WaveSpecifics spec) {
		CGKPlaymakerUtility.SendEventIfValid(waveStartSetting, EventsByFsmName);
	}

    public override void EliminationWaveCompleted(WaveSpecifics spec) { // called at the end of each wave, whether or not it is repeating. This is called before the Repeat delay
        CGKPlaymakerUtility.SendEventIfValid(elimWaveCompleteSetting, EventsByFsmName);
    }
	
	public override void WaveRepeat(WaveSpecifics spec) {
		CGKPlaymakerUtility.SendEventIfValid(waveRepeatSetting, EventsByFsmName);
	}
}
