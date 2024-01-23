using UnityEngine;

public class CarSounds : MonoBehaviour
{
	[SerializeField] private float minSpeed;
	[SerializeField] private float pitch;

	private Rigidbody carRb;
	private AudioSource carAudioSource;
	private float currentSpeed;
	private float pitchFromCar;


	private void Start()
	{
		carRb = GetComponent<Rigidbody>();
		carAudioSource = GetComponent<AudioSource>();
	}

	private void Update()
	{
		EngineSound();
	}

	private void EngineSound()
	{
		currentSpeed = carRb.velocity.magnitude;
		pitchFromCar = carRb.velocity.magnitude / 50f;

		if (currentSpeed < minSpeed)
		{
			carAudioSource.pitch = pitch;
		}
		else if (currentSpeed > minSpeed)
		{
			carAudioSource.pitch = pitch + Mathf.Log(10f, pitchFromCar);
		}
	}
}
