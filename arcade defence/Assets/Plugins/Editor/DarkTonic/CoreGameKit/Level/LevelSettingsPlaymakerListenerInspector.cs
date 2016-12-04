using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DarkTonic.CoreGameKit;

[CustomEditor(typeof(LevelSettingsPlaymakerListener))]
public class LevelSettingsPlaymakerListenerInspector : Editor {
	private LevelSettingsPlaymakerListener listener;
	private Dictionary<string, CGKPlaymakerUtility.PlaymakerFsmWithEvents> fsmEventsByFsm;
	
	public override void OnInspectorGUI() {
		EditorGUI.indentLevel = 0;
		
		listener = (LevelSettingsPlaymakerListener)target;

		WorldVariableTracker.ClearInGamePlayerStats();
		 
        DTInspectorUtility.DrawTexture(CoreGameKitInspectorResources.LogoTexture);
		
		var isDirty = false;
		
		fsmEventsByFsm = CGKPlaymakerUtility.GetEventListByFSM(listener);
		
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.gameOverSetting, "Game Over", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.winEventSetting, "Win", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.loseEventSetting, "Lose", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.levelEndedSetting, "Level Ended", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.waveStartedSetting, "Wave Started", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.waveEndedSetting, "Wave Ended", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.waveRestartedSetting, "Wave Restarted", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.waveCompleteBonusesStartSetting, "Wave Completed Bonuses Start", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.waveEndedEarlySetting, "Wave Ended Early", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.waveSkippedSetting, "Wave Skipped", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.waveItemsRemainingChangedSetting, "Wave Items Remaining Changed", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.waveTimeRemainingChangedSetting, "Wave Time Remaining Changed", fsmEventsByFsm, listener);
		
		if (GUI.changed || isDirty) {
			EditorUtility.SetDirty(target);	// or it won't save the data!!
		}

		//DrawDefaultInspector();
    }
}
