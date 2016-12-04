using UnityEngine;
using System;
using System.Collections.Generic;
using DarkTonic.CoreGameKit;

[AddComponentMenu("Dark Tonic/Core GameKit/Listeners/Level Settings Playmaker Listener")]
[RequireComponent(typeof(PlayMakerFSM))]
public class LevelSettingsPlaymakerListener : LevelSettingsListener {
	public CGKPlaymakerUtility.PlaymakerEventSetting levelEndedSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting waveItemsRemainingChangedSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting waveTimeRemainingChangedSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting winEventSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting loseEventSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting gameOverSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting waveStartedSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting waveEndedSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting waveRestartedSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting waveCompleteBonusesStartSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting waveEndedEarlySetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	public CGKPlaymakerUtility.PlaymakerEventSetting waveSkippedSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	
	private Dictionary<string, CGKPlaymakerUtility.PlaymakerFsmWithEvents> fsmEventsMap = null;

	public override void LevelEnded(int levelNum) {
		CGKPlaymakerUtility.SendEventIfValid(levelEndedSetting, EventsByFsmName);
	}

	public override void WaveItemsRemainingChanged(int waveItemsRemaining) {
		CGKPlaymakerUtility.SendEventIfValid(waveItemsRemainingChangedSetting, EventsByFsmName);
	}
	
	public override void WaveTimeRemainingChanged(int secondsRemaining) {
		CGKPlaymakerUtility.SendEventIfValid(waveTimeRemainingChangedSetting, EventsByFsmName);
	}
	
	public override void Win() {
		CGKPlaymakerUtility.SendEventIfValid(winEventSetting, EventsByFsmName);
	}
	
	public override void Lose() {
		CGKPlaymakerUtility.SendEventIfValid(loseEventSetting, EventsByFsmName);
	}
	
	public override void GameOver(bool hasWon) {
		CGKPlaymakerUtility.SendEventIfValid(gameOverSetting, EventsByFsmName);
	}
	
	public override void WaveStarted(LevelWave levelWaveInfo) {
		CGKPlaymakerUtility.SendEventIfValid(waveStartedSetting, EventsByFsmName);
	}
	
	public override void WaveEnded(LevelWave levelWaveInfo) {
		CGKPlaymakerUtility.SendEventIfValid(waveEndedSetting, EventsByFsmName);
	}
	
	public override void WaveRestarted(LevelWave levelWaveInf) {
		CGKPlaymakerUtility.SendEventIfValid(waveRestartedSetting, EventsByFsmName);
	}
	
	public override void WaveCompleteBonusesStart(List<WorldVariableModifier> bonusModifiers) {
		CGKPlaymakerUtility.SendEventIfValid(waveCompleteBonusesStartSetting, EventsByFsmName);
	}
	
	public override void WaveEndedEarly(LevelWave levelWaveInfo) {
		CGKPlaymakerUtility.SendEventIfValid(waveEndedEarlySetting, EventsByFsmName);
	}
	 
	public override void WaveSkipped(LevelWave levelWaveInfo) {
		CGKPlaymakerUtility.SendEventIfValid(waveSkippedSetting, EventsByFsmName);
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