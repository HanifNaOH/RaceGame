using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DriverStandingManager : MonoBehaviour
{
    public static DriverStandingManager Instance;
    public List<Car> cars;
    public WaypointManager waypointManager;
    public List<Car> raceStandings;
    public List<string> finalStandings;
    void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        raceStandings = cars.OrderByDescending(car => car.lap)
            .ThenByDescending(car => car.totalWaypoints)
            .ThenBy(car =>
            {
                int currentWaypointIndex = car.totalWaypoints % waypointManager.waypoints.Count;
                return Vector3.Distance(waypointManager.waypoints[currentWaypointIndex].position, car.transform.position);
            }).ToList();
    }
    public void FinalSort()
    {
        raceStandings = cars
            .OrderByDescending(car => car.lap)
            .ThenByDescending(car => car.totalWaypoints)
            .ThenBy(car =>
            {
                int currentWaypointIndex = car.totalWaypoints % waypointManager.waypoints.Count;
                return Vector3.Distance(waypointManager.waypoints[currentWaypointIndex].position,
                                        car.transform.position);
            })
            .ToList();
    }
}
