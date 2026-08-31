using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public PlayerMovement playerMovementScript;
    private TMP_Text display;

    private Vector3 startPos;

    void Awake()
    {
        display = GetComponent<TMP_Text>();
        startPos = playerMovementScript.getStartPos();
    }

    // Update is called once per frame
    void Update()
    {
        display.text = (playerMovementScript.getPos().z - startPos.z).ToString("0");
    }
}
