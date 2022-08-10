using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathUI : MonoBehaviour
{

    public GameObject uiPrefab;
    public Transform targetTransform;

    private Transform uiTransform;
    private Image hpImage;
    private Transform cameraTransform;
    public Transform uiParentTransform;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        uiTransform = Instantiate(uiPrefab, uiParentTransform).transform;
        uiTransform.gameObject.name = name;
        GetComponent<CharacterStats>().OnHealthChanged += OnHealthChanged;
        hpImage = uiTransform.GetChild(1).GetComponent<Image>();
    }

    private void LateUpdate()
    {
        uiTransform.position = targetTransform.position;
        uiTransform.forward = -cameraTransform.forward;
    }


    private void OnHealthChanged(int currentHealth, int maxHealth)
    {
        float percent = (float)currentHealth / (float)maxHealth;
        hpImage.fillAmount = percent;
        if (currentHealth <= 0)
        {
            Destroy(uiTransform.gameObject);
        }
    }
}
