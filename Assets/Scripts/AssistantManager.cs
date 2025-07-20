using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections; // Required for Coroutines

public class AssistantManager : MonoBehaviour
{
    [Header("UI and Managers")]
    public TextMeshProUGUI instructionText;
    public SaveManager saveManager;
    public XRInteractionManager interactionManager;

    [Header("Puzzle Objects")]
    public GameObject blueSphereParent;
    public GameObject redSphereParent;
    public XRSocketInteractor blueSocket;
    public XRSocketInteractor redSocket;

    private XRGrabInteractable blueSphereInteractable;
    private XRGrabInteractable redSphereInteractable;
    private SessionData sessionData = new SessionData();
    private Vector3 blueSphereInitialPos;
    private Quaternion blueSphereInitialRot;
    private Vector3 redSphereInitialPos;
    private Quaternion redSphereInitialRot;

    void Start()
    {
        blueSphereInteractable = blueSphereParent.GetComponent<XRGrabInteractable>();
        redSphereInteractable = redSphereParent.GetComponent<XRGrabInteractable>();

        blueSphereInitialPos = blueSphereParent.transform.position;
        blueSphereInitialRot = blueSphereParent.transform.rotation;
        redSphereInitialPos = redSphereParent.transform.position;
        redSphereInitialRot = redSphereParent.transform.rotation;

        LoadState();
    }

    public void BlueSpherePlaced() { sessionData.isBlueSpherePlaced = true; CheckPuzzleCompletion(); }
    public void RedSpherePlaced() { sessionData.isRedSpherePlaced = true; CheckPuzzleCompletion(); }

    public void SaveState()
    {
        sessionData.blueSpherePosition = blueSphereParent.transform.position;
        sessionData.blueSphereRotation = blueSphereParent.transform.rotation;
        sessionData.redSpherePosition = redSphereParent.transform.position;
        sessionData.redSphereRotation = redSphereParent.transform.rotation;
        saveManager.SaveSession(sessionData);
    }

    public void LoadState()
    {
        // Don't do anything if a reset is already in progress
        StopAllCoroutines();
        StartCoroutine(ResetSceneState(true));
    }

    public void ResetSession()
    {
        // Don't do anything if a reset is already in progress
        StopAllCoroutines();
        StartCoroutine(ResetSceneState(false));
    }

    private IEnumerator ResetSceneState(bool shouldLoad)
    {
        // 1. Disable the sockets so they can't re-grab the spheres
        blueSocket.enabled = false;
        redSocket.enabled = false;

        // 2. Force the manager to release the spheres from the sockets
        interactionManager.CancelInteractableSelection((IXRSelectInteractable)blueSphereInteractable);
        interactionManager.CancelInteractableSelection((IXRSelectInteractable)redSphereInteractable);

        // 3. Wait for the end of the frame to let the system update
        yield return new WaitForEndOfFrame();

        // 4. Load data or create a new session
        if (shouldLoad)
        {
            SessionData loadedData = saveManager.LoadSession();
            sessionData = loadedData ?? new SessionData(); // Use loaded data or create new if null
        }
        else
        {
            saveManager.DeleteSaveFile();
            sessionData = new SessionData();
        }
        
        // 5. Apply the positions
        blueSphereParent.transform.position = sessionData.isBlueSpherePlaced ? blueSocket.attachTransform.position : blueSphereInitialPos;
        blueSphereParent.transform.rotation = sessionData.isBlueSpherePlaced ? blueSocket.attachTransform.rotation : blueSphereInitialRot;
        redSphereParent.transform.position = sessionData.isRedSpherePlaced ? redSocket.attachTransform.position : redSphereInitialPos;
        redSphereParent.transform.rotation = sessionData.isRedSpherePlaced ? redSocket.attachTransform.rotation : redSphereInitialRot;

        ResetSpherePhysics(blueSphereParent);
        ResetSpherePhysics(redSphereParent);
        CheckPuzzleCompletion();

        // 6. Re-enable the sockets for future interactions
        blueSocket.enabled = true;
        redSocket.enabled = true;
    }
    
    private void ResetSpherePhysics(GameObject sphereParent)
    {
        Rigidbody rb = sphereParent.GetComponentInChildren<Rigidbody>();
        if (rb != null && !rb.isKinematic)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void CheckPuzzleCompletion()
    {
        if (sessionData.isBlueSpherePlaced && sessionData.isRedSpherePlaced) { instructionText.text = "Analysis complete. Well done, Researcher!"; }
        else if (sessionData.isBlueSpherePlaced) { instructionText.text = "Blue specimen analysis complete. Please place the red specimen."; }
        else if (sessionData.isRedSpherePlaced) { instructionText.text = "Red specimen analysis complete. Please place the blue specimen."; }
        else { instructionText.text = "Welcome, Researcher. Please place the blue and red specimens in their corresponding analysis sockets."; }
    }
}