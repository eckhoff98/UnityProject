using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.CoreGameKit;

[AddComponentMenu("Dark Tonic/Core GameKit/Listeners/Killable Playmaker Listener")]
[RequireComponent(typeof(PlayMakerFSM))]
public class KillablePlaymakerListener : KillableListener {
	public CGKPlaymakerUtility.PlaymakerEventSetting spawnerDestroyedSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting despawningSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting takingDamageSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting damagePrefabSpawnedSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting damagePrefabFailedToSpawnSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting deathPrefabSpawnedSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting deathPrefabFailedToSpawnSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting destroyingKillableSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting determiningScenarioSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting modifyingDeathVars = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting modifyingDamageVars = new CGKPlaymakerUtility.PlaymakerEventSetting();
	
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
	
	public override void SpawnerDestroyed() {
		CGKPlaymakerUtility.SendEventIfValid(spawnerDestroyedSetting, EventsByFsmName);
	}
	
	public override void Despawning(TriggeredSpawner.EventType eType) {
		CGKPlaymakerUtility.SendEventIfValid(despawningSetting, EventsByFsmName);
	}
	
	public override void TakingDamage(int pointsDamage, Killable enemyHitBy) {
		CGKPlaymakerUtility.SendEventIfValid(takingDamageSetting, EventsByFsmName);
	}

	public override void DamagePrefabSpawned(Transform damagePrefab) {
		CGKPlaymakerUtility.SendEventIfValid(damagePrefabSpawnedSetting, EventsByFsmName);
	}
	
	public override void DamagePrefabFailedToSpawn(Transform damagePrefab) {
		CGKPlaymakerUtility.SendEventIfValid(damagePrefabFailedToSpawnSetting, EventsByFsmName);
	}
	
	public override void DeathPrefabSpawned(Transform deathPrefab) {
		CGKPlaymakerUtility.SendEventIfValid(deathPrefabSpawnedSetting, EventsByFsmName);
	}
	
	public override void DeathPrefabFailedToSpawn(Transform deathPrefab) {
		CGKPlaymakerUtility.SendEventIfValid(deathPrefabFailedToSpawnSetting, EventsByFsmName);
	}

	public override void ModifyingDeathWorldVariables(List<WorldVariableModifier> variableModifiers) {
		CGKPlaymakerUtility.SendEventIfValid(modifyingDeathVars, EventsByFsmName);
	}

	public override void ModifyingDamageWorldVariables(List<WorldVariableModifier> variableModifiers) {
		CGKPlaymakerUtility.SendEventIfValid(modifyingDamageVars, EventsByFsmName);
	}
	
	public override void DestroyingKillable(Killable deadKillable) {
		CGKPlaymakerUtility.SendEventIfValid(destroyingKillableSetting, EventsByFsmName);
	}
	
	public override string DeterminingScenario(Killable deadKillable, string scenario) {
		CGKPlaymakerUtility.SendEventIfValid(determiningScenarioSetting, EventsByFsmName);
		
		return scenario; 
	}
}
