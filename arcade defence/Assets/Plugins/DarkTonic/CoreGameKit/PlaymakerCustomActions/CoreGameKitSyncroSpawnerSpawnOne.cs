using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Spawn one item from a Syncro Spawner in Core GameKit")]
public class CoreGameKitSyncroSpawnerSpawnOne : FsmStateAction {
	private WaveSyncroPrefabSpawner spawner = null;

    [RequiredField]
	[CheckForComponent(typeof(WaveSyncroPrefabSpawner))]
    [Tooltip("Game Object holding Syncro Spawner")]
	public FsmOwnerDefault gameObject = new FsmOwnerDefault();
	
	[RequiredField]
	[Tooltip("The variable to store the Transform of the spawned item in.")]
	public FsmGameObject spawnedGameObject = new FsmGameObject();
	
    [Tooltip("Repeat every frame while the state is active.")]
    public bool everyFrame;
	
	public override void OnEnter() {
		SpawnOne();
		
		if (!everyFrame) {
			Finish();
		}
	}

	public override void OnUpdate() {
		SpawnOne();
	}
	
	private void SpawnOne() {
		if (this.spawner == null) {
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			this.spawner = go.GetComponent<WaveSyncroPrefabSpawner>();
		}
		
		// spawn one!
		var spawned = this.spawner.SpawnOneItem();
		spawnedGameObject = spawned == null ? null : spawned.gameObject;
	}
	
	public override void Reset() {
		gameObject = new FsmOwnerDefault();
		spawnedGameObject = new FsmGameObject();
	}
}
