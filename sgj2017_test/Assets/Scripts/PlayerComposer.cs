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
        var body = playerObject.transform.GetChild(0).gameObject;
        body.transform.localScale = new UnityEngine.Vector3(scale, scale, scale);
    }

    private float scale;
}

public class CubeComposer : PlayerComposer
{
    public override void compose(GameObject playerObject)
    {
        var body = GameObject.CreatePrimitive(PrimitiveType.Cube);
        body.transform.SetParent(playerObject.transform);
    }
}

public class BallComposer : PlayerComposer
{
    public override void compose(GameObject playerObject)
    {
        var body = GameObject.CreatePrimitive(PrimitiveType.Sphere);
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
        //TODO add jumpo action
    }
}

public class LampComposer : PlayerComposer
{
    public override void compose(GameObject playerObject)
    {
        // TODO add light source
    }
}

public class EmptyComposer : PlayerComposer
{
    public override void compose(GameObject playerObject) { }
}