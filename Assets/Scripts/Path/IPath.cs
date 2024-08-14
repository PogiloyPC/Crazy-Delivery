public interface IPath
{
    Point GetPoint();

    void ChangePoint(IPathWalkerPlatform pathWalker);
}

public enum TypePath
{
    line,
    loop
}