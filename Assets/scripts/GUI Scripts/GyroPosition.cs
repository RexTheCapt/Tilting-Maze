using UnityEngine;

public class GyroPosition : MonoBehaviour
{
    private movePlayer mp;

    public GameObject PlayerGameObject;
    public float positionModifier = 0f;

    void Start()
    {
        mp = PlayerGameObject.GetComponent<movePlayer>();
    }

    void FixedUpdate()
    {
        transform.localPosition = new Vector3(mp.acc.x * positionModifier, mp.acc.y * positionModifier);
    }
}
