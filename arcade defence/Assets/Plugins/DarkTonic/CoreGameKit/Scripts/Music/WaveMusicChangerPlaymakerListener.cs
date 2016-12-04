using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.CoreGameKit;

[AddComponentMenu("Dark Tonic/Core GameKit/Listeners/Wave Music Changer Playmaker Listener")]
[RequireComponent(typeof(PlayMakerFSM))]
public class WaveMusicChangerPlaymakerListener : WaveMusicChangerListener {
	public CGKPlaymakerUtility.PlaymakerEventSetting musicChangingSetting = new CGKPlaymakerUtility.PlaymakerEventSetting();
	
	private Dictionary<string, CGKPlaymakerUtility.PlaymakerFsmWithEvents> fsmEventsMap = null;

	public override void MusicChanging(LevelWaveMusicSettings musicSettings) {
		CGKPlaymakerUtility.SendEventIfValid(musicChangingSetting, EventsByFsmName);
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
