using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
	[Header("Room Size")]
	public Grid coordGrid;
	public Vector3Int TLCorner;
	public Vector2Int size;

	[Header("Game Data")]
	public roomState state = roomState.unvisited;
	public List<EnemyBehaviour> enemies = new List<EnemyBehaviour>();
	public Door[] doors;

	// Private data
	private BoxCollider2D localBC;
	private ScoreSystem scoreSystem;
	
	void Start() {
		// References
		localBC = gameObject.GetComponent<BoxCollider2D>();
		scoreSystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreSystem>();
		
		// Collider shape
		Vector3 TLCornerWorld = coordGrid.CellToWorld(new Vector3Int(TLCorner.x, TLCorner.y + 1, 0));
		CalculateCollider(TLCornerWorld, size, localBC);

		// Find the contained enemies, add them to the enemies list and notify them of their room
		float midX = TLCornerWorld.x + (size.x / 2);
		float midY = TLCornerWorld.y - (size.y / 2);
	 	Collider2D[] containedColliders = Physics2D.OverlapBoxAll(new Vector2(midX, midY), size, 0);

		foreach(Collider2D collider in containedColliders) {
			if (collider.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemy)) {
				enemies.Add(enemy);
				enemy.memberOfRoom = this;
			}
		}
	}

	void CalculateCollider(Vector3 boxTLCorner, Vector2 boxSize, BoxCollider2D collider) {	
		float midX = boxTLCorner.x + (boxSize.x / 2);
		float midY = boxTLCorner.y - (boxSize.y / 2);
		Vector3 centerPoint = new Vector3(midX, midY, 0);

		Vector2 boxOffset = centerPoint - gameObject.transform.position;

		collider.offset = boxOffset;
		collider.size = boxSize;
	}

	void RoomClearCheck(bool shouldReward) {
		if (enemies.Count == 0) {
			state = roomState.cleared;
			
			foreach(Door door in doors) {
				door.OpenClose(true);
			}

			if (shouldReward) {
				scoreSystem.RewardPlayer(ScoreSystem.pointReasons.roomCleared);
			}
		}		
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("Player")) {
			// Visiting an unvisited room marks it as entered and initializes it
			if (state == roomState.unvisited) {
				state = roomState.entered;

				foreach(EnemyBehaviour enemy in enemies) {
					enemy.isActive = true;
				}
				foreach(Door door in doors) {
					door.OpenClose(false);
				}

				// Check if room is clear as there might be no enemies from the start
				RoomClearCheck(false);
			}	
		}
	}

	public void RemoveEnemy(EnemyBehaviour enemy) {
		enemies.Remove(enemy);

		RoomClearCheck(true);
	}
}

public enum roomState {
	unvisited,
	entered,
	cleared,
}