using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;

    [SerializeField] bool _spawnInTime = true;
    float _timeSpent;
	int _counter;
	private void FixedUpdate()
	{
		if (GameManager.Single.GameActive)
		{
			if (_spawnInTime)
			{
				_timeSpent += Time.deltaTime;
				if (_timeSpent > GameManager.Single.Interval)
				{
					_timeSpent = 0;

					Spawn();
				}
			}
		}
	}

	private void Spawn()
	{
		if (_counter > 15) return;

		var newGO = Instantiate(prefabs[Random.Range(0, prefabs.Length)], SetPosition(), Quaternion.identity);
		newGO.transform.SetParent(transform, true);
		_counter++;
	}

	public void CounterSubtract()
	{
		_counter--;
		if (_counter < 0) _counter = 0;
	}

	private Vector3 SetPosition()
	{
		return new Vector3(Random.Range(-GameManager.Single.RightUpperCorner.x + 1, GameManager.Single.RightUpperCorner.x - 1), Random.value > 0.5f ? -GameManager.Single.RightUpperCorner.y - 1 : GameManager.Single.RightUpperCorner.y + 1, 0);
	}
}
