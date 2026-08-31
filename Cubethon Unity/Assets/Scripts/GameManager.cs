using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public InputActionAsset InputActions;
    private InputAction moveAction;

    private PlayerMovement playerMovement;
    private PlayerCollision playerCollision;
    private ScoreDisplay scoreDisplay;

    private Vector3 startPos;
    private int score = 0;
    private int topScore = 0;

    private bool gameStopped = true;

    private void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        playerCollision = FindAnyObjectByType<PlayerCollision>();
        scoreDisplay = FindAnyObjectByType<ScoreDisplay>();

        moveAction = InputSystem.actions.FindAction("Move");

        playerMovement.enabled = false;
        startPos = playerMovement.getPos();
        setTitleScreen();
    }

    private void Update()
    {
        if (gameStopped) {
            // Starts the game (again) when the player inputs movement
            Vector2 movementInput = moveAction.ReadValue<Vector2>();
            if (movementInput.x != 0 || movementInput.y != 0) {
                gameStopped = false;
                playerMovement.enabled = true;
            }
        } else {
            int scoreCalc = Mathf.FloorToInt(playerMovement.getPos().z - startPos.z);
            if (scoreCalc != score) {
                score = scoreCalc;
                scoreDisplay.SetScore(score.ToString());
            }
        }
    }

    private void setTitleScreen() {
        scoreDisplay.SetScore($"Top Score: {topScore}\nMove to start");
    }

    public void EndGame() {
        if (!gameStopped) {
            gameStopped = true;
            playerMovement.enabled = false;
            this.enabled = false;

            if (score > topScore) {
                topScore = score;
            }

            Invoke("ResetGame", 2);
        }
    }

    private void ResetGame() {
        playerMovement.resetToPos(startPos);
        setTitleScreen();
        this.enabled = true;
    }
}
