using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DarkTonic.CoreGameKit;

[CustomEditor(typeof(TimedDespawnerPlaymakerListener))]
public class TimedDespawnerPlaymakerListenerInspector : Editor {
	private TimedDespawnerPlaymakerListener listener;
	private Dictionary<string, CGKPlaymakerUtility.PlaymakerFsmWithEvents> fsmEventsByFsm;
	
	public override void OnInspectorGUI() {
		EditorGUI.indentLevel = 0;
		
		listener = (TimedDespawnerPlaymakerListener)target;

		WorldVariableTracker.ClearInGamePlayerStats();
		
        DTInspectorUtility.DrawTexture(CoreGameKitInspectorResources.LogoTexture);
		
		var isDirty = false;
		
		fsmEventsByFsm = CGKPlaymakerUtility.GetEventListByFSM(listener);
		
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.despawningSetting, "Despawning", fsmEventsByFsm, listener);
		
		if (GUI.changed || isDirty) {
			EditorUtility.SetDirty(target);	// or it won't save the data!!
		}

		//this.Repaint();

		//DrawDefaultInspector();
    }
}