using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressStart : MonoBehaviour
{
    private TextMeshProUGUI text;
    private float limitUp, limitDown, delta;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        delta = (text.fontSize * 10 / 100);
        limitUp = text.fontSize + delta;
        limitDown = text.fontSize - delta;
    }
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayMusic("Menu");
        StartCoroutine(_BlupUp());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }

    private IEnumerator _BlupUp()
    {
        while (text.fontSize <= limitUp)
        {
            text.fontSize += delta * Time.deltaTime * 2;
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(_BlupDown());
    }

    private IEnumerator _BlupDown()
    {
        while (text.fontSize >= limitDown)
        {
            text.fontSize -= delta * Time.deltaTime * 2;
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(_BlupUp());
    }
}
