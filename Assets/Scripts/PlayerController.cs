using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] GameObject centerOfMass;
	[SerializeField] WheelCollider[] wheelColliders;
	[SerializeField] Transform[] wheels;
    private Rigidbody playerRb;
	private float torque = 60f;
	private float angle = 25f;
	private CheckpointController checkpointController;
	private CameraController cameraController;
	private bool isPlaying = false;

	private void Start()
	{
		playerRb = GetComponent<Rigidbody>();
		checkpointController = GetComponent<CheckpointController>();
		cameraController = GameObject.Find("FocalPoint").GetComponent<CameraController>();

		playerRb.centerOfMass = centerOfMass.transform.localPosition;
		GameObject.Find("GameManager").GetComponent<GameManager>().GameStarted += StartGame;
		
	}

	private void Update()
	{
		Move();

		if (Input.GetKeyDown(KeyCode.R) && isPlaying)
		{
			checkpointController.RespawnPlayer();
		}
		if (Input.GetKeyDown(KeyCode.V) && isPlaying)
		{
			cameraController.ChangeCameraView();
		}
	}

	private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

		for(int i = 0; i<wheelColliders.Length; i++)
		{
			if (verticalInput > 0 && isPlaying)
			{
				wheelColliders[i].brakeTorque = 0f;
				wheelColliders[i].motorTorque = verticalInput * torque;
			}
			else if (verticalInput <= 0)
			{
				wheelColliders[i].brakeTorque = 200f;
			}

			if (i == 0 || i == 1)
			{
				wheelColliders[i].steerAngle = horizontalInput * angle;
				wheels[i].transform.localEulerAngles = Vector3.up * horizontalInput * angle;
			}

		}

    }

	private void StartGame()
	{
		isPlaying = true;
	}
}
