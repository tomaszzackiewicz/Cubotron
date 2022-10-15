namespace TZackiewicz
{
    public class ShapeFactory
    {
        public BaseShapeClass GetSpawnableBase(SpawnableType spawnableTypeParam)
        {
            switch (spawnableTypeParam)
            {
                case SpawnableType.Cube:
                    BaseShapeClass spawnableBase = new CubeShapeClass();
                    return spawnableBase;
                case SpawnableType.None:
                    ErrorController.SetError(ErrorType.TypeOfShape);
                    return null;
            }

            return null;
        }
    }
}
