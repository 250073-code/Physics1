using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulatedPhysics : MonoBehaviour
{
    private Scene _simulatedScene;
    private PhysicsScene _physicsScene;
    [SerializeField] private Transform labParent;

    // Start is called before the first frame update
    void Start()
    {
        labParent = gameObject.transform.parent.root;
        CreateSimulatedPhysicsScene();
    }

    public void CreateSimulatedPhysicsScene()
    {
        _simulatedScene = 
            SceneManager.CreateScene("SimulatedPhysics", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        _physicsScene = _simulatedScene.GetPhysicsScene();
        
        foreach (Transform obstacle in labParent)
        {
            if (obstacle.gameObject.CompareTag("Obstacle"))
            {
                var simulatedObstacle = Instantiate(obstacle.gameObject, obstacle.position, obstacle.rotation);
                if (obstacle.GetComponent<Renderer>() != null)
                {
                    obstacle.GetComponent<Renderer>().enabled = false;
                }
                SceneManager.MoveGameObjectToScene(simulatedObstacle, _simulatedScene);
            }
        }
    }

    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private int _maxPhysicsSimulation;

    public void SimulatedTrajectory(AirmailPackage airmailPackagePrefab, Vector3 pos, Vector3 velocity)
    {
        var simulatedObj = Instantiate(airmailPackagePrefab, pos, Quaternion.identity);

        simulatedObj.GetComponent<Renderer>().enabled = false;

        SceneManager.MoveGameObjectToScene(simulatedObj.gameObject, _simulatedScene);
        simulatedObj.Init(velocity);

        _lineRenderer.positionCount = _maxPhysicsSimulation;

        for (int i = 0; i < _maxPhysicsSimulation; i++)
        {
            _physicsScene.Simulate(Time.fixedDeltaTime * 4);
            _lineRenderer.SetPosition(i, simulatedObj.transform.position);
        }

        Destroy(simulatedObj.gameObject);
    }
}