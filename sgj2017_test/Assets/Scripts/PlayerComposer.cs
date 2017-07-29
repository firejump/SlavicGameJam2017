using UnityEngine;

public abstract class PlayerComposer
{
    public abstract void compose(GameObject playerObject);
}

public class SizeComposer : PlayerComposer
{
    public SizeComposer(float scale)
    {
        this.scale = scale;
    }

    public override void compose(GameObject playerObject)
    {
        // scale first child, which should be player body
        var body = playerObject.transform.GetChild(0);
        body.localScale = new UnityEngine.Vector3(scale, scale, scale);
        body.Translate(new Vector3(0, 0.5f, 0) * (scale - 1));
    }

    private float scale;
}

public class CubeComposer : PlayerComposer
{
    public override void compose(GameObject playerObject)
    {
        var body = GameObject.CreatePrimitive(PrimitiveType.Cube);
        body.transform.Translate(new Vector3(0, 0.5f, 0));
        body.transform.SetParent(playerObject.transform);
    }
}

public class BallComposer : PlayerComposer
{
    public override void compose(GameObject playerObject)
    {
        var body = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        body.transform.Translate(new Vector3(0, 0.5f, 0));
        body.transform.SetParent(playerObject.transform);
    }
}

public class ColorComposer : PlayerComposer
{
    public ColorComposer(Material material)
    {
        this.material = material;
    }
    public override void compose(GameObject playerObject)
    {
        var body = playerObject.transform.GetChild(0);
        body.GetComponent<MeshRenderer>().material = material;
    }

    private Material material;
}

public class JumpComposer : PlayerComposer
{
    public override void compose(GameObject playerObject)
    {
        GameObject animTemplate = Resources.Load<GameObject>("Prefabs/JumpWrapper");
        GameObject animWrapper = GameObject.Instantiate(animTemplate);
        var body = playerObject.transform.GetChild(0);
        body.SetParent(animWrapper.transform);
        animWrapper.transform.SetParent(playerObject.transform);
    }
}

public class LampComposer : PlayerComposer
{
    public override void compose(GameObject playerObject)
    {
        GameObject template = Resources.Load<GameObject>("Prefabs/Photophore");
        GameObject child = GameObject.Instantiate(template);
        var body = playerObject.transform.GetChild(0);
        child.transform.SetParent(body);
    }
}

public class EmptyComposer : PlayerComposer
{
    public override void compose(GameObject playerObject) { }
}
