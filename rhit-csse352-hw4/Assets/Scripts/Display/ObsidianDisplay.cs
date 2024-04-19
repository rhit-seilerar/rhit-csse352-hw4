using TMPro;

public class ObsidianDisplay : GameUpdatable
{
    TMP_Text text;

    protected override void Start()
    {
        base.Start();
        text = GetComponent<TMP_Text>();
    }

    protected override void OnStart() { }

    protected override void OnUpdate()
    {
        text.text = $"<size=36>Obsidian: </size>{GameManager.Instance.GetObsidian()}pc";
    }

    protected override void OnStop() { }
}
