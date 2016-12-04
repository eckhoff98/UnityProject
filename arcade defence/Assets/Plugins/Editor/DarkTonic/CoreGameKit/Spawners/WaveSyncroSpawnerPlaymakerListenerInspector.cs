using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DarkTonic.CoreGameKit;

[CustomEditor(typeof(WaveSyncroSpawnerPlaymakerListener))]
public class WaveSyncroSpawnerPlaymakerListenerInspector : Editor {
	private WaveSyncroSpawnerPlaymakerListener listener;
	private Dictionary<string, CGKPlaymakerUtility.PlaymakerFsmWithEvents> fsmEventsByFsm;
	
	public override void OnInspectorGUI() {
		EditorGUI.indentLevel = 0;
		
		listener = (WaveSyncroSpawnerPlaymakerListener)target;

		WorldVariableTracker.ClearInGamePlayerStats();
		
        DTInspectorUtility.DrawTexture(CoreGameKitInspectorResources.LogoTexture);
		
		var isDirty = false;
		
		fsmEventsByFsm = CGKPlaymakerUtility.GetEventListByFSM(listener);
		
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.itemFailedToSpawnSetting, "Item Failed To Spawn", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.itemSpawnedSetting, "Item Spawned", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.waveFinishedSpawningSetting, "Wave Finished Spawning", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.waveStartSetting, "Wave Start", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.elimWaveCompleteSetting, "Elimination Wave Completed", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.waveRepeatSetting, "Wave Repeat", fsmEventsByFsm, listener);
		
		if (GUI.changed || isDirty) {
			EditorUtility.SetDirty(target);	// or it won't save the data!!
		}

		//DrawDefaultInspector();
    }
}
