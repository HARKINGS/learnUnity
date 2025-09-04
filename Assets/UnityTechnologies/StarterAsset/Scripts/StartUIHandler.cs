using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class StartUIHandler : MonoBehaviour
{
    public float displayTime = 4.0f;
    private VisualElement m_NPCDialogue;
    private float m_TimerDisplay;
    private VisualElement m_Healthbar;
    public static StartUIHandler instance { get; private set; }

    // Awake is called when the script instance is being loaded (in this situation, when the game scene loads)
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealthValue(1.0f);

        m_NPCDialogue = uiDocument.rootVisualElement.Q<VisualElement>("NPCDialogue");
        m_NPCDialogue.style.display = DisplayStyle.None;
        m_TimerDisplay = -1.0f;
    }

    private void Update()
    {
        if (m_TimerDisplay > 0)
        {
            m_TimerDisplay -= Time.deltaTime;
            if (m_TimerDisplay < 0)
                m_NPCDialogue.style.display = DisplayStyle.None;
        }
    }

    public void SetHealthValue(float percentage)
    {
        m_Healthbar.style.width = Length.Percent(100 * percentage);
    }

    public void DisplayDialogue()
    {
        m_NPCDialogue.style.display = DisplayStyle.Flex;
        m_TimerDisplay = displayTime;
    }
}
