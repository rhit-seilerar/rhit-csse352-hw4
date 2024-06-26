public class HoverInfo
{
    readonly string title;
    readonly string text;

    public HoverInfo(string title, string text)
    {
        this.title = title;
        this.text = text;
    }

    public virtual string GetTitle() => title;
    public virtual string GetText() => text;
}
