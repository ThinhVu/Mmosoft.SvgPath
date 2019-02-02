namespace SVGPath.CmdConverter
{
    public interface ICmdConverter
    {
        Cmd[] Convert(Cmd c, Cmd prevC, ref float absX, ref float absY);
    }
}
