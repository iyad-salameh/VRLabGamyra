using UnityEngine;

[System.Serializable]
public class SessionData
{
    // Puzzle state
    public bool isBlueSpherePlaced;
    public bool isRedSpherePlaced;

    // We will save the position of the PARENT objects
    public Vector3 blueSpherePosition;
    public Quaternion blueSphereRotation;
    public Vector3 redSpherePosition;
    public Quaternion redSphereRotation;
}