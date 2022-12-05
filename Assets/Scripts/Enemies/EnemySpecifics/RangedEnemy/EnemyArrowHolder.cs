using UnityEngine;

public class EnemyArrowHolder : MonoBehaviour
{
    [SerializeField] private Transform enemy;

    private void Update()
    {
		if (enemy != null)
		{
        	transform.localScale = enemy.localScale;
		}
    }
}