using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickListener : MonoBehaviour
{
	[SerializeField] float _upperBoard;
	[SerializeField] float _lowerBoard;
	[SerializeField] SpriteRenderer _targetBox;
	private TargetMotion _target;

	Spawner _spawner;
    private void Start()
    {
        _spawner = FindObjectOfType<Spawner>();
    }
    private void Update()
	{
		if (GameManager.Single.GameActive)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Vector2 mousePos = GameManager.Single.MainCamera.ScreenToWorldPoint(Input.mousePosition);

				Collider2D col = Physics2D.OverlapCircle(mousePos, 0.2f);
				if (col)
				{
					if (col.CompareTag("Target"))
					{
						if (col.transform.position.y <= _upperBoard && col.transform.position.y >= _lowerBoard)
						{
							GameManager.Single.Score++;
						}
						else
						{
							GameManager.Single.Lives--;
						}

                        if (!_target) _target = col.GetComponent<TargetMotion>();
						_target.NewPos();
                    }
				}
			}
		}
	}

    private void FixedUpdate()
    {
        float currentY = _targetBox.transform.position.y;
        float size = _targetBox.bounds.size.y * 0.5f;
        _upperBoard = currentY + size;
        _lowerBoard = currentY - size;
    }
}
