using UnityEngine;

public class Sorting : MonoBehaviour
{

	[SerializeField] private int minSortingOrder;
	[SerializeField] private int maxSortingOrder;
	
	private void OnTriggerStay2D(Collider2D other)
	{
		if (!other.CompareTag("Player") && !other.CompareTag("Enemy")) return;
		
		if (transform.position.y >= other.transform.position.y) {
			GetComponent<SpriteRenderer>().sortingOrder = minSortingOrder;
		}

		if (transform.position.y < other.transform.position.y) {
			GetComponent<SpriteRenderer>().sortingOrder = maxSortingOrder;
		}
	}
}
