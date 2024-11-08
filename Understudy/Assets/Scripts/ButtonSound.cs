using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IDeselectHandler
{
    public AudioClip buttonSound;  // Assign your sound clip in the Inspector
    private AudioSource audioSource; // Reference to the AudioSource

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Get the Button component and add a listener for the OnClick event
        Button button = GetComponent<Button>();
        button.onClick.AddListener(PlaySound);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Play the sound when the pointer enters the button
        PlaySound();
    }

    public void OnSelect(BaseEventData eventData)
    {
        // Play the sound when the button is selected via keyboard/controller
        PlaySound();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        // Optionally, you can play a different sound or handle deselection here
        // For now, it is left empty
    }

    void PlaySound()
    {
        // Play the sound if it has been assigned
        if (buttonSound != null)
        {
            audioSource.PlayOneShot(buttonSound);
        }
    }
}