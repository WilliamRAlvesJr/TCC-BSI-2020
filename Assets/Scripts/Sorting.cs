using UnityEngine;

public class Sorting : MonoBehaviour {

	private void OnTriggerStay2D(Collider2D other)
	{
		if (!other.CompareTag("Player") && !other.CompareTag("Enemy")) return;
		
		if (transform.position.y >= other.transform.position.y) {
			GetComponent<SpriteRenderer>().sortingOrder = 1;
		}

		if (transform.position.y < other.transform.position.y) {
			GetComponent<SpriteRenderer>().sortingOrder = 3;
		}
	}
}
