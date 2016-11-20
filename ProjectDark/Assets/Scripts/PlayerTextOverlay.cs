using UnityEngine;
using System.Collections;

public class PlayerTextOverlay : MonoBehaviour
{
    public string Onoma = "";
    public string playerAxisHorizontal;
    public string playerAxisVertical;

    private UnityEngine.UI.Text movementOnoma;
    private float switchNext;
    private float switchNextGap = 0.5f;

    // Use this for initialization
    void Start()
    {
        movementOnoma = GetComponentInChildren<UnityEngine.UI.Text>();
        movementOnoma.text = Onoma;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Mathf.Abs(Input.GetAxisRaw(playerAxisHorizontal));
        float v = Mathf.Abs(Input.GetAxisRaw(playerAxisVertical));
        if (h + v > 0.1)
        {
            movementOnoma.text = Onoma;
        }
        else
        {
            movementOnoma.text = string.Empty;
        }

        if (Time.time >= switchNext)
        {
            switchNext = Time.time + switchNextGap;
            var newPosition = new Vector3(Random.Range(-2, 2) + 1f, Random.Range(-2, 2) +1f, 0.1f);
            movementOnoma.transform.localPosition = newPosition;
        }
        movementOnoma.transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}
