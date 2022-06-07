using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PuzzleState
{
    IDLE,
    NOT_IDLE,
    CORRECT1,
    CORRECT2,
    CORRECT3,
    CORRECT4,
    INCORRECT
}

public class PuzzleNo1 : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject doors;
    public GameObject companionCube;

    private float counter = 0f;

    [SerializeField]
    private PuzzleState state = PuzzleState.IDLE;
    [SerializeField]
    private bool returnToSquareZero = false;
    [SerializeField]
    private ButtonState correct1;
    [SerializeField]
    private ButtonState correct2;
    [SerializeField]
    private ButtonState correct3;
    [SerializeField]
    private ButtonState correct4;
    [SerializeField]
    private Material material1;
    [SerializeField]
    private Material material2;
    [SerializeField]
    private Material material3;
    [SerializeField]
    private Material material4;

    private void Awake()
    {
        correct1 = buttons[0].GetComponent<ButtonState>();
        correct2 = buttons[1].GetComponent<ButtonState>();
        correct3 = buttons[2].GetComponent<ButtonState>();
        correct4 = buttons[3].GetComponent<ButtonState>();

        material1 = buttons[0].GetComponent<Renderer>().material;
        material2 = buttons[1].GetComponent<Renderer>().material;
        material3 = buttons[2].GetComponent<Renderer>().material;
        material4 = buttons[3].GetComponent<Renderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == PuzzleState.INCORRECT)
        {
            FailedPuzzle();
        }

        if (returnToSquareZero && state != PuzzleState.INCORRECT)
        {
            material1.color = Color.white;
            material2.color = Color.white;
            material3.color = Color.white;
            material4.color = Color.white;
            returnToSquareZero = false;
        }

        if (correct1.activated || correct2.activated || correct3.activated || correct4.activated)
        {
            Debug.Log("Entro");
            state = PuzzleState.NOT_IDLE;
        }

        if(correct1.activated && !correct2.activated && !correct3.activated && !correct4.activated)
        {
            Debug.Log("1st");
            material1.color = Color.green;
            state = PuzzleState.CORRECT1;
            return;
        }
        else if (correct1.activated && correct2.activated && !correct3.activated && !correct4.activated)
        {
            Debug.Log("2nd");
            material2.color = Color.green;
            state = PuzzleState.CORRECT2;
            return;
        }
        else if (correct1.activated && correct2.activated && correct3.activated && !correct4.activated)
        {
            Debug.Log("3rd");
            material3.color = Color.green;
            state = PuzzleState.CORRECT3;
            return;
        }
        else if (correct1.activated && correct2.activated && correct3.activated && correct4.activated)
        {
            Debug.Log("4th");
            material4.color = Color.green;
            state = PuzzleState.CORRECT4;

            doors.SetActive(false);
            companionCube.SetActive(true);
            return;
        }

        if(state != PuzzleState.IDLE)
        {
            Debug.Log("KEKE");
            state = PuzzleState.INCORRECT;
        }
    }

    private void FailedPuzzle()
    {
        material1.color = Color.red;
        material2.color = Color.red;
        material3.color = Color.red;
        material4.color = Color.red;

        correct1.activated = false;
        correct2.activated = false;
        correct3.activated = false;
        correct4.activated = false;

        if(counter < 1f)
        {
            counter += Time.deltaTime;
            if(counter > 1f)
            {
                returnToSquareZero = true;
                state = PuzzleState.IDLE;
                counter = 0f;
            }
        }
    }
}
