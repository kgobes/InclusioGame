using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITransformTest : MonoBehaviour
{

    public RectTransform panel;

    public GameObject endItemImagePrefab;

	// Use this for initialization
	void Start ()
    {
        GameObject _newImage = Instantiate(endItemImagePrefab) as GameObject;
        _newImage.transform.parent = panel;
        _newImage.GetComponent<RectTransform>().sizeDelta = new Vector2(128f, 128f);
        _newImage.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        _newImage.GetComponent<RectTransform>().anchoredPosition = new Vector3((0f), 0f, 0f);
        _newImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("sprites/spr_troll");

        GameObject _newImage2 = Instantiate(endItemImagePrefab) as GameObject;
        _newImage2.transform.parent = panel;
        _newImage2.GetComponent<RectTransform>().sizeDelta = new Vector2(128f, 128f);
        _newImage2.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        _newImage2.GetComponent<RectTransform>().anchoredPosition = new Vector3((138f), 0f, 0f);
        _newImage2.GetComponent<Image>().sprite = Resources.Load<Sprite>("sprites/fairy");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
