using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndScreenController : MonoBehaviour
{  
    public GameObject endItemImagePrefab;

    public Text timeText;
    public Text healthText;
    public RectTransform itemsPanel;
    public RectTransform survivedPanel;

    EndGameInfo info;
    int tempTime = 0;
    float tempHealth = 0f;

	// Use this for initialization
	void Start ()
    {
        timeText.text = "";
        healthText.text = "";
        GetEndGameInfo();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void GetEndGameInfo()
    {
        EndGame _endObject = GameObject.Find("Maze End").GetComponent<EndGame>();
        info = _endObject.GetEndGameInfo();
        Destroy(_endObject.gameObject);

        StartCoroutine(DisplayEndResults());
    }

    public void OnPressContinue()
    {
        Application.LoadLevel("StartScreen");
    }

    IEnumerator DisplayEndResults()
    {
        yield return new WaitForSeconds(1f);

        // time
        while(tempTime < info.time)
        {
            yield return new WaitForSeconds(0.02f);
            tempTime += 1;
            timeText.text = (tempTime / 60).ToString("00") + ":" + (tempTime % 60).ToString("00");
        }
        timeText.text = (info.time / 60).ToString("00") + ":" + (info.time % 60).ToString("00");    // set text to final time value

        // health
        while (tempHealth < info.health)
        {
            yield return new WaitForSeconds(0.02f);
            tempHealth += 1;
            healthText.text = ((int)tempHealth).ToString();
        }
        healthText.text = ((int)info.health).ToString();    // set text to final health value

        // items
        //for (int i = 0; i < info.items.Count; ++i)
        //{
        //    yield return new WaitForSeconds(1f);

        //    GameObject _newImage = Instantiate(endItemImagePrefab) as GameObject;
        //    _newImage.transform.parent = itemsPanel;
        //    _newImage.GetComponent<RectTransform>().localPosition = new Vector3((i * 138f), 0f, 0f);
        //    _newImage.GetComponent<Image>().sprite = info.items[i].image;
        //}

        // survived characters
        for (int i = 0; i < info.survivedCharacters.Count; ++i)
        {
            yield return new WaitForSeconds(1f);

            GameObject _newImage = Instantiate(endItemImagePrefab) as GameObject;
            _newImage.transform.parent = survivedPanel;
            _newImage.GetComponent<RectTransform>().sizeDelta = new Vector2(128f, 128f);
            _newImage.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            _newImage.GetComponent<RectTransform>().anchoredPosition = new Vector3((i * 138f), 0f, 0f);
            _newImage.GetComponent<Image>().sprite = info.survivedCharacters[i].image;            
        }

        StopCoroutine(DisplayEndResults());
    }
}