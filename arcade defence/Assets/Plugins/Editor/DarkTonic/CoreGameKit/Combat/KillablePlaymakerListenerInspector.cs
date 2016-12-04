using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DarkTonic.CoreGameKit;

[CustomEditor(typeof(KillablePlaymakerListener))]
public class KillablePlaymakerListenerInspector : Editor {
	private KillablePlaymakerListener listener;
	private Dictionary<string, CGKPlaymakerUtility.PlaymakerFsmWithEvents> fsmEventsByFsm;
	
	public override void OnInspectorGUI() {
        EditorGUIUtility.LookLikeControls();
		EditorGUI.indentLevel = 0;
		
		listener = (KillablePlaymakerListener)target;

		WorldVariableTracker.ClearInGamePlayerStats();
		
        DTInspectorUtility.DrawTexture(CoreGameKitInspectorResources.LogoTexture);
		
		var isDirty = false;
		
		fsmEventsByFsm = CGKPlaymakerUtility.GetEventListByFSM(listener);
		
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.spawnerDestroyedSetting, "Spawner Destroyed", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.despawningSetting, "Despawning", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.takingDamageSetting, "Taking Damage", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.damagePrefabSpawnedSetting, "Damage Prefab Spawned", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.damagePrefabFailedToSpawnSetting, "Damage Prefab Failed To Spawn", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.deathPrefabSpawnedSetting, "Death Prefab Spawned", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.deathPrefabFailedToSpawnSetting, "Death Prefab Failed To Spawn", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.destroyingKillableSetting, "Destroying Killable", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.determiningScenarioSetting, "Determining Scenario", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.modifyingDeathVars, "Modifying Death World Variables", fsmEventsByFsm, listener);
		DTPlaymakerUtility.RenderPlaymakerTransmitEvent(listener.modifyingDamageVars, "Modifying Damage World Variables", fsmEventsByFsm, listener);
		
		if (GUI.changed || isDirty) {
			EditorUtility.SetDirty(target);	// or it won't save the data!!
		}

		//this.Repaint();

		//DrawDefaultInspector();
    }
}
