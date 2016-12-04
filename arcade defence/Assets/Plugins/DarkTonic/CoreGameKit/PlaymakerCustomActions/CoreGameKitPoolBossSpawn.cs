using DarkTonic.CoreGameKit;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.ScriptControl)]
[Tooltip("Spawn one item from Pool Boss in Core GameKit")]
public class CoreGameKitPoolBossSpawn : FsmStateAction {

	[RequiredField]
    [Tooltip("Prefab To Spawn")]
	public WaveSpecifics.SpawnOrigin prefabSource = WaveSpecifics.SpawnOrigin.Specific;

	public FsmGameObject prefabToSpawn = new FsmGameObject();
	
	[Tooltip("Drag your prefab pool here, or type the name below if this game object is not in the Scene.")]
	public WavePrefabPool prefabPoolByRef;

	[Tooltip("Type the prefab pool name here, only if this game object is not in the Scene, otherwise use the field above.")]
	public string prefabPoolByName;

	public LevelSettings.SpawnPositionMode spawnPositionMode = LevelSettings.SpawnPositionMode.UseVector3;

	public FsmVector3 spawnLocation = new FsmVector3(Vector3.zero);

	public FsmGameObject otherObjectForPosition = new FsmGameObject();

	[Tooltip("Choose 'Custom Euler' to enter a rotation. Spawner Rotation will use this Game Object's rotation.")]
	public LevelSettings.RotationType rotationType = LevelSettings.RotationType.Identity;
	
	[Tooltip("Only used when 'Custom Euler' is chosen above for Rotation Type")] 
	public FsmVector3 eulerRotation = new FsmVector3(Vector3.zero);
	
	[Tooltip("The Game Object to parent the spawned object under (optional)")]
	public FsmGameObject parentGameObject = new FsmGameObject();
	
	[Tooltip("The variable to store the spawned object in.")]
	public FsmGameObject spawnedGameObject = new FsmGameObject();

	public override void OnEnter() {
		SpawnOne();
		
		Finish();
	}

	private void SpawnOne() {
		Transform prefab = null;

		switch (prefabSource) {
			case WaveSpecifics.SpawnOrigin.Specific:
				if (prefabToSpawn.Value == null) {
					Debug.LogError("No prefab to spawn has been assigned in FSM in Game Object '" + this.Owner.transform.name + "'.");
					return;
				}
				
				prefab = prefabToSpawn.Value.transform;
				break;
			case WaveSpecifics.SpawnOrigin.PrefabPool:
				if (prefabPoolByRef != null) {
					// ok
				} else if (!string.IsNullOrEmpty(prefabPoolByName)) {
					prefabPoolByRef = LevelSettings.GetFirstMatchingPrefabPool(prefabPoolByName);
					if (prefabPoolByRef == null) {
						Debug.LogError("Prefab pool '" + prefabPoolByName + "' not found.");
						return;
					}
				} else {
					Debug.LogError("No prefab pool specified. Either use Prefab Pool By Ref or Prefab Pool By Name.");	
					return;
				}
			
				prefab = prefabPoolByRef.GetRandomWeightedTransform();			
				
				break;
		}

		Quaternion spawnQuat = Quaternion.identity;
		if (rotationType == LevelSettings.RotationType.CustomEuler) {
			spawnQuat = Quaternion.Euler(eulerRotation.Value);
		} else if (rotationType == LevelSettings.RotationType.SpawnerRotation) {
			spawnQuat = this.Owner.transform.rotation;
		}

		Vector3 spawnPos = Vector3.zero;

		switch (spawnPositionMode) {
			case LevelSettings.SpawnPositionMode.UseVector3:
				spawnPos = spawnLocation.Value;
				break;
			case LevelSettings.SpawnPositionMode.UseThisObjectPosition:
				spawnPos = this.Owner.transform.position;
				break;
			case LevelSettings.SpawnPositionMode.UseOtherObjectPosition:
				if (this.otherObjectForPosition.Value == null) {
					Debug.LogError("No game object specified for 'Other Object For Position'");
					return;	
				}
				
				spawnPos = this.otherObjectForPosition.Value.transform.position;
				break;
		}

		var spawned = PoolBoss.SpawnInPool(prefab, spawnPos, spawnQuat);
		if (spawned == null) {
			Debug.LogError("Could not spawn: " + prefabToSpawn.Value.name);
			return;
		}
		
		if (parentGameObject.Value != null) {
			spawned.parent = parentGameObject.Value.transform;
		}
		
		spawnedGameObject.Value = spawned.gameObject;
	}
	
	public override void Reset() {
		prefabToSpawn = new FsmGameObject();
		spawnLocation = new FsmVector3(Vector3.zero);
		eulerRotation = new FsmVector3(Vector3.zero);
		spawnedGameObject = new FsmGameObject();
		otherObjectForPosition = new FsmGameObject();
		spawnPositionMode = LevelSettings.SpawnPositionMode.UseVector3;
		prefabSource = WaveSpecifics.SpawnOrigin.Specific;
		parentGameObject = new FsmGameObject();
		prefabPoolByRef = null;
	}
}
