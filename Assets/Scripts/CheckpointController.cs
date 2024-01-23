using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointController : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI lapText;
	private Rigidbody playerRb;
	private GameObject lastTrackPos;
	private GameObject halfLap;
	private int lapCount = 1;
	private int laps = 3;

	private void Start()
	{
		playerRb = GetComponent<Rigidbody>();
		lastTrackPos = lastTrackPos = GameObject.FindWithTag("Checkpoint");
	}

	public void RespawnPlayer()
	{
		playerRb.velocity = Vector3.zero;
		transform.position = lastTrackPos.transform.position;
		transform.rotation = lastTrackPos.transform.rotation;
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.CompareTag("Checkpoint"))
		{
			lastTrackPos = collider.gameObject;
		}

		if (collider.gameObject.CompareTag("Scaner"))
		{
			RespawnPlayer();
		}

		if (collider.gameObject.CompareTag("Finish"))
		{
			if (halfLap != null)
			{
				lapCount++;
				if (lapCount <= laps)
				{
					lapText.text = $"Lap {lapCount.ToString()}/{laps}";
					halfLap = null;
				}
				else if (lapCount > laps)
				{
					SceneManager.LoadScene(0);
				}
			}
		}

		if (collider.gameObject.CompareTag("HalfLap"))
		{
			halfLap = collider.gameObject;
		}
	}
}
