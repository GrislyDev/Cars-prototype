using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Vector3 firstViewPos;
	[SerializeField] private Vector3 thirdViewPos;
    private bool isFirstView = false;

	void LateUpdate()
    {
		transform.position = target.transform.position;

        if (isFirstView)
        {
            
            transform.rotation = Quaternion.Euler(target.transform.rotation.eulerAngles);
        }
        else
        {
			transform.rotation = Quaternion.Euler(new Vector3(0, target.transform.rotation.eulerAngles.y, 0));
		}
    }

    public void ChangeCameraView()
    {
		if (!isFirstView)
		{
			mainCamera.transform.localPosition = firstViewPos;
			isFirstView = true;
		}
		else if (isFirstView)
		{
			mainCamera.transform.localPosition = thirdViewPos;
			isFirstView = false;
		}
	}
}
